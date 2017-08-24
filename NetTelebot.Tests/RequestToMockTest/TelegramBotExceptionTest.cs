using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NetTelebot.Tests.RequestToMockTest
{
    internal class TelegramBotExceptionTest
    {
        [Test]
        public static void GetUpdatesWithTokenNullTest()
        {
            TelegramBotClient telegramBot = new TelegramBotClient();
            
            Assert.Throws<Exception>(() => telegramBot.StartCheckingUpdates());
            Assert.Throws<Exception>(() => telegramBot.GetUpdates());
        }

        [Test, Ignore("In process")]
        public static void ExceptionEventHandlerTest()
        {
            bool wasCalled = false;

            TelegramBotClient telegramBot =
                new TelegramBotClient();

            UnhandledExceptionEventHandler unhandledExceptionEventHandler = (s, e) =>
            {
                telegramBot.StopCheckUpdates();

                if (wasCalled) return;
                wasCalled = true;
            };

            telegramBot.GetUpdatesError += unhandledExceptionEventHandler;

            //todo add test here

            Thread.Sleep(1000);

            Assert.True(wasCalled);

            telegramBot.StopCheckUpdates();
            telegramBot.GetUpdatesError -= unhandledExceptionEventHandler;
        }
    }
}
