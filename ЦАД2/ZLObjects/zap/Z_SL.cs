using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ЦАД2.Objects.zap;

namespace ЦАД2.Objects.z_sl
{
    public class Z_SL 
    {
        public string IDCASE { get; set; } = "Undefined";
        public string USL_OK { get; set; } = "Undefined";
        public string VIDPOM { get; set; } = "Undefined";
        public string? FOR_POM { get; set; }
        public string? NPR_MO { get; set; }
        public string? NPR_DATE { get; set; }
        public string LPU { get; set; } = "Undefined";
        public string? VBR { get; set; }
        public string DATE_Z_1 { get; set; } = "Undefined";
        public string DATE_Z_2 { get; set; } = "Undefined";
        public string? KD_Z { get; set; }
        public string? VNOV_M { get; set; }
        public string? P_OTK { get; set; }
        public string? RSLT_D { get; set; }
        public string? RSLT { get; set; }
        public string? ISHOD { get; set; }
        public string? VB_P { get; set; }
        public string? OS_SLUCH { get; set; }
        [XmlElement]
        public List<SL> SL { get; set; } = new();
        public string IDSP { get; set; } = "Undefined";
        public string SUMV { get; set; } = "Undefined";
        public string? OPLATA { get; set; }
        public string SUMP { get; set; } = "Undefined";//добавить класс для санкций
        [XmlElement]
        public List<SANK> SANK { get; set; } = new();
        public string? SANK_IT { get; set; }



        public Z_SL(TypeFile type, object idcase, object usl_ok, object vidpom, object formmp, object npr_mo, object npr_date, object lpu,
            object vbr, object date_z1, object date_z2, object kd_z, object vnov_m, object p_otk, object rslt_d,
            object rslt, object ishod, object vb_p, object os_sluch, object idsp, object sum_v, object oplata, object sum_p
            )
        {
            IDCASE = idcase.ToString()!;
            USL_OK = usl_ok.ToString()!;
            VIDPOM = vidpom.ToString()!;
            if (type != TypeFile.DVN)
            {
                FOR_POM = formmp.ToString();
                NPR_MO = string.IsNullOrEmpty(npr_mo.ToString()) || npr_mo.ToString()!.Equals("0") ? "" : npr_mo.ToString();
                NPR_DATE = string.IsNullOrEmpty(npr_date.ToString()) || npr_date.ToString()!.Equals("0") ? "" : npr_date.ToString();
            }
            LPU = lpu.ToString()!;
            if (type == TypeFile.DVN)
            {
                VBR = vbr.ToString();
            }
            DATE_Z_1 = date_z1.ToString()!;
            DATE_Z_2 = date_z2.ToString()!;
            if (usl_ok.ToString() != "3")
            {
                KD_Z = kd_z.ToString();
            }
            VNOV_M = string.IsNullOrEmpty(vnov_m.ToString()) ? null : vnov_m.ToString();
            if (type == TypeFile.DVN)
            {
                P_OTK = string.IsNullOrEmpty(p_otk.ToString()) || p_otk.ToString()!.Equals("0") ? "" : p_otk.ToString();
                RSLT_D = rslt_d.ToString()!;
            }
            else
            {
                RSLT = rslt.ToString();
                ISHOD = ishod.ToString()!;
                if (vb_p.ToString() == "4")
                {
                    VB_P = "1";
                }
            }
            OS_SLUCH = string.IsNullOrEmpty(os_sluch.ToString()) ? null : os_sluch.ToString();
            IDSP = idsp.ToString()!;
            SUMV = sum_v.ToString()!.Replace(",", ".");
            OPLATA = oplata.ToString();
            SUMP = sum_p.ToString()!.Replace(",", ".");

        }

        public Z_SL() { }

        //public override void Fill(object[] n)
        //{
        //    this = new Z_SL(TypeFile.DVN, n[1], n[2], n[3], n[4],
        //        n[0], n[1], n[2], n[3], n[4],
        //        n[0], n[1], n[2], n[3], n[4],
        //        n[0], n[1], n[2], n[3], n[4],
        //        n[0], n[1], n[2]);
        //}
    }
}
