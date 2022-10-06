using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЦАД2.Objects
{
    public class ZGLV
    {
        //public string ZGLV { get; set; } = "Undefined";
        public string VERSION { get; set; } = "Undefined";
        public string DATA { get; set; } = "Undefined";
        public string FILENAME { get; set; } = "Undefined";
        public string SD_Z { get; set; } = "Undefined";

        public ZGLV(object vERSION, object dATA, object fILENAME, object sD_Z)
        {
            VERSION = vERSION.ToString()!;
            DATA = dATA.ToString()!;
            FILENAME = fILENAME.ToString()!;
            SD_Z = sD_Z.ToString()!;
        }

        public ZGLV() { }
    }
}
