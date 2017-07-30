using System;
using System.Text;
using NetTelebot.Interface;

namespace NetTelebot.Type
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will hide the current custom keyboard and display the default letter-keyboard.
    /// By default, custom keyboards are displayed until a new keyboard is sent by a bot. An exception is made for one-time keyboards that are hidden immediately after the user presses a button
    /// </summary>
    [Obsolete]
    public class ReplyKeyboardHideMarkup : IReplyMarkup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReplyKeyboardHideMarkup"/> class.
        /// </summary>
        public ReplyKeyboardHideMarkup()
        {
            HideKeyboard = true;
        }

        /// <summary>
        /// Requests clients to hide the custom keyboard
        /// </summary>
        public bool HideKeyboard { get; private set; }

        /// <summary>
        /// Optional. Use this parameter if you want to hide keyboard for specific users only.
        /// Targets:
        /// 1) users that are @mentioned in the text of the Message object; 
        /// 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// </summary>
        public bool? Selective { get; set; }

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <returns></returns>
        public string GetJson()
        {
            var builder = new StringBuilder();
            builder.Append("{ \"hide_keyboard\" : true ");
            if (Selective.HasValue)
            {
                builder.AppendFormat(", \"selective\" : {0} ", Selective.Value.ToString().ToLower());
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
}
