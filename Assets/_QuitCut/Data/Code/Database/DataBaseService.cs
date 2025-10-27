using System;
using System.Globalization;
using Common;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace QuitCut.Data
{

    public class DataBaseService : IInitializable
    {
        public Subject<Unit> OnCigarettesDataChanged = new();
        
        private readonly SQLiteDB _db;
        public DataBaseService(SQLiteDB db)
        {
            _db = db;
        }
        
        public void Initialize()
        {
            CheckDataBase();
        }
        public void CheckDataBase()
        {
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.CREATE_CIGARS_TABLE);
                qr.Step();												
                qr.Release();
            
                qr = new SQLiteQuery(_db, SQLQueries.CREATE_CHALLENGES_TABLE);
                qr.Step();												
                qr.Release();   
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to create tables: " + e.Message + "");
            }
        }

        public void LogCigarette(DateTime date, string note = null)
        {
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.INSERT_CIGARETTES_QUERY);
                qr.Bind(date.SQLDate());
                qr.Bind(note ?? String.Empty);
                qr.Step();												
                qr.Release();
                OnCigarettesDataChanged.OnNext(Unit.Default);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to log cigarette: {e.Message}");
            }
        }

        public void ClearCigarettesTable()
        {
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.CLEAR_CIGARETTES_TABLE);
                qr.Step();												
                qr.Release();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to clear cigarettes table: {e.Message}");
            }
        }
        public void ClearChallengesTable()
        {
            try
            {
                var qr = new SQLiteQuery(_db, string.Format(SQLQueries.CLEAR_CHALLENGES_TABLE));
                qr.Step();												
                qr.Release();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to clear cigarettes table: {e.Message}");
            }
        }
        
        public int GetTodayCigarettesCount()
        {
            int count = 0;
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.TODAY_CIGARETTES_QUERY);
                if (qr.Step())
                {
                    count = qr.GetInteger("cnt");
                }
                qr.Release();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get today's cigarettes count: {e.Message}");
            }

            return count;
        }

        public DateTime GetLastCigaretteDate()
        {
            DateTime last = DateTime.MinValue;
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.LAST_CIGARETTES_QUERY);
                if (qr.Step())
                {
                    last= DateTime.ParseExact(qr.GetString("smoked_at"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                }
                qr.Release();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get today's cigarettes count: {e.Message}");
            }

            return last;
        }
        
        
    }
}