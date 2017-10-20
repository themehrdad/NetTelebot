using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Payment
{
    /// <summary>
    /// This object represents a portion of the price for goods or services.
    /// </summary>
    public class LabeledPriceInfo
    {
        internal LabeledPriceInfo()
        {
        }

        /* 
         * Temporarily off
         * 
         * internal LabeledPriceInfo(JObject jsonObject)
        {
            Label = jsonObject["label"].Value<string>();
            Amount = jsonObject["amount"].Value<int>();
        }*/

        /// <summary>
        /// Portion label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Price of the product in the smallest units of the currency (integer, not float/double). 
        /// For example, for a price of US$ 1.45 pass amount = 145. 
        /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>, 
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// </summary>
        public int Amount { get;  set; }

        /*
         * Temporarily off
         * 
         * internal static LabeledPriceInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new LabeledPriceInfo(jobject)).ToArray();
        }*/

        /// <summary>
        /// This method creates part of the json-serialize array of the available shipping options.
        /// </summary>
        internal static JArray GetJsonArray(IEnumerable<LabeledPriceInfo> labeledPrices)
        {
            JArray jArray = new JArray
            {
                from labelPrice in labeledPrices
                select GetJsonObject(labelPrice)
            };

            return jArray;
        }

        /// <summary>
        /// This method creates part of the json-serialize array of the available shipping options.
        /// </summary>
        private static JObject GetJsonObject(LabeledPriceInfo labeledPrice)
        {
            dynamic json = new JObject();

            json.label = labeledPrice.Label;
            json.amount = labeledPrice.Amount;

            return json;
        }
    }
}
