using System;
using System.Linq;
using NetTelebot.Result;
using NetTelebot.Type;

namespace NetTelebot.ReplyKeyboardMarkups.TestApplication
{
    internal static class ForceReplyExample
    {
        internal static bool InterceptorOfResponseMessages(TelegramUpdateEventArgs updateEvent)
        {
            foreach (UpdateInfo update in updateEvent.Updates.Where(update => update.Message.ReplyToMessage.Text != null))
            {
                Console.WriteLine("Id " + update.UpdateId + " ReplyResponse " + update.Message.Text);
                Console.WriteLine("Id " + update.UpdateId + " ReplyQuery" + update.Message.ReplyToMessage.Text);

                Program.SendMessage(update.Message.Chat.Id, "Your reply is \"" + update.Message.Text + "\"");
            }

            return false;
        }
    }
}
