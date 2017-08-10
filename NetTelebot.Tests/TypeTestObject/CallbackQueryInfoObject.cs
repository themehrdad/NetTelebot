using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class CallbackQueryInfoObject
    {
        internal static JObject GetObject(string id, JObject userInfo, JObject messageInfo,
            string inlineMessageId, string chatInstance, string data, string gameShortName)
        {
            dynamic callbackQuery = new JObject();

            callbackQuery.id = id;
            callbackQuery.from = userInfo;
            callbackQuery.message = messageInfo;
            callbackQuery.inline_message_id = inlineMessageId;
            callbackQuery.chat_instance = chatInstance;
            callbackQuery.data = data;
            callbackQuery.game_short_name = gameShortName;

            return callbackQuery;
        }
    }
}
