using Newtonsoft.Json;

namespace NetTelebot.Type
{
    /// <summary>
    /// Describes reply parameters for the message that is being sent.
    /// See <see href="https://core.telegram.org/bots/api#replyparameters">API</see>
    /// </summary>
    public class ReplyParameters
    {
        /// <summary>
        /// Identifier of the message that will be replied to in the current chat, or in the chat chat_id if it is specified
        /// </summary>
        [JsonProperty("message_id", Required = Required.Always)]
        public int MessageId { get; set; }

        /// <summary>
        /// Optional. If the message to be replied to is from a different chat, unique identifier for the chat or username of the channel (in the format @channelusername)
        /// </summary>
        [JsonProperty("chat_id", NullValueHandling = NullValueHandling.Ignore)]
        public object ChatId { get; set; }

        /// <summary>
        /// Optional. Pass True if the message should be sent even if the specified message to be replied to is not found; can be used only for replies in the same chat and forum topic.
        /// </summary>
        [JsonProperty("allow_sending_without_reply", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowSendingWithoutReply { get; set; }

        /// <summary>
        /// Optional. Quoted part of the message to be replied to; 0-1024 characters after entities parsing. The quote must be an exact substring of the message to be replied to, including bold, italic, underline, strikethrough, spoiler, and custom_emoji entities. The message will fail to send if the quote isn't found in the original message.
        /// </summary>
        [JsonProperty("quote", NullValueHandling = NullValueHandling.Ignore)]
        public string Quote { get; set; }

        /// <summary>
        /// Optional. Mode for parsing entities in the quote.
        /// </summary>
        [JsonProperty("quote_parse_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string QuoteParseMode { get; set; }

        /// <summary>
        /// Optional. Position of the quote in the original message in UTF-16 code units
        /// </summary>
        [JsonProperty("quote_position", NullValueHandling = NullValueHandling.Ignore)]
        public int? QuotePosition { get; set; }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
