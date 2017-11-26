using System.Linq;
using NetTelebot.Type.InlineMode;
using NetTelebot.Type.Payment;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents an incoming update.
    /// At most one of the optional parameters can be present in any given update.
    /// See <see href="https://core.telegram.org/bots/api#update">API</see>
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

            InlineQuery = jsonObject["inline_query"] != null
                ? new InlineQueryInfo(jsonObject["inline_query"].Value<JObject>())
                : new InlineQueryInfo{ From = new UserInfo(), Location = new LocationInfo() };

            ChosenInlineResult = jsonObject["chosen_inline_result"] != null
                ? new ChosenInlineResultInfo(jsonObject["chosen_inline_result"].Value<JObject>())
                : new ChosenInlineResultInfo {From = new UserInfo(), Location = new LocationInfo()};

            CallbackQuery = jsonObject["callback_query"] != null
                ? new CallbackQueryInfo(jsonObject["callback_query"].Value<JObject>())
                : new CallbackQueryInfo
                {
                    From = new UserInfo(),
                    Message =
                        MessageInfo.GetNewMessageInfo(MessageInfo.GetNewMessageInfo(), MessageInfo.GetNewMessageInfo())
                };

            ShippingQuery = jsonObject["shipping_query"] != null
                ? new ShippingQueryInfo(jsonObject["shipping_query"].Value<JObject>())
                : new ShippingQueryInfo {From = new UserInfo(), ShippingAddress = new ShippingAddressInfo()};

            PreCheckoutQuery = jsonObject["pre_checkout_query"] != null
                ? new PreCheckoutQueryInfo(jsonObject["pre_checkout_query"].Value<JObject>())
                : new PreCheckoutQueryInfo {From = new UserInfo(), OrderInfo = new OrderInfo()};
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
        /// This ID becomes especially handy if you’re using Webhooks, since it allows you to 
        /// ignore repeated updates or to restore the correct update sequence, should they get out of order.
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

        /// <summary>
        /// Optional.
        /// New incoming inline query
        /// </summary>
        public InlineQueryInfo InlineQuery { get; private set; }

        /// <summary>
        /// Optional. 
        /// The result of an inline query that was chosen by a user and sent to their chat partner. 
        /// Please see our documentation on the <see href="https://core.telegram.org/bots/inline#collecting-feedback">feedback collecting</see> for details on how to enable these updates for your bot.
        /// </summary>
        public ChosenInlineResultInfo ChosenInlineResult { get; private set; }

        /// <summary>
        /// Optional. 
        /// New incoming callback query
        /// </summary>
        public CallbackQueryInfo CallbackQuery { get; private set;  }

        /// <summary>
        /// Optional. 
        /// New incoming shipping query. Only for invoices with flexible price
        /// </summary>
        public ShippingQueryInfo ShippingQuery { get; private set;  }

        /// <summary>
        /// Optional. 
        /// New incoming pre-checkout query. Contains full information about checkout
        /// </summary>
        public PreCheckoutQueryInfo PreCheckoutQuery { get; private set; }
    }
}
