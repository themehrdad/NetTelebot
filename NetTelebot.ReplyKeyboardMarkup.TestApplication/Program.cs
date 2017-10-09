using System;
using System.Linq;
using System.Net;
using NetTelebot.CommonUtils;
using NetTelebot.Interface;
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
            //EnableProxy();

            mClient = new TelegramBot().GetBot();

            mClient.UpdatesReceived += ClientUpdatesReceived;
            mClient.GetUpdatesError += ClientGetUpdatesError;
            mClient.StartCheckingUpdates();
            
            Console.WriteLine("Bot start. For exit press any key");
            Console.ReadKey();
        }

        private static void ClientUpdatesReceived(object sender, TelegramUpdateEventArgs e)
        {
            foreach (var update in e.Updates)
            {
                if (update.Message.Text != null)
                    ParseMessageInfo(e);
                if (update.CallbackQuery.Message != null)
                    ParseCallbackQuery(e);
            }
        }

        private static void ParseCallbackQuery(TelegramUpdateEventArgs e)
        {
            foreach (UpdateInfo update in e.Updates.Where(update => update.CallbackQuery.Data.StartsWith("/")))
            {
                if (update.CallbackQuery.Data.Equals("/getId"))
                    SendMessage(update.CallbackQuery.Message.Chat.Id, "This chat id is " + update.CallbackQuery.Message.Chat.Id);
                else if (update.CallbackQuery.Data.Equals("/reply"))
                    SendMessage(update.CallbackQuery.Message.Chat.Id, "Please reply this message", new ForceReplyMarkup());
                else if (update.CallbackQuery.Data.Equals("/calculate"))
                    SendMessage(update.CallbackQuery.Message.Chat.Id, "Please enter an arithmetic expression.", ReplyKeyboardMarkupExample.GetKeyboardMarkup());
                else if (update.CallbackQuery.Data.Equals("/remove_calculate"))
                    SendMessage(update.CallbackQuery.Message.Chat.Id, "Remove keyboard", new ReplyKeyboardRemove());
            }
        }

        private static void ParseMessageInfo(TelegramUpdateEventArgs e)
        {
            if (ForceReplyExample.InterceptorOfResponseMessages(e))
                return;
            
            foreach (UpdateInfo update in e.Updates.Where(update => update.Message.Text.StartsWith("/")))
            {
                if (update.Message.Text.Equals("/start"))
                {
                    mClient.SendMessage(update.Message.Chat.Id,
                        "Hello. I`m example bot. " +
                        "\nType /calculate for exmple keyboard button and reply keyboard markup. " +
                        "\nType /reply for example force reply. " +
                        "\nType /getId return chat_id." + 
                        "\nOr press inline button.",
                        replyMarkup: InlineKeyboardExample.GetInlineKeyboard());
                }
                else if (update.Message.Text.Equals("/calculate"))
                {
                    SendMessage(update.Message.Chat.Id, "Please enter an arithmetic expression and press =",
                        ReplyKeyboardMarkupExample.GetKeyboardMarkup());
                }
                else if (update.Message.Text.Equals("/reply"))
                {
                    SendMessage(update.Message.Chat.Id, "Please reply this message", new ForceReplyMarkup());
                }
                else if (update.Message.Text.Equals("/getId"))
                {
                    SendMessage(update.Message.Chat.Id, "This chat id is " + update.Message.Chat.Id);
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

        internal static SendMessageResult SendMessage(long chat_id, string message, IReplyMarkup iReplyMarkup = null)
        {
            return mClient.SendMessage(chat_id, message, replyMarkup: iReplyMarkup);
        }

        private static void EnableProxy()
        {
            WebProxy proxyObject = new WebProxy("http://192.168.1.254:3128/", true);
            WebRequest.DefaultWebProxy = proxyObject;
        }

    }
}
