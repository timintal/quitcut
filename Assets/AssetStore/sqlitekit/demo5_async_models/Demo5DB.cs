using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;
using SQLiteExtension;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class Demo5DB : MonoBehaviour
{
    //
    // Public part.
    public const long Version = 2;

    // Singleton for database controller. 
    static public Demo5DB Instance
    {
        get
        {
            if (_Instance == null)
            {
                GameObject obj = GameObject.Find("Demo5DB");
                if (obj == null)
                {
                    obj = new GameObject("Demo5DB");

                    // make sure it's stay always alive till application destroy it on exit.
                    DontDestroyOnLoad(obj);

                    // open and migrate the database
                    Demo5DB.Initialize();
                }

                // paranoia code :)
                _Instance = obj.GetComponent<Demo5DB>();
                if (_Instance == null)
                {
                    _Instance = obj.AddComponent<Demo5DB>();
                }
            }

            return _Instance;
        }
    }



    public delegate void InsertScoreComplete(Demo5ScoreModel model);
    public IEnumerator InsertScore(Demo5ScoreModel model, InsertScoreComplete callback)
    {
        while (dbLock)
        {
            yield return null;
        }

        dbLock = true;

        yield return this.SQLiteQuery("INSERT INTO scores (name,level,score) VALUES (?,?,?);", 
            (SQLiteQuery qr, object state) => {
                qr.Bind(model.name);
                qr.Bind(model.level);
                qr.Bind(model.score);
            }, handle);
        yield return this.SQLiteStep((SQLiteQuery qr, bool rv, object state) => {
            model.id = (int)qr.SqlDb.LastInsertRowId();
            return rv;
        }, handle);
        yield return this.SQLiteRelease(handle);
        
        dbLock = false;

        if (callback != null)
        {
            callback(model);
        }
    }

    // update existed in database score model
    public IEnumerator UpdateScore(Demo5ScoreModel model)
    {
        while(dbLock) {
            yield return null;
        }

        dbLock = true;

        yield return this.SQLiteQuery("UPDATE scores SET name=?, level=?, score=? WHERE id=?;", (SQLiteQuery qr, object state) => {
            qr.Bind(model.name);
            qr.Bind(model.level);
            qr.Bind(model.score);
            qr.Bind(model.id);
        }, handle);
        yield return this.SQLiteStep(null, handle);
        yield return this.SQLiteRelease(handle);

        dbLock = false;
    }

    // update existed in database score model
    public IEnumerator DeleteScore(Demo5ScoreModel model)
    {
        while (dbLock)
        {
            yield return null;
        }

        dbLock = true;

        yield return this.SQLiteQuery("DELETE FROM scores WHERE id=?;", (SQLiteQuery qr, object state) => {
            qr.Bind(model.id);
        }, handle);
        yield return this.SQLiteStep(null, handle);
        yield return this.SQLiteRelease(handle);

        dbLock = false;
    }


    public delegate void SelectComplete(List<Demo5ScoreModel> models);
    public IEnumerator SelectScoreByLevel(string level, SelectComplete callback)
    {
        while (dbLock)
        {
            yield return null;
        }

        dbLock = true;

        List<Demo5ScoreModel> models = new List<Demo5ScoreModel>();

        yield return this.SQLiteQuery("SELECT * FROM scores WHERE level=?;",
            (SQLiteQuery qr, object state) => {
                qr.Bind(level);
            }, handle);

        yield return this.SQLiteStep((SQLiteQuery qr, bool rv, object state) => {
            if (rv)
            {
                Demo5ScoreModel model = new Demo5ScoreModel();
                model.id = qr.GetInteger("id");
                model.name = qr.GetString("name");
                model.level = qr.GetString("level");
                model.score = qr.GetFloat("score");

                models.Add(model);
            }
            return rv;
        }, handle);
        yield return this.SQLiteRelease(handle);

        dbLock = false;

        if (callback != null)
        {
            callback(models);
        }
    }

    private IEnumerator Start()
    {
        string dbpath = Path.Combine(Application.persistentDataPath, filename);
        yield return this.SQLiteOpenDatabase(dbpath, handle);

        //
        // set ENCRYPTION if needed (not recommended for development stage)
        //
        //yield return this.SQLiteQuery("\"PRAGMA hexkey=?;",
        //   (SQLiteQuery qr, object state) => {
        //       qr.Bind("0x0102010405060708090a0b0c0d0e0f10");
        //   }, handle);
        //yield return this.SQLiteStep(null, handle);
        //yield return this.SQLiteRelease(handle);

        // We done here and ready to launch singleton live.
        dbLock = false;
    }

    //
    // Implementation.

    // this is filename of controlled SQLite database file.
    const string filename = "demo5.db";

    // Singleton handler.
    static Demo5DB _Instance = null;

    // The handle of asynchronous db operation.
    SQLiteExt.Handle handle = new SQLiteExt.Handle();

    // lock flag to control sequential access to the database file.
    bool dbLock = true;

    // Start is called before the first frame update
    static void Initialize()
    {

        // Expecting preloaded database file at StreamingAssets,
        // so if no local copy of the database copy it from StreamAssets folder.
        CopyFileFromStreamingAssetsToPersistenceFolder(filename);


        // 
        // Migration time
        // We read version table to know of version current database.
        // It's allow to normalize database structure to latest one.
        SQLiteDB db = new SQLiteDB();

        try
        {
            // open first.
            string dbpath = Path.Combine(Application.persistentDataPath, filename);
            Debug.Log(dbpath);
            db.Open(dbpath);

            SQLiteQuery qr = null;

            //
            // set ENCRYPTION if needed (not recommended for development stage)
            //
            //qr = new SQLiteQuery(db, "PRAGMA hexkey=\"0x0102010405060708090a0b0c0d0e0f10\";");
            //qr.Step();
            //qr.Release();

            // read current database's version
            long version = -1;

            qr = new SQLiteQuery(db, "SELECT name FROM sqlite_master WHERE type='table' AND name='version';");
            if (qr.Step())
            {
                qr.Release();
                qr = new SQLiteQuery(db, "SELECT * FROM version LIMIT 1;");
                if (qr.Step())
                {
                    version = qr.GetLong("version");
                }
                qr.Release();
            }
            else
                qr.Release();


            if (Version != version)
            {
                if (version == -1)
                {
                    version = 1;

                    // It's fresh new empty database!
                    // We have to rebuild from scratch.

                    // Cerate version table if not exists.
                    qr = new SQLiteQuery(db, "CREATE TABLE version( version INT );");
                    qr.Step();
                    qr.Release();

                    // fill version into the table.
                    qr = new SQLiteQuery(db, "INSERT INTO version( version ) VALUES (?);");
                    qr.Bind(version);
                    qr.Step();
                    qr.Release();
                }
                
                
                // Example of upgrading database from version 1 >> 2 
                // adding table and version update.
                if (version == 1)
                {
                    // it's perfect, work on apply version 2
                    version = 2;

                    // As example - lets create a table.
                    qr = new SQLiteQuery(db, "CREATE TABLE scores( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(256), level VARCHAR(256), score FLOAT );");
                    qr.Step();
                    qr.Release();

                    // update database version table
                    qr = new SQLiteQuery(db, "UPDATE version SET version=?;");
                    qr.Bind(version);
                    qr.Step();
                    qr.Release();
                }

            }

            db.Close();

        }
        catch (Exception e)
        {
            Debug.LogException(e);
            db.Close();
            throw e;
        }
        
    }

    static byte[] ReadFile(string path)
    {
        UnityWebRequest www = UnityWebRequest.Get(path);
        www.SendWebRequest();
        while (!www.isDone) { }
        return www.downloadHandler.data;
    }

    static void CopyFileFromStreamingAssetsToPersistenceFolder(string dbfilename)
    {
        // a product persistant database path.
        string filename = Application.persistentDataPath + "/" + dbfilename;


        // check if database already exists.

        if (!File.Exists(filename))
        {

            // ok , this is first time application start!
            // so lets copy prebuild dtabase from StreamingAssets and load store to persistancePath with Test2

            byte[] bytes = null;


#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
            string dbpath = "file://" + Application.streamingAssetsPath + "/" + dbfilename;
            bytes = ReadFile(dbpath);
#elif UNITY_WEBGL
			string dbpath = "StreamingAssets/" + dbfilename;
			bytes = ReadFile(dbpath);
#elif UNITY_IOS
			string dbpath = Application.dataPath + "/Raw/" + dbfilename;				
			try{	
				using ( FileStream fs = new FileStream(dbpath, FileMode.Open, FileAccess.Read, FileShare.Read) ){
					bytes = new byte[fs.Length];
					fs.Read(bytes,0,(int)fs.Length);
				}			
			} catch (Exception e){
				log += 	"\nTest Fail with Exception " + e.ToString();
				log += 	"\n";
			}
#elif UNITY_ANDROID
			string dbpath = Application.streamingAssetsPath + "/" + dbfilename;	            
			bytes = ReadFile(dbpath);
#endif
            if (bytes != null)
            {
                try
                {

                    //
                    //
                    // copy database to real file into cache folder
                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(bytes, 0, bytes.Length); 
                    }

                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    throw e;
                }
            }
            else
            {
                throw new FileLoadException(String.Format("no file at: {0}", dbpath));
            }
        }
    }


}
