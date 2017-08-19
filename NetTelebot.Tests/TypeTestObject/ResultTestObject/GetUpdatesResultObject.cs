using NetTelebot.Result;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal static class GetUpdatesResultObject
    {
        /// <summary>
        /// Object represent this type <see cref="GetUpdatesResult"/>
        /// </summary>
        internal static JObject GetObject(bool ok, JArray result)
        {
            dynamic getUpadtes = new JObject();

            getUpadtes.ok = ok;
            getUpadtes.result = result;

            return getUpadtes;
        }
    }
}
