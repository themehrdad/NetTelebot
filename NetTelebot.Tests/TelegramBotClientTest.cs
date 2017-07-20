
//todo Blank for mock tests

using System;
using Funq;
using NUnit.Framework;
using ServiceStack;


namespace NetTelebot.Tests
{
    
    [TestFixture, Ignore("Not work")]
    public class TelegramBotClientTest
    {
        private const string BaseUri = "http://localhost:2000/";

        private ServiceStackHost appHost;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            //Start your AppHost on TestFixture SetUp
            appHost = new AppHost()
                .Init()
                .Start(BaseUri);
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            //Dispose it on TearDown
            appHost.Dispose();
        }

        [Test]
        public void Run_Customer_REST_Example()
        {
            var client = new JsonServiceClient(BaseUri);
            Console.WriteLine(client);

            var sendMessage = client.Post(new TelegramBotClient {Token = "Token"}.SendMessage(123, "123"));
            Console.WriteLine(sendMessage.ResponseUri);
        }

    }

    public class AppHost : AppSelfHostBase
    {
        public AppHost() : base("ServiceStack Examples", typeof(TelegramBotClientService).Assembly) { }

        public override void Configure(Container container)
        {
        }
    }

    [Route("/botToken/sendMessage", "POST")]
    public class GetTelegramBotClientResult : IReturn<SendMessageResult>
    {
        public SendMessageResult SendMessageResult { get; set; }
    }

    public class TelegramBotClientService : Service
    {
        public object Post(GetTelegramBotClientResult telegramBotClientResult)
        {
            return telegramBotClientResult.SendMessageResult;
        }
    }
}
