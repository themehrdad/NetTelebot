using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type.Keyboard;
using NUnit.Framework;

namespace NetTelebot.Tests.RequestToTelegramTest
{
    class TelegramBotInlineKeyboardTest
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

        [Test]
        public void SendInlineKeyboardToGroupTest()
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

            SendMessageResult sendMessage = mTelegramBot.SendMessage(mChatGroupId, "Please press button", replyMarkup: inlineKeyboard);

            Assert.True(sendMessage.Ok);
        }
    }
}
