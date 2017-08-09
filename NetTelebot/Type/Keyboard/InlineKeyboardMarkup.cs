using System.Linq;
using NetTelebot.Interface;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Keyboard 
{
    /// <summary>
    /// This object represents an inline keyboard that appears right next to the message it belongs to..
    /// </summary>
    public class InlineKeyboardMarkup : IReplyMarkup
    {
        /// <summary>
        /// Gets the json.
        /// </summary>
        public JObject GetJson()
        {
            dynamic json = new JObject();

            json.inline_keyboard = GetJsonArrayOfArray(Keyboard);

            return json;
        }

        private static JArray GetJsonArrayOfArray(InlineKeyboardButton[][] keyboard)
        {
            JArray jArray = new JArray
            {
                from KeyboardArray in keyboard
                select GetJsonArray(KeyboardArray)
            };

            return jArray;
        }

        private static JArray GetJsonArray(InlineKeyboardButton[] keyboard)
        {
            JArray jArray = new JArray
            {
                from KeyboardArray in keyboard
                select InlineKeyboardButton.GetJson(KeyboardArray)
            };

            return jArray;
        }

        /// <summary>
        /// Array of button rows, each represented by an Array of Strings
        /// </summary>
        public InlineKeyboardButton[][] Keyboard { get; set; }
    }
}
