using NetTelebot.Type.Keyboard;

namespace NetTelebot.CommonUtils
{
    public static class Keyboards
    {
        public static InlineKeyboardMarkup GetInlineKeyboard()
        {
            InlineKeyboardButton[][] keyboard =
            {
                new[] {new InlineKeyboardButton {Text = "1"}, new InlineKeyboardButton {Text = "2"}},
                new[] {new InlineKeyboardButton {Text = "3"}, new InlineKeyboardButton {Text = "4"}},
            };

            return new InlineKeyboardMarkup
            {
                Keyboard = keyboard
            };
        }
    }
}
