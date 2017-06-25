namespace NetTelebot
{
    /// <summary>
    /// This interface is used to specify reply_markup parameter when sending a message. It can be a ReplyKeyboardMarkup, ReplyKeyboardHideMarkup and ForceReplyMarkup.
    /// </summary>
    public interface IReplyMarkup
    {
        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <returns></returns>
        string GetJson();
    }
}
