using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type.Keyboard;
using NUnit.Framework;

namespace NetTelebot.Tests.RequestToTelegramTest
{
    [TestFixture]
    internal class KeyboardTest
    {
        private TelegramBotClient mTelegramBot;
        private long? mChatGroupId;
        private long? mChatSuperGroupId;

        [SetUp]
        public void OnTestStart()
        {
            mTelegramBot = new TelegramBot().GetGroupChatBot();

            mChatGroupId = new TelegramBot().GetGroupChatId();
            mChatSuperGroupId = new TelegramBot().GetSuperGroupChatId();
        }

        [Test]
        public void SendReplyKeyboardToGroupTest()
        {
            KeyboardButton[] lines1 =
            {
                new KeyboardButton {Text = "Button1"},
                new KeyboardButton {Text = "Button2"},
                new KeyboardButton {Text = "Button3"},
                new KeyboardButton {Text = "Button4"}
            };

            KeyboardButton[] lines2 =
            {
                new KeyboardButton {Text = "Button5"},
                new KeyboardButton {Text = "Button4"}
            };

            KeyboardButton[][] keyboard =
            {
                lines1, lines2
            };

            ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
            {
                Keyboard = keyboard,
            };

            SendMessageResult sendMessageToGroup = mTelegramBot.SendMessage(mChatGroupId, "Test", replyMarkup: replyMarkup);
            SendMessageResult sendMessageToSuperGroup = mTelegramBot.SendMessage(mChatSuperGroupId, "Test", replyMarkup: replyMarkup);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessageToGroup.Ok);
                Assert.True(sendMessageToSuperGroup.Ok);
            });
        }

        [Test]
        public void SendReplyKeyboardRemoveToGroupTest()
        {
            ReplyKeyboardRemove hideMarkup = new ReplyKeyboardRemove
            {
                Selective = false
            };

            SendMessageResult sendMessageToGroup = mTelegramBot.SendMessage(mChatGroupId, "Goodbay", replyMarkup: hideMarkup);
            SendMessageResult sendMessageToSuperGroup = mTelegramBot.SendMessage(mChatSuperGroupId, "Goodbay", replyMarkup: hideMarkup);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessageToGroup.Ok);
                Assert.True(sendMessageToSuperGroup.Ok);
            });
        }

        [Test]
        public void SendForceReplyMarkupToGroupTest()
        {
            ForceReplyMarkup forceReply = new ForceReplyMarkup
            {
                Selective = false
            };

            SendMessageResult sendMessageToGroup = mTelegramBot.SendMessage(mChatGroupId, "Please type number", replyMarkup: forceReply);
            SendMessageResult sendMessageToSuperGroup = mTelegramBot.SendMessage(mChatSuperGroupId, "Please type number", replyMarkup: forceReply);
            Assert.Multiple(() =>
            {
                Assert.True(sendMessageToGroup.Ok);
                Assert.True(sendMessageToSuperGroup.Ok);
            });
        }
    }
}
