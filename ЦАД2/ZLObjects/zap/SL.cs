using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ЦАД2.Objects.zap.sl;
using ЦАД2.Objects.zap.sl.ONKSL;
using ЦАД2.Objects.zap.SL;

namespace ЦАД2.Objects.z_sl
{
    public class SL : IObjects
    {
        public string SL_ID { get; set; } = "Undefined";
        public string? VID_HMP { get; set; }
        public string? METOD_HMP { get; set; }
        public string? LPU_1 { get; set; } = "";
        public string? PODR { get; set; }
        public string? PROFIL { get; set; }
        public string? PROFIL_K { get; set; }
        public string? DET { get; set; }
        public string? TAL_D { get; set; }
        public string? TAL_NUM { get; set; }
        public string? TAL_P { get; set; }
        public string? P_CEL { get; set; }
        public string NHISTORY { get; set; } = "Undefined";
        public string? P_PER { get; set; }
        public string DATE_1 { get; set; } = "Undefined";
        public string DATE_2 { get; set; } = "Undefined";
        public string? KD { get; set; }
        public string? WEI { get; set; }
        public string? DS0 { get; set; }
        public string DS1 { get; set; } = "Undefined";
        public string? DS1_PR { get; set; }
        [XmlElement]
        public List<string>? DS2 { get; set; }
        [XmlElement]
        public string[]? DS3 { get; set; }
        public string? C_ZAB { get; set; }
        public string? DS_ONK { get; set; }
        public string? DN { get; set; }
        public string? CODE_MES1 { get; set; }
        public string? CODE_MES2 { get; set; }
        [XmlElement]
        public List<NAPR> NAPR { get; set; } = new();
        [XmlElement]
        public List<CONS> CONS { get; set; } = new();
        [XmlElement]
        public List<ONK_SL> ONK_SL { get; set; } = new();
        [XmlElement]
        public List<KSG_KPG> KSG_KPG { get; set; } = new();
        public string? REAB { get; set; }
        public string? PR_D_N { get; set; }
        [XmlElement]
        public List<DS2_N> DS2_N { get; set; } = new();
        [XmlElement]
        public List<NAZ> NAZ { get; set; } = new();
        public string? PRVS { get; set; }
        public string? VERS_SPEC { get; set; }
        public string? IDDOKT { get; set; }
        public string? ED_COL { get; set; }
        public string TARIF { get; set; } = "";
        public string SUM_M { get; set; } = "Undefined";
        [XmlElement]
        public List<LEK_PR_COVID> LEK_PR { get; set; } = new();
        [XmlElement]
        public List<USL> USL { get; set; } = new();
        public string? COMENTSL { get; set; }
        [XmlIgnore]
        public string ID_Z_SL { get; set; } = "Undefined";
        [XmlIgnore]
        public string NSCHET { get; set; } = "Undefined";

        public SL() { }

        public SL(TypeFile type, object usl_ok, object sl_id, object vid_hmp, object metod_hmp, object lpu_1, object podr, object profil, object profil_k,
            object det, object tal_d, object tal_num, object tal_p, object p_cel, object nhistory, object p_per,
            object date_1, object date_2, object kd, object wei, object ds0, object ds1, object ds1_pr, object ds2, object ds3,
            object c_zab, object ds_onk, object dn, object code_mes1, object code_mes2, object reab, object pr_d_n, object prvs,
            object vers_spec, object iddoct, object ed_col, object tarif, object sum_m, object comentsl, object id_z_sl, object nschet)
        {
            this.SLFill(type, usl_ok, sl_id, vid_hmp, metod_hmp, lpu_1, podr, profil, profil_k,
            det, tal_d, tal_num, tal_p, p_cel, nhistory, p_per,
            date_1, date_2, kd, wei, ds0, ds1, ds1_pr, ds2, ds3,
            c_zab, ds_onk, dn, code_mes1, code_mes2, reab, pr_d_n, prvs,
            vers_spec, iddoct, ed_col, tarif, sum_m, comentsl, id_z_sl, nschet);
        }

        public void SLFill(TypeFile type, object usl_ok, object sl_id, object vid_hmp, object metod_hmp, object lpu_1, object podr, object profil, object profil_k,
            object det, object tal_d, object tal_num, object tal_p, object p_cel, object nhistory, object p_per,
            object date_1, object date_2, object kd, object wei, object ds0, object ds1, object ds1_pr, object ds2, object ds3,
            object c_zab, object ds_onk, object dn, object code_mes1, object code_mes2, object reab, object pr_d_n, object prvs,
            object vers_spec, object iddoct, object ed_col, object tarif, object sum_m, object comentsl, object id_z_sl, object nschet)
        {
            SL_ID = sl_id.ToString()!;
            if (type == TypeFile.VMP)
            {
                VID_HMP = vid_hmp.ToString();
                METOD_HMP = metod_hmp.ToString();
                TAL_D = tal_d.ToString();
                TAL_NUM = tal_num.ToString();
                TAL_P = tal_p.ToString();
            }
            LPU_1 = string.IsNullOrEmpty(lpu_1.ToString()) ? "" : lpu_1.ToString();
            if (type != TypeFile.DVN)
            {
                PODR = string.IsNullOrEmpty(podr.ToString()) ? "" : podr.ToString();
                PROFIL = profil.ToString();
                PROFIL_K = string.IsNullOrEmpty(profil_k.ToString()) ? null : profil_k.ToString();
                DET = det.ToString();
            }
            if (usl_ok!.ToString() == "3" && type != TypeFile.DVN)
            {
                P_CEL = p_cel.ToString();
            }
            NHISTORY = nhistory.ToString()!;
            if ((type == TypeFile.Else || type == TypeFile.ONK) && (usl_ok!.ToString() == "1" || usl_ok!.ToString() == "2"))
            {
                P_PER = p_per.ToString();
                KD = kd.ToString();
            }
            DATE_1 = date_1.ToString()!;
            DATE_2 = date_2.ToString()!;
            WEI = string.IsNullOrEmpty(wei.ToString()) ? null : wei.ToString()!.Replace(",", ".");
            DS1 = ds1.ToString()!;
            if (type != TypeFile.DVN)
            {
                DS0 = string.IsNullOrEmpty(ds0.ToString()) ? null : ds0.ToString();
                if (!string.IsNullOrEmpty(ds2.ToString()))
                {
                    DS2 = new();
                    string s = ds2.ToString()!;
                    DS2.AddRange(s.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
                if (!string.IsNullOrEmpty(ds3.ToString()))
                {
                    string s = ds3.ToString()!;
                    DS3 = s.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                }

                C_ZAB = c_zab.ToString();
            }
            else
            {
                if (ds1_pr.ToString() != "0")
                {
                    DS1_PR = ds1_pr.ToString();
                }
            }
            if (type != TypeFile.Else)
            {
                DS_ONK = ds_onk.ToString();
            }
            if (p_cel.ToString() == "1.3")
            {
                DN = dn.ToString();
            }
            if (type == TypeFile.Else || type == TypeFile.VMP)
            {
                CODE_MES1 = string.IsNullOrEmpty(code_mes1.ToString()) ? null : code_mes1.ToString();
                CODE_MES2 = string.IsNullOrEmpty(code_mes2.ToString()) ? null : code_mes2.ToString();
                REAB = string.IsNullOrEmpty(reab.ToString()) ? null : reab.ToString();
            }
            if (type == TypeFile.DVN)
            {
                PR_D_N = pr_d_n.ToString();
            }
            else
            {
                PRVS = prvs.ToString();
                VERS_SPEC = vers_spec.ToString();
                IDDOKT = iddoct.ToString();
            }
            ED_COL = string.IsNullOrEmpty(ed_col.ToString()) ? null : ed_col.ToString()!.Replace(",", ".");
            TARIF = tarif.ToString()!.Replace(",", ".");
            SUM_M = sum_m.ToString()!.Replace(",", ".");
            COMENTSL = comentsl.ToString();
            ID_Z_SL = id_z_sl.ToString()!;
            NSCHET = nschet.ToString()!;
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.SLFill(t, n[0], n[1], n[2], n[3], n[4], n[5], n[6],
                        n[7], n[8], n[9], n[10], n[11], n[12], n[13], n[14], n[15], n[16],
                        n[17], n[18], n[19], n[20], n[21], n[22], n[23], n[24], n[25], n[26],
                        n[27], n[28], n[29], n[30], n[31], n[32], n[33], n[34], n[35], n[36],
                        n[37], n[38], n[39]);
        }

        public override string GetCode()
        {
            return ID_Z_SL;
        }
    }
}
