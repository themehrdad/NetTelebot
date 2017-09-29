using NetTelebot.BotEnum;
using NetTelebot.Extension;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Payment
{
    /// <summary>
    /// This object contains basic information about a successful payment.
    /// See <see href="https://core.telegram.org/bots/api#successfulpayment">API</see>
    /// </summary>
    public class SuccessfulPaymentInfo
    {
        internal SuccessfulPaymentInfo()
        {
        }

        internal SuccessfulPaymentInfo(JObject jsonObject)
        {
            Currency = jsonObject["currency"].Value<string>().ToEnum<Currency>();
            TotalAmmount = jsonObject["total_amount"].Value<int>();
            InvoicePayload = jsonObject["invoice_payload"].Value<string>();

            if (jsonObject["shipping_option_id"] != null)
                ShippingOptionId = jsonObject["shipping_option_id"].Value<string>();
            if (jsonObject["order_info"] != null)
                OrderInfo = new OrderInfo(jsonObject["order_info"].Value<JObject>());

            TelegramPaymentChargeId = jsonObject["telegram_payment_charge_id"].Value<string>();
            ProviderPaymentChargeId = jsonObject["provider_payment_charge_id"].Value<string>();
        }

        /// <summary>
        /// Three-letter ISO 4217 currency code
        /// </summary>
        public Currency? Currency { get; private set; }

        /// <summary>
        /// Total price in the smallest units of the currency (integer, not float/double). 
        /// For example, for a price of US$ 1.45 pass amount = 145. 
        /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json </see>, 
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// </summary>
        public int TotalAmmount { get; private set; }

        /// <summary>
        /// Bot specified invoice payload
        /// </summary>
        public string InvoicePayload { get; private set; }

        /// <summary>
        /// Optional. Identifier of the shipping option chosen by the user
        /// </summary>
        public string ShippingOptionId { get; private set; }

        /// <summary>
        /// Optional. Order info provided by the user
        /// </summary>
        public OrderInfo OrderInfo { get; internal set; }

        /// <summary>
        /// Telegram payment identifier
        /// </summary>
        public string TelegramPaymentChargeId { get; private set; }

        /// <summary>
        /// Provider payment identifier
        /// </summary>
        public string ProviderPaymentChargeId { get; private set; }
    }
}
