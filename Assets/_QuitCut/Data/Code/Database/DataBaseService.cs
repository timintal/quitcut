using System;
using System.Collections.Generic;
using Common;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace QuitCut.Data.Database
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
                
                qr = new SQLiteQuery(_db, SQLQueries.CIGARETTS_INDEX);
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

        public Dictionary<DateTime,int> GetCigarettesCountByDay(DateTime from, DateTime to)
        {
            Dictionary<DateTime,int> counts = new Dictionary<DateTime,int>();
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.CIGS_PER_DAY_QUERY);
                qr.Bind(from.SQLDate());
                qr.Bind(to.SQLDate());
                while (qr.Step())
                {
                    counts.Add(qr.GetString("day").FromSQL(), qr.GetInteger("cnt"));
                }
                qr.Release();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get cigarettes count by day: {e.Message}");
            }

            return counts;
        }

        public DateTime GetLastCigaretteDate()
        {
            DateTime last = DateTime.MinValue;
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.LAST_CIGARETTES_QUERY);
                if (qr.Step())
                {
                    last = qr.GetString("smoked_at").FromSQL();
                }
                qr.Release();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get today's cigarettes count: {e.Message}");
            }

            return last;
        }

        public TimeSpan GetLongestStreak()
        {
            TimeSpan longest = TimeSpan.MinValue;
            var qr = new SQLiteQuery(_db, SQLQueries.GET_LONGEST_STREAK_QUERY);
            if (qr.Step())
            {
                var start = qr.GetString("start_ts").FromSQL();
                var end = qr.GetString("end_ts").FromSQL();
                longest = end - start;

            }
            qr.Release();
            return longest;
        }
        
        
    }
}