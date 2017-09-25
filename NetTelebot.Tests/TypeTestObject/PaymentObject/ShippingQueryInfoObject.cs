using NetTelebot.Type.Payment;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.PaymentObject
{
    internal static class ShippingQueryInfoObject
    {
        /// <summary>
        /// This object contains information about an incoming shipping query.
        /// See <see href="https://core.telegram.org/bots/api#shippingquery">API</see>
        /// </summary>
        /// <param name="id">Unique query identifier</param>
        /// <param name="from">User who sent the query</param>
        /// <param name="invoicePayload">Bot specified invoice payload</param>
        /// <param name="shippingAddress">User specified shipping address</param>
        /// <returns><see cref="ShippingQueryInfo"/></returns>
        internal static JObject GetObject(string id, JObject from, string invoicePayload,
            JObject shippingAddress)
        {
            dynamic shippingQuery = new JObject();

            shippingQuery.id = id;
            shippingQuery.from = from;
            shippingQuery.invoice_payload = invoicePayload;
            shippingQuery.shipping_address = shippingAddress;

            return shippingQuery;
        }
    }
}
