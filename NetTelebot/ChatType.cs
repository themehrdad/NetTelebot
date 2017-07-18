namespace NetTelebot
{
    /// <summary>
    /// Type of chat, can be either “private”, “group”, “supergroup” or “channel”
    /// </summary>
    public enum ChatType
    {
        /// <summary>
        /// The private
        /// </summary>
        @private,

        /// <summary>
        /// The group
        /// </summary>
        group,

        /// <summary>
        /// The supergroup
        /// </summary>
        supergroup,

        /// <summary>
        /// The channel
        /// </summary>
        channel
    }
}
