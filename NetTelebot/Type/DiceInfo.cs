using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents an animated emoji that displays a random value.
    /// See <see href="https://core.telegram.org/bots/api#dice">API</see>
    /// </summary>
    public class DiceInfo
    {
        internal DiceInfo()
        {
        }

        internal DiceInfo(JObject jsonObject)
        {
            Emoji = jsonObject["emoji"].Value<string>();
            Value = jsonObject["value"].Value<int>();
        }

        /// <summary>
        /// Emoji on which the dice throw animation is based
        /// </summary>
        public string Emoji { get; private set; }

        /// <summary>
        /// Value of the dice, 1-6 for "🎲", "🎯" and "🎳" base emoji, 1-5 for "🏀" and "⚽" base emoji, 1-64 for "🎰" base emoji
        /// </summary>
        public int Value { get; private set; }
    }
}
