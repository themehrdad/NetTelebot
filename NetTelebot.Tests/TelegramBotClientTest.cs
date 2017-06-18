using System;
using NetTelebot.Tests.Utils;
using NUnit.Framework;

namespace NetTelebot.Tests
{
    [TestFixture]
    internal class TelegramBotClientTest : IWindowsCredential
    {
        private const string mBotName = "NetTelebotTest";
        private string mToken;
        private int mChatId;

        [SetUp]
        public void OnTestStart()
        {
            mToken = GetTelegramCredential(mBotName).Token;
            mChatId = GetTelegramCredential(mBotName).ChatId;
        }

        /// <summary>
        /// Test the return value (SendMessageResult.Result.Text) and send a message (SendMessageResult.Ok)
        /// </summary>
        [Test]
        public void TestSendMessage()
        {
            SendMessageResult sendMessage = TelegramBot().SendMessage(mChatId, "Test");
            Assert.AreEqual(sendMessage.Result.Text, "Test");

            Console.WriteLine("Result " + sendMessage.Result);
            Assert.True(sendMessage.Ok);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private TelegramBotClient TelegramBot()
        {
            TelegramBotClient telegramBotClient = new TelegramBotClient
            {
                Token = mToken
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
