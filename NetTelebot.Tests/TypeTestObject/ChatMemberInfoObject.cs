using NetTelebot.Type;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class ChatMemberInfoObject
    {
        /// <summary>
        /// This object contains information about one member of a chat.
        /// </summary>
        /// <param name="user">Information about the user</param>
        /// <param name="status">The member's status in the chat. Can be “creator”, “administrator”, “member”, “restricted”, “left” or “kicked”</param>
        /// <param name="untilDateUnix">Optional. Restictred and kicked only. Date when restrictions will be lifted for this user, unix time</param>
        /// <param name="canBeEdited">Optional. Administrators only. True, if the bot is allowed to edit administrator privileges of that user</param>
        /// <param name="canChangeInfo">Optional. Administrators only. True, if the administrator can change the chat title, photo and other settings</param>
        /// <param name="canPostMessages">Optional. Administrators only. True, if the administrator can post in the channel, channels only</param>
        /// <param name="canEditMessages">Optional. Administrators only. True, if the administrator can edit messages of other users, channels only</param>
        /// <param name="canDeleteMessages">Optional. Administrators only. True, if the administrator can delete messages of other users</param>
        /// <param name="canInviteUsers">Optional. Administrators only. True, if the administrator can invite new users to the chat</param>
        /// <param name="canRestrictMembers">Optional. Administrators only. True, if the administrator can restrict, ban or unban chat members</param>
        /// <param name="canPinMessages">Optional. Administrators only. True, if the administrator can pin messages, supergroups only</param>
        /// <param name="canPromoteMembers">Optional. Administrators only. True, if the administrator can add new administrators with a subset of his own privileges or demote administrators that he has promoted, directly or indirectly (promoted by administrators that were appointed by the user)</param>
        /// <param name="canSendMessages">Optional. Restricted only. True, if the user can send text messages, contacts, locations and venues</param>
        /// <param name="canSendMediaMessages">Optional. Restricted only. True, if the user can send audios, documents, photos, videos, video notes and voice notes, implies can_send_messages</param>
        /// <param name="canSendOtherMessages">Optional. Restricted only. True, if the user can send animations, games, stickers and use inline bots, implies can_send_media_messages</param>
        /// <param name="canAddWebPagePreviews">Optional. Restricted only. True, if user may add web page previews to his messages, implies can_send_media_messages</param>
        /// <returns><see cref="ChatMemberInfo"/>
        /// </returns>
        internal static JObject GetObject(JObject user, string status, int untilDateUnix, bool canBeEdited,
            bool canChangeInfo, bool canPostMessages, bool canEditMessages, bool canDeleteMessages, bool canInviteUsers,
            bool canRestrictMembers, bool canPinMessages, bool canPromoteMembers, bool canSendMessages, 
            bool canSendMediaMessages, bool canSendOtherMessages, bool canAddWebPagePreviews)
        {
            dynamic chatMemberInfo = new JObject();

            chatMemberInfo.user = user;
            chatMemberInfo.status = status;
            chatMemberInfo.until_date = untilDateUnix;
            chatMemberInfo.can_be_edited = canBeEdited;
            chatMemberInfo.can_change_info = canChangeInfo;
            chatMemberInfo.can_post_messages = canPostMessages;
            chatMemberInfo.can_edit_messages = canEditMessages;
            chatMemberInfo.can_delete_messages = canDeleteMessages;
            chatMemberInfo.can_invite_users = canInviteUsers;
            chatMemberInfo.can_restrict_members = canRestrictMembers;
            chatMemberInfo.can_pin_messages = canPinMessages;
            chatMemberInfo.can_promote_members = canPromoteMembers;
            chatMemberInfo.can_send_messages = canSendMessages;
            chatMemberInfo.can_send_media_messages = canSendMediaMessages;
            chatMemberInfo.can_send_other_messages = canSendOtherMessages;
            chatMemberInfo.can_add_web_page_previews = canAddWebPagePreviews;

            return chatMemberInfo;
        }
    }
}
