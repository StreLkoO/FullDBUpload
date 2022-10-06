using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.SL.ONKSL
{
    public class B_DIAG : IObjects
    {
        public string DIAG_DATE { get; set; } = "Undefined";
        public string? DIAG_TIP { get; set; }
        public string? DIAG_CODE { get; set; }
        public string? DIAG_RSLT { get; set; }
        public string? REC_RSLT { get; set; }
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public B_DIAG() { }

        public B_DIAG(object diag_date, object diag_tip, object diag_code,
            object diag_rslt, object rec_rslt, object n7, object sl_id)
        {
            this.DIAGFill(diag_date, diag_tip, diag_code, diag_rslt, rec_rslt, n7, sl_id);
        }

        public void DIAGFill(object diag_date, object diag_tip, object diag_code,
            object diag_rslt, object rec_rslt, object n7, object sl_id)
        {
            if (diag_code.ToString() == n7.ToString() && diag_tip.ToString() == "1" || diag_tip.ToString() == "2")
            {
                DIAG_DATE = diag_date.ToString()!;
                DIAG_TIP = string.IsNullOrEmpty(diag_tip.ToString()) ? "" : diag_tip.ToString()!;
                DIAG_CODE = string.IsNullOrEmpty(diag_code.ToString()) ? "" : diag_code.ToString()!;
                DIAG_RSLT = string.IsNullOrEmpty(diag_rslt.ToString()) ? "" : diag_rslt.ToString()!;
                REC_RSLT = string.IsNullOrEmpty(rec_rslt.ToString()) ? "" : rec_rslt.ToString()!;
                SL_ID = sl_id.ToString()!;
            }
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.DIAGFill(n[0], n[1], n[2], n[3],
                          n[4], n[5], n[6]);
        }
    }
}
