using NetTelebot.Type.Keyboard;

namespace NetTelebot.ReplyKeyboardMarkups.TestApplication
{
    internal static class ReplyKeyboardMarkupExample
    {
        internal static ReplyKeyboardMarkup GetKeyboardMarkup()
        {
            KeyboardButton[] line1 =
{
                new KeyboardButton {Text = "1"},
                new KeyboardButton {Text = "2"},
                new KeyboardButton {Text = "3"},
                new KeyboardButton {Text = "+"}
            };

            KeyboardButton[] line2 =
            {
                new KeyboardButton {Text = "4"},
                new KeyboardButton {Text = "5"},
                new KeyboardButton {Text = "6"},
                new KeyboardButton {Text = "-"}
            };

            KeyboardButton[] line3 =
            {
                new KeyboardButton {Text = "7"},
                new KeyboardButton {Text = "8"},
                new KeyboardButton {Text = "9"},
                new KeyboardButton {Text = "/"},
            };

            KeyboardButton[] line4 =
            {
                new KeyboardButton {Text = "."},
                new KeyboardButton {Text = "0"},
                new KeyboardButton {Text = "="},
                new KeyboardButton {Text = "*"}
            };

            KeyboardButton[][] buttons = { line1, line2, line3, line4 };

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup
            {
                Keyboard = buttons,
                ResizeKeyboard = true
            };

            return keyboard;
        }
    }
}
