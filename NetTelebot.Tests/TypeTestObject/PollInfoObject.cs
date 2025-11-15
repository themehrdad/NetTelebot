using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class PollInfoObject
    {
        /// <summary>
        /// This object contains information about a poll.
        /// See <see href="https://core.telegram.org/bots/api#poll">API</see>
        /// </summary>
        /// <param name="id">Unique poll identifier</param>
        /// <param name="question">Poll question</param>
        /// <param name="options">List of poll options</param>
        /// <param name="totalVoterCount">Total number of users that voted</param>
        /// <param name="isClosed">True if the poll is closed</param>
        /// <param name="isAnonymous">True if the poll is anonymous</param>
        /// <param name="type">Poll type (regular or quiz)</param>
        /// <param name="allowsMultipleAnswers">True if multiple answers allowed</param>
        /// <param name="correctOptionId">0-based identifier of correct answer (quiz mode)</param>
        /// <param name="explanation">Text shown for incorrect answer</param>
        /// <returns>JObject representing PollInfo</returns>
        internal static JObject GetObject(string id, string question, JArray options, int totalVoterCount,
            bool isClosed, bool isAnonymous, string type, bool allowsMultipleAnswers,
            int? correctOptionId = null, string explanation = null)
        {
            dynamic pollInfo = new JObject();

            pollInfo.id = id;
            pollInfo.question = question;
            pollInfo.options = options;
            pollInfo.total_voter_count = totalVoterCount;
            pollInfo.is_closed = isClosed;
            pollInfo.is_anonymous = isAnonymous;
            pollInfo.type = type;
            pollInfo.allows_multiple_answers = allowsMultipleAnswers;

            if (correctOptionId.HasValue)
                pollInfo.correct_option_id = correctOptionId.Value;
            if (!string.IsNullOrEmpty(explanation))
                pollInfo.explanation = explanation;

            return pollInfo;
        }
    }
}
