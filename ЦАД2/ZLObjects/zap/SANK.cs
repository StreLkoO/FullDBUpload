using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap
{
    public class SANK : IObjects
    {
        public string S_CODE { get; set; } = "Undefined";
        public string S_SUM { get; set; } = "Undefined";
        public string S_TIP { get; set; } = "Undefined";
        public string? SL_ID { get; set; }
        public string? S_OSN { get; set; }
        public string DATE_ACT { get; set; } = "Undefined";
        public string NUM_ACT { get; set; } = "Undefined";
        public string? CODE_EXP { get; set; }
        public string? S_COM { get; set; }
        public string S_IST { get; set; } = "Undefined";
        [XmlIgnore]
        public string IDCASE { get; set; } = "Undefined";
        [XmlIgnore]
        public string NSCHET { get; set; } = "Undefined";

        public void SANKFill(object cODE, object sUM, object tIP, object sL_ID, object oSN, object dATE_ACT,
            object nUM_ACT, object cODE_EXP, object cOM, object iST, object idcase, object nschet)
        {
            S_CODE = cODE.ToString()!;
            S_SUM = sUM.ToString()!.Replace(",", ".");
            S_TIP = tIP.ToString()!;
            SL_ID = string.IsNullOrEmpty(sL_ID.ToString()) ? "" : sL_ID.ToString()!;
            S_OSN = string.IsNullOrEmpty(oSN.ToString()) ? "" : oSN.ToString()!;
            DATE_ACT = dATE_ACT.ToString()!;
            NUM_ACT = nUM_ACT.ToString()!;
            CODE_EXP = string.IsNullOrEmpty(cODE_EXP.ToString()) ? "" : cODE_EXP.ToString()!;
            S_COM = string.IsNullOrEmpty(cOM.ToString()) ? "" : cOM.ToString()!;
            S_IST = iST.ToString()!;
            IDCASE = idcase.ToString()!;
            NSCHET = nschet.ToString()!;
        }

        public SANK() { }

        public SANK(object cODE, object sUM, object tIP, object sL_ID, object oSN, object dATE_ACT,
            object nUM_ACT, object cODE_EXP, object cOM, object iST, object idcase, object nschet)
        {
            this.SANKFill(cODE, sUM, tIP, sL_ID, oSN, dATE_ACT,
            nUM_ACT, cODE_EXP, cOM, iST, idcase, nschet);
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.SANKFill(n[0], n[1], n[2], n[3], n[4],
                            n[5], n[6], n[7], n[8], n[9], n[10], n[11]);
        }

        public override string GetCode()
        {
            return IDCASE;
        }
    }
}
