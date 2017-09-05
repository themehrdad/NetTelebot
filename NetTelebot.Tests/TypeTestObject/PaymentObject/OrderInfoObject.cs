using NetTelebot.Type.Payment;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.PaymentObject
{
    internal static class OrderInfoObject
    {
        /// <summary>
        /// This object represents information about an order.
        /// See <see href="https://core.telegram.org/bots/api#orderinfo">API</see>
        /// </summary>
        /// <param name="name">Optional. User name</param>
        /// <param name="phoneNumber">Optional. User's phone number</param>
        /// <param name="email">Optional. User email.</param>
        /// <param name="shippingAddress">Optional. User shipping address</param>
        /// <returns><see cref="OrderInfo"/></returns>
        internal static JObject GetObject(string name, string phoneNumber, string email,
            JObject shippingAddress)
        {
            dynamic orderInfo = new JObject();

            orderInfo.name = name;
            orderInfo.phone_number = phoneNumber;
            orderInfo.email = email;
            orderInfo.shipping_address = shippingAddress;

            return orderInfo;
        }
    }
}
