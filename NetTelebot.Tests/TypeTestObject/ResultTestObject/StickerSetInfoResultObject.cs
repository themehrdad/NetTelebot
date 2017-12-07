using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal static class StickerSetInfoResultObject
    {
        internal static JObject GetObject(bool ok, JObject result)
        {
            dynamic stickerSetInfoResult = new JObject();

            stickerSetInfoResult.ok = ok;
            stickerSetInfoResult.result = result;

            return stickerSetInfoResult;
        }
    }
}
