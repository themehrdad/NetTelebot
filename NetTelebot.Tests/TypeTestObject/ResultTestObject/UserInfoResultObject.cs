using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal static class UserInfoResultObject
    {
        /// <summary>
        /// Object represent this type <see cref="UserInfoObject"/>
        /// </summary>
        internal static JObject GetObject(bool ok, JObject result)
        {
            dynamic getUpadtes = new JObject();

            getUpadtes.ok = ok;
            getUpadtes.result = result;

            return getUpadtes;
        }
    }
}
