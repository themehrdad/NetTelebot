using NetTelebot.BotEnum;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class ChatInfoObject
    {

        /// <summary>
        /// This object represents a chat. Used to test the parser.
        /// </summary>
        /// <param name="id">Unique identifier for this chat. This number may be greater than 32 bits and some programming languages may have 
        /// difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision float 
        /// type are safe for storing this identifier</param>
        /// <param name="type">Type of chat, can be either “private”, “group”, “supergroup” or “channel”</param>
        /// <returns><see cref="Type.ChatInfo"/></returns>
        internal static JObject GetMinimalMandatoryObject(int id, ChatType type)
        {
            dynamic chat = new JObject();

            chat.id = id;
            chat.type = type;

            return chat;
  
        }

        /// <summary>
        /// This object represents a chat. Used to test the parser.
        /// </summary>
        /// <param name="id">Unique identifier for this chat. This number may be greater than 32 bits and some programming languages may have 
        /// difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision float 
        /// type are safe for storing this identifier.</param>
        /// <param name="type">Type of chat, can be either “private”, “group”, “supergroup” or “channel”</param>
        /// <param name="title">Optional. Title, for supergroups, channels and group chats</param>
        /// <param name="username">Optional. Username, for private chats, supergroups and channels if available</param>
        /// <param name="firstName">Optional. First name of the other party in a private chat</param>
        /// <param name="lastName">Optional. Last name of the other party in a private chat</param>
        /// <param name="allMembersAreAdministrators">Optional. True if a group has ‘All Members Are Admins’ enabled.</param>
        /// <param name="photo">Optional. Chat photo. Returned only in getChat.</param>
        /// <param name="description">Optional. Description, for supergroups and channel chats. Returned only in getChat.</param>
        /// <param name="inviteLink">Optional. Chat invite link, for supergroups and channel chats. Returned only in getChat.</param>
        /// <returns><see cref="Type.ChatInfo"/></returns>
        internal static JObject GetObject(object id, string type, 
            string title = null, 
            string username = null,
            string firstName = null, 
            string lastName = null, 
            bool? allMembersAreAdministrators = null,
            JObject photo = null,
            string description = null, 
            string inviteLink = null)
        {
            dynamic chat = new JObject();

            if (id != null)
                chat.id = id;
            if (type != null)
                chat.type = type;
            if (title != null)
                chat.title = title;
            if (username != null)
                chat.username = username;
            if (firstName != null)
                chat.first_name = firstName;
            if (lastName != null)
                chat.last_name = lastName;
            if (allMembersAreAdministrators != null)
                chat.all_members_are_administrators = allMembersAreAdministrators;
            if (photo != null)
                chat.photo = photo;
            if (description != null)
                chat.description = description;
            if (inviteLink != null)
                chat.invite_link = inviteLink;

            return chat;
        }
    }
}