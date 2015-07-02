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
        public UpdateInfo[] Updates { get; private set; }
    }
}
