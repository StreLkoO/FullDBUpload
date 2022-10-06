using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl
{
    public class SL_KOEF : IObjects
    {
        public string IDSL { get; set; } = "1";
        public string Z_SL { get; set; } = "Undefined";
        [XmlIgnore]
        public string? sl_id { get; set; }

        public SL_KOEF(object z_SL)
        {
            Z_SL = z_SL.ToString()!;
        }

        public void SLKOEFFill(object idsl, object z_SL, object slid)
        {
            IDSL = idsl.ToString()!;
            Z_SL = z_SL.ToString()!.Replace(",", ".");
            sl_id = slid.ToString()!;
        }

        public SL_KOEF() { }

        public bool IsEmpty()
        {
            return Z_SL == null || Z_SL == "0";
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.SLKOEFFill(n[0], n[1], n[2]);
        }
    }
}
