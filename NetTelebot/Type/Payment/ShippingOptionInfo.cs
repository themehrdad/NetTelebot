using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Payment
{
    /// <summary>
    /// This object represents one shipping option.
    /// </summary>
    public class ShippingOptionInfo
    {
        internal ShippingOptionInfo() 
        {   
        }

        /*
         * Temporarily off
         * 
         * internal ShippingOptionInfo(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<string>();
            Title = jsonObject["title"].Value<string>();
            LabelPrice = LabeledPriceInfo.ParseArray(jsonObject["prices"].Value<JArray>());
        }*/

        /// <summary>
        /// Shipping option identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Option title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// List of price portions
        /// </summary>
        public LabeledPriceInfo[] LabelPrice { get; set; }

        /// <summary>
        /// This method create JSON-serialized array of available shipping options. Used for resonse in AnswerShippingQuery method.
        /// </summary>
        /// <param name="shippingOption"><see cref="ShippingOptionInfo"/> array</param>
        /// <returns><see cref="ShippingOptionInfo"/> JSON-serialized array</returns>
        internal static JObject GetJson(ShippingOptionInfo[] shippingOption)
        {
            dynamic json = new JObject();
            json.prices = GetJsonArray(shippingOption);

            return json;
        }

        /// <summary>
        /// This method creates part of the json-serialize array of the available shipping options.
        /// </summary>
        private static JArray GetJsonArray(IEnumerable<ShippingOptionInfo> shippingOptions)
        {
            JArray jArray = new JArray
            {
                from shipingOption in shippingOptions
                select GetJsonObject(shipingOption)
            };

            return jArray;
        }

        /// <summary>
        /// This method creates part of the json-serialize array of the available shipping options.
        /// </summary>
        private static JObject GetJsonObject(ShippingOptionInfo shippingOption)
        {
            dynamic json = new JObject();

            json.id = shippingOption.Id;
            json.title = shippingOption.Title;
            json.prices = LabeledPriceInfo.GetJsonArray(shippingOption.LabelPrice);

            return json;
        }
    }
}
