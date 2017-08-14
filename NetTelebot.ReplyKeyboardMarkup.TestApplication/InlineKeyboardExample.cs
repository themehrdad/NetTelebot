using NetTelebot.Type.Keyboard;

namespace NetTelebot.ReplyKeyboardMarkups.TestApplication
{
    internal static class InlineKeyboardExample
    {
        internal static InlineKeyboardMarkup GetInlineKeyboard()
        {
            InlineKeyboardButton buttonGetId = new InlineKeyboardButton
            {
                Text = "Get ChatId",
                CallbackData = "/getId"
            };

            InlineKeyboardButton[] line1 = {buttonGetId};

            InlineKeyboardButton[][] buttons = {line1};

            return new InlineKeyboardMarkup
            {
                Keyboard = buttons
            };
        }
    }
}
