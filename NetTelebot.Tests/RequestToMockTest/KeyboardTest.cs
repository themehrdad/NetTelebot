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
    internal class KeyboardTest
    {
        private const int mServerPort = 8090;

        private readonly TelegramBotClient mBotOkResponse = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:" + mServerPort) };

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
        public void SendMessageWithReplyKeyboardMarkupTest()
        {
            KeyboardButton line1 = new KeyboardButton { Text = "Button1", RequestContact = true, RequestLocation = false };
            KeyboardButton line2 = new KeyboardButton { Text = "Button2", RequestContact = false, RequestLocation = true };
            KeyboardButton line3 = new KeyboardButton { Text = "Button3" };
            KeyboardButton line4 = new KeyboardButton { Text = "Button4" };

            KeyboardButton[] lines1 = { line1, line2, line3, line4 };
            KeyboardButton[] lines2 = { line3, line4 };
            KeyboardButton[][] keyboard =
            {
                lines1, lines2
            };

            ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup
            {
                Keyboard = keyboard,
                ResizeKeyboard = true,
                Selective = false,
                OneTimeKeyboard = true
            };

            mBotOkResponse.SendMessage(123, "Test", replyMarkup: replyMarkup);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendMessage").UsingPost());

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "text=Test&" +
                "reply_markup=%7B%0D%0A%20%20%22keyboard%22%3A%20%5B%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%22Button1" +
                "%22%2C%0D%0A%20%20%20%20%20%20%20%20%22request_contact%22%3A%20true%2C%0D%0A%20%20%20%20%20%20%20%20%22request_location%22%3A%20false" +
                "%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%22Button2%22%2C%0D%0A%20%20%20%20%20%20%20%20%22request_contact" +
                "%22%3A%20false%2C%0D%0A%20%20%20%20%20%20%20%20%22request_location%22%3A%20true%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text" +
                "%22%3A%20%22Button3%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%22Button4" +
                "%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%2C%0D%0A%20%20%20%20%5B%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%22Button3" +
                "%22%0D%0A%20%20%20%20%20%20%7D%2C%0D%0A%20%20%20%20%20%20%7B%0D%0A%20%20%20%20%20%20%20%20%22text%22%3A%20%22Button4" +
                "%22%0D%0A%20%20%20%20%20%20%7D%0D%0A%20%20%20%20%5D%0D%0A%20%20%5D%2C%0D%0A%20%20%22resize_keyboard%22%3A%20true%2C%0D%0A%20%20%22" +
                "one_time_keyboard%22%3A%20true%2C%0D%0A%20%20%22selective%22%3A%20false%0D%0A%7D");

            ConsoleUtlis.PrintResult(request);

            MockServer.ServerOkResponse.ResetRequestLogs();
        }

        [Test]
        public void SendMessageWithForceReplyTest()
        {
            mBotOkResponse.SendMessage(123, "Test", replyMarkup: new ForceReplyMarkup {Selective = true});

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendMessage").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "text=Test&reply_markup=%" +
                "7B%0D%0A%20%20%22force_reply%22%3A%20true%2C%0D%0A%20%20%22selective%22%3A%20true%0D%0A%7D");
            

            MockServer.ServerOkResponse.ResetRequestLogs();

            mBotOkResponse.SendMessage(123, "Test", replyMarkup: new ForceReplyMarkup { Selective = false });

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "text=Test&reply_markup=%" +
                "7B%0D%0A%20%20%22force_reply%22%3A%20true%2C%0D%0A%20%20%22selective%22%3A%20false%0D%0A%7D");

            ConsoleUtlis.PrintResult(request);

            MockServer.ServerOkResponse.ResetRequestLogs();
        }

        [Test]
        public void SendMessageWithReplyKeyboardRemoveTest()
        {
            mBotOkResponse.SendMessage(123, "Test", replyMarkup: new ReplyKeyboardRemove { Selective = true });

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendMessage").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "text=Test&reply_markup=%" +
                "7B%0D%0A%20%20%22remove_keyboard%22%3A%20true%2C%0D%0A%20%20%22selective%22%3A%20true%0D%0A%7D");


            MockServer.ServerOkResponse.ResetRequestLogs();

            mBotOkResponse.SendMessage(123, "Test", replyMarkup: new ReplyKeyboardRemove { Selective = false });

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "text=Test&reply_markup=%" +
                "7B%0D%0A%20%20%22remove_keyboard%22%3A%20true%2C%0D%0A%20%20%22selective%22%3A%20false%0D%0A%7D");

            ConsoleUtlis.PrintResult(request);

            MockServer.ServerOkResponse.ResetRequestLogs();
        }
    }
}
