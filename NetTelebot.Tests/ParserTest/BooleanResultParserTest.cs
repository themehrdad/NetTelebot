using NetTelebot.Result;
using NetTelebot.Tests.ResultTestObject;
using NUnit.Framework;

namespace NetTelebot.Tests.ParserTest
{
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
           
            dynamic booleanResultObject = BooleanResultObect.GetObject(ok, result);

            BooleanResult booleanResult = new BooleanResult(booleanResultObject);

            Assert.True(booleanResult.Ok);
            Assert.True(booleanResult.Result);
        }
    }
}
