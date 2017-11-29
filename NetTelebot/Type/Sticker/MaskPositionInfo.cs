using Newtonsoft.Json.Linq;

namespace NetTelebot.Type.Sticker
{
    /// <summary>
    /// This object describes the position on faces where a mask should be placed by default.
    /// See <see href="https://core.telegram.org/bots/api#maskposition">API</see>
    /// </summary>
    public class MaskPositionInfo
    {
        internal MaskPositionInfo()
        {
            //todo this
        }

        internal MaskPositionInfo(JObject jsonObject)
        {
            
        }

        public string Point { get; private set; }

        public float X_shift { get; private set;  }

        public float Y_shift { get; private set;  }

        public float Scale { get; private set;  }
    }
}
