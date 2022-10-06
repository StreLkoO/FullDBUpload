using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ЦАД2.Objects.zap.sl.onksl;
using ЦАД2.Objects.zap.SL.ONKSL;

namespace ЦАД2.Objects.zap.SL
{
    public class ONK_SL : IObjects
    {
        public string DS1_T { get; set; } = "Undefined";
        public string? STAD { get; set; }
        public string? ONK_T { get; set; }
        public string? ONK_N { get; set; }
        public string? ONK_M { get; set; }
        public string? MTSTZ { get; set; }
        public string? SOD { get; set; }
        public string? K_FR { get; set; }
        public string? WEI { get; set; }
        public string? HEI { get; set; }
        public string? BSA { get; set; }
        [XmlElement]
        public List<B_DIAG> B_DIAG { get; set; } = new();
        [XmlElement]
        public List<B_PROT> B_PROT { get; set; } = new();
        [XmlElement]
        public List<ONK_USL> ONK_USL { get; set; } = new();
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public ONK_SL() { }

        public ONK_SL(object ds1_t, object stad, object onk_t, object onk_n, object onk_m, 
            object mtstz, object sod, object k_fr, object wei, object hei, object bsa, object sl_id)
        {
            this.ONKFill(ds1_t, stad, onk_t, onk_n, onk_m, mtstz, sod, k_fr, wei, hei, bsa, sl_id);
        }

        public void ONKFill(object ds1_t, object stad, object onk_t, object onk_n, object onk_m,
            object mtstz, object sod, object k_fr, object wei, object hei, object bsa, object sl_id)
        {
            DS1_T = ds1_t.ToString()!;
            STAD = string.IsNullOrEmpty(stad.ToString()) ? null : stad.ToString();
            ONK_T = string.IsNullOrEmpty(onk_t.ToString()) ? null : onk_t.ToString();
            ONK_N = string.IsNullOrEmpty(onk_n.ToString()) ? null : onk_n.ToString();
            ONK_M = string.IsNullOrEmpty(onk_m.ToString()) ? null : onk_m.ToString();
            MTSTZ = string.IsNullOrEmpty(mtstz.ToString()) ? null : mtstz.ToString();
            SOD = string.IsNullOrEmpty(sod.ToString()) ? null : sod.ToString()!.Replace(",", ".");
            K_FR = string.IsNullOrEmpty(k_fr.ToString()) ? null : k_fr.ToString()!.Replace(",", ".");
            WEI = string.IsNullOrEmpty(wei.ToString()) ? null : wei.ToString()!.Replace(",", ".");
            HEI = string.IsNullOrEmpty(hei.ToString()) ? null : hei.ToString()!.Replace(",", ".");
            BSA = string.IsNullOrEmpty(bsa.ToString()) ? null : bsa.ToString()!.Replace(",", ".");
            SL_ID = sl_id.ToString()!;
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.ONKFill(n[0], n[1], n[2], n[3], n[4], n[5],
                         n[6], n[7], n[8], n[9], n[10], n[11]);
        }
    }
}
