using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot.Commands
{
    public static class UtilityExtensions
    {
        public static bool IsCommand(this UpdateInfo update)
        {
            return update.Message != null && update.Message.IsCommand();
        }

        public static bool IsCommand(this MessageInfo message)
        {
            return message.Text != null && message.Text.StartsWith("/");
        }
    }
}
