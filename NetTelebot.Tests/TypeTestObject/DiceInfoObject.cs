using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class DiceInfoObject
    {
        /// <summary>
        /// This object represents an animated emoji that displays a random value.
        /// See <see href="https://core.telegram.org/bots/api#dice">API</see>
        /// </summary>
        /// <param name="emoji">Emoji on which the dice throw animation is based</param>
        /// <param name="value">Value of the dice</param>
        /// <returns>JObject representing DiceInfo</returns>
        internal static JObject GetObject(string emoji, int value)
        {
            dynamic diceInfo = new JObject();

            diceInfo.emoji = emoji;
            diceInfo.value = value;

            return diceInfo;
        }
    }
}
