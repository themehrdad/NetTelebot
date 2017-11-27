using Newtonsoft.Json.Linq;

namespace NetTelebot.Interface
{
    /// <summary>
    /// This interface is used to specify inline_keyboard_markup parameter when edited a message.
    /// Can be InlineKeyboardMarkup.
    /// </summary>
    public interface IInlineKeyboardMarkup
    {
        /// <summary>
        /// Gets the json InlineKeyboardMarkup
        /// </summary>
        JObject GetJson();
    }
}
