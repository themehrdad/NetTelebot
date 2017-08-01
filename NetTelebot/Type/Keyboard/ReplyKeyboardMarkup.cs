using System;
using System.Collections.Generic;
using System.Linq;
using NetTelebot.Interface;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Keyboard
{
    /// <summary>
    /// This object represents a custom keyboard with reply options
    /// </summary>
    public class ReplyKeyboardMarkup : IReplyMarkup
    {
        /// <summary>
        /// Gets the json.
        /// </summary>
        public string GetJson()
        {
            dynamic replyKeyboardMarkup = new JObject();

            replyKeyboardMarkup.keyboard = GetJsonArrayOfArray(Keyboard);

            if (ResizeKeyboard.HasValue)
                replyKeyboardMarkup.resize_keyboard = ResizeKeyboard;
            if (OneTimeKeyboard.HasValue)
                replyKeyboardMarkup.one_time_keyboard = OneTimeKeyboard;
            if (Selective.HasValue)
                replyKeyboardMarkup.selective = Selective;

            return replyKeyboardMarkup.ToString();
        }

        private static JArray GetJsonArrayOfArray(KeyboardButton[][] keyboard)
        {
            JArray jArray = new JArray();

            foreach (var keyboardArray in keyboard)
            {
                jArray.Add(new KeyboardButton().GetJsonArray(keyboardArray));
            }

            return jArray;
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
