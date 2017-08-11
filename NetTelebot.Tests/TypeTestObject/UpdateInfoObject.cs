using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class UpdateInfoObject
    {
        /// <summary>
        /// This object represents an incoming update.
        /// At most one of the optional parameters can be present in any given update.
        /// See <see href="https://core.telegram.org/bots/api#update">API</see>
        /// </summary>
        /// <param name="updateId">The update‘s unique identifier. 
        /// Update identifiers start from a certain positive number and increase sequentially. 
        /// This ID becomes especially handy if you’re using Webhooks, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order.</param>
        /// <param name="messageInfo">Optional. New incoming message of any kind — text, photo, sticker, etc.</param>
        /// <returns><see cref="UpdateInfo"/></returns>
        internal static JObject GetObject(int updateId, JObject messageInfo = null)
        {
            dynamic updateInfo = new JObject();

            updateInfo.update_id = updateId;
            updateInfo.message = messageInfo;

            return updateInfo;
        }

        /// <summary>
        /// Gets the incoming object in array.
        /// See <see href="https://core.telegram.org/bots/api#update">API</see>
        /// </summary>
        /// <param name="updateId">The update‘s unique identifier. 
        /// Update identifiers start from a certain positive number and increase sequentially. 
        /// This ID becomes especially handy if you’re using Webhooks, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order.</param>
        /// <param name="messageInfo">Optional. New incoming message of any kind — text, photo, sticker, etc.</param>
        /// <returns>One object <see cref="UpdateInfo"/> in JArray</returns>
        internal static JArray GetObjectInArray(int updateId, JObject messageInfo = null)
        {
            JObject objects = GetObject(updateId, messageInfo);
            return new JArray(objects);
        }
    }
}
