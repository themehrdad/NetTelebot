using System;
using System.Globalization;
using System.Linq;
using System.Net;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;

namespace NetTelebot.ReplyKeyboardMarkups.TestApplication
{
    internal static class Program
    {
        private static TelegramBotClient mClient;

        private static void Main()
        {
            //EnableProxy();

            mClient = new TelegramBot().GetBot();

            mClient.UpdatesReceived += ClientUpdatesReceived;
            mClient.GetUpdatesError += ClientGetUpdatesError;
            mClient.StartCheckingUpdates();

            ConsoleUtlis.WriteConsoleLog("Example bot start. For exit press any key");
            Console.ReadKey();
        }

        private static void ClientGetUpdatesError(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Error occured: {0}", ((Exception)e.ExceptionObject).Message);
        }

        private static void ClientUpdatesReceived(object sender, TelegramUpdateEventArgs e)
        {
            foreach (var update in e.Updates.Where(update => update.Message.MessageId != 0))
            {
                if (update.Message.Text.StartsWith("/"))
                    ParseCommandInMessageInfo(update.Message);

                else if (update.Message.Text.Equals("Exit"))
                    ReplyKeyboardRemove(update.Message.Chat.Id);

                else
                    ParseAnswerInMessageInfo(update.Message);
            }
        }


        private static void ParseCommandInMessageInfo(MessageInfo messageInfo)
        {
            if (messageInfo.Text.Equals("/start"))
            {
                mClient.SendMessage(messageInfo.Chat.Id,
                    "Hey. I'm a demo bot." +
                    "\nI'll show you how the inline keyboard works." +
                    "\nPlease answer how many bits in the byte?",
                    replyMarkup: ReplyKeyboard.GetKeyboard());
            }
        }

        private static void ReplyKeyboardRemove(long chatId)
        {
            mClient.SendMessage(chatId, "Goodbay", replyMarkup: ReplyKeyboard.ReplyKeyboardRemove);
        }

        private static void ParseAnswerInMessageInfo(MessageInfo messageInfo)
        {
            int tempOut;
            var chatId = messageInfo.Chat.Id;

            if (int.TryParse(messageInfo.Text, NumberStyles.None, CultureInfo.InvariantCulture, out tempOut))
            {
                if (tempOut == 8)
                {
                    mClient.SendMessage(chatId, "You win!");
                    ReplyKeyboardRemove(chatId);
                }
                else
                {
                    mClient.SendMessage(chatId, "No. Try again");
                }
            }
            else
            {
                mClient.SendMessage(chatId, "Need numeral");
            }
        }

        private static void EnableProxy()
        {
            WebProxy proxyObject = new WebProxy("http://192.168.1.254:3128/", true);
            WebRequest.DefaultWebProxy = proxyObject;
        }

    }
}
