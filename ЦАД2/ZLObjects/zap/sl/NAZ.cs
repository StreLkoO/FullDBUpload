using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.SL
{
    public class NAZ : IObjects
    {
        public string NAZ_N { get; set; } = "Undefined";
        public string? NAZ_R { get; set; }
        public string? NAZ_IDDOKT { get; set; }
        public string? NAZ_V { get; set; }
        public string? NAZ_USL { get; set; }
        public string? NAPR_DATE { get; set; }
        public string? NAPR_MO { get; set; }
        public string? NAZ_PMP { get; set; }
        public string? NAZ_PK { get; set; }
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public NAZ() { }

        public NAZ(object nAZ_N, object nAZ_R, object nAZ_IDDOKT, object nAZ_V, object nAZ_USL,
            object nAPR_DATE, object nAPR_MO, object nAZ_PMP, object nAZ_PK, object ds_onk, object sl_id)
        {
            this.NAZFill(nAZ_N, nAZ_R, nAZ_IDDOKT, nAZ_V, nAZ_USL, nAPR_DATE, nAPR_MO, nAZ_PMP, nAZ_PK, ds_onk, sl_id);
        }

        public void NAZFill(object nAZ_N, object nAZ_R, object nAZ_IDDOKT, object nAZ_V, object nAZ_USL,
            object nAPR_DATE, object nAPR_MO, object nAZ_PMP, object nAZ_PK, object ds_onk, object sl_id)
        {
            NAZ_N = nAZ_N.ToString()!;
            NAZ_R = nAZ_R.ToString();
            NAZ_IDDOKT = nAZ_IDDOKT.ToString();
            NAZ_V = string.IsNullOrEmpty(nAZ_V.ToString()) ? null : nAZ_V.ToString()!;
            NAZ_USL = string.IsNullOrEmpty(nAZ_USL.ToString()) ? null : nAZ_USL.ToString()!;
            if (ds_onk.ToString() == "1" || NAZ_R == "2" || NAZ_R == "3")
            {
                NAPR_DATE = string.IsNullOrEmpty(nAPR_DATE.ToString()) ? null : nAPR_DATE.ToString();
                NAPR_MO = string.IsNullOrEmpty(nAPR_MO.ToString()) ? null : nAPR_MO.ToString();
            }
            NAZ_PMP = string.IsNullOrEmpty(nAZ_PMP.ToString()) ? null : nAZ_PMP.ToString();
            NAZ_PK = string.IsNullOrEmpty(nAZ_PK.ToString()) ? null : nAZ_PK.ToString();
            SL_ID = sl_id.ToString()!;
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.NAZFill(n[0], n[1], n[2], n[3], n[4],
                         n[5], n[6], n[7], n[8], n[9], n[10]);
        }
    }
}
