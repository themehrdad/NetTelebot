using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    public class NewFile : IFile
    {
        public byte[] FileContent { get; set; }
        public string FileName { get; set; }
    }
}
