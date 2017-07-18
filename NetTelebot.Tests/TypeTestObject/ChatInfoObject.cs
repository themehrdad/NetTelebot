using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal sealed class ChatInfoObject
    {
        internal static JObject GetObject(int id, string type, 
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

            chat.id = id;
            chat.type = type;
            chat.title = title;
            chat.username = username;
            chat.first_name = firstName;
            chat.last_name = lastName;

            //todo if null = null reference exception
            if (allMembersAreAdministrators != null)
                chat.all_members_are_administrators = allMembersAreAdministrators;
            if (photo != null)
                chat.photo = photo;

            chat.description = description;
            chat.invite_link = inviteLink;

            return chat;
        }
    }
}