using System;
using NetTelebot.Interface;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Keyboard
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will hide the current custom keyboard and display the default letter-keyboard.
    /// By default, custom keyboards are displayed until a new keyboard is sent by a bot. An exception is made for one-time keyboards that are hidden immediately after the user presses a button
    /// Since the value "hide_keyboard: false" does not make sense, the field of the class of this value is missing
    /// </summary>
    [Obsolete("In version 1.0.11 it will be deleted. Use ReplyKeyboardRemove")]
    public class ReplyKeyboardHideMarkup : IReplyMarkup
    {
        /// <summary>
        /// Gets the string json object ReplyKeyboardHideMarkup
        /// </summary>
        public JObject GetJson()
        {
            dynamic keyboardHide = new JObject();

            keyboardHide.hide_keyboard = true;

            if (Selective.HasValue)
                keyboardHide.selective = Selective;

            return keyboardHide;
        }

        /// <summary>
        /// Optional. Use this parameter if you want to force reply from specific users only. 
        /// Targets: 
        /// 1) users that are @mentioned in the text of the Message object; 
        /// 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// </summary>
        public bool? Selective { get; set; }
    }
}
