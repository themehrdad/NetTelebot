using NetTelebot.Result;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal static class GetUserProfilePhotosResultObject
    {
        /// <summary>
        /// Object represent this type <see cref="GetUserProfilePhotosResult"/>
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
