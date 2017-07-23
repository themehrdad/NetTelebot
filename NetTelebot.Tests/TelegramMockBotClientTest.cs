using System;
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

        [OneTimeSetUp]
        public void OnStart()
        {
            server = FluentMockServer.Start(8090);
        }

        [OneTimeTearDown]
        public void OnStop()
        {
            server.Stop();
        }

        [Test]
        public void SendMessageTest()
        {
            server
              .Given(
                Requests.WithUrl("/*").UsingPost()
              )
              .RespondWith(
                Responses
                  .WithStatusCode(200)
                  .WithBody(expectedBody)
              );

            TelegramBotClient bot = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:8090") };
           
            bot.SendMessage(123, "123", ParseMode.HTML, false, false, 123, new ForceReplyMarkup());

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/sendMessage").UsingPost());
            
            Assert.AreEqual(request.FirstOrDefault().Body, 
                "chat_id=123&text=123&parse_mode=HTML&disable_web_page_preview=False&disable_notification=False&reply_to_message_id=123&reply_markup=%7B%20%22force_reply%22%20%3A%20true%20%7D");
            Assert.AreEqual(request.FirstOrDefault().Url, "/botToken/sendMessage");

            Console.WriteLine(request.FirstOrDefault().Body);
            Console.WriteLine(request.FirstOrDefault().Url);
        }

        [Test]
        public void ForwardMessageTest()
        {
            server
              .Given(
                Requests.WithUrl("/*").UsingPost()
              )
              .RespondWith(
                Responses
                  .WithStatusCode(200)
                  .WithBody(expectedBody)
              );

            TelegramBotClient bot = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:8090") };

            bot.ForwardMessage(123, 123 ,123, true);

            var request = server.SearchLogsFor(Requests.WithUrl("/botToken/forwardMessage").UsingPost());
            
            Assert.AreEqual(request.FirstOrDefault().Body,
                "chat_id=123&from_chat_id=123&message_id=123&disable_notification=True");
            Assert.AreEqual(request.FirstOrDefault().Url, "/botToken/forwardMessage");

            Console.WriteLine(request.FirstOrDefault().Body);
            Console.WriteLine(request.FirstOrDefault().Url);
        }


    }
}
