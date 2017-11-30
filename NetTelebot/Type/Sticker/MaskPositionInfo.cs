using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Sticker
{
    /// <summary>
    /// This object describes the position on faces where a mask should be placed by default.
    /// See <see href="https://core.telegram.org/bots/api#maskposition">API</see>
    /// </summary>
    public class MaskPositionInfo
    {
        internal MaskPositionInfo(JObject jsonObject)
        {
            Point = jsonObject["point"].Value<string>();
            X_shift = jsonObject["x_shift"].Value<double>();
            Y_shift = jsonObject["y_shift"].Value<double>();
            Scale = jsonObject["scale"].Value<double>();
        }

        /// <summary>
        /// The part of the face relative to which the mask should be placed. 
        /// One of “forehead”, “eyes”, “mouth”, or “chin”.
        /// //todo need enum
        /// </summary>
        public string Point { get; private set; }

        /// <summary>
        /// Shift by X-axis measured in widths of the mask scaled to the face size, from left to right. 
        /// For example, choosing -1.0 will place mask just to the left of the default mask position.
        /// </summary>
        public double X_shift { get; private set;  }

        /// <summary>
        /// Shift by Y-axis measured in heights of the mask scaled to the face size, from top to bottom. 
        /// For example, 1.0 will place the mask just below the default mask position.
        /// </summary>
        public double Y_shift { get; private set;  }

        /// <summary>
        /// Mask scaling coefficient. For example, 2.0 means double size.
        /// </summary>
        public double Scale { get; private set;  }
    }
}
