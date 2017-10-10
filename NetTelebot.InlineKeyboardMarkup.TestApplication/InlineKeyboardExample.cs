using NetTelebot.Type.Keyboard;

namespace NetTelebot.InlineKeyboardMarkup.TestApplication
{
    internal static class InlineKeyboardExample
    {
        internal static Type.Keyboard.InlineKeyboardMarkup GetInlineKeyboard()
        {
            InlineKeyboardButton buttonGetId = new InlineKeyboardButton
            {
                Text = "Get this ChatId",
                CallbackData = "/getId"
            };

            InlineKeyboardButton buttonForceReply = new InlineKeyboardButton
            {
                Text = "Get ForceReply",
                CallbackData = "/reply"
            };

            InlineKeyboardButton buttonCalculate = new InlineKeyboardButton
            {
                Text = "Get calculator",
                CallbackData = "/calculate"
            };

            InlineKeyboardButton removeButton = new InlineKeyboardButton
            {
                Text = "Remove calculator",
                CallbackData = "/remove_calculate"
            };

            InlineKeyboardButton[] line1 = {buttonGetId, buttonForceReply};
            InlineKeyboardButton[] line2 = {buttonCalculate, removeButton};

            InlineKeyboardButton[][] buttons = {line1, line2};

            return new Type.Keyboard.InlineKeyboardMarkup
            {
                Keyboard = buttons
            };
        }
    }
}
