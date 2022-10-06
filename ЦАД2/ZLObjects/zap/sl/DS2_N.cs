using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.SL
{
    public class DS2_N : IObjects
    {
        public string DS2 { get; set; } = "Undefined";
        public string? DS2_PR { get; set; }
        public string? PR_DS2_N { get; set; }
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";
        [XmlIgnore]
        public string NSCHET { get; set; } = "Undefined";

        public DS2_N() { }

        public DS2_N(object dS2, object dS2_PR, object pR_DS2_N, object sL_ID, object nSCHET)
        {
            this.DS2Fill(dS2, dS2_PR, pR_DS2_N, sL_ID, nSCHET);
        }

        public void DS2Fill(object dS2, object dS2_PR, object pR_DS2_N, object sl_id, object nschet)
        {
            DS2 = dS2.ToString()!;
            DS2_PR = string.IsNullOrEmpty(dS2_PR.ToString()) ? null : dS2_PR.ToString();
            PR_DS2_N = string.IsNullOrEmpty(pR_DS2_N.ToString()) ? "" : pR_DS2_N.ToString();
            SL_ID = sl_id.ToString()!;
            NSCHET = nschet.ToString()!;
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.DS2Fill(n[0], n[1], n[2], n[3], n[4]);
        }
    }
}
