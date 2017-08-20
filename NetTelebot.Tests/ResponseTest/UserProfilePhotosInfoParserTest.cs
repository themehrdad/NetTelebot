using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Type;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class UserProfilePhotosInfoParserTest
    {
        /// <summary>
        /// Test for <see cref="UserProfilePhotosInfo"/> parse field.
        /// </summary>
        [Test]
        public static void UserProfilePhotosInfoTest()
        {
            const int totalCount = 2;
            const string fieldId = "testFieldId";
            const int width = 123;
            const int height = 123;
            const int fileSize = 123;

            var photoArrayOne = new JArray(PhotoSizeInfoObject.GetObject(fieldId, width, height, fileSize));
            var photoArrayTwo = new JArray(PhotoSizeInfoObject.GetObject(fieldId, width, height, fileSize));
            
            var jArray = new JArray(photoArrayOne, photoArrayTwo);

            dynamic userProfilePhotos = UserProfilePhotosInfoObject.GetObject(totalCount, jArray);

            var userProfile = new UserProfilePhotosInfo(userProfilePhotos);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(userProfile.TotalCount, totalCount);

                for (var i = 0; i < 1; i++)
                {
                    Assert.AreEqual(userProfile.Photos[i][0].FileId, fieldId);
                    Assert.AreEqual(userProfile.Photos[i][0].Width, width);
                    Assert.AreEqual(userProfile.Photos[i][0].Height, height);
                    Assert.AreEqual(userProfile.Photos[i][0].FileSize, fileSize);
                }
            });
        }
    }
}
