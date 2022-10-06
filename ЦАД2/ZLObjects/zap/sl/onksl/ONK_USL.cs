using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl.onksl
{
    public class ONK_USL : IObjects
    {
        public string USL_TIP { get; set; } = "Undefined";
        public string? HIR_TIP { get; set; } = "";
        public string? LEK_TIP_L { get; set; } = "";
        public string? LEK_TIP_V { get; set; } = "";
        [XmlElement]
        public List<LEK_PR> LEK_PR { get; set; } = new();
        public string? PPTR { get; set; }
        public string? LUCH_TIP { get; set; } = "";
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public ONK_USL(object uSL_TIP, object hIR_TIP, object lEK_TIP_L, object lEK_TIP_V,
            object pPTR, object lUCH_TIP, object sl_id)
        {
            this.ONK_USLFill(uSL_TIP, hIR_TIP, lEK_TIP_L, lEK_TIP_V, pPTR, lUCH_TIP, sl_id);
        }

        public void ONK_USLFill(object uSL_TIP, object hIR_TIP, object lEK_TIP_L, object lEK_TIP_V,
            object pPTR, object lUCH_TIP, object sl_id)
        {
            USL_TIP = uSL_TIP.ToString()!;
            HIR_TIP = hIR_TIP.ToString();
            LEK_TIP_L = lEK_TIP_L.ToString();
            LEK_TIP_V = lEK_TIP_V.ToString();
            PPTR = string.IsNullOrEmpty(pPTR.ToString()) || pPTR.ToString()!.Equals("0") ? null : pPTR.ToString();
            LUCH_TIP = lUCH_TIP.ToString();
            SL_ID = sl_id.ToString()!;
        }

        public ONK_USL() { }

        public override void Fill(object[] n, TypeFile t)
        {
            this.ONK_USLFill(n[0], n[1], n[2], n[3],
                             n[4], n[5], n[6]);
        }
    }
}
