using NetTelebot.Result;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class GetUserProfilePhotosResultParserTest
    {
        /// <summary>
        /// Test for <see cref="GetUserProfilePhotosResult"/> parse field.
        /// </summary>
        [Test]
        public static void GetUserProfilePhotosResultTest()
        {
            const int totalCount = 2;
            const string fieldId = "testFieldId";
            const int width = 123;
            const int height = 123;
            const int fileSize = 123;

            //create UserProfilePhotosInfo
            var photoArrayOne = new JArray(PhotoSizeInfoObject.GetObject(fieldId, width, height, fileSize));
            var photoArrayTwo = new JArray(PhotoSizeInfoObject.GetObject(fieldId, width, height, fileSize));
            var jArray = new JArray(photoArrayOne, photoArrayTwo);
            dynamic userProfilePhotosInfo = UserProfilePhotosInfoObject.GetObject(totalCount, jArray);

            //create GetUserProfilePhotosResult
            dynamic getUserProfileResult = GetUserProfilePhotosResultObject.GetObject(true, userProfilePhotosInfo);

            //create instance GetUserProfilePhotosResult
            var userProfile = new GetUserProfilePhotosResult(getUserProfileResult.ToString());

            Assert.Multiple(() =>
            {
                Assert.True(userProfile.Ok);

                Assert.AreEqual(userProfile.Result.TotalCount, totalCount);

                for (var i = 0; i < 1; i++)
                {
                    Assert.AreEqual(userProfile.Result.Photos[i][0].FileId, fieldId);
                    Assert.AreEqual(userProfile.Result.Photos[i][0].Width, width);
                    Assert.AreEqual(userProfile.Result.Photos[i][0].Height, height);
                    Assert.AreEqual(userProfile.Result.Photos[i][0].FileSize, fileSize);
                }
            });
        }
    }
}
