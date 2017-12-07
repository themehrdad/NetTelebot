using NetTelebot.Tests.TypeTestObject.StickerObject;
using Newtonsoft.Json;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal class StickerSetInfoResultObject
    {
        [JsonProperty("ok")]
        internal bool Ok { get; set; }

        [JsonProperty("result")]
        internal StickerSetInfoObject Result { get; set; }
    }
}
