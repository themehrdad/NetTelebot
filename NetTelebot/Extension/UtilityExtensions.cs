using System;
using NetTelebot.BotEnum;
using Newtonsoft.Json.Linq;

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

        /// <summary>
        /// Converts a string to the specified in T enum type
        /// </summary>
        /// <param name="enumString">String value for conversion to an existing structure</param>
        /// <typeparam name="T">Exiting structure</typeparam>
        /// <returns>The value of the enumeration T from string. Null if constant in enumeration not exist</returns>
        public static T? ToEnum<T>(this string enumString) where T:struct
        {
            if (Enum.IsDefined(typeof(T), enumString))
                return (T) Enum.Parse(typeof (T), enumString, true);

            return null;
        }

        /// <summary>
        /// Converts AllowedUpdates[] to JArray.
        /// </summary>
        /// <param name="allowedUpdateses">List the types of updates you want your bot to receive</param>
        /// <returns>Jarray the types of updates</returns>
        public static string ToJarray(this AllowedUpdates[] allowedUpdateses)
        {
            JArray jArray = new JArray();

            foreach (AllowedUpdates allowedUpdates in allowedUpdateses)
            {
                if(allowedUpdates == AllowedUpdates.Message)
                    jArray.Add("message");
                if (allowedUpdates == AllowedUpdates.EditedMessage)
                    jArray.Add("edited_message");
                if(allowedUpdates == AllowedUpdates.ChannelPost)
                    jArray.Add("channel_post");
                if(allowedUpdates == AllowedUpdates.EditedChannelPost)
                    jArray.Add("edited_channel_post");
                if(allowedUpdates == AllowedUpdates.InlineQuery)
                    jArray.Add("inline_query");
                if(allowedUpdates == AllowedUpdates.ChosenInlineResult)
                    jArray.Add("chosen_inline_result");
                if(allowedUpdates == AllowedUpdates.CallbackQuery)
                    jArray.Add("callback_query");
                if(allowedUpdates == AllowedUpdates.ShippingQuery)
                    jArray.Add("shipping_query");
                if(allowedUpdates == AllowedUpdates.PreCheckoutQuery)
                    jArray.Add("pre_checkout_query");
            }

            return jArray.ToString();
        }
    }
}
