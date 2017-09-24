using NetTelebot.Type.Payment;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.PaymentObject
{
    internal static class PreCheckoutQueryInfoObject
    {
        /// <summary>
        /// This object contains information about an incoming pre-checkout query.
        /// See <see href="https://core.telegram.org/bots/api#precheckoutquery">API</see>
        /// </summary>
        /// <param name="id">Unique query identifier</param>
        /// <param name="from">User who sent the query</param>
        /// <param name="currency">Three-letter ISO 4217 currency code</param>
        /// <param name="totalAmmount">Total price in the smallest units of the currency (integer, not float/double). 
        /// For example, for a price of US$ 1.45 pass amount = 145. See the exp parameter in currencies.json, 
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</param>
        /// <param name="invoicePayload">Bot specified invoice payload</param>
        /// <param name="shippingOptionId">Optional. Identifier of the shipping option chosen by the user</param>
        /// <param name="orderInfo">Optional. Order info provided by the user</param>
        /// <returns><see cref="PreCheckoutQueryInfo"/></returns>
        internal static JObject GetObject(string id, JObject from, string currency,
            int totalAmmount, string invoicePayload, string shippingOptionId, JObject orderInfo)
        {
            dynamic preCheckoutQueryInfoObject = new JObject();

            preCheckoutQueryInfoObject.id = id;
            preCheckoutQueryInfoObject.from = from;
            preCheckoutQueryInfoObject.currency = currency;
            preCheckoutQueryInfoObject.total_amount = totalAmmount;
            preCheckoutQueryInfoObject.invoice_payload = invoicePayload;
            preCheckoutQueryInfoObject.shipping_option_id = shippingOptionId;
            preCheckoutQueryInfoObject.order_info = orderInfo;

            return preCheckoutQueryInfoObject;
        }
    }
}
