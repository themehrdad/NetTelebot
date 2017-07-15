using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal class MessageInfoObject
    {
        protected MessageInfoObject()
        {
        }

        /// <summary>
        /// Minimum required object fields <see cref="MessageInfo" />
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="date">The UNIX date.</param>
        /// <param name="chatId">The chat identifier.</param>
        /// <param name="chatFirstName">First name of the chat.</param>
        /// <returns>
        /// Mandatory required object fields <see cref="MessageInfo" />
        /// </returns>
        internal static JObject GetMandatoryFieldsMessageInfo(int messageId, int date, int chatId, string chatFirstName)
        {
            dynamic messageInfo = new JObject();

            messageInfo.message_id = messageId;
            messageInfo.date = date;
            messageInfo.chat = IConversationSourceObject.GetObject(chatId, chatFirstName);

            return messageInfo;
        }

    }
}