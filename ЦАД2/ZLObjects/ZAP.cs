using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ЦАД2.Objects.z_sl;
using ЦАД2.Objects.zap;

namespace ЦАД2.Objects
{
    public class ZAP : IObjects
    {
        public string N_ZAP { get; set; } = "Undefined";
        public string PR_NOV { get; set; } = "Undefined";

        public PACIENT PACIENT { get; set; } = new();

        public Z_SL Z_SL { get; set; } = new();
        [XmlIgnore]
        public string Nschet { get; set; } = "Undefined";



        public ZAP() { }

        public ZAP(object n_ZAP, object pR_NOV, PACIENT pac, Z_SL z_sl, object nschet)
        {
            N_ZAP = n_ZAP.ToString()!;
            PR_NOV = pR_NOV.ToString()!;
            PACIENT = pac;
            Z_SL = z_sl;
            Nschet = nschet.ToString()!;
        }

        public override void Fill(object[] n, TypeFile t)
        {
            N_ZAP = n[38].ToString()!;
            PR_NOV = n[0].ToString()!;
            PACIENT = new PACIENT(t, n[1], n[2], n[3], n[4], n[5], n[6], n[7], n[8], n[9],
                n[10], n[11], n[12], n[13], n[14]);
            Z_SL = new Z_SL(t, n[15], n[16], n[17], n[18], n[19], n[20],
                            n[21], n[22], n[23], n[24], n[25], n[26], n[27],
                            n[28], n[29], n[30], n[31], n[32], n[33],
                            n[34], n[35], n[36]);
            Nschet = n[37].ToString()!;
        }

        public override string GetCode()
        {
            return Nschet;
        }
    }
}
