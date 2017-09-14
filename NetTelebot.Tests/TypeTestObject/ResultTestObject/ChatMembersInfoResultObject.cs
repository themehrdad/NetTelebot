using NetTelebot.Result;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal static class ChatMembersInfoResultObject
    {
        /// <summary>
        /// Object represent this type <see cref="ChatMembersInfoResult"/>
        /// </summary>
        internal static JObject GetObject(bool ok, JArray result)
        {
            dynamic chatMemberInfo = new JObject();

            chatMemberInfo.ok = ok;
            chatMemberInfo.result = result;

            return chatMemberInfo;
        }
    }
}
