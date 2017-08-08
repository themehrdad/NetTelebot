using System;
using System.Linq;
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
            mClient = new TelegramBotClient
            {
                Token = WindowsCredential.GetTelegramCredential("NetTelebotBot").Token,
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
            if (ForceReplyExample.InterceptorOfResponseMessages(e))
                return;

            foreach (UpdateInfo update in e.Updates.Where(update => update.Message.Text.StartsWith("/")))
            {
                if (update.Message.Text.Equals("/start"))
                {
                    mClient.SendMessage(update.Message.Chat.Id,
                        "Hello. I`m example bot. Type /calculate for exmple keyboard button and reply keyboard markup. " +
                        "Type /reply for example force reply");
                }
                else if (update.Message.Text.Equals("/calculate"))
                {
                    SendMessage(update.Message.Chat.Id, "Please enter an arithmetic expression and press =", ForceReplyMarkupExample.GetKeyboardMarkup());
                }
                else if (update.Message.Text.Equals("/reply"))
                {

                    SendMessage(update.Message.Chat.Id, "Please reply this message", new ForceReplyMarkup());
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
    }
}
