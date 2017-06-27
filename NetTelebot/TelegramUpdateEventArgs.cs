using System;

namespace NetTelebot
{
    public class TelegramUpdateEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramUpdateEventArgs"/> class.
        /// </summary>
        /// <param name="updates">The updates.</param>
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
