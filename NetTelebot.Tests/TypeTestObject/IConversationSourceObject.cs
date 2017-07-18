using System;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal sealed class IConversationSourceObject
    {
        /// <summary>
        /// This object represents objects with an implementation interface <see cref="IConversationSource" />.
        /// </summary>
        /// <param name="chatId">The chat identifier.</param>
        /// <param name="firstName">The first name.</param>
        [Obsolete]
        internal static JObject GetObject(int chatId, string firstName)
        {
            dynamic chat = new JObject();

            chat.id = chatId;
            chat.first_name = firstName;

            return chat;
        }
    }
}