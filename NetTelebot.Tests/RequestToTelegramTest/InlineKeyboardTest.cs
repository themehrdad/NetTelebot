using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type.Keyboard;
using NUnit.Framework;

namespace NetTelebot.Tests.RequestToTelegramTest
{
    [TestFixture]
    internal class InlineKeyboardTest
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
        public void SendInlineKeyboardWithUrlToGroupTest()
        {

            InlineKeyboardButton[] lines1 =
            {
                new InlineKeyboardButton {Text = "AboutInline", Url = "https://core.telegram.org/bots/api#inlinekeyboardmarkup"},
                new InlineKeyboardButton {Text = "GoToRepo", Url = "https://github.com/themehrdad/NetTelebot"},
            };

            InlineKeyboardButton[] lines2 =
            {
                new InlineKeyboardButton {Text = "GoToGoogle", Url = "https://www.google.com", },
                new InlineKeyboardButton {Text = "GoToYouTube", Url = "https://www.youtube.com"}
            };

            InlineKeyboardButton[][] keyboard =
            {
                lines1, lines2
            };

            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup
            {
                Keyboard = keyboard,
            };

            SendMessageResult sendMessageToGroup = mTelegramBot.SendMessage(mChatGroupId, "Please press button", replyMarkup: inlineKeyboard);
            SendMessageResult sendMessageToSuperGroup = mTelegramBot.SendMessage(mChatSuperGroupId, "Please press button", replyMarkup: inlineKeyboard);

            Assert.Multiple(() =>
            {
                Assert.True(sendMessageToGroup.Ok);
                Assert.True(sendMessageToSuperGroup.Ok);
            });
        }
    }
}
