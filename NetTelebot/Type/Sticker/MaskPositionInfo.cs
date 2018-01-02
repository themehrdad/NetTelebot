using NetTelebot.BotEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetTelebot.Type.Sticker
{
    /// <summary>
    /// This object describes the position on faces where a mask should be placed by default.
    /// See <see href="https://core.telegram.org/bots/api#maskposition">API</see>
    /// </summary>
    public class MaskPositionInfo
    {
        /// <summary>
        /// The part of the face relative to which the mask should be placed. 
        /// One of “forehead”, “eyes”, “mouth”, or “chin”.
        /// </summary>
        [JsonProperty("point", Required = Required.Always), JsonConverter(typeof(StringEnumConverter))]
        public Point? Point { get;  set; }

        /// <summary>
        /// Shift by X-axis measured in widths of the mask scaled to the face size, from left to right. 
        /// For example, choosing -1.0 will place mask just to the left of the default mask position.
        /// </summary>
        [JsonProperty("x_shift", Required = Required.Always)]
        public double XShift { get; set; }

        /// <summary>
        /// Shift by Y-axis measured in heights of the mask scaled to the face size, from top to bottom. 
        /// For example, 1.0 will place the mask just below the default mask position.
        /// </summary>
        [JsonProperty("y_shift", Required = Required.Always)]
        public double YShift { get; set; }

        /// <summary>
        /// Mask scaling coefficient. For example, 2.0 means double size.
        /// </summary>
        [JsonProperty("scale", Required = Required.Always)]
        public double Scale { get; set; }
    }
}
