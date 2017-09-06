using NetTelebot.BotEnum;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class UpdateInfoParserTest
    {
        /// <summary>
        /// Test for <see cref="UpdateInfo"/> parse field.
        /// </summary>
        [Test]
        public static void UpdateInfoTest()
        {
            //field class UpdateInfo
            const int updateId = 123;

            //field class MessageInfo
            const int messageId = 123;
            const int date = 0;
            const int chatId = 123;
            const ChatType chatType = ChatType.channel;

            JObject messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatType);

            //check message
            dynamic updateInfoObject = UpdateInfoObject.GetObject(updateId, messageInfo);
            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            //common field
            Assert.AreEqual(updateInfo.UpdateId, updateId);

            Assert.AreEqual(updateInfo.Message.MessageId, messageId);
            Assert.AreEqual(updateInfo.Message.DateUnix, date);
            Assert.AreEqual(updateInfo.Message.Chat.Id, chatId);
            Assert.AreEqual(updateInfo.Message.Chat.Type, chatType);

            //check editedMessage
            updateInfoObject = UpdateInfoObject.GetObject(updateId, editedMessage: messageInfo);
            updateInfo = new UpdateInfo(updateInfoObject);
            
            Assert.AreEqual(updateInfo.EditedMessage.MessageId, messageId);
            Assert.AreEqual(updateInfo.EditedMessage.DateUnix, date);
            Assert.AreEqual(updateInfo.EditedMessage.Chat.Id, chatId);
            Assert.AreEqual(updateInfo.EditedMessage.Chat.Type, chatType);

            //check channelPost
            updateInfoObject = UpdateInfoObject.GetObject(updateId, channelPost: messageInfo);
            updateInfo = new UpdateInfo(updateInfoObject);
            
            Assert.AreEqual(updateInfo.ChannelPost.MessageId, messageId);
            Assert.AreEqual(updateInfo.ChannelPost.DateUnix, date);
            Assert.AreEqual(updateInfo.ChannelPost.Chat.Id, chatId);
            Assert.AreEqual(updateInfo.ChannelPost.Chat.Type, chatType);

            //check channelPost
            updateInfoObject = UpdateInfoObject.GetObject(updateId, editedChannelPost: messageInfo);
            updateInfo = new UpdateInfo(updateInfoObject);

            Assert.AreEqual(updateInfo.EditedChannelPost.MessageId, messageId);
            Assert.AreEqual(updateInfo.EditedChannelPost.DateUnix, date);
            Assert.AreEqual(updateInfo.EditedChannelPost.Chat.Id, chatId);
            Assert.AreEqual(updateInfo.EditedChannelPost.Chat.Type, chatType);
        }

        [Test]
        public static void CallbackQueryUpdateInfoTest()
        {
            //field class UpdateInfo
            const int updateId = 123;

            //field class UserInfo
            const int id = 123;
            const string idСallback = "123";
            const string firstName = "TestFirstName";
            const string lastName = "TestLastName";
            const string username = " TestUserName";
            const string languageCode = "TestLanguageCode";

            //field class MessageInfo
            const int messageId = 123;
            const int date = 0;
            const int chatId = 123;
            const ChatType chatType = ChatType.channel;

            //field class CallbackQueryInfo
            const string inlineMessageId = "123";
            const string chatInstance = "123";
            const string data = "TestData";
            const string gameShortName = "TestGameShortName";

            JObject userInfo = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);
            JObject messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatType);

            dynamic callbackQueryInfo = CallbackQueryInfoObject.GetObject(idСallback, userInfo, messageInfo, inlineMessageId,
                chatInstance, data, gameShortName);

            var updateInfoObject = UpdateInfoObject.GetObject(updateId, callbackQuery: callbackQueryInfo);
            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            Assert.AreEqual(updateInfo.UpdateId, updateId);

            //UserInfo field
            Assert.AreEqual(updateInfo.CallbackQuery.From.Id, id);
            Assert.AreEqual(updateInfo.CallbackQuery.From.FirstName, firstName);
            Assert.AreEqual(updateInfo.CallbackQuery.From.LastName, lastName);
            Assert.AreEqual(updateInfo.CallbackQuery.From.UserName, username);
            Assert.AreEqual(updateInfo.CallbackQuery.From.LanguageCode, languageCode);

            //MessageInfo field
            Assert.AreEqual(updateInfo.CallbackQuery.Message.MessageId, messageId);
            Assert.AreEqual(updateInfo.CallbackQuery.Message.DateUnix, date);
            Assert.AreEqual(updateInfo.CallbackQuery.Message.Chat.Id, chatId);
            Assert.AreEqual(updateInfo.CallbackQuery.Message.Chat.Type, chatType);

            //CallbackQueryInfo field
            Assert.AreEqual(updateInfo.CallbackQuery.Id, idСallback);
            Assert.AreEqual(updateInfo.CallbackQuery.InlineMessageId, inlineMessageId);
            Assert.AreEqual(updateInfo.CallbackQuery.ChatInstance, chatInstance);
            Assert.AreEqual(updateInfo.CallbackQuery.Data, data);
            Assert.AreEqual(updateInfo.CallbackQuery.GameShortName, gameShortName);
        }
    }
}
