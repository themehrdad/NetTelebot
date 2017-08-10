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
    }
}
