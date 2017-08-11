using NetTelebot.BotEnum;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class CallbackQueryParserTest
    {
        /// <summary>
        /// Test for <see cref="CallbackQueryInfo"/> parse field.
        /// </summary>
        [Test]
        public static void CallbackQueryTest()
        {
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

            CallbackQueryInfo callbackQuery = new CallbackQueryInfo(callbackQueryInfo);

            //UserInfo field
            Assert.AreEqual(callbackQuery.From.Id, id);
            Assert.AreEqual(callbackQuery.From.FirstName, firstName);
            Assert.AreEqual(callbackQuery.From.LastName, lastName);
            Assert.AreEqual(callbackQuery.From.UserName, username);
            Assert.AreEqual(callbackQuery.From.LanguageCode, languageCode);

            //MessageInfo field
            Assert.AreEqual(callbackQuery.Message.MessageId, messageId);
            Assert.AreEqual(callbackQuery.Message.DateUnix, date);
            Assert.AreEqual(callbackQuery.Message.Chat.Id, chatId);
            Assert.AreEqual(callbackQuery.Message.Chat.Type, chatType);

            //CallbackQueryInfo field
            Assert.AreEqual(callbackQuery.Id, idСallback);
            Assert.AreEqual(callbackQuery.InlineMessageId, inlineMessageId);
            Assert.AreEqual(callbackQuery.ChatInstance, chatInstance);
            Assert.AreEqual(callbackQuery.Data, data);
            Assert.AreEqual(callbackQuery.GameShortName, gameShortName);
        }
    }
}
