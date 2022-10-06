using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ЦАД2.Objects.zap.sl;

namespace ЦАД2.Objects.zap.SL
{
    public class USL : IObjects
    {
        public string IDSERV { get; set; } = "Undefined";
        public string LPU { get; set; } = "Undefined";
        public string LPU_1 { get; set; } = "";
        public string? PODR { get; set; }
        public string? PROFIL { get; set; }
        public string? VID_VME { get; set; }
        public string? DET { get; set; }
        public string DATE_IN { get; set; } = "Undefined";
        public string DATE_OUT { get; set; } = "Undefined";
        public string? P_OTK { get; set; }
        public string? DS { get; set; }
        public string CODE_USL { get; set; } = "Undefined";
        public string? KOL_USL { get; set; }
        public string TARIF { get; set; } = "";
        public string SUMV_USL { get; set; } = "Undefined";
        [XmlElement]
        public List<MED_DEV>? MED_DEV { get; set; }
        [XmlElement]
        public List<MR_USL_N>? MR_USL_N { get; set; }
        public string? PRVS { get; set; }
        public string? CODE_MD { get; set; }
        public string? NPL { get; set; }
        public string COMENTU { get; set; } = "";
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";
        [XmlIgnore]
        public string NSCHET { get; set; } = "Undefined";

        public USL() { }

        public void USLFill(TypeFile type, object iDSERV, object lPU, object lPU_1, object pODR, object pROFIL, object vID_VME, object dET, object dATE_IN, object dATE_OUT,
            object p_OTK, object dS, object cODE_USL, object kOL_USL, object tARIF, object sUMV_USL, object nPL, object cOMENTU, object sl_id, object nschet)
        {
            IDSERV = iDSERV.ToString()!;
            LPU = lPU.ToString()!;
            LPU_1 = string.IsNullOrEmpty(lPU_1.ToString()) ? "" : lPU_1.ToString()!;
            if (type != TypeFile.DVN)
            {
                PODR = string.IsNullOrEmpty(pODR.ToString()) ? "" : pODR.ToString()!;
                PROFIL = string.IsNullOrEmpty(pROFIL.ToString()) ? "" : pROFIL.ToString()!;
                VID_VME = string.IsNullOrEmpty(vID_VME.ToString()) ? "" : vID_VME.ToString()!;
                DET = dET.ToString()!;
            }
            DATE_IN = dATE_IN.ToString()!;
            DATE_OUT = dATE_OUT.ToString()!;
            if (type == TypeFile.DVN)
            {
                P_OTK = string.IsNullOrEmpty(p_OTK.ToString()) ? "" : p_OTK.ToString()!;

            }
            else
            {
                DS = string.IsNullOrEmpty(dS.ToString()) ? "" : dS.ToString()!;
                KOL_USL = string.IsNullOrEmpty(kOL_USL.ToString()) ? "" : kOL_USL.ToString()!;
                NPL = string.IsNullOrEmpty(nPL.ToString()) ? null : nPL.ToString();
            }
            CODE_USL = cODE_USL.ToString()!;

            TARIF = tARIF.ToString()!.Replace(",", ".");
            SUMV_USL = sUMV_USL.ToString()!.Replace(",", ".");

            COMENTU = string.IsNullOrEmpty(cOMENTU.ToString()) ? "" : cOMENTU.ToString()!;
            SL_ID = sl_id.ToString()!;
            NSCHET = nschet.ToString()!;
        }

        public USL(TypeFile type, object iDSERV, object lPU, object lPU_1, object pODR, object pROFIL, object vID_VME, object dET, object dATE_IN, object dATE_OUT,
            object p_OTK, object dS, object cODE_USL, object kOL_USL, object tARIF, object sUMV_USL, object nPL, object cOMENTU, object sl_id, object nschet)
        {
            this.USLFill(type, iDSERV, lPU, lPU_1, pODR, pROFIL, vID_VME, dET, dATE_IN, dATE_OUT,
                p_OTK, dS, cODE_USL, kOL_USL, tARIF, sUMV_USL, nPL, cOMENTU, sl_id, nschet);
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.USLFill(t, n[0], n[1], n[2], n[3], n[4], n[5], n[6],
                        n[7], n[8], n[9], n[10], n[11], n[12], n[13], n[14],
                        n[15], n[16], n[17], n[18]);
        }
    }
}
