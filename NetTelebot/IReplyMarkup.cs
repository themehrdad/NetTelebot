using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    /// <summary>
    /// This interface is used to specify reply_markup parameter when sending a message. It can be a ReplyKeyboardMarkup, ReplyKeyboardHideMarkup and ForceReplyMarkup.
    /// </summary>
    public interface IReplyMarkup
    {
        string GetJson();
    }
}
