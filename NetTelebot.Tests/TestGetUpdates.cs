using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetTelebot.Tests
{
    [TestClass]
    public class TestGetUpdates
    {
        TelegramBotClient client;

        [TestInitialize]
        public void Initialize()
        {
            client = new TelegramBotClient()
            {
                Token = ""
            };
        }
        [TestMethod]
        public void TestExceptions()
        {
            client.GetUpdatesError += client_GetUpdatesError;
            client.UpdatesReceived += client_UpdatesReceived;
            client.StartCheckingUpdates();
            var time = DateTime.Now.AddSeconds(10);
            while (DateTime.Now < time)
            {

            }
        }

        void client_UpdatesReceived(object sender, TelegramUpdateEventArgs e)
        {
            Console.WriteLine("Updates received: {0}", e.Updates.Length);
        }

        void client_GetUpdatesError(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Error occured: {0}", ((Exception)e.ExceptionObject).Message);
        }
    }
}
