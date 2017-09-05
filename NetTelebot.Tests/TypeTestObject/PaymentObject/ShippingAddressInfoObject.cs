using NetTelebot.Type.Payment;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.PaymentObject
{
    internal static class ShippingAddressInfoObject
    {
        /// <summary>
        /// This object represents a shipping address.
        /// See <see href="https://core.telegram.org/bots/api#shippingaddress">API</see>
        /// </summary>
        /// <param name="countryCode"> ISO 3166-1 alpha-2 country code</param>
        /// <param name="state">State, if applicable.</param>
        /// <param name="city">City</param>
        /// <param name="streetLineOne">First line for the address</param>
        /// <param name="streetLineTwo">Second line for the address</param>
        /// <param name="postCode">Address post code</param>
        /// <returns><see cref="ShippingAddressInfo"/></returns>
        internal static JObject GetObject(string countryCode, string state, string city,
            string streetLineOne, string streetLineTwo, string postCode)
        {
            dynamic shippingAddressInfo = new JObject();

            shippingAddressInfo.country_code = countryCode;
            shippingAddressInfo.state = state;
            shippingAddressInfo.city = city;
            shippingAddressInfo.street_line1 = streetLineOne;
            shippingAddressInfo.street_line2 = streetLineTwo;
            shippingAddressInfo.post_code = postCode;

            return shippingAddressInfo;
        }
    }
}
