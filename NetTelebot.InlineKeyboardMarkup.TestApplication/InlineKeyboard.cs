using NetTelebot.Type.Keyboard;

namespace NetTelebot.InlineKeyboardMarkup.TestApplication
{
    internal static class InlineKeyboard
    {
        internal static Type.Keyboard.InlineKeyboardMarkup GetKeyboard()
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

            InlineKeyboardButton buttonGetLogo = new InlineKeyboardButton
            {
                Text = "Get NetTelbot logo",
                CallbackData = "/getLogo"
            };

            InlineKeyboardButton[] line1 = {buttonGetId, buttonUrl};
            InlineKeyboardButton[] line2 = {buttonInlineQuery, buttonGetLogo};

            InlineKeyboardButton[][] buttons = {line1, line2};

            return new Type.Keyboard.InlineKeyboardMarkup
            {
                Keyboard = buttons
            };
        }
    }
}
