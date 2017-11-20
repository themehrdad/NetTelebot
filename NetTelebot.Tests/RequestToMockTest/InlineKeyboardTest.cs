using System.Linq;
using Mock4Net.Core;
using NetTelebot.CommonUtils;
using NetTelebot.Tests.MockServers;
using NetTelebot.Type.Keyboard;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.RequestToMockTest
{
    [TestFixture]
    internal class InlineKeyboardTest
    {
        private const int mServerPort = 8081;

        private readonly TelegramBotClient mBotOkResponse = new TelegramBotClient
        {
            Token = "Token",
            RestClient = new RestClient("http://localhost:" + mServerPort)
        };

        [OneTimeSetUp]
        public static void OnStart()
        {
            MockServer.Start(mServerPort);
        }

        [OneTimeTearDown]
        public static void OnStop()
        {
            MockServer.Stop();
        }

        [Test]
        public void SendMessageWithInlineKeyboardTest()
        {
            InlineKeyboardButton line1 = new InlineKeyboardButton
            {
                Text = "Button1",
                Url = "TestUrl",
                CallbackData = "TestCallbckData",
                SwitchInlineQuery = "TestSwitchInlineQuery",
                SwitchInlineQueryCurrentChat = "TestSwitchInlineQueryCurrentChat",
                CallbackGame = "TestCallbckGame",
                Pay = true
            };

            InlineKeyboardButton line2 = new InlineKeyboardButton
            {
                Text = "Button2",
                CallbackData = "TestCallbackData"
            };

            InlineKeyboardButton line3 = new InlineKeyboardButton
            {
                Text = "Button3"
            };

            InlineKeyboardButton line4 = new InlineKeyboardButton
            {
                Text = "Button4"
            };

            InlineKeyboardButton[] lines1 = { line1, line2, line3, line4 };
            InlineKeyboardButton[] lines2 = { line3, line4 };
            InlineKeyboardButton[][] keyboard =
            {
                lines1, lines2
            };

            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup
            {
                Keyboard = keyboard
            };

            mBotOkResponse.SendMessage(123, "Test", replyMarkup: inlineKeyboardMarkup);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendMessage").UsingPost());

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "text=Test&" +
                "reply_markup=%7B%0D%0A%20%20%22inline_keyboard" +
                "%22%3A%20%5B%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text" +
                "%22%3A%20%22Button1%22%2C%0D%0A%20%20%20%20%20%20%20%20%22url%22%3A%20%22TestUrl" +
                "%22%2C%0D%0A%20%20%20%20%20%20%20%20%22callback_data%22%3A%20%22TestCallbckData" +
                "%22%2C%0D%0A%20%20%20%20%20%20%20%20%22switch_inline_query%22%3A%20%22TestSwitchInlineQuery" +
                "%22%2C%0D%0A%20%20%20%20%20%20%20%20%22switch_inline_query_current_chat%22%3A%20%22TestSwitchInlineQueryCurrentChat" +
                "%22%2C%0D%0A%20%20%20%20%20%20%20%20%22callback_game%22%3A%20%22TestCallbckGame" +
                "%22%2C%0D%0A%20%20%20%20%20%20%20%20%22pay%22%3A%20true" +
                "%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%22Button2" +
                "%22%2C%0D%0A%20%20%20%20%20%20%20%20%22callback_data%22%3A%20%22TestCallbackData" +
                "%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%22Button3" +
                "%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%22Button4" +
                "%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%2C%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%" +
                "20%20%20%20%20%20%20%22text%22%3A%20%22Button3%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22" +
                "text%22%3A%20%22Button4%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%0D%0A%20%20%5D%0D%0A%7D");

            ConsoleUtlis.PrintResult(request);

            MockServer.ServerOkResponse.ResetRequestLogs();
        }
    }
}
