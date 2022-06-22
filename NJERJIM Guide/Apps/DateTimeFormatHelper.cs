using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJERJIM_Guide.Apps
{
    internal static class DateTimeFormatHelper
    {
        /// <summary>
        ///     Convert DateTime format to String format for database.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>String Format of DateTime</returns>
        internal static string DateTimeToStringDB(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss:ff");
        }
        /// <summary>
        ///     Convert String format from database to DateTime datatype.
        /// </summary>
        /// <param name="dateTime">string</param>
        /// <returns>DateTime datatype</returns>
        internal static DateTime StringDBToDateTime(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss:ff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }
        /// <summary>
        ///     Convert String format from database to DateTime datatype.
        /// </summary>
        /// <param name="dateTime">object</param>
        /// <returns>DateTime datatype</returns>
        internal static DateTime StringDBToDateTime(object dateTime)
        {
            return DateTime.ParseExact(dateTime.ToString(), "yyyy-MM-dd HH:mm:ss:ff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }
        internal static DateTime StringUIToDateTime(string dateTime)
        {
            return DateTime.ParseExact(dateTime.ToString(), "MMMM dd, yyyy - dddd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }
        internal static DateTime StringUIToDateTime(object dateTime)
        {
            return DateTime.ParseExact(dateTime.ToString(), "MMMM dd, yyyy - dddd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }
        internal static string DateTimeToStringUI(DateTime dateTime)
        {
            return dateTime.ToString("MMMM dd, yyyy - dddd");
        }
        internal static string DateTimeToStringUI(string dateTime)
        {
            return DateTime.ParseExact(dateTime.ToString(), "yyyy-MM-dd HH:mm:ss:ff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal)
                .ToString("MMMM dd, yyyy - dddd");
        }
        internal static string DateTimeToStringUI(object dateTime)
        {
            return DateTime.ParseExact(dateTime.ToString(), "yyyy-MM-dd HH:mm:ss:ff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal)
                .ToString("MMMM dd, yyyy - dddd");
        }
        internal static string GetDay(DateTime dateTime)
        {
            return dateTime.ToString("dddd");
        }
    }
}
