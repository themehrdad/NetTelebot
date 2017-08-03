using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class ChatPhotoInfoObject
    {
        /// <summary>
        /// This object represents a chat photo.
        /// </summary>
        /// <param name="SmallFileId">Unique file identifier of small (160x160) chat photo. This file_id can be used only for photo download.</param>
        /// <param name="BigFileId">Unique file identifier of big (640x640) chat photo. This file_id can be used only for photo download.</param>
        /// <returns></returns>
        internal static JObject GetObject(string SmallFileId, string BigFileId)
        {
            dynamic chatPhoto = new JObject();

            chatPhoto.small_file_id = SmallFileId;
            chatPhoto.big_file_id = BigFileId;

            return chatPhoto;
        }
    }
}