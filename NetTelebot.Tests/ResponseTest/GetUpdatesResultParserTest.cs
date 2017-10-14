using NetTelebot.Result;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class GetUpdatesResultParserTest
    {
        private const int mUpdateId = 123;

        //field class MessageInfo 
        private const int mMessageId = 123;
        private const int mDate = 0;
        private const int mChatId = 123;
        private const string mChatType = @"private";

        //field class GetUpadtesResult
        private const bool mOk = true;

        /// <summary>
        /// Test for <see cref="GetUpdatesResult"/> parse field message.
        /// </summary>
        [Test]
        public static void GetUpdatesResultMessageInfoTest()
        {
            //message
            JObject messageInfo = MessageInfoObject.GetMandatoryFieldsMessageInfo(mMessageId, mDate, mChatId, mChatType);
            dynamic result = UpdateInfoObject.GetObjectInArray(mUpdateId, messageInfo);

            dynamic getUpdates = GetUpdatesResultObject.GetObject(mOk, result);
            GetUpdatesResult updateResult = new GetUpdatesResult(getUpdates.ToString());

            AssertUpdateInfo(updateResult);
            AssertMessageInfo(updateResult.Result[0].Message);

            //editedMessage
            result = UpdateInfoObject.GetObjectInArray(mUpdateId, editedMessage: messageInfo);

            getUpdates = GetUpdatesResultObject.GetObject(mOk, result);
            updateResult = new GetUpdatesResult(getUpdates.ToString());

            AssertUpdateInfo(updateResult);
            AssertMessageInfo(updateResult.Result[0].EditedMessage);

            //channelPost
            result = UpdateInfoObject.GetObjectInArray(mUpdateId, channelPost: messageInfo);

            getUpdates = GetUpdatesResultObject.GetObject(mOk, result);
            updateResult = new GetUpdatesResult(getUpdates.ToString());

            AssertUpdateInfo(updateResult);
            AssertMessageInfo(updateResult.Result[0].ChannelPost);

            //editedChannelPost
            result = UpdateInfoObject.GetObjectInArray(mUpdateId, editedChannelPost: messageInfo);

            getUpdates = GetUpdatesResultObject.GetObject(mOk, result);
            updateResult = new GetUpdatesResult(getUpdates.ToString());

            AssertUpdateInfo(updateResult);
            AssertMessageInfo(updateResult.Result[0].EditedChannelPost);
        }

        private static void AssertUpdateInfo(GetUpdatesResult updatesResult)
        {
            Assert.True(updatesResult.Ok);
            Assert.AreEqual(mUpdateId, updatesResult.Result[0].UpdateId);
        }

        private static void AssertMessageInfo(MessageInfo updatesResult)
        {
            Assert.AreEqual(mMessageId, updatesResult.MessageId);
            Assert.AreEqual(mDate, updatesResult.DateUnix);
            Assert.AreEqual(mChatId, updatesResult.Chat.Id);
            Assert.AreEqual(mChatType, updatesResult.Chat.Type.ToString());
        }
    }
}
