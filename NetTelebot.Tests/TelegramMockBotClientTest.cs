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
            var request = server.SearchLogsFor(Requests.WithUrl("/*").UsingPost());

            server
              .Given(
                Requests.WithUrl("/*").UsingPost()
              )
              .RespondWith(
                Responses
                  .WithStatusCode(200)
                  .WithBody(@"{ ok: ""true"", result: {message_id: 123, date: 0, chat: {id: 123, type: ""private""}}}")
              );

            TelegramBotClient bot = new TelegramBotClient { Token = "Token", RestClient = new RestClient("http://localhost:8090") };
           
            bot.SendMessage(123, "123", ParseMode.HTML);

            Assert.AreEqual(request.First().Body, "chat_id=123&text=123&parse_mode=HTML");
        }
    }
}
