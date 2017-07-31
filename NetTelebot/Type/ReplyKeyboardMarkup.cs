using System.Linq;
using System.Security.Cryptography;
using NetTelebot.Interface;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a custom keyboard with reply options
    /// </summary>
    public class ReplyKeyboardMarkup : IReplyMarkup
    {
        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <returns></returns>
        public string GetJson()
        {
            dynamic replyKeyboardMarkup = new JObject();

            //JArray test =
                //new JArray(Keyboard.Select(item => new KeyboardButton {Text = item.Select(s => s)}.GetJson()));

            replyKeyboardMarkup.keyboard = test; // new JArray(Keyboard.Select(JToken.FromObject));
            if (ResizeKeyboard.HasValue)
                replyKeyboardMarkup.keyboard = ResizeKeyboard;
            if (OneTimeKeyboard.HasValue)
                replyKeyboardMarkup.one_time_keyboard = OneTimeKeyboard;
            if (Selective.HasValue)
                replyKeyboardMarkup.selective = Selective;

            return replyKeyboardMarkup.ToString();
        }

        /// <summary>
        /// Array of button rows, each represented by an Array of Strings
        /// </summary>
        public KeyboardButton[][] Keyboard { get; set; }

        /// <summary>
        /// Optional. Requests clients to resize the keyboard vertically for optimal fit (e.g., make the keyboard smaller if there are just two rows of buttons).
        /// Defaults to false, in which case the custom keyboard is always of the same height as the app's standard keyboard.
        /// </summary>
        public bool? ResizeKeyboard { get; set; }

        /// <summary>
        /// Optional. Requests clients to hide the keyboard as soon as it's been used. Defaults to false.
        /// </summary>
        public bool? OneTimeKeyboard { get; set; }

        /// <summary>
        /// Optional. Use this parameter if you want to show the keyboard to specific users only.
        /// Targets:
        /// 1) users that are @mentioned in the text of the Message object;
        /// 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// </summary>
        public bool? Selective { get; set; }
    }
}
