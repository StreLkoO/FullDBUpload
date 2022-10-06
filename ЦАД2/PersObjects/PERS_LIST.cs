using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ЦАД2.Objects;

namespace ЦАД2.PersObjects
{
    public class PERS_LIST
    {
        public ZGLV_P ZGLV { get; set; } = new();
        [XmlElement]
        public PERS PERS { get; set; } = new();

        public PERS_LIST() { }

        public PERS_LIST(ZGLV_P z, PERS p)
        {
            this.ZGLV = z;
            this.PERS = p;
        }


    }
}
