using NetTelebot.Result;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal static class BooleanResultObject
    {
        /// <summary>
        /// Object represent this type <see cref="BooleanResult"/>
        /// </summary>
        internal static JObject GetObject(bool ok, bool result)
        {
            dynamic booleanResult = new JObject();

            booleanResult.ok = ok;
            booleanResult.result = result;

            return booleanResult;
        }
    }
}
