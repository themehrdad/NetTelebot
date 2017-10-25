using NetTelebot.BotEnum;
using NetTelebot.Interface;
using NetTelebot.Result;
using NetTelebot.Type.Payment;
using RestSharp;

namespace NetTelebot
{
    /* About tests
     * After adding the class field, you need to add the following tests:
     *  
     * NetTelebot.Tests.RequestToMockTest.[ClassName]
     * 
     * [ClassName] = TelegramBotClientTest if you want to test the method
     * [ClassName] = TelegramBotGetUpdatesTest if you are testing for updates
     * [ClassName] = TelegramBotInlineKeyboardTest or TelegramBotKeyboardTest if you test keyboard.
     * [ClassName] = TelegramBotEventHandlerTest if you test event handler
     * 
     * Also you can check how the written added methods work in the namespace classes NetTelebot.Tests.RequestToTelegramTest.
     * There are requests to the telegram servers
     */

    /* About this partial class
     * 
     * In this part of the class, only methods for payment. 
     * See API https://core.telegram.org/bots/api#payments
     *  
     */

    public partial class TelegramBotClient
    {
        private const string mAnswerShippingQueryUri = "/bot{0}/answerShippingQuery";
        private const string mSendInvoiceUri = "/bot{0}/sendInvoice";
        private const string mAnswerPreCheckoutQuery = "/bot{0}/answerPreCheckoutQuery";

        /// <summary>
        /// If you sent an invoice requesting a shipping address and the parameter is_flexible was specified, 
        /// the Bot API will send an <see href="https://core.telegram.org/bots/api#update">Update</see> with a shipping_query field to the bot. 
        /// Use this method to reply to shipping queries.
        /// </summary>
        /// <param name="shippingQueryId">Unique identifier for the query to be answered</param>
        /// <param name="ok">Specify True if delivery to the specified address is possible and False if there are any problems 
        /// (for example, if delivery to the specified address is not possible)</param>
        /// <param name="shippingOption">Required if ok is True. 
        /// A JSON-serialized array of available shipping options.</param>
        /// <param name="errorMessage">Required if ok is False. 
        /// Error message in human readable form that explains why it is impossible to complete the order (e.g. "Sorry, delivery to your desired address is unavailable'). 
        /// Telegram will display this message to the user.</param>
        /// <returns>On success, True is returned.</returns>
        public BooleanResult AnswerShippingQuery(string shippingQueryId, bool ok,
            ShippingOptionInfo[] shippingOption = null,
            string errorMessage = null)
        {
            RestRequest request = NewRestRequest(mAnswerShippingQueryUri);

            request.AddParameter("shipping_query_id", shippingQueryId);
            request.AddParameter("ok", ok);

            if (shippingOption != null)
                request.AddParameter("shipping_options", ShippingOptionInfo.GetJson(shippingOption));
            if (!string.IsNullOrEmpty(errorMessage))
                request.AddParameter("error_message", errorMessage);

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }

        /// <summary>
        /// Use this method to send invoices. 
        /// See <see href="https://core.telegram.org/bots/api#sendinvoice">API</see>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target private chat</param>
        /// <param name="title">Product name, 1-32 characters</param>
        /// <param name="description">Product description, 1-255 characters</param>
        /// <param name="payload">Bot-defined invoice payload, 1-128 bytes. 
        /// This will not be displayed to the user, use for your internal processes.</param>
        /// <param name="providerToken">Payments provider token, obtained via Botfather</param>
        /// <param name="startParameter">Unique deep-linking parameter that can be used to generate this invoice when used as a start parameter</param>
        /// <param name="currency">Three-letter ISO 4217 currency code</param>
        /// <param name="labeledPrice">Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.)</param>
        /// <param name="photoUrl">URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service. 
        /// People like it better when they see what they are paying for.</param>
        /// <param name="photoSize">Photo size</param>
        /// <param name="photoWidth">Photo width</param>
        /// <param name="photoHeight">Photo height</param>
        /// <param name="needName">Pass True, if you require the user's full name to complete the order</param>
        /// <param name="needPhoneNumber">Pass True, if you require the user's phone number to complete the order</param>
        /// <param name="needEmail">Pass True, if you require the user's email to complete the order</param>
        /// <param name="needShippingAdress">Pass True, if you require the user's shipping address to complete the order</param>
        /// <param name="isFlexible">Pass True, if the final price depends on the shipping method</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">A JSON-serialized object for an inline keyboard. 
        /// If empty, one 'Pay total price' button will be shown. If not empty, the first button must be a Pay button.</param>
        /// <returns>On success, the sent <see cref="SendMessageResult"/> is returned.</returns>
        public SendMessageResult SendInvoice(string chatId,
            string title,
            string description,
            string payload,
            string providerToken,
            string startParameter,
            Currency currency,
            LabeledPriceInfo[] labeledPrice,
            string photoUrl = null,
            int? photoSize = null,
            int? photoWidth = null,
            int? photoHeight = null,
            bool? needName = null,
            bool? needPhoneNumber = null,
            bool? needEmail = null,
            bool? needShippingAdress = null,
            bool? isFlexible = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            IReplyMarkup replyMarkup = null)
        {
            RestRequest request = NewRestRequest(mSendInvoiceUri);

            request.AddParameter("chat_id", chatId);
            request.AddParameter("title", title);
            request.AddParameter("description", description);
            request.AddParameter("payload", payload);
            request.AddParameter("provider_token", providerToken);
            request.AddParameter("start_parameter", startParameter);
            request.AddParameter("currency", currency.ToString());
            request.AddParameter("prices", LabeledPriceInfo.GetJsonArray(labeledPrice));

            if (photoUrl != null)
                request.AddParameter("photo_url", photoUrl);
            if (photoSize != null)
                request.AddParameter("photo_size", photoSize);
            if (photoWidth != null)
                request.AddParameter("photo_width", photoWidth);
            if (photoHeight != null)
                request.AddParameter("photo_height", photoHeight);

            request.AddParameter("need_name", needName ?? false);
            request.AddParameter("need_phone_number", needPhoneNumber ?? false);
            request.AddParameter("need_email", needEmail ?? false);
            request.AddParameter("need_shipping_address", needShippingAdress ?? false);
            request.AddParameter("is_flexible", isFlexible ?? false);

            if (disableNotification.HasValue)
                request.AddParameter("disable_notification", disableNotification.Value);
            if (replyToMessageId != null)
                request.AddParameter("reply_to_message_id", replyToMessageId);
            if (replyMarkup != null)
                request.AddParameter("reply_markup", replyMarkup.GetJson());

            return ExecuteRequest<SendMessageResult>(request) as SendMessageResult;
        }

        /// <summary>
        /// Once the user has confirmed their payment and shipping details, 
        /// the Bot API sends the final confirmation in the form of an Update with the field pre_checkout_query. 
        /// Use this method to respond to such pre-checkout queries.
        /// See <see href="https://core.telegram.org/bots/api#answerprecheckoutquery">API</see>
        /// </summary>
        /// <param name="preCheckoutQueryId">Unique identifier for the query to be answered</param>
        /// <param name="ok">Specify True if everything is alright (goods are available, etc.) 
        /// and the bot is ready to proceed with the order. Use False if there are any problems.</param>
        /// <param name="errorMessage">Required if ok is False. 
        /// Error message in human readable form that explains the reason for failure to proceed with the checkout 
        /// (e.g. "Sorry, somebody just bought the last of our amazing black T-shirts while you were busy filling out your payment details. 
        /// Please choose a different color or garment!"). Telegram will display this message to the user.</param>
        /// <returns>On success, True is returned. 
        /// Note: The Bot API must receive an answer within 10 seconds after the pre-checkout query was sent.</returns>
        public BooleanResult AnswerPreCheckoutQuery(string preCheckoutQueryId, bool ok, string errorMessage = null)
        {
            RestRequest request = NewRestRequest(mAnswerPreCheckoutQuery);

            request.AddParameter("pre_checkout_query_id", preCheckoutQueryId);
            request.AddParameter("ok", ok);

            if (!string.IsNullOrEmpty(errorMessage))
                request.AddParameter("error_message", errorMessage);

            return ExecuteRequest<BooleanResult>(request) as BooleanResult;
        }
    }
}
