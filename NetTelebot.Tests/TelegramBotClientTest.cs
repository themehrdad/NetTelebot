
//todo Blank for mock tests

using System;
using System.ComponentModel.Design;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using Funq;
using NetTelebot.Tests.TypeTestObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Host.AspNet;
using ServiceStack.Text;
using ServiceStack.Web;


namespace NetTelebot.Tests
{
    
    [TestFixture]
    public class TelegramBotClientTest
    {
        private const string BaseUri = "http://localhost:2000/";

        private ServiceStackHost appHost;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            appHost = new AppHost()
                .Init()
                .Start(BaseUri);
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void RunCustomerRESTExample()
        {
            var client = new JsonServiceClient(BaseUri);

            client.Post(new TelegramBotClient {Token = "Token"}.SendMessage(123123456, "123"));
            
            /*
            string response = client.Get(new SendMessageString { 
                Text = new TelegramBotClient { Token = "Token" }.SendMessage(123123456, "123").ToString() } );
            Console.WriteLine(response);
            */
          
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
    public class SendMessage : IReturn<SendMessageResults>
    {
        public TelegramBotClient Text { get; set; }
        
    }

    public class SendMessageResults
    {
        public SendMessageResult SendMessageResult { get; set; }
    }

    public class TelegramBotClientService : Service
    {
        
        public object Post(SendMessage request)
        {
      
            return new HttpResult(new { ok = true, result = 
                new { message_id = 123, date = 0, chat = 
                new { id = 123, type="chanell"}} });
            
        }

        //public object Any(SendMessageString request)
        //{
         //   return request.Text;
        //}
    }
}
