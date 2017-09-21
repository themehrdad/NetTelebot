using NetTelebot.BotEnum;
using Newtonsoft.Json.Linq;
using NetTelebot.Extension;

namespace NetTelebot.Type.Payment
{
    /// <summary>
    /// This object contains basic information about an invoice.
    /// See <see href="https://core.telegram.org/bots/api#invoice">API</see>
    /// </summary>
    public class InvoceInfo
    {
        internal InvoceInfo()
        {   
        }

        internal InvoceInfo(JObject jsonObject)
        {
            Title = jsonObject["title"].Value<string>();
            Description = jsonObject["description"].Value<string>();
            StartParameter = jsonObject["start_parameter"].Value<string>();
            Currency = jsonObject["currency"].Value<string>().ToEnum<Currency>();
            TotalAmmount = jsonObject["total_amount"].Value<int>();
        }

        /// <summary>
        /// Product name
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Unique bot deep-linking parameter that can be used to generate this invoice
        /// </summary>
        public string StartParameter { get; private set; }

        /// <summary>
        /// Three-letter ISO 4217 <see cref="BotEnum.Currency"/>
        /// </summary>
        public Currency? Currency { get; private set; }

        /// <summary>
        /// Total price in the smallest units of the currency (integer, not float/double). 
        /// For example, for a price of US$ 1.45 pass amount = 145. 
        /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>, 
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// </summary>
        public int TotalAmmount { get; private set; }
    }
}
