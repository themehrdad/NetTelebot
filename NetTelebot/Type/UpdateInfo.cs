using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents an incoming update.
    /// At most one of the optional parameters can be present in any given update.
    /// </summary>
    public class UpdateInfo
    {
        internal UpdateInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            UpdateId = jsonObject["update_id"].Value<int>();

            Message = jsonObject["message"] != null
                ? new MessageInfo(jsonObject["message"].Value<JObject>())
                : MessageInfo.GetNewMessageInfo(MessageInfo.GetNewMessageInfo(), MessageInfo.GetNewMessageInfo());

            EditedMessage = jsonObject["edited_message"] != null
                ? new MessageInfo(jsonObject["edited_message"].Value<JObject>())
                : MessageInfo.GetNewMessageInfo(MessageInfo.GetNewMessageInfo(), MessageInfo.GetNewMessageInfo());

            ChannelPost = jsonObject["channel_post"] != null
                ? new MessageInfo(jsonObject["channel_post"].Value<JObject>())
                : MessageInfo.GetNewMessageInfo(MessageInfo.GetNewMessageInfo(), MessageInfo.GetNewMessageInfo());

            EditedChannelPost = jsonObject["edited_channel_post"] != null
                ? new MessageInfo(jsonObject["edited_channel_post"].Value<JObject>())
                : MessageInfo.GetNewMessageInfo(MessageInfo.GetNewMessageInfo(), MessageInfo.GetNewMessageInfo());

            CallbackQuery = jsonObject["callback_query"] != null
                ? new CallbackQueryInfo(jsonObject["callback_query"].Value<JObject>())
                : new CallbackQueryInfo();
        }

        /// <summary>
        /// Parses the array.
        /// </summary>
        /// <param name="jsonArray">The json array</param>
        internal static UpdateInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new UpdateInfo(jobject)).ToArray();
        }

        /// <summary>
        /// The update‘s unique identifier. 
        /// Update identifiers start from a certain positive number and increase sequentially. 
        /// This ID becomes especially handy if you’re using Webhooks, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order.
        /// </summary>
        public int UpdateId { get; private set; }

        /// <summary>
        /// Optional. 
        /// New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        public MessageInfo Message { get; private set; }

        /// <summary>
        /// Optional. 
        /// New version of a message that is known to the bot and was edited
        /// </summary>
        public MessageInfo EditedMessage { get; private set; }

        /// <summary>
        /// Optional. 
        /// New incoming channel post of any kind — text, photo, sticker, etc.
        /// </summary>
        public MessageInfo ChannelPost { get; private set; }

        /// <summary>
        /// Optional. 
        /// New version of a channel post that is known to the bot and was edited
        /// </summary>
        public MessageInfo EditedChannelPost { get; private set;  }

        //todo InlineQuery => InlineQuery
        //todo ChosenInlineResult => ChosenInline_Result

        /// <summary>
        /// Optional. 
        /// New incoming callback query
        /// </summary>
        public CallbackQueryInfo CallbackQuery { get; private set;  }

        //todo ShippingQuery => ChippingQuery
        //todo PreCheckoutQuery => PreCheckoutQuery
    }
}
