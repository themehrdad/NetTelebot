using System.Collections.Generic;
using System.Linq;
using NetTelebot.Interface;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Keyboard 
{
    /// <summary>
    /// This object represents an inline keyboard that appears right next to the message it belongs to..
    /// </summary>
    public class InlineKeyboardMarkup : IReplyMarkup, IInlineKeyboardMarkup
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

        private static JArray GetJsonArrayOfArray(IEnumerable<InlineKeyboardButton[]> keyboard)
        {
            JArray jArray = new JArray
            {
                from keyboardArray in keyboard
                select GetJsonArray(keyboardArray)
            };

            return jArray;
        }

        private static JArray GetJsonArray(IEnumerable<InlineKeyboardButton> keyboard)
        {
            JArray jArray = new JArray
            {
                from keyboardArray in keyboard
                select InlineKeyboardButton.GetJson(keyboardArray)
            };

            return jArray;
        }

        /// <summary>
        /// Array of button rows, each represented by an Array of Strings
        /// </summary>
        public InlineKeyboardButton[][] Keyboard { get; set; }
    }
}
