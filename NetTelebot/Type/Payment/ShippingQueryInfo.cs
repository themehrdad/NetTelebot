using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Payment
{
    /// <summary>
    /// This object contains information about an incoming shipping query.
    /// See <see href="https://core.telegram.org/bots/api#shippingquery">API</see>
    /// </summary>
    public class ShippingQueryInfo
    {
        internal ShippingQueryInfo()
        {
        }

        internal ShippingQueryInfo(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<string>();
            From = new UserInfo(jsonObject["from"].Value<JObject>());
            InvoicePayload = jsonObject["invoice_payload"].Value<string>();
            ShippingAddress = new ShippingAddressInfo(jsonObject["shipping_address"].Value<JObject>());
        }

        /// <summary>
        /// Unique query identifier
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// User who sent the query
        /// </summary>
        public UserInfo From { get; internal set; }

        /// <summary>
        /// Bot specified invoice payload
        /// </summary>
        public string InvoicePayload { get; private set; }

        /// <summary>
        /// User specified shipping address
        /// </summary>
        public ShippingAddressInfo ShippingAddress { get; internal set; }
    }
}
