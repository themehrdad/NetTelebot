using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class MessageEntityInfoObject
    {
        /// <summary>
        /// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc. .
        /// </summary>
        /// <param name="type">Type of the entity. Can be mention (@username), hashtag, bot_command, url, email, bold (bold text), italic (italic text),
        /// code (monowidth string), pre (monowidth block), text_link (for clickable text URLs), text_mention (for users without usernames)</param>
        /// <param name="offset">Offset in UTF-16 code units to the start of the entity</param>
        /// <param name="length">Length of the entity in UTF-16 code units</param>
        /// <param name="url">Optional. For “text_link” only, url that will be opened after user taps on the text</param>
        /// <param name="user">Optional. For “text_mention” only, the mentioned user</param>
        /// <returns><see cref="MessageEntityInfo"/></returns>
        internal static JObject GetObject(string type, int offset, int length, string url, JObject user)
        {
            dynamic messageEntity = new JObject();

            messageEntity.type = type;
            messageEntity.offset = offset;
            messageEntity.length = length;
            messageEntity.url = url;
            messageEntity.user = user;

            return messageEntity;
        }
    }
}
