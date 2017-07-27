using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.ResultTestObject
{
    internal static class BooleanResultObect
    {

        internal static JObject GetObject(bool ok, bool result)
        {
            dynamic booleanResult = new JObject();

            booleanResult.ok = ok;
            booleanResult.result = result;

            return booleanResult;
        }
    }
}
