using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЦАД2.Objects.zap
{
    public class PACIENT
    {
        public string ID_PAC { get; set; } = "Undefined";
        public string VPOLIS { get; set; } = "Undefined";
        public string? SPOLIS { get; set; } = "";
        public string? NPOLIS { get; set; }
        public string? ENP { get; set; }
        public string? ST_OKATO { get; set; }
        public string? SMO { get; set; } = "";
        public string? SMO_OGRN { get; set; }
        public string? SMO_OK { get; set; }
        public string? SMO_NAM { get; set; } = "";
        public string? INV { get; set; }
        public string? MSE { get; set; }
        public string NOVOR { get; set; } = "Undefined";
        public string? VNOV_D { get; set; }


        public PACIENT(TypeFile type, object id_pac, object vpolis, object spolis, object npolis, object enp, object st_okato,
            object smo, object smo_ogrn, object smo_ok, object smo_nam, object inv, object mse, object novor, object vnov_d)
        {
            ID_PAC = id_pac.ToString()!;
            VPOLIS = vpolis.ToString()!;
            SPOLIS = spolis.ToString();
            if (type == TypeFile.DVN || type == TypeFile.Else)
            {
                if (vpolis.ToString() == "3")
                {
                    NPOLIS = npolis.ToString();
                }
                else
                {
                    ENP = enp.ToString();
                }
            }
            else
            {
                NPOLIS = npolis.ToString();
            }
            ST_OKATO = string.IsNullOrEmpty(st_okato.ToString()) ? null : st_okato.ToString();
            SMO = smo.ToString();
            if (type == TypeFile.VMP || type == TypeFile.ONK)
            {
                SMO_OGRN = string.IsNullOrEmpty(smo_ogrn.ToString()) || smo_ogrn.ToString()!.Equals("0") ? "" : smo_ogrn.ToString();
                SMO_OK = string.IsNullOrEmpty(smo_ok.ToString()) || smo_ok.ToString()!.Equals("0") ? "" : smo_ok.ToString();
            }
            SMO_NAM = smo_nam.ToString();
            if (type == TypeFile.VMP || type == TypeFile.Else)
            {
                INV = string.IsNullOrEmpty(inv.ToString()) || inv.ToString()!.Equals("0") ? "" : inv.ToString();
            }
            if (type != TypeFile.DVN)
            {
                MSE = string.IsNullOrEmpty(mse.ToString()) || mse.ToString()!.Equals("0") ? null : mse.ToString();
                VNOV_D = string.IsNullOrEmpty(vnov_d.ToString()) || vnov_d.ToString()!.Equals("0") ? null : vnov_d.ToString();
            }
            NOVOR = novor.ToString()!;


        }

        public PACIENT() { }
    }
}
