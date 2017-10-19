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
            const bool isBot = true;
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
            
            JObject userInfo = UserInfoObject.GetObject(id, isBot, firstName, lastName, username, languageCode);
            JObject messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatType);

            dynamic callbackQueryInfo = CallbackQueryInfoObject.GetObject(idСallback, userInfo, messageInfo, inlineMessageId,
                chatInstance, data, gameShortName);

            CallbackQueryInfo callbackQuery = new CallbackQueryInfo(callbackQueryInfo);

            Assert.Multiple(() =>
            {
                //UserInfo field
                Assert.AreEqual(id, callbackQuery.From.Id);
                Assert.AreEqual(isBot, callbackQuery.From.IsBot);
                Assert.AreEqual(firstName, callbackQuery.From.FirstName);
                Assert.AreEqual(lastName, callbackQuery.From.LastName);
                Assert.AreEqual(username, callbackQuery.From.UserName);
                Assert.AreEqual(languageCode, callbackQuery.From.LanguageCode);

                //MessageInfo field
                Assert.AreEqual(messageId, callbackQuery.Message.MessageId);
                Assert.AreEqual(date, callbackQuery.Message.DateUnix);
                Assert.AreEqual(chatId, callbackQuery.Message.Chat.Id);
                Assert.AreEqual(chatType, callbackQuery.Message.Chat.Type);

                //CallbackQueryInfo field
                Assert.AreEqual(idСallback, callbackQuery.Id);
                Assert.AreEqual(inlineMessageId, callbackQuery.InlineMessageId);
                Assert.AreEqual(chatInstance, callbackQuery.ChatInstance);
                Assert.AreEqual(data, callbackQuery.Data);
                Assert.AreEqual(gameShortName, callbackQuery.GameShortName);
            });
        }
    }
}
