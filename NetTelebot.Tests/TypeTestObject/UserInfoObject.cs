using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class UserInfoObject
    {
        /// <summary>
        /// This object represents a Telegram user or bot.
        /// See <see href="https://core.telegram.org/bots/api#user">API</see>
        /// </summary>
        /// <param name="id">Unique identifier for this user or bot</param>
        /// <param name="isBot">True if this user is a bot</param>
        /// <param name="firstName">User's or bot's first name</param>
        /// <param name="lastName">Optional. User's or bot's last name</param>
        /// <param name="username">Optional. User's or bot's username</param>
        /// <param name="languageCode">Optional. IETF language tag of the user's language</param>
        /// <param name="isPremium">Optional. True if this user is a Telegram Premium user</param>
        /// <param name="canJoinGroups">Optional. True if bot can be invited to groups</param>
        /// <param name="canReadAllGroupMessages">Optional. True if privacy mode is disabled</param>
        /// <param name="supportsInlineQueries">Optional. True if bot supports inline queries</param>
        /// <returns><see cref="UserInfo" /></returns>
        internal static JObject GetObject(long id, bool isBot, string firstName, string lastName = null,
            string username = null, string languageCode = null, bool? isPremium = null,
            bool? canJoinGroups = null, bool? canReadAllGroupMessages = null, bool? supportsInlineQueries = null)
        {
            dynamic userInfo = new JObject();

            userInfo.id = id;
            userInfo.is_bot = isBot;
            userInfo.first_name = firstName;

            if (lastName != null)
                userInfo.last_name = lastName;
            if (username != null)
                userInfo.username = username;
            if (languageCode != null)
                userInfo.language_code = languageCode;
            if (isPremium.HasValue)
                userInfo.is_premium = isPremium.Value;
            if (canJoinGroups.HasValue)
                userInfo.can_join_groups = canJoinGroups.Value;
            if (canReadAllGroupMessages.HasValue)
                userInfo.can_read_all_group_messages = canReadAllGroupMessages.Value;
            if (supportsInlineQueries.HasValue)
                userInfo.supports_inline_queries = supportsInlineQueries.Value;

            return userInfo;
        }
    }
}