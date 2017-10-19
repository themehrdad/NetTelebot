using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Payment
{
    //todo add test
    /// <summary>
    /// This object represents a portion of the price for goods or services.
    /// </summary>
    public class LabelPriceInfo
    {
        internal LabelPriceInfo()
        {
        }

        internal LabelPriceInfo(JObject jsonObject)
        {
            Label = jsonObject["label"].Value<string>();
            Amount = jsonObject["amount"].Value<int>();
        }

        /// <summary>
        /// Portion label
        /// </summary>
        public string Label { get; private set; }

        /// <summary>
        /// Price of the product in the smallest units of the currency (integer, not float/double). 
        /// For example, for a price of US$ 1.45 pass amount = 145. 
        /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>, 
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// </summary>
        public int Amount { get; private set; }

        internal static LabelPriceInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new LabelPriceInfo(jobject)).ToArray();
        }
    }
}
