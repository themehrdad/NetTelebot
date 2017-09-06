using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class UserProfilePhotosInfoObject
    {
        internal static JObject GetObject(int totalCount, JArray photos)
        {
            dynamic userProfilePhotosInfo = new JObject();

            userProfilePhotosInfo.total_count = totalCount;
            userProfilePhotosInfo.photos = photos;
            
            return userProfilePhotosInfo;
        }
    }
}
