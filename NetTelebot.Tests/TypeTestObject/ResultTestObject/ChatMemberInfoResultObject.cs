using NetTelebot.Result;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal static class ChatMemberInfoResultObject
    {
        /// <summary>
        /// Object represent this type <see cref="ChatMemberInfoResult"/>
        /// </summary>
        internal static JObject GetObject(bool ok, JObject result)
        {
            dynamic chatMemberInfo = new JObject();

            chatMemberInfo.ok = ok;
            chatMemberInfo.result = result;

            return chatMemberInfo;
        }
    }
}
