using System;
using System.Collections.Generic;
using System.Linq;
using Mock4Net.Core;
using NUnit.Framework;
using RestSharp;


namespace NetTelebot.Tests
{
    [TestFixture]
    public class TelegramMockBotClientTest
    {
        private FluentMockServer server;

        private const string expectedBody =
            @"{ ok: ""true"", result: { message_id: 123, date: 0, chat: { id: 123, type: ""private"" }}}";

        private readonly TelegramBotClient mBot = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:8090") };

        [OneTimeSetUp]
        public void OnStart()
        {
            server = FluentMockServer.Start(8090);

            server
             .Given(
               Requests.WithUrl("/*").UsingPost()
             )
             .RespondWith(
               Responses
                 .WithStatusCode(200)
                 .WithBody(expectedBody)
             );
        }

        [OneTimeTearDown]
        public void OnStop()
        {
            server.Stop();
        }

        /// <summary>
        /// Sends the message test method <see cref="TelegramBotClient.SendMessage"/>.
        /// </summary>
        [Test]
        public void SendMessageTest()
        {
            mBot.SendMessage(123, "123", ParseMode.HTML, false, false, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendMessage").UsingPost());
            
            Assert.AreEqual(request.FirstOrDefault()?.Body, 
                "chat_id=123&" +
                "text=123&" +
                "parse_mode=HTML&" +
                "disable_web_page_preview=False&" +
                "disable_notification=False&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendMessage");
            
            PrintResult(request);
        }

        /// <summary>
        /// Forward the message test method <see cref="TelegramBotClient.ForwardMessage"/>.
        /// </summary>
        [Test]
        public void ForwardMessageTest()
        {
            mBot.ForwardMessage(123, 123 ,123, true);

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/forwardMessage").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "from_chat_id=123&" +
                "disable_notification=True&" +
                "message_id=123");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/forwardMessage"); 
        }

        /// <summary>
        /// Sends the photo test method <see cref="TelegramBotClient.SendPhoto"/>.
        /// </summary>
        [Test]
        public void SendPhotoTest()
        {
            mBot.SendPhoto(123, new ExistingFile { FileId = "123" }, "caption", false, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendPhoto").UsingPost());

            PrintResult(request);

            Assert.AreEqual(request.FirstOrDefault()?.Body,
                "chat_id=123&" +
                "photo=123&" +
                "caption=caption&" +
                "disable_notification=False&" +
                "reply_to_message_id=123&" +
                "reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");

            Assert.AreEqual(request.FirstOrDefault()?.Url, "/botToken/sendPhoto");
        }

        private static void PrintResult(IEnumerable<Request> request)
        {
            Console.WriteLine(request.FirstOrDefault()?.Body);
            Console.WriteLine(request.FirstOrDefault()?.Url);
        }
    }
}
