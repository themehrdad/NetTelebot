using System;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents one button of the reply keyboard. For simple text buttons String can be used instead of this object to specify text of the button. 
    /// Optional fields are mutually exclusive.
    /// </summary>
    public class KeyboardButton
    {
        internal KeyboardButton()
        {
            GetJson();
        }

        /// <summary>
        /// Text of the button. If none of the optional fields are used, it will be sent to the bot as a message when the button is pressed
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only
        /// </summary>
        //public bool RequestContact { get; set; }

        /// <summary>
        /// Optional. If True, the user's current location will be sent when the button is pressed. Available in private chats only
        /// </summary>
        //public bool RequestLocation { get; set; }

        public string GetJson()
        {
            dynamic json = new JObject();

            json.text = text;
            /*if (RequestContact != null)
                json.request_contact = RequestContact;
            if (RequestLocation != null)
                json.request_location = RequestLocation;*/

            return json.ToString();
        }
    }
}
