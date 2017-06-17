using NetTelebot.Tests.Utils;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    [TestFixture]
    internal class TelegramBotClientTest : IWindowsCredential
    {
        /// <summary>
        /// Test the return value (SendMessageResult.Result.Text) and send a message (SendMessageResult.Ok)
        /// </summary>
        [Test]
        public void TestSendMessage()
        {
            SendMessageResult sendMessage = TelegramBot().SendMessage(GetTelegramCredential("NetTelebotTest").ChatId, "Test");
            Assert.AreEqual(sendMessage.Result.Text, "Test");
            Assert.True(sendMessage.Ok);
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
