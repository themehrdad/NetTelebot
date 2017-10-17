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
        /// <param name="firstName">User‘s or bot’s first name</param>
        /// <param name="lastName">Optional. User‘s or bot’s last name</param>
        /// <param name="username">Optional. User‘s or bot’s username</param>
        /// <param name="languageCode">Optional. IETF language tag of the user's language</param>
        /// <returns><see cref="UserInfo" /></returns>
        internal static JObject GetObject(int id, bool isBot, string firstName, string lastName, string username,
            string languageCode)
        {
            dynamic userInfo = new JObject();

            userInfo.id = id;
            userInfo.is_bot = isBot;
            userInfo.first_name = firstName;
            userInfo.last_name = lastName;
            userInfo.username = username;
            userInfo.language_code = languageCode;

            return userInfo;
        }
    }
}