using NetTelebot.Type.Sticker;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Tests.TypeTestObject
{
    internal static class MaskPositionInfoObject
    {
        /// <summary>
        /// This object describes the position on faces where a mask should be placed by default.
        /// See <see href="https://core.telegram.org/bots/api#maskposition">API</see>
        /// </summary>
        /// <param name="point">The part of the face relative to which the mask should be placed. One of “forehead”, “eyes”, “mouth”, or “chin”.</param>
        /// <param name="x_shift">Shift by X-axis measured in widths of the mask scaled to the face size, from left to right. 
        /// For example, choosing -1.0 will place mask just to the left of the default mask position.</param>
        /// <param name="y_shift">Shift by Y-axis measured in heights of the mask scaled to the face size, from top to bottom. 
        /// For example, 1.0 will place the mask just below the default mask position.</param>
        /// <param name="scale">Mask scaling coefficient. For example, 2.0 means double size.</param>
        /// <returns><see cref="MaskPositionInfo"/></returns>
        internal static JObject GetObject(string point, double x_shift, double y_shift, double scale)
        {
            dynamic maskPositionInfo = new JObject();

            maskPositionInfo.point = point;
            maskPositionInfo.x_shift = x_shift;
            maskPositionInfo.y_shift = y_shift;
            maskPositionInfo.scale = scale;

            return maskPositionInfo;
        }
    }
}
