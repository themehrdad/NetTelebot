using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents one button of the reply keyboard. For simple Text buttons String can be used instead of this object to specify Text of the button. 
    /// Optional fields are mutually exclusive.
    /// </summary>
    public class KeyboardButton
    {
        /// <summary>
        /// Text of the button. If none of the optional fields are used, it will be sent to the bot as a message when the button is pressed
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only
        /// </summary>
        public bool? RequestContact { get; set; }

        /// <summary>
        /// Optional. If True, the user's current location will be sent when the button is pressed. Available in private chats only
        /// </summary>
        public bool? RequestLocation { get; set; }

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <returns></returns>
        public string GetJson()
        {
            dynamic json = new JObject();

            json.text = Text;
            if (RequestContact.HasValue)
                json.request_contact = RequestContact;
            if (RequestLocation.HasValue)
                json.request_location = RequestLocation;

            return json.ToString();
        }
    }
}
