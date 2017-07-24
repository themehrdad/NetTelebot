using System;
using NetTelebot.Tests.Utils;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    [TestFixture]
    internal class TelegramRealBotClientTest
    {
        private TelegramBotClient mTelegramBot;
        private int mChatId;

        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetBot();
            mChatId = new TelegramBot().GetChatId();
        }

        [Test]
        public void TestSendMessageToChat()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatId, "Test");

            Console.WriteLine(
                "\n id " + sendMessage.Result.Chat.Id + 
                "\n type " + sendMessage.Result.Chat.Type + 
                "\n title " + sendMessage.Result.Chat.Title +
                "\n username " + sendMessage.Result.Chat.Username +
                "\n firstname " + sendMessage.Result.Chat.FirstName +
                "\n lastaname " + sendMessage.Result.Chat.LastName +
                "\n All members are administrator " + sendMessage.Result.Chat.AllMembersAreAdministrators +
                "\n Photo " + sendMessage.Result.Chat.Photo +
                "\n description " + sendMessage.Result.Chat.Description +
                "\n invite link" + sendMessage.Result.Chat.InviteLink
                );

            Assert.AreEqual(sendMessage.Result.Chat.Id, mChatId);
            Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.@group);
            Assert.IsTrue(sendMessage.Result.Chat.AllMembersAreAdministrators);
        }

        /// <summary>
        /// Test the send and return location point (SendMessageResult.Result.Location.Latitude, SendMessageResult.Result.Location.Longitude)
        /// </summary>
        [Test]
        public void TestSendSendLocation()
        {
            const float latitude = 1.00000095f;
            const float longitude = 1.00000203f;

            SendMessageResult sendLocation = mTelegramBot.SendLocation(mChatId, latitude, longitude);

            Assert.AreEqual(sendLocation.Result.Location.Latitude, latitude);
            Assert.AreEqual(sendLocation.Result.Location.Longitude, longitude);
        }

        /// <summary>
        /// Gets me test for method <see cref="TelegramBotClient.GetMe"/>.
        /// </summary>
        [Test]
        public void GetMeTest()
        {
            MeInfo getMe = mTelegramBot.GetMe();
            Assert.AreEqual(getMe.FirstName, "NetTelebotTestedBot");
        }
    }
}
