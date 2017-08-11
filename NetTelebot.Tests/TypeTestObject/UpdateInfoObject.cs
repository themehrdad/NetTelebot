using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class UpdateInfoObject
    {
        internal static JObject GetObject(int updateId, JObject messageInfo = null)
        {
            dynamic updateInfo = new JObject();

            updateInfo.update_id = updateId;
            updateInfo.message = messageInfo;

            return updateInfo;
        }

        internal static JArray GetObjectInArray(int updateId, JObject messageInfo = null)
        {
            JObject objects = GetObject(updateId, messageInfo);
            return new JArray(objects);
        }
    }
}
