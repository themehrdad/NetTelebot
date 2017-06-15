using NetTelebot.Tests.Utils;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    [TestFixture]
    internal class TelegramBotClientTest : IWindowsCredential
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestSendMessage()
        {
            bool sendMessage = TelegramBot().SendMessage(GetTelegramCredential("NetTelebotTest").ChatId, "Test").Ok;
            Assert.True(sendMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private TelegramBotClient TelegramBot()
        {
            TelegramBotClient telegramBotClient = new TelegramBotClient()
            {
                Token = GetTelegramCredential("NetTelebotTest").Token
            };

            return telegramBotClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="botAlias"></param>
        /// <returns></returns>
        public TelegramCredentials GetTelegramCredential(string botAlias)
        {
            return new WindowsCredential().GetTelegramCredential(botAlias);
        }
    }
}
