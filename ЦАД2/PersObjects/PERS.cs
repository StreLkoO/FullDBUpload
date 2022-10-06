using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЦАД2.PersObjects
{
    public class PERS
    {
        public string ID_PAC { get; set; } = "Undefined";
        public string FAM { get; set; } = "Undefined";
        public string IM { get; set; } = "Undefined";
        public string OT { get; set; } = "Undefined";
        public string W { get; set; } = "Undefined";
        public string DR { get; set; } = "Undefined";
        public string? DOST { get; set; } = "";
        public string? TEL { get; set; }
        public string? FAM_P { get; set; }
        public string? IM_P { get; set; } 
        public string? OT_P { get; set; }
        public string? W_P { get; set; }
        public string? DR_P { get; set; } 
        public string? DOST_P { get; set; }
        public string? MR { get; set; } 
        public string? DOCTYPE { get; set; }
        public string? DOCSER { get; set; }
        public string? DOCNUM { get; set; }
        public string? DOCDATE { get; set; }
        public string? DOCORG { get; set; }
        public string? SNILS { get; set; }
        public string? OKATOG { get; set; }
        public string? OKATOP { get; set; }
        public string? COMENTP { get; set; }

        public PERS() { }

        public PERS(object iD_PAC, object fAM, object iM, object oT, object w, object dR, object dOST,
            object tEL, object fAM_P, object iM_P, object oT_P, object w_P, object dR_P, object dOST_P,
            object mR, object dOCTYPE, object dOCSER, object dOCNUM, object dOCDATE, object dOCORG, 
            object sNILS, object oKATOG, object oKATOP, object cOMENTP)
        {
            ID_PAC = iD_PAC.ToString()!;
            FAM = fAM.ToString()!;
            IM = iM.ToString()!;
            OT = oT.ToString()!;
            W = w.ToString()!;
            DR = dR.ToString()!;
            DOST = string.IsNullOrEmpty(dOST.ToString()) ? null : dOST.ToString()!;
            TEL = string.IsNullOrEmpty(tEL.ToString()) ? null : tEL.ToString()!;
            FAM_P = string.IsNullOrEmpty(fAM_P.ToString()) ? null : fAM_P.ToString()!;
            IM_P = string.IsNullOrEmpty(iM_P.ToString()) ? null : iM_P.ToString()!;
            OT_P = string.IsNullOrEmpty(oT_P.ToString()) ? null : oT_P.ToString()!;
            W_P = string.IsNullOrEmpty(w_P.ToString()) ? null : w_P.ToString()!;
            DR_P = string.IsNullOrEmpty(dR_P.ToString()) ? null : dR_P.ToString()!;
            DOST_P = string.IsNullOrEmpty(dOST_P.ToString()) ? null : dOST_P.ToString()!;
            MR = string.IsNullOrEmpty(mR.ToString()) ? null : mR.ToString()!;
            DOCTYPE = string.IsNullOrEmpty(dOCTYPE.ToString()) ? null : dOCTYPE.ToString()!;
            DOCSER = string.IsNullOrEmpty(dOCSER.ToString()) ? null : dOCSER.ToString()!;
            DOCNUM = string.IsNullOrEmpty(dOCNUM.ToString()) ? null : dOCNUM.ToString()!;
            DOCDATE = string.IsNullOrEmpty(dOCDATE.ToString()) ? null : dOCDATE.ToString()!;
            DOCORG = string.IsNullOrEmpty(dOCORG.ToString()) ? null : dOCORG.ToString()!;
            SNILS = string.IsNullOrEmpty(sNILS.ToString()) ? null : sNILS.ToString()!;
            OKATOG = string.IsNullOrEmpty(oKATOG.ToString()) ? null : oKATOG.ToString()!;
            OKATOP = string.IsNullOrEmpty(oKATOP.ToString()) ? null : oKATOP.ToString()!;
            COMENTP = string.IsNullOrEmpty(cOMENTP.ToString()) ? null : cOMENTP.ToString()!;
        }
    }
}
