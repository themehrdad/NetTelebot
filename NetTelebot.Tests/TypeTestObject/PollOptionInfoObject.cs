using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class PollOptionInfoObject
    {
        /// <summary>
        /// This object contains information about one answer option in a poll.
        /// See <see href="https://core.telegram.org/bots/api#polloption">API</see>
        /// </summary>
        /// <param name="text">Option text</param>
        /// <param name="voterCount">Number of users that voted for this option</param>
        /// <returns>JObject representing PollOptionInfo</returns>
        internal static JObject GetObject(string text, int voterCount)
        {
            dynamic pollOption = new JObject();

            pollOption.text = text;
            pollOption.voter_count = voterCount;

            return pollOption;
        }
    }
}
