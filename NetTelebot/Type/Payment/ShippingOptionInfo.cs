using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Payment
{
    /// <summary>
    /// This object represents one shipping option.
    /// </summary>
    public class ShippingOptionInfo
    {
        //todo add test
        internal ShippingOptionInfo()
        {   
        }

        internal ShippingOptionInfo(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<string>();
            Title = jsonObject["title"].Value<string>();
            LabelPrice = LabelPriceInfo.ParseArray(jsonObject["prices"].Value<JArray>());
        }
        
        /// <summary>
        /// Shipping option identifier
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Option title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// List of price portions
        /// </summary>
        public LabelPriceInfo[] LabelPrice { get; internal set; }
    }
}
