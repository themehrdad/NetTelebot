using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace NetTelebot
{
    /// <summary>
    /// When caling GetMe method on TelegramBotClient class, this object will be returned.
    /// </summary>
    public class MeInfo
    {
        internal MeInfo(string jsonText)
        {
            try
            {
                Parse(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("JSON parse error", ex);
            }
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Id = jsonObject["result"]["id"].Value<string>();
            FirstName = jsonObject["result"]["first_name"].Value<string>();
            UserName = jsonObject["result"]["username"].Value<string>();
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="MeInfo"/> is ok.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ok; otherwise, <c>false</c>.
        /// </value>
        public bool Ok { get; private set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; private set; }
    }
}
