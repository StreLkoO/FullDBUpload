using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl.ONKSL
{
    public class NAPR : IObjects
    {
        public string NAPR_DATE { get; set; } = "Undefined";
        public string NAPR_MO { get; set; } = "";
        public string NAPR_V { get; set; } = "Undefined";
        public string MET_ISSL { get; set; } = "";
        public string NAPR_USL { get; set; } = "";
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public NAPR() { }

        public NAPR(object napr_date, object napr_mo, object napr_v, object met_issl, object napr_usl, object sl_id)
        {
            this.NAPRFill(napr_date, napr_mo, napr_v, met_issl, napr_usl, sl_id);
        }

        public void NAPRFill(object napr_date, object napr_mo, object napr_v, object met_issl, object napr_usl, object sl_id)
        {
            NAPR_DATE = napr_date.ToString()!;
            NAPR_MO = string.IsNullOrEmpty(napr_mo.ToString()) ? "" : napr_mo.ToString()!;
            NAPR_V = napr_v.ToString()!;
            MET_ISSL = string.IsNullOrEmpty(met_issl.ToString()) ? "" : met_issl.ToString()!;
            NAPR_USL = string.IsNullOrEmpty(napr_usl.ToString()) ? "" : napr_usl.ToString()!;
            SL_ID = sl_id.ToString()!;
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.NAPRFill(n[0], n[1], n[2],
                n[3], n[4], n[5]);
        }

        public override string GetCode()
        {
            return SL_ID;
        }
    }
}
