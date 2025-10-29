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
  start_at      DATETIME NOT NULL,
  end_at        DATETIME,
  daily_target  INTEGER NOT NULL,
  overall_target  INTEGER NOT NULL
);";

        public static string CIGARETTS_INDEX = "CREATE INDEX IF NOT EXISTS cigarettes_smoked_at_index ON cigarettes (smoked_at);";

        public static string CIGS_PER_DAY_QUERY = @"
SELECT strftime('%Y-%m-%d', smoked_at) AS day, COUNT(*) AS cnt
FROM cigarettes
WHERE smoked_at BETWEEN ? AND ?
GROUP BY day
ORDER BY day ASC;";

        public static string INSERT_CIGARETTES_QUERY = "INSERT INTO cigarettes (smoked_at, note) VALUES (?, ?);";

        public static string TODAY_CIGARETTES_QUERY = @"SELECT COUNT(*) AS cnt
FROM cigarettes
WHERE smoked_at >= date('now') AND smoked_at < date('now', '+1 day');";

        public static string LAST_CIGARETTES_QUERY = @"SELECT * FROM cigarettes ORDER BY smoked_at DESC LIMIT 1;";

        public static string GET_LONGEST_STREAK_QUERY = @"
WITH ordered AS (
  SELECT
    smoked_at,
    LAG(smoked_at) OVER (ORDER BY smoked_at) AS prev_time
  FROM cigarettes
  WHERE smoked_at IS NOT NULL
),
gaps AS (
  SELECT
    smoked_at           AS gap_end,
    prev_time           AS gap_start,
    -- difference in days; multiply for hours/minutes if you want
    (julianday(smoked_at) - julianday(prev_time)) AS gap_days
  FROM ordered
  WHERE prev_time IS NOT NULL
)
SELECT
  gap_start,
  gap_end,
  gap_days,
  ROUND(gap_days * 24.0, 2)  AS gap_hours,
  ROUND(gap_days * 24.0*60, 0) AS gap_minutes
FROM gaps
ORDER BY gap_days DESC
LIMIT 1;";
    }
}