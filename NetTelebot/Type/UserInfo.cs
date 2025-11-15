using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents a Telegram user or bot.
    /// </summary>
    public class UserInfo
    {
        internal UserInfo()
        {
        }

        internal UserInfo(JObject jsonObject)
        {
            Id = jsonObject["id"].Value<long>();
            IsBot = jsonObject["is_bot"].Value<bool>();
            FirstName = jsonObject["first_name"].Value<string>();
            if (jsonObject["last_name"] != null)
                LastName = jsonObject["last_name"].Value<string>();
            if (jsonObject["username"] != null)
                UserName = jsonObject["username"].Value<string>();
            if (jsonObject["language_code"] != null)
                LanguageCode = jsonObject["language_code"].Value<string>();
            if (jsonObject["is_premium"] != null)
                IsPremium = jsonObject["is_premium"].Value<bool>();
            if (jsonObject["added_to_attachment_menu"] != null)
                AddedToAttachmentMenu = jsonObject["added_to_attachment_menu"].Value<bool>();
            if (jsonObject["can_join_groups"] != null)
                CanJoinGroups = jsonObject["can_join_groups"].Value<bool>();
            if (jsonObject["can_read_all_group_messages"] != null)
                CanReadAllGroupMessages = jsonObject["can_read_all_group_messages"].Value<bool>();
            if (jsonObject["supports_inline_queries"] != null)
                SupportsInlineQueries = jsonObject["supports_inline_queries"].Value<bool>();
            if (jsonObject["can_connect_to_business"] != null)
                CanConnectToBusiness = jsonObject["can_connect_to_business"].Value<bool>();
            if (jsonObject["has_main_web_app"] != null)
                HasMainWebApp = jsonObject["has_main_web_app"].Value<bool>();
        }

        /// <summary>
        /// Unique identifier for this user or bot
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// True, if this user is a bot
        /// </summary>
        public bool IsBot { get; private set;  }

        /// <summary>
        /// User‘s or bot’s first name
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Optional. User‘s or bot’s last name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Optional. User‘s or bot’s username
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Optional. IETF language tag of the user's language
        /// About <see href="https://en.wikipedia.org/wiki/IETF_language_tag">IETF language tag</see>
        /// </summary>
        public string LanguageCode { get; private set; }

        /// <summary>
        /// Optional. True, if this user is a Telegram Premium user
        /// </summary>
        public bool IsPremium { get; private set; }

        /// <summary>
        /// Optional. True, if this user added the bot to the attachment menu
        /// </summary>
        public bool AddedToAttachmentMenu { get; private set; }

        /// <summary>
        /// Optional. True, if the bot can be invited to groups. Returned only in getMe.
        /// </summary>
        public bool CanJoinGroups { get; private set; }

        /// <summary>
        /// Optional. True, if privacy mode is disabled for the bot. Returned only in getMe.
        /// </summary>
        public bool CanReadAllGroupMessages { get; private set; }

        /// <summary>
        /// Optional. True, if the bot supports inline queries. Returned only in getMe.
        /// </summary>
        public bool SupportsInlineQueries { get; private set; }

        /// <summary>
        /// Optional. True, if the bot can be connected to a Telegram Business account. Returned only in getMe.
        /// </summary>
        public bool CanConnectToBusiness { get; private set; }

        /// <summary>
        /// Optional. True, if the bot has a main Web App. Returned only in getMe.
        /// </summary>
        public bool HasMainWebApp { get; private set; }

        internal static UserInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new UserInfo(jobject)).ToArray();
        }
    }
}
