using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object contains information about a poll.
    /// See <see href="https://core.telegram.org/bots/api#poll">API</see>
    /// </summary>
    public class PollInfo
    {
        internal PollInfo()
        {
        }

        internal PollInfo(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<string>();
            Question = jsonObject["question"].Value<string>();
            Options = PollOptionInfo.ParseArray(jsonObject["options"].Value<JArray>());
            TotalVoterCount = jsonObject["total_voter_count"].Value<int>();
            IsClosed = jsonObject["is_closed"].Value<bool>();
            IsAnonymous = jsonObject["is_anonymous"].Value<bool>();
            Type = jsonObject["type"].Value<string>();
            AllowsMultipleAnswers = jsonObject["allows_multiple_answers"].Value<bool>();

            if (jsonObject["correct_option_id"] != null)
                CorrectOptionId = jsonObject["correct_option_id"].Value<int>();
            if (jsonObject["explanation"] != null)
                Explanation = jsonObject["explanation"].Value<string>();
            if (jsonObject["explanation_entities"] != null)
                ExplanationEntities = MessageEntityInfo.ParseArray(jsonObject["explanation_entities"].Value<JArray>());
            if (jsonObject["open_period"] != null)
                OpenPeriod = jsonObject["open_period"].Value<int>();
            if (jsonObject["close_date"] != null)
                CloseDate = jsonObject["close_date"].Value<long>();
        }

        /// <summary>
        /// Unique poll identifier
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Poll question, 1-300 characters
        /// </summary>
        public string Question { get; private set; }

        /// <summary>
        /// List of poll options
        /// </summary>
        public PollOptionInfo[] Options { get; private set; }

        /// <summary>
        /// Total number of users that voted in the poll
        /// </summary>
        public int TotalVoterCount { get; private set; }

        /// <summary>
        /// True, if the poll is closed
        /// </summary>
        public bool IsClosed { get; private set; }

        /// <summary>
        /// True, if the poll is anonymous
        /// </summary>
        public bool IsAnonymous { get; private set; }

        /// <summary>
        /// Poll type, currently can be "regular" or "quiz"
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// True, if the poll allows multiple answers
        /// </summary>
        public bool AllowsMultipleAnswers { get; private set; }

        /// <summary>
        /// Optional. 0-based identifier of the correct answer option. Available only for polls in the quiz mode, which are closed, or was sent (not forwarded) by the bot or to the private chat with the bot.
        /// </summary>
        public int CorrectOptionId { get; private set; }

        /// <summary>
        /// Optional. Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll, 0-200 characters
        /// </summary>
        public string Explanation { get; private set; }

        /// <summary>
        /// Optional. Special entities like usernames, URLs, bot commands, etc. that appear in the explanation
        /// </summary>
        public MessageEntityInfo[] ExplanationEntities { get; private set; }

        /// <summary>
        /// Optional. Amount of time in seconds the poll will be active after creation
        /// </summary>
        public int OpenPeriod { get; private set; }

        /// <summary>
        /// Optional. Point in time (Unix timestamp) when the poll will be automatically closed
        /// </summary>
        public long CloseDate { get; private set; }
    }

    /// <summary>
    /// This object contains information about one answer option in a poll.
    /// See <see href="https://core.telegram.org/bots/api#polloption">API</see>
    /// </summary>
    public class PollOptionInfo
    {
        internal PollOptionInfo()
        {
        }

        internal PollOptionInfo(JObject jsonObject)
        {
            Text = jsonObject["text"].Value<string>();
            VoterCount = jsonObject["voter_count"].Value<int>();
        }

        /// <summary>
        /// Option text, 1-100 characters
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Number of users that voted for this option
        /// </summary>
        public int VoterCount { get; private set; }

        internal static PollOptionInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new PollOptionInfo(jobject)).ToArray();
        }
    }
}
