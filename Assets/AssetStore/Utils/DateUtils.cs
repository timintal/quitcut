using System;

namespace Common
{
    public static class DateUtils
    {
        public static string SQLDate(this DateTime dt) => dt.ToString("yyyy-MM-dd HH:mm:ss");
    }
}