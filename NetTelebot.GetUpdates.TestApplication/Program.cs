using System;
using NetTelebot.BotEnum;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;

namespace NetTelebot.GetUpdates.TestApplication
{
    internal static class Program
    {
        private static TelegramBotClient mClient;

        private static void Main()
        {
            AllowedUpdates[] allowedUpdateses = {AllowedUpdates.CallbackQuery};
            mClient = GetBot();

            mClient.UpdatesReceived += ClientUpdatesReceived;
            mClient.GetUpdatesError += ClientGetUpdatesError;
            mClient.GetUpdates(allowedUpdates:allowedUpdateses);

            ConsoleUtlis.WriteConsoleLog("Example bot start. For exit press any key");
            Console.ReadKey();
        }

        /// <summary>
        /// To start the bot remove
        /// <code>return new TelegramBot().GetBot();</code> 
        /// and uncomment 
        /// <code>
        /// return new TelegramBotClient {Token = "ENTER YOUR TOKEN HERE"};
        /// </code>
        /// by specifying your token.
        /// </summary>
        /// <returns><see cref="TelegramBotClient"/></returns>
        private static TelegramBotClient GetBot()
        {
            //return new TelegramBotClient {Token = "ENTER YOUR TOKEN HERE"};

            return new TelegramBot().GetBot();
        }

        private static void ClientGetUpdatesError(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Error occured: {0}", ((Exception)e.ExceptionObject).Message);
        }

        private static void ClientUpdatesReceived(object sender, TelegramUpdateEventArgs e)
        {
            foreach (var update in e.Updates)
            {
                if (update.CallbackQuery.Id != null)
                {
                    ConsoleUtlis.WriteConsoleLog("New CallbackQuery");
                    //ParseCommandInCallbackQuery(update.CallbackQuery);
                }

                if (update.Message.MessageId != 0)
                {
                    ConsoleUtlis.WriteConsoleLog("New MessageInfo");
                    //if (update.Message.Text.StartsWith("/"))
                        //ParseCommandInMessageInfo(update.Message);
                }
            }
        }

        private static void ParseCommandInMessageInfo(MessageInfo messageInfo)
        {
            if (messageInfo.Text.Equals("/start"))
            {
                /*mClient.SendMessage(messageInfo.Chat.Id,
                    "Hey. I'm a demo bot." +
                    "\nI'll show you how the inline keyboard works" +
                    "\nPlease press inline button",
                    replyMarkup: InlineKeyboard.GetKeyboard());*/
            }
        }
    }
}
