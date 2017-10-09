using System;
using NetTelebot.CommonUtils;

namespace NetTelebot.InlineKeyboardMarkup.TestApplication
{
    internal static class Program
    {
        private static TelegramBotClient mClient;

        private static void Main()
        {
            mClient = new TelegramBot().GetBot();

            //mClient.UpdatesReceived += ClientUpdatesReceived;
            //mClient.GetUpdatesError += ClientGetUpdatesError;
            mClient.StartCheckingUpdates();


            Console.WriteLine("Bot start. For exit press any key");
            Console.ReadKey();
        }
    }
}
