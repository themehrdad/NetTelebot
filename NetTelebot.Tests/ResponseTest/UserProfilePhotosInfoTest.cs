using NetTelebot.BotEnum;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    internal static class UserProfilePhotosInfoTest
    {
        //todo add tests
        /// <summary>
        /// Test for <see cref="UserProfilePhotosInfo"/> parse field.
        /// </summary>
        [Test, Ignore("In process")]
        public static void UpdateInfoTest()
        {
            const int totalCount = 123;
            const string fieldId = "testFieldId";
            const int width = 123;
            const int height = 123;
            const int fileSize = 123;

            JArray photoArray = new JArray( new JArray(PhotoSizeInfoObject.GetObject(fieldId, width, height, fileSize).ToString(), 
                PhotoSizeInfoObject.GetObject(fieldId, width, height, fileSize).ToString()));

            dynamic userProfilePhotos = UserProfilePhotosInfoObject.GetObject(totalCount, photoArray);

            UserProfilePhotosInfo userProfile = new UserProfilePhotosInfo(userProfilePhotos);

            Assert.AreEqual(userProfile.TotalCount, totalCount);
            Assert.AreEqual(userProfile.Photos[0][0].FileId, fieldId);
            Assert.AreEqual(userProfile.Photos[0][0].Width, width);
            Assert.AreEqual(userProfile.Photos[0][0].Height, height);
            Assert.AreEqual(userProfile.Photos[0][0].FileSize, fileSize);
        }


    }
}
