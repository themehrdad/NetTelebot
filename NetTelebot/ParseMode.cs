namespace NetTelebot
{
    /// <summary>
    /// Use this if you want Telegram apps to show bold, italic, fixed-width text or inline URLs in your bot's message. Optional.
    /// </summary>
    public enum ParseMode
    {
        /// <summary>
        /// How use <see href="https://core.telegram.org/bots/api#markdown-style">this</see>
        /// </summary>
        Markdown,
        /// <summary>
        /// How use <see href="https://core.telegram.org/bots/api#html-style">this</see>
        /// </summary>
        HTML
    }
}
