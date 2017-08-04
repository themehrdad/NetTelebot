using System;
using System.Linq;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;
using NetTelebot.Type.Keyboard;

namespace NetTelebot.ReplyKeyboardMarkups.TestApplication
{
    internal static class Program
    {
        private static TelegramBotClient mClient;

        private static void Main()
        {
            mClient = new TelegramBotClient
            {
                Token = new WindowsCredential().GetTelegramCredential("NetTelebotBot").Token,
                CheckInterval = 1000
            };

            mClient.UpdatesReceived += ClientUpdatesReceived;
            mClient.GetUpdatesError += ClientGetUpdatesError;
            mClient.StartCheckingUpdates();

            Console.WriteLine("Bot start. For exit press any key");
            Console.ReadKey();
        }

        private static void ClientUpdatesReceived(object sender, TelegramUpdateEventArgs e)
        {
            foreach (UpdateInfo update in e.Updates.Where(update => update.Message.Text.StartsWith("/")))
            {
                if (update.Message.Text.Equals("/start"))
                {
                    mClient.SendMessage(update.Message.Chat.Id, "Hello. I`m calculator bot. Type \"/calculate\" to start the calculation");
                }
                else if (update.Message.Text.Equals("/calculate"))
                {
                    mClient.SendMessage(update.Message.Chat.Id, "Please enter an arithmetic expression and press =", replyMarkup:GetKeyboardMarkup());
                }
                else
                {
                    mClient.SendMessage(update.Message.Chat.Id, "Unknow command");
                } 
            }
        }

        private static void ClientGetUpdatesError(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Error occured: {0}", ((Exception)e.ExceptionObject).Message);
        }

        private static ReplyKeyboardMarkup GetKeyboardMarkup()
        {
            KeyboardButton[] line1 =
{
                new KeyboardButton {Text = "1"},
                new KeyboardButton {Text = "2"},
                new KeyboardButton {Text = "3"},
                new KeyboardButton {Text = "+"}
            };

            KeyboardButton[] line2 =
            {
                new KeyboardButton {Text = "4"},
                new KeyboardButton {Text = "5"},
                new KeyboardButton {Text = "6"},
                new KeyboardButton {Text = "-"}
            };

            KeyboardButton[] line3 =
            {
                new KeyboardButton {Text = "7"},
                new KeyboardButton {Text = "8"},
                new KeyboardButton {Text = "9"},
                new KeyboardButton {Text = "/"},
            };

            KeyboardButton[] line4 =
            {
                new KeyboardButton {Text = "."},
                new KeyboardButton {Text = "0"},
                new KeyboardButton {Text = "="},
                new KeyboardButton {Text = "*"}
            };

            KeyboardButton[][] buttons = { line1, line2, line3, line4 };

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup
            {
                Keyboard = buttons,
                ResizeKeyboard = true
            };

            return keyboard;
        }
    }
}
