using System;
using NetTelebot.Result;
using NetTelebot.Tests.MockServers;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.RequestToMockTest
{
    [TestFixture]
    internal static class EventHandlerTest
    {
        private const int mOkServerPort = 8097;
        private const int mBadServerPort = 8098;

        private static readonly TelegramBotClient mBotOkResponse = new TelegramBotClient
        {
            Token = "Token",
            CheckInterval = 0,
            RestClient = new RestClient("http://localhost:" + mOkServerPort)
        };

        private static readonly TelegramBotClient mBotBadResponse = new TelegramBotClient
        {
            Token = "Token",
            CheckInterval = 0,
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
        
        [Test, Timeout(10000)]
        public static void ExceptionEventHandlerTest()
        {
            bool wasCalled = false;

            UnhandledExceptionEventHandler unhandledExceptionEventHandler = (s, e) =>
            {
                if (!wasCalled)
                    wasCalled = true;
            };

            mBotBadResponse.GetUpdatesError += unhandledExceptionEventHandler;

            do
            {
                mBotBadResponse.StartCheckingUpdates();
            } while (!wasCalled);

            Assert.True(wasCalled);

            mBotBadResponse.StopCheckUpdates();
            mBotBadResponse.GetUpdatesError -= unhandledExceptionEventHandler;
        }
        
        [Test, Timeout(10000)]
        public static void TelegramUpdateEventArgsHandler()
        {
            MockServer.AddNewRouter("/botToken/getUpdates", ResponseStringGetUpdatesResult.ExpectedBodyWithObjectMessage);

            bool wasCalled = false;

            EventHandler<TelegramUpdateEventArgs> telegramUpdateEventArgs = (s, e) =>
            {
                if (!wasCalled)
                    wasCalled = true;
            };

            mBotOkResponse.UpdatesReceived += telegramUpdateEventArgs;

            do
            {
                mBotOkResponse.StartCheckingUpdates();
            } while (!wasCalled);

            Assert.True(wasCalled);

            mBotOkResponse.StopCheckUpdates();
            mBotOkResponse.UpdatesReceived -= telegramUpdateEventArgs;
        }
    }
}
