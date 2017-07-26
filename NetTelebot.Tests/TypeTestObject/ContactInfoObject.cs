using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class ContactInfoObject
    {
        /// <summary>
        /// This object represents a phone contact. See <see href="https://core.telegram.org/bots/api#contact">API</see>
        /// </summary>
        /// <param name="phoneNumber">Contact's phone number</param>
        /// <param name="firstName">Contact's first name</param>
        /// <param name="lastName">Optional. Contact's last name</param>
        /// <param name="userId">Optional. Contact's user identifier in Telegram.</param>
        /// <returns><see cref="ContactInfo"/></returns>
        internal static JObject GetObject(string phoneNumber, string firstName, string lastName, string userId)
        {
            dynamic contactInfo = new JObject();

            contactInfo.phone_number = phoneNumber;
            contactInfo.first_name = firstName;
            contactInfo.last_name = lastName;
            contactInfo.user_id = userId;

            return contactInfo;
        }
    }
}