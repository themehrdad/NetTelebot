using NetTelebot.Type.Keyboard;

namespace NetTelebot.InlineKeyboardMarkup.TestApplication
{
    internal static class InlineKeyboard
    {
        internal static Type.Keyboard.InlineKeyboardMarkup GetInlineKeyboard()
        {
            InlineKeyboardButton buttonGetId = new InlineKeyboardButton
            {
                Text = "Get this dialog chat id",
                CallbackData = "/getId"
            };

            InlineKeyboardButton buttonUrl = new InlineKeyboardButton
            {
                Text = "See InlineKeyboard API",
                Url = "https://core.telegram.org/bots/api#inlinekeyboardbutton"

            };

            InlineKeyboardButton buttonInlineQuery = new InlineKeyboardButton
            {
                Text = "Switch Inline Query",
                SwitchInlineQuery = "@vertigraInlineBot "
            };

            InlineKeyboardButton buttonStopBot = new InlineKeyboardButton
            {
                Text = "Stop bot",
                CallbackData = "/stopBot"
            };

            InlineKeyboardButton[] line1 = {buttonGetId, buttonUrl};
            InlineKeyboardButton[] line2 = {buttonInlineQuery, buttonStopBot};

            InlineKeyboardButton[][] buttons = {line1, line2};

            return new Type.Keyboard.InlineKeyboardMarkup
            {
                Keyboard = buttons
            };
        }
    }
}
