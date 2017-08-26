using System;
using System.Linq;
using Mock4Net.Core;
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
    internal class TelegramBotGetUpdatesTest
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

            Assert.Throws<Exception>(() => telegramBot.StartCheckingUpdates());
            Assert.Throws<Exception>(() => telegramBot.GetUpdates());
        }

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

        private static void StartTest(string body)
        {
            MockServer.AddNewRouter("/botToken/getUpdates", body);

            mBotOkResponse.GetUpdates();
            var request = MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUpdates").UsingPost());

            Console.WriteLine(request.FirstOrDefault()?.Url);

            Assert.AreEqual("/botToken/getUpdates", request.FirstOrDefault()?.Url);
            Assert.Throws<Exception>(() => mBotBadResponse.GetUpdates());
        }
    }
}
