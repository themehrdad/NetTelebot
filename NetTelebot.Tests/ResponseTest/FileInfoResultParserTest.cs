using NetTelebot.Result;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class FileInfoResultParserTest
    {
        /// <summary>
        /// Test for <see cref="FileInfoResult"/> parse field.
        /// </summary>
        [Test]
        public static void UserInfoResultTest()
        {
            const bool ok = true;
            const string fileId = "fileId";
            const int fileSize = 123456;
            const string filePath = "/file/path";


            JObject fileInfo = FileInfoObject.GetObject(fileId, fileSize, filePath);

            dynamic fileInfoResultObject = FileInfoResultObject.GetObject(ok, fileInfo);

            FileInfoResult fileInfoResult = new FileInfoResult(fileInfoResultObject.ToString());

            Assert.AreEqual(ok, fileInfoResult.Ok);
            Assert.AreEqual(fileId, fileInfoResult.Result.FileId);
            Assert.AreEqual(fileSize, fileInfoResult.Result.FileSize);
            Assert.AreEqual(filePath, fileInfoResult.Result.FilePath);
        }
    }
}
