using NetTelebot.Result;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class BooleanResultParserTest
    {
        /// <summary>
        /// Test for <see cref="BooleanResult"/> parse field.
        /// </summary>
        [Test]
        public static void BooleanResultTest()
        {
            const bool ok = true;
            const bool result = true;
           
            dynamic booleanResultObject = BooleanResultObject.GetObject(ok, result);

            BooleanResult booleanResult = new BooleanResult(booleanResultObject.ToString());

            Assert.True(booleanResult.Ok);
            Assert.True(booleanResult.Result);
        }
    }
}
