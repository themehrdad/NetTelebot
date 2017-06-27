using System;

namespace NetTelebot
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
        public static DateTime ToDateTime(this int unixDate)
        {
            return baseDate.AddSeconds(unixDate).ToLocalTime();
        }
    }
}
