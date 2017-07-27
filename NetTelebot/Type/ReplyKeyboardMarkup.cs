using System.Linq;
using System.Text;
using NetTelebot.Interface;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a custom keyboard with reply options
    /// </summary>
    public class ReplyKeyboardMarkup : IReplyMarkup
    {
        /// <summary>
        /// Array of button rows, each represented by an Array of Strings
        /// </summary>
        public string[][] Keyboard { get; set; }

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

        public string GetJson()
        {
            var builder = new StringBuilder();
            var keyboard = GetKeyboardJson();
            builder.AppendFormat("{{ \"keyboard\" : [{0}] ",keyboard);
            if (ResizeKeyboard.HasValue)
                builder.AppendFormat(", \"resize_keyboard\" : {0} ", ResizeKeyboard.Value.ToString().ToLower());
            if (OneTimeKeyboard.HasValue)
                builder.AppendFormat(", \"one_time_keyboard\" : {0} ", OneTimeKeyboard.Value.ToString().ToLower());
            if (Selective.HasValue)
                builder.AppendFormat(", \"selective\" : {0} ", Selective.Value.ToString().ToLower());
            builder.Append("}");
            return builder.ToString();
        }

        private string GetKeyboardJson()
        {
            return string.Join(",", Keyboard.Select(line =>
                $"[{string.Join(",", line.Select(item => $"\"{item}\"").ToArray())}]").ToArray());
        }
    }
}
