using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal class UserInfoObject
    {
        protected UserInfoObject()
        {
        }

        /// <summary>
        /// This object represents a Telegram user or bot. See <see href="https://core.telegram.org/bots/api#user">API</see>
        /// </summary>
        /// <returns><see cref="UserInfo"/></returns>
        internal static JObject GetObject(int id, string firstName, string lastName, string username, string languageCode)
        {

            dynamic userInfo = new JObject();

            userInfo.id = id;
            userInfo.first_name = firstName;

            return userInfo;
        }
}