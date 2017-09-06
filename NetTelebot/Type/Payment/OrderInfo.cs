using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Payment
{
    /// <summary>
    /// This object represents information about an order.
    /// See <see href="https://core.telegram.org/bots/api#orderinfo">API</see>
    /// </summary>
    public class OrderInfo
    {
        internal OrderInfo()
        {
        }

        internal OrderInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            if (jsonObject["name"] != null)
                Name = jsonObject["name"].Value<string>();
            if (jsonObject["phone_number"] != null)
                PnoneNumber = jsonObject["phone_number"].Value<string>();
            if (jsonObject["email"] != null)
                Email = jsonObject["email"].Value<string>();
            if (jsonObject["shipping_address"] != null)
                ShippingAddress = new ShippingAddressInfo(jsonObject["shipping_address"].Value<JObject>());
        }

        /// <summary>
        /// Optional. User name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Optional. User's phone number
        /// </summary>
        public string PnoneNumber { get; private set; }

        /// <summary>
        /// Optional. User email
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Optional. User shipping address
        /// </summary>
        public ShippingAddressInfo ShippingAddress { get; internal set; }
    }
}
