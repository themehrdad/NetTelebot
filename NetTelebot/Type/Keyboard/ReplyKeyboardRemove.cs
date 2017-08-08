using NetTelebot.Interface;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Keyboard
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will remove the current custom keyboard and display the default letter-keyboard.
    /// By default, custom keyboards are displayed until a new keyboard is sent by a bot.
    /// An exception is made for one-time keyboards that are hidden immediately after the user presses a button
    /// Since the value "remove_keyboard: false" does not make sense, the field of the class of this value is missing
    /// </summary>
    public class ReplyKeyboardRemove : IReplyMarkup
    {
        /// <summary>
        /// Gets the string json object ReplyKeyboardRemove
        /// </summary>
        public string GetJson()
        {
            dynamic keyboardHide = new JObject();

            keyboardHide.remove_keyboard = true;

            if (Selective.HasValue)
                keyboardHide.selective = Selective;

            return keyboardHide.ToString();
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
