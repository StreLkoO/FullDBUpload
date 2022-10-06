using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl.onksl
{
    public class B_PROT : IObjects
    {
        public string? PROT { get; set; } 
        public string? D_PROT { get; set; }
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public B_PROT(object pROT, object d_PROT, object sl_id)
        {
            PROT = string.IsNullOrEmpty(pROT.ToString()) ? null : pROT.ToString()!;
            D_PROT = string.IsNullOrEmpty(d_PROT.ToString()) ? null : d_PROT.ToString()!;
            SL_ID = sl_id.ToString()!;
        }

        public B_PROT() { }

        public override void Fill(object[] n, TypeFile t)
        {
            PROT = string.IsNullOrEmpty(n[0].ToString()) ? null : n[0].ToString()!;
            D_PROT = string.IsNullOrEmpty(n[1].ToString()) ? null : n[1].ToString()!;
            SL_ID = n[2].ToString()!;
        }
    }
}
