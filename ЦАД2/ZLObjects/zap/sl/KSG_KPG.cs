using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl
{
    public class KSG_KPG : IObjects
    {
        public string N_KSG { get; set; } = "Undefined";
        public string VER_KSG { get; set; } = "Undefined";
        public string KSG_PG { get; set; } = "Undefined";
        public string? N_KPG { get; set; }
        public string KOEF_Z { get; set; } = "Undefined";
        public string KOEF_UP { get; set; } = "Undefined";
        public string BZTSZ { get; set; } = "Undefined";
        public string KOEF_D { get; set; } = "Undefined";
        public string KOEF_U { get; set; } = "Undefined";
        public string? CRIT { get; set; } = "Undefined";
        public string SL_K { get; set; } = "Undefined";
        public string? IT_SL { get; set; } = "Undefined";
        [XmlElement]
        public List<SL_KOEF>? SL_KOEF { get; set; }
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public KSG_KPG() { }

        public KSG_KPG(object n_KSG, object vER_KSG, object kSG_PG, object n_KPG, object kOEF_Z,
            object kOEF_UP, object bZTSZ, object kOEF_D, object kOEF_U, object cRIT, object sL_K,
            object iT_SL, object sl_id, object usl_ok, SL_KOEF sl_koef)
        {
            this.KSGFill(n_KSG, vER_KSG, kSG_PG, n_KPG, kOEF_Z, kOEF_UP, bZTSZ, kOEF_D, kOEF_U, cRIT, sL_K, iT_SL, sl_id, usl_ok, sl_koef);
        }

        public void KSGFill(object n_KSG, object vER_KSG, object kSG_PG, object n_KPG, object kOEF_Z,
            object kOEF_UP, object bZTSZ, object kOEF_D, object kOEF_U, object cRIT, object sL_K,
            object iT_SL, object sl_id, object usl_ok, SL_KOEF sl_koef)
        {
            if (usl_ok.ToString() == "0101" || usl_ok.ToString() == "0201")
            {
                N_KSG = n_KSG.ToString()!;
                VER_KSG = vER_KSG.ToString()!;
                KSG_PG = kSG_PG.ToString()!;
                N_KPG = string.IsNullOrEmpty(n_KPG.ToString()) ? null : n_KPG.ToString();
                KOEF_Z = kOEF_Z.ToString()!.Replace(",", ".");
                KOEF_UP = kOEF_UP.ToString()!.Replace(",", ".");
                BZTSZ = bZTSZ.ToString()!.Replace(",", ".");
                KOEF_D = kOEF_D.ToString()!.Replace(",", ".");
                KOEF_U = kOEF_U.ToString()!.Replace(",", ".");
                CRIT = cRIT.ToString()!;
                SL_K = sL_K.ToString()!;
                IT_SL = string.IsNullOrEmpty(cRIT.ToString()) || cRIT.ToString() == "0" ? null : iT_SL.ToString()!.Replace(",", ".");
                SL_ID = sl_id.ToString()!;
                if (!sl_koef.IsEmpty())
                {
                    this.SL_KOEF = new()
                    {
                        sl_koef
                    };
                }
            }
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.KSGFill(n[0], n[1], n[2], n[3], n[4],
                         n[5], n[6], n[7], n[8], n[9], n[10],
                         n[11], n[12], n[13], new(n[14]));
        }
    }
}
