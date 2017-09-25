using NetTelebot.BotEnum;
using NetTelebot.Extension;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Payment
{
    /// <summary>
    /// This object contains information about an incoming pre-checkout query.
    /// See <see href="https://core.telegram.org/bots/api#precheckoutquery">API</see>
    /// </summary>
    public class PreCheckoutQueryInfo
    {
        internal PreCheckoutQueryInfo()
        {
        }

        internal PreCheckoutQueryInfo(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<string>();
            From = new UserInfo(jsonObject["from"].Value<JObject>());
            Currency = jsonObject["currency"].Value<string>().ToEnum<Currency>();
            TotalAmmount = jsonObject["total_amount"].Value<int>();
            InvoicePayload = jsonObject["invoice_payload"].Value<string>();

            if (jsonObject["shipping_option_id"] != null)
                ShippingOptionId = jsonObject["shipping_option_id"].Value<string>();
            if (jsonObject["order_info"] != null)
                OrderInfo = new OrderInfo(jsonObject["order_info"].Value<JObject>());
        }

        /// <summary>
        /// Unique query identifier
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// User who sent the query
        /// </summary>
        public UserInfo From { get; private set; }

        /// <summary>
        /// Three-letter ISO 4217 currency code
        /// </summary>
        public Currency? Currency { get; private set; }

        /// <summary>
        /// Total price in the smallest units of the currency (integer, not float/double). 
        /// For example, for a price of US$ 1.45 pass amount = 145. See the exp parameter in currencies.json, 
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// </summary>
        public int TotalAmmount { get; private set; }

        /// <summary>
        /// Bot specified invoice payload
        /// </summary>
        public string InvoicePayload { get; private set; }

        /// <summary>
        /// Optional. 
        /// Identifier of the shipping option chosen by the user
        /// </summary>
        public string ShippingOptionId { get; private set; }

        /// <summary>
        /// Optional. 
        /// Order info provided by the user
        /// </summary>
        public OrderInfo OrderInfo { get; private set; }
    }
}
