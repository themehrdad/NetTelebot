using System;
using System.Linq;
using Mock4Net.Core;
using NetTelebot.BotEnum;
using NetTelebot.CommonUtils;
using NetTelebot.Tests.MockServers;
using NetTelebot.Type;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.RequestToMockTest
{
    /// <summary>
    /// Tests for new methods added in v1.1.0
    /// </summary>
    [TestFixture]
    internal class NewMethodsTest
    {
        private const int mOkServerPort = 8091;
        private const int mBadServerPort = 8092;

        private readonly TelegramBotClient mBotOkResponse = new TelegramBotClient
        {
            Token = "Token",
            RestClient = new RestClient("http://localhost:" + mOkServerPort)
        };

        private readonly TelegramBotClient mBotBadResponse = new TelegramBotClient
        {
            Token = "Token",
            RestClient = new RestClient("http://localhost:" + mBadServerPort)
        };

        [OneTimeSetUp]
        public static void OnStart()
        {
            MockServer.Start(mOkServerPort, mBadServerPort);
        }

        [OneTimeTearDown]
        public static void OnStop()
        {
            MockServer.Stop();
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendAnimation"/>.
        /// </summary>
        [Test]
        public void SendAnimationTest()
        {
            ExistingFile animation = new ExistingFile { FileId = "test_animation_id" };
            mBotOkResponse.SendAnimation(123, animation, "Test caption", ParseMode.HTML, 10, 640, 480, true, 456);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendAnimation").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("chat_id=123", request.FirstOrDefault()?.Body);
                StringAssert.Contains("animation=test_animation_id", request.FirstOrDefault()?.Body);
                StringAssert.Contains("caption=Test+caption", request.FirstOrDefault()?.Body);
                StringAssert.Contains("parse_mode=HTML", request.FirstOrDefault()?.Body);
                StringAssert.Contains("duration=10", request.FirstOrDefault()?.Body);
                StringAssert.Contains("width=640", request.FirstOrDefault()?.Body);
                StringAssert.Contains("height=480", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendAnimation", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.SendAnimation(123, animation));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendDice"/>.
        /// </summary>
        [Test]
        public void SendDiceTest()
        {
            mBotOkResponse.SendDice(123, "🎲", false, 456);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendDice").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("chat_id=123", request.FirstOrDefault()?.Body);
                StringAssert.Contains("emoji", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendDice", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.SendDice(123));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendPoll"/>.
        /// </summary>
        [Test]
        public void SendPollTest()
        {
            string[] options = { "Option 1", "Option 2", "Option 3" };
            mBotOkResponse.SendPoll(123, "Test question?", options, true, "regular", false);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendPoll").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("chat_id=123", request.FirstOrDefault()?.Body);
                StringAssert.Contains("question=Test+question", request.FirstOrDefault()?.Body);
                StringAssert.Contains("options=", request.FirstOrDefault()?.Body);
                StringAssert.Contains("is_anonymous=True", request.FirstOrDefault()?.Body);
                StringAssert.Contains("type=regular", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/sendPoll", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.SendPoll(123, "Test?", options));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.StopPoll"/>.
        /// </summary>
        [Test]
        public void StopPollTest()
        {
            mBotOkResponse.StopPoll(123, 456);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/stopPoll").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("chat_id=123", request.FirstOrDefault()?.Body);
                StringAssert.Contains("message_id=456", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/stopPoll", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.StopPoll(123, 456));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.CopyMessage"/>.
        /// </summary>
        [Test]
        public void CopyMessageTest()
        {
            mBotOkResponse.CopyMessage(123, 456, 789, "New caption", ParseMode.Markdown);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/copyMessage").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("chat_id=123", request.FirstOrDefault()?.Body);
                StringAssert.Contains("from_chat_id=456", request.FirstOrDefault()?.Body);
                StringAssert.Contains("message_id=789", request.FirstOrDefault()?.Body);
                StringAssert.Contains("caption=New+caption", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/copyMessage", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.CopyMessage(123, 456, 789));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.SendMediaGroup"/>.
        /// </summary>
        [Test]
        public void SendMediaGroupTest()
        {
            InputMedia[] media = new InputMedia[]
            {
                new InputMediaPhoto { Media = "photo_id_1", Caption = "Photo 1" },
                new InputMediaPhoto { Media = "photo_id_2", Caption = "Photo 2" }
            };

            mBotOkResponse.SendMediaGroup(123, media, false, 456);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/sendMediaGroup").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("chat_id=123", request.FirstOrDefault()?.Body);
                StringAssert.Contains("media=", request.FirstOrDefault()?.Body);
                StringAssert.Contains("type", request.FirstOrDefault()?.Body); // JSON should contain type field

                Assert.AreEqual("/botToken/sendMediaGroup", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.SendMediaGroup(123, media));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.PinChatMessage"/>.
        /// </summary>
        [Test]
        public void PinChatMessageTest()
        {
            mBotOkResponse.PinChatMessage(123, 456, true);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/pinChatMessage").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("chat_id=123", request.FirstOrDefault()?.Body);
                StringAssert.Contains("message_id=456", request.FirstOrDefault()?.Body);
                StringAssert.Contains("disable_notification=True", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/pinChatMessage", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.PinChatMessage(123, 456));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.UnpinChatMessage"/>.
        /// </summary>
        [Test]
        public void UnpinChatMessageTest()
        {
            mBotOkResponse.UnpinChatMessage(123, 456);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/unpinChatMessage").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("chat_id=123", request.FirstOrDefault()?.Body);
                StringAssert.Contains("message_id=456", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/unpinChatMessage", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.UnpinChatMessage(123));
            });
        }

        /// <summary>
        /// Test method <see cref="TelegramBotClient.AnswerCallbackQuery"/> (correctly spelled version).
        /// </summary>
        [Test]
        public void AnswerCallbackQueryTest()
        {
            mBotOkResponse.AnswerCallbackQuery("callback_query_id", "Response text", true, "http://example.com", 300);

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/answerCallbackQuery").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("callback_query_id=callback_query_id", request.FirstOrDefault()?.Body);
                StringAssert.Contains("text=Response+text", request.FirstOrDefault()?.Body);
                StringAssert.Contains("show_alert=True", request.FirstOrDefault()?.Body);
                StringAssert.Contains("cache_time=300", request.FirstOrDefault()?.Body);

                Assert.AreEqual("/botToken/answerCallbackQuery", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.AnswerCallbackQuery("callback_query_id"));
            });
        }

        /// <summary>
        /// Test obsolete method <see cref="TelegramBotClient.AswerCallbackQuery"/> still works.
        /// </summary>
        [Test]
        public void AswerCallbackQueryObsoleteTest()
        {
            // This should still work but show obsolete warning
            #pragma warning disable CS0618 // Type or member is obsolete
            mBotOkResponse.AswerCallbackQuery("callback_query_id", "Response text");
            #pragma warning restore CS0618

            var request =
                MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/answerCallbackQuery").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                StringAssert.Contains("callback_query_id=callback_query_id", request.FirstOrDefault()?.Body);
                Assert.AreEqual("/botToken/answerCallbackQuery", request.FirstOrDefault()?.Url);
            });
        }
    }
}
