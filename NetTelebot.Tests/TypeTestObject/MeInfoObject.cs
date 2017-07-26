using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class MeInfoObject
    {
        /// <summary>
        /// When caling <see cref="TelegramBotClient.GetMe"/>, method must return <see cref="UserInfo"/>. 
        /// See in <see href="https://core.telegram.org/bots/api#getme">API</see>
        /// This class is a copy of the UserInfo class, but with access to the ok field.
        /// </summary>
        /// <param name="ok">Gets a value "ok" in response.</param>
        /// <param name="id">Unique identifier for this user or bot</param>
        /// <param name="firstName">User‘s or bot’s first name</param>
        /// <param name="lastName">Optional. User‘s or bot’s last name</param>
        /// <param name="username">Optional. User‘s or bot’s username</param>
        /// <param name="languageCode">Optional. IETF language tag of the user's language</param>
        /// <returns><see cref="UserInfo" /></returns>
        internal static JObject GetObject(bool ok, int id, string firstName, string lastName, string username,
            string languageCode)
        {
            dynamic meInfo = new JObject();

            meInfo.ok = ok;
            meInfo.result = GetResult(id, firstName, lastName, username, languageCode);

            return meInfo;
        }

        private static JObject GetResult(int id, string firstName, string lastName, string username, string languageCode)
        {
            dynamic result = new JObject();

            result.id = id;
            result.first_name = firstName;
            result.last_name = lastName;
            result.username = username;
            result.language_code = languageCode;

            return result;
        }
    }
}
