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
        [Test]
        internal static void UpdateInfoTest()
        {
            const int updateId = 123;

            const int messageId = 123;
            const int date = 0;
            const int chatId = 123;
            const ChatType chatType = ChatType.channel;

            JObject messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatType);

            dynamic updateInfoObject = UpdateInfoObject.GetObject(updateId, messageInfo);

            UpdateInfo updateInfo = new UpdateInfo(updateInfoObject);

            Assert.AreEqual(updateInfo.UpdateId, updateId);

            Assert.AreEqual(updateInfo.Message.MessageId, messageId);
            Assert.AreEqual(updateInfo.Message.DateUnix, date);
            Assert.AreEqual(updateInfo.Message.Chat.Id, chatId);
            Assert.AreEqual(updateInfo.Message.Chat.Type, chatType);
        }
    }
}
