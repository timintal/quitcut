using System;
using System.Collections.Generic;
using Common;
using Newtonsoft.Json;
using QuitCut.Configs;
using QuitCut.Data.DataServices;
using QuitCut.Services;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace QuitCut.Data.Database
{

    public class DataBaseService : IInitializable
    {
        public Subject<Unit> OnCigarettesDataChanged = new();
        public Subject<Unit> OnChallengesDataChanged = new();

        private readonly SQLiteDB _db;
        private readonly ChallengeSets _challengeSets;
        private readonly TimeProvider _timeProvider;
        public DataBaseService(SQLiteDB db, ChallengeSets challengeSets, TimeProvider timeProvider)
        {
            _db = db;
            _challengeSets = challengeSets;
            _timeProvider = timeProvider;
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
                var dateTimeDate = _timeProvider.GetUtcNow().DateTime.Date;
                var qr = new SQLiteQuery(_db, SQLQueries.GET_CIGARETTES_FOR_PERIOD_QUERY);
                qr.Bind(dateTimeDate.SQLDate());
                qr.Bind((dateTimeDate + TimeSpan.FromDays(1)).SQLDate());
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

        public Dictionary<DateTime, int> GetCigarettesCountByDay(DateTime from, DateTime to)
        {
            Dictionary<DateTime, int> counts = new Dictionary<DateTime, int>();
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

        public void StartChallenge(ChallengeId challengeId)
        {
            var start = _timeProvider.GetUtcNow().DateTime;
            var config = _challengeSets.GetChallengeConfig(challengeId);
            var end = start + TimeSpan.FromDays(config.DurationDays);
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.ADD_CHALLENGE_QUERY);
                qr.Bind(JsonConvert.SerializeObject(challengeId));
                qr.Bind(start.SQLDate());
                qr.Bind(end.SQLDate());
                qr.Bind(config.PerDayLimit);
                qr.Bind(config.TotalLimit);

                qr.Step();
                qr.Release();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to add challenge: {e.Message}");
            }
            OnChallengesDataChanged.OnNext(Unit.Default);
        }

        public List<SavedChallengeInfo> GetActiveChallenges()
        {
            List<SavedChallengeInfo> activeChallenges = new List<SavedChallengeInfo>();
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.GET_ACTIVE_CHALLENGES_QUERY);
                while (qr.Step())
                {
                    var challenge = new SavedChallengeInfo
                    {
                        Id = qr.GetInteger("id"),
                        ChallengeId = JsonConvert.DeserializeObject<ChallengeId>(qr.GetString("challenge_id")),
                        StartDate = qr.GetString("start_at").FromSQL(),
                        EndDate = qr.GetString("end_at").FromSQL(),
                        State = (ChallengeState)qr.GetInteger("state"),
                        
                    };
                    activeChallenges.Add(challenge);
                }
                qr.Release();
                
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get active challenges: {e.Message}");
            }
            
            return activeChallenges;
        }
        
        public List<SavedChallengeInfo> GetCompletedChallenges()
        {
            List<SavedChallengeInfo> activeChallenges = new List<SavedChallengeInfo>();
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.GET_COMPLETED_CHALLENGES_QUERY);
                while (qr.Step())
                {
                    var challenge = new SavedChallengeInfo
                    {
                        Id = qr.GetInteger("id"),
                        ChallengeId = JsonConvert.DeserializeObject<ChallengeId>(qr.GetString("challenge_id")),
                        StartDate = qr.GetString("start_at").FromSQL(),
                        EndDate = qr.GetString("end_at").FromSQL(),
                        State = (ChallengeState)qr.GetInteger("state"),
                    };
                    activeChallenges.Add(challenge);
                }
                qr.Release();
                
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get active challenges: {e.Message}");
            }
            
            return activeChallenges;
        }

        public void UpdateChallengeState(int id, ChallengeState state)
        {
            try
            {
                var qr = new SQLiteQuery(_db, SQLQueries.UPDATE_CHALLENGE_QUERY);
                qr.Bind((int)state);
                qr.Bind(id);
                qr.Step();
                qr.Release();
                
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to update challenge state: {e.Message}");
            }
            
            OnChallengesDataChanged.OnNext(Unit.Default);
        }
        
    }
}