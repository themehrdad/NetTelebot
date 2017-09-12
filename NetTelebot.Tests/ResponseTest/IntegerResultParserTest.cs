using NetTelebot.Result;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class IntegerResultParserTest
    {
        /// <summary>
        /// Test for <see cref="IntegerResult"/> parse field.
        /// </summary>
        [Test]
        public static void IntegerResultTest()
        {
            const bool ok = true;
            const int result = 123;

            dynamic integerResultObject = IntegerResultObject.GetObject(ok, result);

            IntegerResult integerResult = new IntegerResult(integerResultObject.ToString());

            Assert.True(integerResult.Ok);
            Assert.AreEqual(result, integerResult.Result);
        }
    }
}
