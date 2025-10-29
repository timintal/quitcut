using System;
using System.Globalization;
using UnityEngine;

namespace Common
{
    public static class DateUtils
    {
        public static string SQLDate(this DateTime dt) => dt.ToString("yyyy-MM-dd HH:mm:ss");
        public static DateTime FromSQL(this string dt)
        {
            Debug.Log(dt);
            if (DateTime.TryParseExact(dt, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            else if (DateTime.TryParseExact(dt, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            
            return DateTime.MinValue;
        }
    }
}