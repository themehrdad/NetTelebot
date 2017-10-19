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
        /// <param name="untilDateUnix">Optional. 
        /// Restictred and kicked only. Date when restrictions will be lifted for this user, unix time</param>
        /// <param name="canBeEdited">Optional. 
        /// Administrators only. True, if the bot is allowed to edit administrator privileges of that user</param>
        /// <param name="canChangeInfo">Optional. 
        /// Administrators only. True, if the administrator can change the chat title, photo and other settings</param>
        /// <param name="canPostMessages">Optional. 
        /// Administrators only. True, if the administrator can post in the channel, channels only</param>
        /// <param name="canEditMessages">Optional. 
        /// Administrators only. True, if the administrator can edit messages of other users, channels only</param>
        /// <param name="canDeleteMessages">Optional. 
        /// Administrators only. True, if the administrator can delete messages of other users</param>
        /// <param name="canInviteUsers">Optional. 
        /// Administrators only. True, if the administrator can invite new users to the chat</param>
        /// <param name="canRestrictMembers">Optional. 
        /// Administrators only. True, if the administrator can restrict, ban or unban chat members</param>
        /// <param name="canPinMessages">Optional. 
        /// Administrators only. True, if the administrator can pin messages, supergroups only</param>
        /// <param name="canPromoteMembers">Optional. 
        /// Administrators only. True, if the administrator can add new administrators with a subset of his own privileges or demote administrators that 
        /// he has promoted, directly or indirectly (promoted by administrators that were appointed by the user)</param>
        /// <param name="canSendMessages">Optional. 
        /// Restricted only. True, if the user can send text messages, contacts, locations and venues</param>
        /// <param name="canSendMediaMessages">Optional. 
        /// Restricted only. True, if the user can send audios, documents, photos, videos, video notes and voice notes, implies can_send_messages</param>
        /// <param name="canSendOtherMessages">Optional. 
        /// Restricted only. True, if the user can send animations, games, stickers and use inline bots, implies can_send_media_messages</param>
        /// <param name="canAddWebPagePreviews">Optional. 
        /// Restricted only. True, if user may add web page previews to his messages, implies can_send_media_messages</param>
        /// <returns><see cref="ChatMemberInfo"/>
        /// </returns>
        internal static JObject GetObject(JObject user, string status, 
            int? untilDateUnix = null, 
            bool? canBeEdited = null,
            bool? canChangeInfo = null, 
            bool? canPostMessages = null, 
            bool? canEditMessages = null, 
            bool? canDeleteMessages = null, 
            bool? canInviteUsers = null,
            bool? canRestrictMembers = null,
            bool? canPinMessages = null, 
            bool? canPromoteMembers = null, 
            bool? canSendMessages = null, 
            bool? canSendMediaMessages = null, 
            bool? canSendOtherMessages = null, 
            bool? canAddWebPagePreviews= null)
        {
            dynamic chatMemberInfo = new JObject();

            chatMemberInfo.user = user;
            chatMemberInfo.status = status;

            if (untilDateUnix != null)
                chatMemberInfo.until_date = untilDateUnix;
            if (canBeEdited != null)
                chatMemberInfo.can_be_edited = canBeEdited;
            if (canChangeInfo != null)
                chatMemberInfo.can_change_info = canChangeInfo;
            if (canPostMessages != null)
                chatMemberInfo.can_post_messages = canPostMessages;
            if (canEditMessages != null)
                chatMemberInfo.can_edit_messages = canEditMessages;
            if (canDeleteMessages != null)
                chatMemberInfo.can_delete_messages = canDeleteMessages;
            if (canInviteUsers != null)
                chatMemberInfo.can_invite_users = canInviteUsers;
            if (canRestrictMembers != null)
                chatMemberInfo.can_restrict_members = canRestrictMembers;
            if (canPinMessages != null)
                chatMemberInfo.can_pin_messages = canPinMessages;
            if (canPromoteMembers != null)
                chatMemberInfo.can_promote_members = canPromoteMembers;
            if (canSendMessages != null)
                chatMemberInfo.can_send_messages = canSendMessages;
            if (canSendMediaMessages != null)
                chatMemberInfo.can_send_media_messages = canSendMediaMessages;
            if (canSendOtherMessages != null)
                chatMemberInfo.can_send_other_messages = canSendOtherMessages;
            if (canAddWebPagePreviews != null)
                chatMemberInfo.can_add_web_page_previews = canAddWebPagePreviews;

            return chatMemberInfo;
        }
    }
}
