using System;

namespace NetTelebot.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public static class UtilityExtensions
    {
        private static DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        
        /// <summary>
        /// Convert date from unix time to the <see cref="DateTime"/>.
        /// </summary>
        /// <param name="unixDate">The unix date</param>
        /// <returns>Convert DateTime</returns>
        public static DateTime ToDateTime(this long unixDate)
        {
            return baseDate.AddSeconds(unixDate).ToLocalTime();
        }

        /// <summary>
        /// Convert a date time object to Unix time representation.
        /// </summary>
        /// <param name="dateTime">The datetime object to convert to Unix time stamp.</param>
        /// <returns>Returns a numerical representation (Unix time) of the DateTime object.</returns>
        public static long ToUnixTime(this DateTime dateTime)
        {
            return (long)(dateTime - baseDate).TotalSeconds;
        }
    }
}
