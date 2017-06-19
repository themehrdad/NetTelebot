using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace NetTelebot
{
    /// <summary>
    /// Represents an incoming message to your bot.
    /// </summary>
    public class UpdateInfo
    {
        internal UpdateInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal UpdateInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            UpdateId = jsonObject["update_id"].Value<int>();
            if (jsonObject["message"] != null)
                Message = new MessageInfo(jsonObject["message"].Value<JObject>());
            if (jsonObject["inline_query"] != null)
                InlineQuery = new InlineQuery(jsonObject["inline_query"].Value<JObject>());
            if (jsonObject["chosen_inline_result"] != null)
                ChosenInlineResult = new ChosenInlineResult(jsonObject["chosen_inline_result"].Value<JObject>());
            if (jsonObject["callback_query"] != null)
                CallbackQuery = new CallbackQuery(jsonObject["callback_query"].Value<JObject>());
        }

        /// <summary>
        /// The update‘s unique identifier.
        /// </summary>
        public int UpdateId { get; private set; }
        
        /// <summary>
        /// New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        public MessageInfo Message { get; private set; }
        public InlineQuery InlineQuery { get; private set; }
        public ChosenInlineResult ChosenInlineResult { get; private set; }
        public CallbackQuery CallbackQuery { get; private set; }

        public static UpdateInfo[] ParseArray(string jsonText)
        {
            JArray jsonArray = (JArray)JsonConvert.DeserializeObject(jsonText);
            return ParseArray(jsonArray);
        }

        public static UpdateInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new UpdateInfo(jobject)).ToArray();
        }
    }
}
