using NetTelebot.Type.InlineMode;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.InlineModeObject
{
    internal static class ChosenInlineResultInfoObject
    {
        /// <summary>
        /// Represents a result of an inline query that was chosen by the user and sent to their chat partner.
        /// See <see cref="https://core.telegram.org/bots/api#choseninlineresult">API</see> 
        /// </summary>
        /// <param name="resultId">The unique identifier for the result that was chosen</param>
        /// <param name="from">The user that chose the result</param>
        /// <param name="location">Optional. Sender location, only for bots that require user location</param>
        /// <param name="inlineMessageId">Optional. Identifier of the sent inline message. 
        /// Available only if there is an inline keyboard attached to the message. Will be also received in callback queries and can be used to edit the message.</param>
        /// <param name="query">The query that was used to obtain the result</param>
        /// <returns><see cref="ChosenInlineResultInfo"/></returns>
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
