using Newtonsoft.Json.Linq;

namespace NetTelebot.Interface
{
    /// <summary>
    /// This interface is used to specify reply_markup parameter when sending a message. 
    /// Can be InlineKeyboardMarkup, ReplyKeyboardMarkup, ReplyKeyboardRemove or ForceReply
    /// </summary>
    public interface IReplyMarkup
    {
        /// <summary>
        /// Gets the json InlineKeyboardMarkup, ReplyKeyboardMarkup, ReplyKeyboardRemove or ForceReply
        /// </summary>
        JObject GetJson();
    }
}
