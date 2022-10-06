using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЦАД2.Objects
{
    public class ZGLV_P
    {
        //public string ZGLV { get; set; } = "Undefined";
        public string VERSION { get; set; } = "Undefined";
        public string DATA { get; set; } = "Undefined";
        public string FILENAME { get; set; } = "Undefined";
        public string FILENAME1 { get; set; } = "Undefined";


        public ZGLV_P(object vERSION, object dATA, object fILENAME, object fILENAME1)
        {
            VERSION = vERSION.ToString()!;
            DATA = dATA.ToString()!;
            FILENAME = fILENAME.ToString()!;
            FILENAME1 = fILENAME1.ToString()!;
        }

        public ZGLV_P() { }
    }
}
