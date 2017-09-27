using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.InlineModeObject
{
    internal static class ChosenInlineResultInfoObject
    {
        internal static JObject GetObject(string resultId, JObject from, JObject location, 
            string inlineMessageId, string query)
        {
            dynamic chooseInlineResultInfo = new JObject();

            chooseInlineResultInfo.result_id = resultId;
            chooseInlineResultInfo.from = from;
            chooseInlineResultInfo.location = location;
            chooseInlineResultInfo.inline_message_id = inlineMessageId;
            chooseInlineResultInfo.query = query;
            
            return chooseInlineResultInfo;
        }
    }
}
