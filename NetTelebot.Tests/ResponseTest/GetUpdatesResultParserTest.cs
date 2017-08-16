using NetTelebot.Result;
using NetTelebot.Tests.ResultTestObject;
using NetTelebot.Tests.TypeTestObject;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class GetUpdatesResultParserTest
    {
        /// <summary>
        /// Test for <see cref="GetUpdatesResult"/> parse field.
        /// </summary>
        [Test]
        public static void GetUpdatesResultTest()
        {
            //field class UpdateInfo
            const int updateId = 123;

            //field class MessageInfo 
            const int messageId = 123;
            const int date = 0;
            const int chatId = 123;
            const string chatType = @"private";

            //field class GetUpadtesResult
            const bool ok = true;

            var messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(messageId, date, chatId, chatType);
            dynamic result = UpdateInfoObject.GetObjectInArray(updateId, messageInfo: messageInfo  );

            dynamic getUpdates = GetUpdatesResultObject.GetObject(ok, result);
            GetUpdatesResult updateResult = new GetUpdatesResult(getUpdates.ToString());

            Assert.True(updateResult.Ok);
            Assert.AreEqual(updateResult.Result[0].UpdateId, updateId);
            Assert.AreEqual(updateResult.Result[0].Message.MessageId, messageId);
            Assert.AreEqual(updateResult.Result[0].Message.DateUnix, date);
            Assert.AreEqual(updateResult.Result[0].Message.Chat.Id, chatId);
            Assert.AreEqual(updateResult.Result[0].Message.Chat.Type.ToString(), chatType);
        }
    }
}
