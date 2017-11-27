namespace NetTelebot.BotEnum
{
    /// <summary>
    /// List the types of updates you want your bot to receive.
    /// </summary>
    public enum AllowedUpdates
    {
        /// <summary>
        /// New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        Message,

        /// <summary>
        /// New version of a message that is known to the bot and was edited
        /// </summary>
        EditedMessage,

        /// <summary>
        /// New incoming channel post of any kind — text, photo, sticker, etc.
        /// </summary>
        ChannelPost,

        /// <summary>
        /// New version of a channel post that is known to the bot and was edited
        /// </summary>
        EditedChannelPost,

        /// <summary>
        /// New incoming inline query
        /// </summary>
        InlineQuery,

        /// <summary>
        /// The result of an inline query that was chosen by a user and sent to their chat partner. 
        /// Please see our documentation on the feedback collecting for details on how to enable these updates for your bot.
        /// </summary>
        ChosenInlineResult,

        /// <summary>
        /// New incoming callback query
        /// </summary>
        CallbackQuery,

        /// <summary>
        /// New incoming shipping query. Only for invoices with flexible price
        /// </summary>
        ShippingQuery,

        /// <summary>
        /// New incoming pre-checkout query. Contains full information about checkout
        /// </summary>
        PreCheckoutQuery
    }
}
