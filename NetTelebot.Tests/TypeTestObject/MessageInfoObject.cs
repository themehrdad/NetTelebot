using NetTelebot.BotEnum;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class MessageInfoObject
    {
        /// <summary>
        /// Minimum required object fields <see cref="MessageInfo" />
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="date">The UNIX date.</param>
        /// <param name="chatId">The chat identifier.</param>
        /// <param name="type">Type of chat. <see cref="ChatType"/></param>
        /// <returns>
        /// Mandatory required object fields <see cref="MessageInfo" />
        /// </returns>
        internal static JObject GetMandatoryFieldsMessageInfo(int messageId, int date, int chatId, ChatType type)
        {
            dynamic messageInfo = new JObject();

            messageInfo.message_id = messageId;
            messageInfo.date = date;
            messageInfo.chat = ChatInfoObject.GetMinimalMandatoryObject(chatId, type);

            return messageInfo;
        }

        /// <summary>
        /// Minimum required object fields <see cref="MessageInfo" />
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="date">The UNIX date.</param>
        /// <param name="chatId">The chat identifier.</param>
        /// <param name="chatType">Type of chat.</param>
        /// <returns>
        /// Mandatory required object fields <see cref="MessageInfo" />
        /// </returns>
        internal static JObject GetMandatoryFieldsMessageInfo(int messageId, int date, int chatId, string chatType)
        {
            dynamic messageInfo = new JObject();


            messageInfo.message_id = messageId;
            messageInfo.date = date;
            messageInfo.chat = ChatInfoObject.GetObject(chatId, chatType);

            return messageInfo;
        }

    }
}