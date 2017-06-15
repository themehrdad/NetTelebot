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
