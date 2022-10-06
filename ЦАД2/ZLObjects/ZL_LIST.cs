using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects
{
    public class ZL_LIST
    {
        public ZGLV ZGLV { get; set; } = new();

        public SCHET SCHET { get; set; } = new();

        [XmlElement]
        public List<ZAP> ZAP { get; set; } = new();

        public ZL_LIST() { }

        public ZL_LIST(ZGLV zGLV, SCHET sCHET, List<ZAP> zaps)
        {
            ZGLV = zGLV;
            SCHET = sCHET;
            ZAP = zaps;
        }




    }
}
