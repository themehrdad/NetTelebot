using NetTelebot.BotEnum;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NUnit.Framework;

namespace NetTelebot.Tests.RequestToTelegramTest
{
    [TestFixture]
    internal class TelegramRealBotClientTest
    {
        private TelegramBotClient mTelegramBot;
        private long mChatGroupId;
        private long mChatSuperGroupId;

        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetGroupChatBot();

            mChatGroupId = new TelegramBot().GetGroupChatId();
            mChatSuperGroupId = new TelegramBot().GetSuperGroupChatId();
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.GetMe"/>.
        /// </summary>
        [Test]
        public void GetMeTest()
        {
            MeInfo getMe = mTelegramBot.GetMe();

            ConsoleUtlis.PrintResult(getMe);

            Assert.Multiple(() =>
            {
                Assert.True(getMe.Ok);
                Assert.AreEqual(getMe.FirstName, "NetTelebotTestedBot");
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendMessage"/>. Send message to group chat id.
        /// </summary>
        [Test]
        public void SendMessageToChatTest()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatGroupId, "Test");

            ConsoleUtlis.PrintResult(sendMessage.Result.Chat);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(sendMessage.Result.Chat.Id, mChatGroupId);
                Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.@group);
                Assert.IsTrue(sendMessage.Result.Chat.AllMembersAreAdministrators);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendMessage"/>. Send message to supergroup chat id.
        /// </summary>
        [Test]
        public void SendMessageToSuperGroupTest()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatSuperGroupId, "Test");

            ConsoleUtlis.PrintResult(sendMessage.Result.Chat);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(sendMessage.Result.Chat.Id, mChatSuperGroupId);
                Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.supergroup);
                Assert.IsFalse(sendMessage.Result.Chat.AllMembersAreAdministrators);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendMessage"/>. Send message to @shannelname chat id.
        /// </summary>
        [Test]
        public void SendMessageToPublicChannelTest()
        {
            SendMessageResult sendMessage = mTelegramBot.SendMessage("@telebotTestChannel", "Test");

            ConsoleUtlis.PrintResult(sendMessage.Result.Chat);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<long>(sendMessage.Result.Chat.Id);
                Assert.AreEqual(sendMessage.Result.Chat.Type, ChatType.channel);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.SendLocation"/>.
        /// </summary>
        [Test]
        public void SendLocationTest()
        {
            const float latitude = 1.00000095f;
            const float longitude = 1.00000203f;

            SendMessageResult sendLocation = mTelegramBot.SendLocation(mChatGroupId, latitude, longitude);

            ConsoleUtlis.PrintResult(sendLocation.Result.Location);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(sendLocation.Result.Location.Latitude, latitude);
                Assert.AreEqual(sendLocation.Result.Location.Longitude, longitude);
            });
        }

        /// <summary>
        /// Test for method <see cref="TelegramBotClient.LeaveChat"/>.
        /// </summary>
        [Test, Ignore("Do not use. Leave bot from group")]
        public void LeaveChatTest()
        {
            BooleanResult leaveChat = mTelegramBot.LeaveChat(mChatGroupId);

            Assert.Multiple(() =>
            {
                Assert.True(leaveChat.Ok);
                Assert.True(leaveChat.Result);
            });
        }

        [Test]
        public void GetChatFromGroupTest()
        {
            ChatInfoResult getChatResult = mTelegramBot.GetChat(mChatGroupId);

            ConsoleUtlis.PrintResult(getChatResult.Result);

            Assert.Multiple(() =>
            {
                Assert.True(getChatResult.Ok);
                Assert.AreEqual(getChatResult.Result.Id, mChatGroupId);
                Assert.AreEqual(getChatResult.Result.Type, ChatType.@group);
                Assert.AreEqual(getChatResult.Result.AllMembersAreAdministrators, true);
            });
        }


    }
}