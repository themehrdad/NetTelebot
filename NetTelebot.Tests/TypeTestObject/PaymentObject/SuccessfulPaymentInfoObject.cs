using NetTelebot.Type.Payment;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.PaymentObject
{
    internal static class SuccessfulPaymentInfoObject
    {
        /// <summary>
        /// This object contains basic information about a successful payment.
        /// See <see href="https://core.telegram.org/bots/api#successfulpayment">API</see>
        /// </summary>
        /// <param name="currency">Three-letter ISO 4217 currency code</param>
        /// <param name="totalAmount">Total price in the smallest units of the currency (integer, not float/double).
        /// For example, for a price of US$ 1.45 pass amount = 145</param>
        /// <param name="invoicePayload">Bot specified invoice payload</param>
        /// <param name="shippingOptionId">Optional. Identifier of the shipping option chosen by the user</param>
        /// <param name="orderInfo">Optional. Order info provided by the user</param>
        /// <param name="telegramPaymentChargeId">Telegram payment identifier</param>
        /// <param name="providerPaymentChargeId">Provider payment identifier</param>
        /// <returns><see cref="SuccessfulPaymentInfo"/></returns>
        internal static JObject GetObject(string currency, int totalAmount, string invoicePayload,
            string shippingOptionId, JObject orderInfo, string telegramPaymentChargeId, 
            string providerPaymentChargeId)
        {
            dynamic successfulPayment = new JObject();

            successfulPayment.currency = currency;
            successfulPayment.total_amount = totalAmount;
            successfulPayment.invoice_payload = invoicePayload;
            successfulPayment.shipping_option_id = shippingOptionId;
            successfulPayment.order_info = orderInfo;
            successfulPayment.telegram_payment_charge_id = telegramPaymentChargeId;
            successfulPayment.provider_payment_charge_id = providerPaymentChargeId;

            return successfulPayment;
        }
    }
}
