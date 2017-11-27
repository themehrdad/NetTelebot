using NetTelebot.CommonUtils;
using NUnit.Framework;

namespace NetTelebot.Tests.CommonProjectTest
{
    [TestFixture]
    internal static class TelegramBotTest
    {
        private static readonly TelegramBot telegramBot = new TelegramBot();

        [Test]
        public static void InsanceTelegramBotClientCreateTest()
        {
            Assert.IsInstanceOf<TelegramBotClient>(telegramBot.GetBot());
            Assert.IsInstanceOf<TelegramBotClient>(telegramBot.GetGroupChatBot());
            Assert.IsInstanceOf<TelegramBotClient>(telegramBot.GetSuperGroupChatBot());
        }

        [Test]
        public static void InsanceLongGetChatIdTest()
        {
            Assert.IsInstanceOf<long>(telegramBot.GetGroupChatId());
            Assert.IsInstanceOf<long>(telegramBot.GetSuperGroupChatId());
        }
    }
}
