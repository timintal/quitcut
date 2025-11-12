namespace QuitCut.Data.Database
{
    public static class SQLQueries
    {
        public static string DB_NAME = "quitcut.db";

        public static string CLEAR_CIGARETTES_TABLE = "DELETE FROM cigarettes;";
        public static string CLEAR_CHALLENGES_TABLE = "DELETE FROM challenges;";

        public static string CREATE_CIGARS_TABLE =
            @"CREATE TABLE IF NOT EXISTS cigarettes (
id              INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
smoked_at       DATETIME NOT NULL, 
note            TEXT
);";

        public static string CREATE_CHALLENGES_TABLE =
            @"CREATE TABLE IF NOT EXISTS challenges (
  id            INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  challenge_id  TEXT NOT NULL,
  start_at      DATETIME NOT NULL,
  end_at        DATETIME,
  daily_target  INTEGER NOT NULL,
  overall_target  INTEGER NOT NULL,
  state        INTEGER NOT NULL DEFAULT 0
);";

        public static string CIGARETTS_INDEX = "CREATE INDEX IF NOT EXISTS cigarettes_smoked_at_index ON cigarettes (smoked_at);";

        public static string CIGS_PER_DAY_QUERY = @"
SELECT strftime('%Y-%m-%d', smoked_at) AS day, COUNT(*) AS cnt
FROM cigarettes
WHERE smoked_at BETWEEN ? AND ?
GROUP BY day
ORDER BY day ASC;";

        public static string INSERT_CIGARETTES_QUERY = "INSERT INTO cigarettes (smoked_at, note) VALUES (?, ?);";
        
        
        public static string GET_CIGARETTES_FOR_PERIOD_QUERY = @"SELECT COUNT(*) AS cnt
FROM cigarettes
WHERE smoked_at >= ? AND smoked_at < ?;";

        public static string LAST_CIGARETTES_QUERY = @"SELECT * FROM cigarettes ORDER BY smoked_at DESC LIMIT 1;";

        public static string GET_LONGEST_STREAK_QUERY = @"
SELECT
  t_prev.smoked_at AS start_ts,
  t_cur.smoked_at  AS end_ts,
  (strftime('%s', t_cur.smoked_at) - strftime('%s', t_prev.smoked_at)) AS gap_seconds
FROM cigarettes AS t_cur
JOIN cigarettes AS t_prev
  ON t_prev.smoked_at = (
    SELECT MAX(smoked_at)
    FROM cigarettes
    WHERE smoked_at < t_cur.smoked_at
      AND smoked_at IS NOT NULL
  )
WHERE t_cur.smoked_at IS NOT NULL
ORDER BY gap_seconds DESC
LIMIT 1;";
        
        public static string ADD_CHALLENGE_QUERY = @"INSERT INTO challenges (challenge_id, start_at, end_at, daily_target, overall_target, state) 
VALUES (?, ?, ?, ?, ?, 0);";    
        
        public static string GET_ACTIVE_CHALLENGES_QUERY = @"SELECT * FROM challenges WHERE state = 0;";
        public static string GET_COMPLETED_CHALLENGES_QUERY = @"SELECT * FROM challenges WHERE state = 1;";
        public static string GET_NOT_CLAIMED_CHALLENGES_QUERY = @"SELECT * FROM challenges WHERE state > 0 AND state < 3;";
        public static string GET_CHALLENGE_QUERY = @"SELECT * FROM challenges WHERE id = ?;";
        public static string UPDATE_CHALLENGE_QUERY = @"UPDATE challenges SET state = ? WHERE id = ?;";
        public static string CLAIM_CHALLENGE_QUERY = @"UPDATE challenges SET state = 3 WHERE id = ?;";
        public static string DELETE_CHALLENGE_QUERY = @"DELETE FROM challenges WHERE id = ?;";
        
    }
}