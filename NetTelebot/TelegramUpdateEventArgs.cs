using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class TelegramUpdateEventArgs : EventArgs
    {
        public TelegramUpdateEventArgs(UpdateInfo[] updates)
        {
            Updates = updates;
        }

        /// <summary>
        /// An array of incoming messages wrapped in UpdateInfo class.
        /// </summary>
        public UpdateInfo[] Updates { get; private set; }
    }
}
