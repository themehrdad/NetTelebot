using NetTelebot.Type.InlineMode;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.InlineModeObject
{
    internal static class InlineQueryInfoObject
    {
        /// <summary>
        /// This object represents an incoming inline query. 
        /// When the user sends an empty query, your bot could return some default or trending results.
        /// See <see href="https://core.telegram.org/bots/api#inlinequery">API</see> 
        /// </summary>
        /// <param name="id">Unique identifier for this query</param>
        /// <param name="from">Sender</param>
        /// <param name="location">Optional. Sender location, only for bots that request user location</param>
        /// <param name="query">Text of the query (up to 512 characters)</param>
        /// <param name="offset">Offset of the results to be returned, can be controlled by the bot</param>
        /// <returns><see cref="InlineQueryInfo"/></returns>
        internal static JObject GetObject(string id, JObject from, JObject location,
           string query, string offset)
        {
            dynamic inlineQueryInfo = new JObject();

            inlineQueryInfo.id = id;
            inlineQueryInfo.from = from;
            inlineQueryInfo.location = location;
            inlineQueryInfo.query = query;
            inlineQueryInfo.offset = offset;

            return inlineQueryInfo;
        }
    }
}
