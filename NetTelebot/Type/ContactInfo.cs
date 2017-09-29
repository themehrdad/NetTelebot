using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a phone contact. See <see href="https://core.telegram.org/bots/api#contact">API</see>
    /// </summary>
    public class ContactInfo
    {
        internal ContactInfo()
        {
        }

        internal ContactInfo(JObject jsonObject)
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
