using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    /// <summary>
    /// Use this enum when you need to tell the user that something is happening on the bot's side. The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
    /// </summary>
    public enum ChatActions
    {
        Typing,
        Upload_photo,
        Record_video,
        Upload_video,
        Record_audio,
        Upload_audio,
        Upload_document,
        Find_location
    }
}
