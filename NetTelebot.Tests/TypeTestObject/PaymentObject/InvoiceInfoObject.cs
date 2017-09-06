using NetTelebot.Type.Payment;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.PaymentObject
{
    internal static class InvoiceInfoObject
    {
        /// <summary>
        /// This object contains basic information about an invoice.
        /// See <see href="https://core.telegram.org/bots/api#invoice">API</see>
        /// </summary>
        /// <param name="title">Product name</param>
        /// <param name="description">Product description</param>
        /// <param name="startParameter">Unique bot deep-linking parameter that can be used to generate this invoice</param>
        /// <param name="currency">Three-letter ISO 4217 currency code</param>
        /// <param name="totalAmount">Total price in the smallest units of the currency (integer, not float/double).
        /// For example, for a price of US$ 1.45 pass amount = 145. </param>
        /// <returns><see cref="InvoceInfo"/></returns>
        internal static JObject GetObject(string title, string description, string startParameter,
            string currency, int totalAmount)
        {
            dynamic audioInfo = new JObject();

            audioInfo.title = title;
            audioInfo.description = description;
            audioInfo.start_parameter = startParameter;
            audioInfo.currency = currency;
            audioInfo.total_amount = totalAmount;

            return audioInfo;
        }
    }
}
