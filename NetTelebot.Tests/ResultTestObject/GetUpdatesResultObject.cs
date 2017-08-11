using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.ResultTestObject
{
    internal static class GetUpdatesResultObject
    {
        internal static JObject GetObject(bool ok, JArray result)
        {
            dynamic getUpadtes = new JObject();

            getUpadtes.ok = ok;
            getUpadtes.result = result;

            return getUpadtes;
        }

    }
}
