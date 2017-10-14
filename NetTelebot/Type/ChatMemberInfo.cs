using System;
using System.Linq;
using NetTelebot.BotEnum;
using NetTelebot.Extension;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object contains information about one member of a chat.
    /// See <see cref="https://core.telegram.org/bots/api#chatmember">API</see>
    /// </summary>
    public class ChatMemberInfo
    {
        internal ChatMemberInfo(JObject jsonObject)
        {
            User = new UserInfo(jsonObject["user"].Value<JObject>());
            Status = jsonObject["status"].Value<string>().ToEnum<Status>();

            if (jsonObject["until_date"] != null)
            {
                UntilDateUnix = jsonObject["until_date"].Value<long>();
                UntilDate = UntilDateUnix.ToDateTime();
            }

            if (jsonObject["can_be_edited"] != null)
                CanBeEdited = jsonObject["can_be_edited"].Value<bool>();
            if (jsonObject["can_change_info"] != null)
                CanChangeInfo = jsonObject["can_change_info"].Value<bool>();
            if (jsonObject["can_post_messages"] != null)
                CanPostMessages = jsonObject["can_post_messages"].Value<bool>();
            if (jsonObject["can_edit_messages"] != null)
                CanEditMessages = jsonObject["can_edit_messages"].Value<bool>();
            if (jsonObject["can_delete_messages"] != null)
                CanDeleteMessages = jsonObject["can_delete_messages"].Value<bool>();
            if (jsonObject["can_invite_users"] != null)
                CanInviteUsers = jsonObject["can_invite_users"].Value<bool>();
            if (jsonObject["can_restrict_members"] != null)
                CanRestrictMembers = jsonObject["can_restrict_members"].Value<bool>();
            if (jsonObject["can_pin_messages"] != null)
                CanPinMessages = jsonObject["can_pin_messages"].Value<bool>();
            if (jsonObject["can_promote_members"] != null)
                CanPromoteMembers = jsonObject["can_promote_members"].Value<bool>();
            if (jsonObject["can_send_messages"] != null)
                CanSendMessages = jsonObject["can_send_messages"].Value<bool>();
            if (jsonObject["can_send_media_messages"] != null)
                CanSendMediaMessages = jsonObject["can_send_media_messages"].Value<bool>();
            if (jsonObject["can_send_other_messages"] != null)
                CanSendOtherMessages = jsonObject["can_send_other_messages"].Value<bool>();
            if (jsonObject["can_add_web_page_previews"] != null)
                CanAddWebPagePreviews = jsonObject["can_add_web_page_previews"].Value<bool>();
        }

        /// <summary>
        /// Parses the array.
        /// </summary>
        /// <param name="jsonArray">The json array.</param>
        /// <returns></returns>
        internal static ChatMemberInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new ChatMemberInfo(jobject)).ToArray();
        }

        /// <summary>
        /// Information about the user
        /// </summary>
        public UserInfo User { get; private set; }

        /// <summary>
        /// The member's status in the chat. Can be “creator”, “administrator”, “member”, “restricted”, “left” or “kicked”
        /// </summary>
        public Status? Status { get; private set; }

        /// <summary>
        /// Optional. 
        /// Restictred and kicked only. Date when restrictions will be lifted for this user, unix time
        /// </summary>
        public long UntilDateUnix { get; private set; }

        /// <summary>
        /// Restictred and kicked only. Date when restrictions will be lifted for this user.
        /// </summary>
        public DateTime UntilDate { get; private set; }

        /// <summary>
        /// Optional. 
        /// Administrators only. True, if the bot is allowed to edit administrator privileges of that user
        /// </summary>
        public bool CanBeEdited { get; private set; }

        /// <summary>
        /// Optional. 
        /// Administrators only. True, if the administrator can change the chat title, photo and other settings
        /// </summary>
        public bool CanChangeInfo { get; private set; }

        /// <summary>
        /// Optional. 
        /// Administrators only. True, if the administrator can post in the channel, channels only
        /// </summary>
        public bool CanPostMessages { get; private set; }

        /// <summary>
        /// Optional. 
        /// Administrators only. True, if the administrator can edit messages of other users, channels only
        /// </summary>
        public bool CanEditMessages { get; private set; }

        /// <summary>
        /// Optional. 
        /// Administrators only. True, if the administrator can delete messages of other users
        /// </summary>
        public bool CanDeleteMessages { get; private set; }

        /// <summary>
        /// Optional. 
        /// Administrators only. True, if the administrator can invite new users to the chat
        /// </summary>
        public bool CanInviteUsers { get; private set; }

        /// <summary>
        /// Optional. 
        /// Administrators only. True, if the administrator can restrict, ban or unban chat members
        /// </summary>
        public bool CanRestrictMembers { get; private set; }

        /// <summary>
        /// Optional. 
        /// Administrators only. True, if the administrator can pin messages, supergroups only
        /// </summary>
        public bool CanPinMessages { get; private set; }

        /// <summary>
        /// Optional. 
        /// Administrators only. 
        /// True, if the administrator can add new administrators with a subset of his own privileges or demote administrators that he has promoted, directly or indirectly 
        /// (promoted by administrators that were appointed by the user)
        /// </summary>
        public bool CanPromoteMembers { get; private set; }

        /// <summary>
        /// Optional. 
        /// Restricted only. True, if the user can send text messages, contacts, locations and venues
        /// </summary>
        public bool CanSendMessages { get; private set; }

        /// <summary>
        /// Optional. 
        /// Restricted only. True, if the user can send audios, documents, photos, videos, video notes and voice notes, implies can_send_messages
        /// </summary>
        public bool CanSendMediaMessages { get; private set; }

        /// <summary>
        /// Optional. 
        /// Restricted only. True, if the user can send animations, games, stickers and use inline bots, implies can_send_media_messages
        /// </summary>
        public bool CanSendOtherMessages { get; private set; }

        /// <summary>
        /// Optional. 
        /// Restricted only. True, if user may add web page previews to his messages, implies can_send_media_messages
        /// </summary>
        public bool CanAddWebPagePreviews { get; private set; }
    }
}
