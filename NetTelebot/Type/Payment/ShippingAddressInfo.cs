using NetTelebot.BotEnum;
using NetTelebot.Extension;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Payment
{
    //todo added tests
    /// <summary>
    /// This object represents a shipping address.
    /// See <see href="https://core.telegram.org/bots/api#shippingaddress"></see>
    /// </summary>
    public class ShippingAddressInfo
    {
        internal ShippingAddressInfo()
        {
        }

        internal ShippingAddressInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            CountryCode = jsonObject["country_code"].Value<string>().ToEnum<Countries>();
            State = jsonObject["state"].Value<string>();
            City = jsonObject["city"].Value<string>();
            StreetLineOne = jsonObject["street_line1"].Value<string>();
            StreetLineTwo = jsonObject["street_line2"].Value<string>();
            PostCode = jsonObject["post_code"].Value<string>();
        }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        public Countries? CountryCode { get; private set; }

        /// <summary>
        /// State, if applicable
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// First line for the address
        /// </summary>
        public string StreetLineOne { get; private set; }

        /// <summary>
        /// Second line for the address
        /// </summary>
        public string StreetLineTwo { get; private set; }

        /// <summary>
        /// Address post code
        /// </summary>
        public string PostCode { get; private set; }        
    }
}
