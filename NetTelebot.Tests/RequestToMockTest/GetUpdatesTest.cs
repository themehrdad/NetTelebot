using System;
using System.Linq;
using Mock4Net.Core;
using NetTelebot.BotEnum;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Tests.MockServers;
using NetTelebot.Type;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.RequestToMockTest
{
    /// <summary>
    /// Testing a chain consisting of private method in <see cref="TelegramBotClient"/> .ExecuteRequest(), 
    /// parser in <see cref="GetUpdatesResult"/> and parser in <see cref="UpdateInfo"/>
    /// 
    /// Server responses are defined within the methods of the current query method is the same (is method GetUpdates <see href="https://core.telegram.org/bots/api#getupdates"/>)
    /// </summary>
    [TestFixture]
    internal static class GetUpdatesTest
    {
        private const int mOkServerPort = 8095;
        private const int mBadServerPort = 8096;

        private static readonly TelegramBotClient mBotOkResponse = new TelegramBotClient
        {
            Token = "Token",
            RestClient = new RestClient("http://localhost:" + mOkServerPort)
        };

        private static readonly TelegramBotClient mBotBadResponse = new TelegramBotClient
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

        [Test]
        public static void GetUpdatesWithNullTokenTest()
        {
            TelegramBotClient telegramBot = new TelegramBotClient();

            Assert.Multiple(() =>
            {
                Assert.Throws<Exception>(() => telegramBot.StartCheckingUpdates());
                Assert.Throws<Exception>(() => telegramBot.GetUpdates());
            });
        }

        #region GetUpdatesWithOffsetAndLimit

        [Test]
        public static void GetUpdatesWithOFfsetAndLimitTest()
        {
            MockServer.ServerOkResponse.ResetRequestLogs();

            MockServer.AddNewRouter("/botToken/getUpdates*", ResponseStringGetUpdatesResult.ExpectedBodyWithObjectMessage);

            mBotOkResponse.GetUpdates(1, 1);
            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUpdates*").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("/botToken/getUpdates?offset=1&limit=1", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.GetUpdates());
            });
        }

        [Test]
        public static void GetUpdatesWithLimitTest()
        {
            MockServer.ServerOkResponse.ResetRequestLogs();

            MockServer.AddNewRouter("/botToken/getUpdates*", ResponseStringGetUpdatesResult.ExpectedBodyWithObjectMessage);

            mBotOkResponse.GetUpdates((byte)1);
            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUpdates*").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("/botToken/getUpdates?limit=1", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.GetUpdates());
            });
        }

        [Test]
        public static void GetUpdatesWithOffsetTest()
        {
            MockServer.ServerOkResponse.ResetRequestLogs();

            MockServer.AddNewRouter("/botToken/getUpdates*", ResponseStringGetUpdatesResult.ExpectedBodyWithObjectMessage);

            mBotOkResponse.GetUpdates(1);
            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUpdates*").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("/botToken/getUpdates?offset=1", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.GetUpdates());
            });
        }

        #endregion

        #region GetUpdatesWithTimeout

        [Test]
        public static void GetUpdatesWithTimeout()
        {
            MockServer.ServerOkResponse.ResetRequestLogs();

            MockServer.AddNewRouter("/botToken/getUpdates*", ResponseStringGetUpdatesResult.ExpectedBodyWithObjectMessage);

            mBotOkResponse.GetUpdates(timeout:10);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUpdates*").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.AreEqual("/botToken/getUpdates?timeout=10", request.FirstOrDefault()?.Url);
        }

        #endregion

        #region GetUpdatesWithAllowedUpdates

        [Test]
        public static void GetUpdatesWithAllowedUpdates()
        {
            MockServer.ServerOkResponse.ResetRequestLogs();

            MockServer.AddNewRouter("/botToken/getUpdates*", ResponseStringGetUpdatesResult.ExpectedBodyWithObjectMessage);

            AllowedUpdates[] allowedUpdateses =
            {
                AllowedUpdates.Message,
                AllowedUpdates.EditedMessage,
                AllowedUpdates.ChannelPost,
                AllowedUpdates.EditedChannelPost,
                AllowedUpdates.InlineQuery,
                AllowedUpdates.ChosenInlineResult,
                AllowedUpdates.CallbackQuery,
                AllowedUpdates.ShippingQuery,
                AllowedUpdates.PreCheckoutQuery
            };

            
            mBotOkResponse.GetUpdates(allowedUpdateses);

            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUpdates*").UsingPost());

            ConsoleUtlis.PrintResult(request);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("/botToken/getUpdates?" +
                                "allowed_updates=%5B%0D%0A%20%20%22message" +
                                "%22%2C%0D%0A%20%20%22edited_message" +
                                "%22%2C%0D%0A%20%20%22channel_post" +
                                "%22%2C%0D%0A%20%20%22edited_channel_post" +
                                "%22%2C%0D%0A%20%20%22inline_query" +
                                "%22%2C%0D%0A%20%20%22chosen_inline_result" +
                                "%22%2C%0D%0A%20%20%22callback_query" +
                                "%22%2C%0D%0A%20%20%22shipping_query" +
                                "%22%2C%0D%0A%20%20%22pre_checkout_query%22%0D%0A%5D", request.FirstOrDefault()?.Url);

                Assert.Throws<Exception>(() => mBotBadResponse.GetUpdates(allowedUpdates:allowedUpdateses));
            });

        }

        #endregion

        [Test]
        public static void GetUpdatesWithMessageObjectTest()
        {
            StartTest(ResponseStringGetUpdatesResult.ExpectedBodyWithObjectMessage);
        }

        [Test]
        public static void GetUpdatesWithEditMessageObjectTest()
        {
            StartTest(ResponseStringGetUpdatesResult.ExpectedBodyWithObjectEditMessage);
        }

        [Test]
        public static void GetUpdatesWithChannelPostObjectTest()
        {
            StartTest(ResponseStringGetUpdatesResult.ExpectedBodyWithObjectChannelPost);
        }

        [Test]
        public static void GetUpdatesWithEditedChannelPostObjectTest()
        {
            StartTest(ResponseStringGetUpdatesResult.ExpectedBodyWithObjectEditedChannelPost);
        }

        [Test]
        public static void GetUpdatesWithEditedCallbackQueryObjectTest()
        {
            StartTest(ResponseStringGetUpdatesResult.ExpectedBodyWithObjectCallbackQuery);
        }

        [Test]
        public static void GetUpdatesWithShippingQueryTest()
        {
            StartTest(ResponseStringGetUpdatesResult.ExpectedBodyWithObjectShippingQuery);
        }

        [Test]
        public static void GetUpdatesWithPreCheckoutQueryTest()
        {
            StartTest(ResponseStringGetUpdatesResult.ExpectedBodyWithObjectPreCheckoutQuery);
        }

        [Test]
        public static void GetUpdatesWithChosenInlineResultTest()
        {
            StartTest(ResponseStringGetUpdatesResult.ExpectedBodyWithObjectChosenInlineResult);
        }

        [Test]
        public static void GetUpdatesWithInlineQueryTest()
        {
            StartTest(ResponseStringGetUpdatesResult.ExpectedBodyWithObjectInlineQuery);
        }

        private static void StartTest(string body)
        {
            MockServer.AddNewRouter("/botToken/getUpdates", body);

            mBotOkResponse.GetUpdates();
            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUpdates").UsingPost());

            ConsoleUtlis.PrintResult(request);


            Assert.Multiple(() =>
            {
                Assert.AreEqual("/botToken/getUpdates", request.FirstOrDefault()?.Url);
                Assert.Throws<Exception>(() => mBotBadResponse.GetUpdates());
            });
        }
    }
}
