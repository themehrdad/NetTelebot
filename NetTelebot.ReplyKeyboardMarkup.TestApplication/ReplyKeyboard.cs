using NetTelebot.Type.Keyboard;

namespace NetTelebot.ReplyKeyboardMarkups.TestApplication
{
    internal static class ReplyKeyboard
    {
        internal static ReplyKeyboardMarkup GetKeyboard()
        {
            KeyboardButton[] line1 =
            {
                new KeyboardButton {Text = "1"},
                new KeyboardButton {Text = "2"},
                new KeyboardButton {Text = "3"}
            };

            KeyboardButton[] line2 =
            {
                new KeyboardButton {Text = "4"},
                new KeyboardButton {Text = "5"},
                new KeyboardButton {Text = "6"}
            };

            KeyboardButton[] line3 =
            {
                new KeyboardButton {Text = "7"},
                new KeyboardButton {Text = "8"},
                new KeyboardButton {Text = "9"}
            };

            KeyboardButton[] line4 =
            {
                new KeyboardButton {Text = "Exit"},
                
            };

            KeyboardButton[][] buttons = { line1, line2, line3, line4 };

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup
            {
                Keyboard = buttons,
                ResizeKeyboard = true
            };

            return keyboard;
        }

        internal static ReplyKeyboardRemove ReplyKeyboardRemove = new ReplyKeyboardRemove
        {
            Selective = false
        };

    }
}
