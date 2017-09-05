using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// When caling <see cref="TelegramBotClient.GetMe"/>, method must return <see cref="UserInfo"/>. 
    /// See in <see href="https://core.telegram.org/bots/api#getme">API</see>>
    /// This class is a copy of the UserInfo class, but with access to the ok field.
    /// </summary>
    [Obsolete("Please use UserInfoResult. This method will be removed at the following updates")]
    public class MeInfo
    {
        internal MeInfo(string jsonText)
        {
            Parse(jsonText);
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Id = jsonObject["result"]["id"].Value<int>();
            FirstName = jsonObject["result"]["first_name"].Value<string>();

            if (jsonObject["result"]["last_name"] != null)
                LastName = jsonObject["result"]["last_name"].Value<string>();
            if (jsonObject["result"]["username"] != null)
                UserName = jsonObject["result"]["username"].Value<string>();
            if (jsonObject["result"]["language_code"] != null)
                LanguageCode = jsonObject["result"]["language_code"].Value<string>();
        }

        /// <summary>
        /// Gets a value "ok" in response.
        /// </summary>
        /// <returns> <c>true</c> if ok; otherwise, <c>false</c>. </returns>
        public bool Ok { get; private set; }

        /// <summary>
        /// Unique identifier for this user or bot
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User‘s or bot’s first name
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Optional. User‘s or bot’s last name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Optional. User‘s or bot’s username
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Optional. <see href="https://en.wikipedia.org/wiki/IETF_language_tag"> IETF language tag  </see>of the user's language
        /// </summary>
        public string LanguageCode { get; private set; }
    }
}
