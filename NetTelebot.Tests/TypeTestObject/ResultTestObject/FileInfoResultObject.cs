using NetTelebot.Result;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject.ResultTestObject
{
    internal static class FileInfoResultObject
    {
        /// <summary>
        /// Object represent this type <see cref="FileInfoResult"/>
        /// </summary>
        internal static JObject GetObject(bool ok, JObject result)
        {
            dynamic fileInfoResult = new JObject();

            fileInfoResult.ok = ok;
            fileInfoResult.result = result;

            return fileInfoResult;
        }
    }
}
