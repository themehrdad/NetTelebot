using System;
using NetTelebot.Tests.Utils;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    [TestFixture]
    internal class TelegramBotClientTest
    {
        private TelegramBotClient mTelegramBot;
        private int mChatId;

        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetBot();
            mChatId = new TelegramBot().GetChatId();
        }

        /// <summary>
        /// Test the send and return value (SendMessageResult.Result.Text) and send a message (SendMessageResult.Ok)
        /// </summary>
        [Test]
        public void TestSendMessage()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "Test");
            Assert.AreEqual(sendMessage.Result.Text, "Test");

            Assert.True(sendMessage.Ok);
            ParseSendMessageResult(sendMessage);
        }

        /// <summary>
        /// Test the send and return location point (SendMessageResult.Result.Location.Latitude, SendMessageResult.Result.Location.Longitude)
        /// </summary>
        [Test]
        [Ignore("Ignore because failed on app veyour")]
        public void TestSendSendLocation()
        {
            //todo check with real point
            const float latitude = 37.0000114f;
            const float longitude = 37.0000076f;
            
            SendMessageResult sendLocation = mTelegramBot.SendLocation(mChatId, latitude, longitude);

            Assert.AreEqual(sendLocation.Result.Location.Latitude, latitude);
            Assert.AreEqual(sendLocation.Result.Location.Longitude, longitude);
        }

        private static void ParseSendMessageResult(SendMessageResult result)
        {
            Console.WriteLine("Parse SendMessageResult:" + 
                "\n result.ok " + result.Ok +
                "\n result.Result.MessageId " + result.Result.MessageId +
                "\n result.Result.From " + result.Result.From +
                "\n result.Result.DateUnix " + result.Result.DateUnix +
                "\n result.Result.Date " + result.Result.Date +
                "\n result.Result.Chat " + result.Result.Chat +
                "\n result.Result.ForwardFrom " + result.Result.ForwardFrom +
                "\n result.Result.ForwardFromMessageId " + result.Result.ForwardFromMessageId +
                "\n result.Result.ForwardDate " + result.Result.ForwardDate +
                "\n result.Result.ReplyToMessage " + result.Result.ReplyToMessage+
                "\n result.Result.EditDateUnix " + result.Result.EditDateUnix +
                "\n result.Result.EditDate " + result.Result.EditDate +
                "\n result.Result.Text " + result.Result.Text +
                "\n result.Result.Audio  " + result.Result.Audio +
                "\n result.Result.Document " + result.Result.Document +
                "\n result.Result.Photo " + result.Result.Photo +
                "\n result.Result.Sticker " + result.Result.Sticker +
                "\n result.Result.Video " + result.Result.Video +
                "\n result.Result.Caption " + result.Result.Caption +
                "\n result.Result.Contact.LastName " + result.Result.Contact.LastName +
                "\n result.Result.Location " + result.Result.Location +
                "\n result.Result.NewChatMember " + result.Result.NewChatMember +
                "\n result.Result.LeftChatMember " + result.Result.LeftChatMember +
                "\n result.Result.NewChatTitle " + result.Result.NewChatTitle +
                "\n result.Result.NewChatPhoto " + result.Result.NewChatPhoto +
                "\n result.Result.DeleteChatPhoto " + result.Result.DeleteChatPhoto +
                "\n result.Result.GroupChatCreated " + result.Result.GroupChatCreated +
                "\n result.Result.SuperGroupChatCreated " + result.Result.SuperGroupChatCreated +
                "\n result.Result.ChannelChatCreated " + result.Result.ChannelChatCreated +
                "\n result.Result.MigrateToChatId " + result.Result.MigrateToChatId +
                "\n result.Result.MigrateFromChatId " + result.Result.MigrateFromChatId +
                "\n result.Result.PinnedMessage " + result.Result.PinnedMessage );
        }
    }
}
