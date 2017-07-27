using NetTelebot.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a Telegram user or bot.
    /// </summary>
    public class UserInfo : IConversationSource
    {
        internal UserInfo()
        {
        }

        internal UserInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal UserInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<int>();
            FirstName = jsonObject["first_name"].Value<string>();
            if (jsonObject["last_name"] != null)
                LastName = jsonObject["last_name"].Value<string>();
            if (jsonObject["username"] != null)
                UserName = jsonObject["username"].Value<string>();
            if (jsonObject["language_code"] != null)
                LanguageCode = jsonObject["language_code"].Value<string>();
        }

        /// <summary>
        /// Unique identifier for this user or bot
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User‘s or bot’s first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. User‘s or bot’s last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional. User‘s or bot’s username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Optional. IETF language tag of the user's language
        /// About <see href="https://en.wikipedia.org/wiki/IETF_language_tag">IETF language tag</see>
        /// </summary>
        public string LanguageCode { get; set; }
    }
}
