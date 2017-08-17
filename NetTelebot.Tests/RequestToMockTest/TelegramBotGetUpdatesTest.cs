using System;
using System.Collections.Generic;
using System.Linq;
using Mock4Net.Core;
using NUnit.Framework;
using RestSharp;

namespace NetTelebot.Tests.RequestToMockTest
{
    [TestFixture]
    internal class TelegramBotGetUpdatesTest
    {
        private const int mOkServerPort = 8095;
        private const int mBadServerPort = 8096;

        private readonly TelegramBotClient mBotOkResponse = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:" + mOkServerPort) };
        private readonly TelegramBotClient mBotBadResponse = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:" + mBadServerPort) };

        [OneTimeSetUp]
        public static void OnStart()
        {
            MockServer.MockServer.Start(mOkServerPort, mBadServerPort);
        }

        [OneTimeTearDown]
        public static void OnStop()
        {
            MockServer.MockServer.Stop();
        }

        /// <summary>
        /// Sends the message test method <see cref="TelegramBotClient.SendMessage"/>.
        /// </summary>
        [Test, Ignore("In process")]
        public void GetUpdatesTest()
        {
            //todo added this
            mBotOkResponse.GetUpdates(limit:1);

            var request = MockServer.MockServer.ServerOkResponse.SearchLogsFor(Requests.WithUrl("/botToken/getUpdates").UsingGet());

            PrintResult(request);

            /*Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "text=123&parse_mode=HTML&" +
                "disable_web_page_preview=False&" +
                "disable_notification=False&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%0D%0A%20%20%22force_reply%22%3A%20true%0D%0A%7D");*/

            //Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendMessage");
            //Assert.Throws<Exception>(() => mBotBadResponse.SendMessage(123, "123", ParseMode.HTML, false, false, 123, new ForceReplyMarkup()));
        }


        internal static void PrintResult(IEnumerable<Request> request)
        {
            Console.WriteLine(request.FirstOrDefault()?.Body);
            Console.WriteLine(request.FirstOrDefault()?.Url);
        }

    }
}
