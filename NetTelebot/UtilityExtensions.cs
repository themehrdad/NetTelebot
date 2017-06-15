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
        /// 
        /// </summary>
        /// <param name="unixDate"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this int unixDate)
        {
            return baseDate.AddSeconds(unixDate).ToLocalTime();
        }
    }
}
