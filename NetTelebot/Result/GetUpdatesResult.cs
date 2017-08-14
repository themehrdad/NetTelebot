using NetTelebot.Type;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Result
{
    /// <summary>
    /// When calling GetUpdates method on TelegramBotClient, this object will be returned.
    /// </summary>
    public class GetUpdatesResult
    {
        internal GetUpdatesResult(string jsonText)
        {
            Parse(jsonText);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Result = UpdateInfo.ParseArray(jsonObject["result"].Value<JArray>());
        }

        private void Parse(string jsonText)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="GetUpdatesResult"/> is ok.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ok; otherwise, <c>false</c>.
        /// </value>
        public bool Ok { get; private set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result is instance of the <see cref="UpdateInfo"/> class
        /// </value>
        public UpdateInfo[] Result { get; private set; }
    }
}
