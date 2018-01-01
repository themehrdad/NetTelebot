using NetTelebot.Type.Sticker;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Result
{
    /// <summary>
    /// When calling method returned <see cref="StickerSetInfo"/> in result field on TelegramBotClient class, this object will be returned.
    /// </summary>
    public class StickerSetInfoResult
    {
        internal StickerSetInfoResult(string jsonText)
        {
            JObject jsonObject = (JObject) JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Result = new StickerSetInfo(jsonObject["result"].Value<JObject>());
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
        /// <returns><see cref="StickerSetInfo"/></returns>
        public StickerSetInfo Result { get; private set; } 


    }
}
