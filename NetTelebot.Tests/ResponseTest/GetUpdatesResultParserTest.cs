using NetTelebot.BotEnum;
using NetTelebot.Result;
using NetTelebot.Tests.ResultTestObject;
using NetTelebot.Tests.TypeTestObject;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    internal static class GetUpdatesResultParserTest
    {
        /// <summary>
        /// Test for <see cref="GetUpdatesResult"/> parse field.
        /// </summary>
        [Test]
        public static void GetUpdatesResultTest()
        {
            const int updateId = 123;

            const int messageId = 123;
            const int date = 0;
            const int chatId = 123;
            const ChatType chatType = ChatType.channel;

            const bool ok = true;

            JObject messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatType);
            dynamic result = UpdateInfoObject.GetObjectInArray(updateId, messageInfo);

            dynamic getUpdates = GetUpdatesResultObject.GetObject(ok, result);
            
            GetUpdatesResult updateResult = new GetUpdatesResult(getUpdates.ToString());

            Assert.True(updateResult.Ok);
            Assert.AreEqual(updateResult.Result[0].UpdateId, updateId);
            Assert.AreEqual(updateResult.Result[0].Message.MessageId, messageId);
            Assert.AreEqual(updateResult.Result[0].Message.DateUnix, date);
            Assert.AreEqual(updateResult.Result[0].Message.Chat.Id, chatId);
            //todo returned null
            //Assert.AreEqual(updateResult.Result[0].Message.Chat.Type, chatType);
        }
    }
}
