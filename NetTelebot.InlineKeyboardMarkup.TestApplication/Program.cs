using System;
using System.Collections.Generic;
using NetTelebot.CommonUtils;
using NetTelebot.Result;
using NetTelebot.Type;

namespace NetTelebot.InlineKeyboardMarkup.TestApplication
{
    internal static class Program
    {
        private static TelegramBotClient mClient;

        private static void Main()
        {
            mClient = new TelegramBot().GetBot();

            mClient.UpdatesReceived += ClientUpdatesReceived;
            mClient.GetUpdatesError += ClientGetUpdatesError;
            mClient.StartCheckingUpdates();

            Console.WriteLine("Example bot start. For exit press any key");
            Console.ReadKey();
        }

        private static void ClientGetUpdatesError(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Error occured: {0}", ((Exception)e.ExceptionObject).Message);
        }

        private static void ClientUpdatesReceived(object sender, TelegramUpdateEventArgs e)
        {
            ParseUpdate(e.Updates);
        }

        private static void ParseUpdate(IEnumerable<UpdateInfo> updateInfo)
        {
            foreach (var update in updateInfo)
            {
                if(update.InlineQuery.Id != null)
                    WriteConsoleLog("New InlineQuery");

                if (update.CallbackQuery.Id != null)
                {
                    WriteConsoleLog("New CallbackQuery");
                    ParseCommandInCallbackQuery(update.CallbackQuery);
                }
                    
                if(update.ChosenInlineResult.ResultId != null)
                    WriteConsoleLog("New ChosenInlineResult");

                if (update.Message.MessageId != 0)
                {
                    WriteConsoleLog("New MessageInfo");
                    if (update.Message.Text.StartsWith("/"))
                        ParseCommandInMessageInfo(update.Message);
                }
            }
        }

        private static void WriteConsoleLog(string text)
        {
            Console.WriteLine(DateTime.Now.ToLocalTime() + " " + text);
        }

        private static void ParseCommandInMessageInfo(MessageInfo messageInfo)
        {
            if (messageInfo.Text.Equals("/start"))
            {
                mClient.SendMessage(messageInfo.Chat.Id, 
                    "Hey. I'm a demo bot." +
                    "\nI'll show you how the inline keyboard works" +
                    "\nPlease press inline button", 
                    replyMarkup: InlineKeyboard.GetInlineKeyboard());
            }
        }

        private static void ParseCommandInCallbackQuery(CallbackQueryInfo callbackQuery)
        {
            if (callbackQuery.Data.Equals("/getId"))
            {
                var chatId = callbackQuery.Message.Chat.Id;
                mClient.SendMessage(chatId, "This chat id is " + chatId);
            }

            if (callbackQuery.Data.Equals("/getLogo"))
            {
                mClient.SendPhoto(callbackQuery.Message.Chat.Id, new ExistingFile
                {
                    Url = "https://raw.githubusercontent.com/themehrdad/NetTelebot/master/Images/Logo/logo-100.png"
                });
            }
        }
    }
}
