using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal static class IntegerResultObject
    {
        /// <summary>
        /// Object represent this type <see cref="IntegerResultObject"/>
        /// </summary>s
        internal static JObject GetObject(bool ok, int result)
        {
            dynamic integerResult = new JObject();

            integerResult.ok = ok;
            integerResult.result = result;

            return integerResult;
        }
    }
}
