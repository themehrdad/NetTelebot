using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Result
{
    /// <summary>
    /// When calling method returned <see cref="bool"/> in result field on TelegramBotClient class, this object will be returned.
    /// </summary>
    public class BooleanResult
    {
        internal BooleanResult(string jsonText)
        {
            Parse(jsonText);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Result = jsonObject["result"].Value<bool>();
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        /// <summary>
        /// Result request
        /// </summary>
        /// <value>
        ///   <c>true</c> if ok; otherwise, <c>false</c>.
        /// </value>
        public bool Ok { get; private set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        ///  <c>true</c> if ok; otherwise, <c>false</c>.
        /// </value>
        public bool Result { get; private set; }
    }
}
