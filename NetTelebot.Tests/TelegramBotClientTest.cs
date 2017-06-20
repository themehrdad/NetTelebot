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
        /// Test the send and return value (SendMessageResult.Result.Text) and send a message (SendMessageResult.Ok)
        /// </summary>
        [Test]
        public void TestSendMessage()
        {
            SendMessageResult sendMessage = TelegramBot().SendMessage(mChatId, "Test");
            Assert.AreEqual(sendMessage.Result.Text, "Test");

            Assert.True(sendMessage.Ok);
        }


        /// <summary>
        /// Test the send and return location point (SendMessageResult.Result.Location.Latitude, SendMessageResult.Result.Location.Longitude)
        /// </summary>
        [Test]
        public void TestSendSendLocation()
        {
            //todo check with real point
            const float latitude = 37.0000114f;
            const float longitude = 37.0000076f;
            
            SendMessageResult sendLocation = TelegramBot().SendLocation(mChatId, latitude, longitude);

            Assert.AreEqual(sendLocation.Result.Location.Latitude, latitude);
            Assert.AreEqual(sendLocation.Result.Location.Longitude, longitude);
        }


        /// <summary>
        /// Create bot insatnce
        /// </summary>
        /// <returns>TelegramBotClient</returns>
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
