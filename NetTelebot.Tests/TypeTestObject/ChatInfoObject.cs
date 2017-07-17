using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal sealed class ChatInfoObject
    {
        internal static JObject GetObject(int id, string type, string title, string username,
            string firstName, string lastName, bool allMembersAreAdministrators, ChatPhotoInfoObject photo,
            string description, string inviteLink)
        {
            dynamic chat = new JObject();

            chat.id = id;
            chat.type = type;
            chat.title = title;
            chat.username = username;
            chat.first_name = firstName;
            chat.last_name = lastName;
            chat.all_members_are_administrators = allMembersAreAdministrators;
            chat.photo = photo;
            chat.description = description;
            chat.invite_link = inviteLink;

            return chat;
        }
    }
}