using System;

namespace NetTelebot
{
    public static class UtilityExtensions
    {
        private static DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public static DateTime ToDateTime(this int unixDate)
        {
            return baseDate.AddSeconds(unixDate).ToLocalTime();
        }
    }
}
