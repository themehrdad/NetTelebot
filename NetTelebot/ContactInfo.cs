﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot
{
    /// <summary>
    /// This object represents a phone contact.
    /// </summary>
    public class ContactInfo
    {
        internal ContactInfo()
        {
        }

        internal ContactInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal ContactInfo(JObject jsonObject)
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
            PhoneNumber = jsonObject["phone_number"].Value<string>();
            FirstName = jsonObject["first_name"].Value<string>();
            if (jsonObject["last_name"] != null)
                LastName = jsonObject["last_name"].Value<string>();
            if (jsonObject["user_id"] != null)
                UserId = jsonObject["user_id"].Value<string>();
        }

        /// <summary>
        /// Contact's phone number
        /// </summary>
        public string PhoneNumber { get; private set; }
        /// <summary>
        /// Contact's first name
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// Optional. Contact's last name
        /// </summary>
        public string LastName { get; private set; }
        /// <summary>
        /// Optional. Contact's user identifier in Telegram
        /// </summary>
        public string UserId { get; private set; }
    }
}
