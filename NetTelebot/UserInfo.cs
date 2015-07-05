using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    /// <summary>
    /// This object represents a Telegram user or bot.
    /// </summary>
    public class UserInfo : IConversationSource
    {
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
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<int>();
            FirstName = jsonObject["first_name"].Value<string>();
            if (jsonObject["last_name"] != null)
                LastName = jsonObject["last_name"].Value<string>();
            if (jsonObject["user_name"] != null)
                UserName = jsonObject["user_name"].Value<string>();
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
    }
}
