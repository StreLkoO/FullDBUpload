using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl
{
    public class MR_USL_N : IObjects
    {
        public string MR_N { get; set; } = "Undefined";
        public string PRVS { get; set; } = "Undefined";
        public string CODE_MD { get; set; } = "Undefined";
        [XmlIgnore]
        public string IDSERV { get; set; } = "Undefined";
        [XmlIgnore]
        public string NSCHET { get; set; } = "Undefined";

        public MR_USL_N() { }
        public void MRFill(object mR_N, object pRVS, object cODE_MD, object iDSERV, object nschet)
        {
            MR_N = mR_N.ToString()!;
            PRVS = pRVS.ToString()!;
            CODE_MD = cODE_MD.ToString()!;
            IDSERV = iDSERV.ToString()!;
            NSCHET = nschet.ToString()!;
        }

        public MR_USL_N(object mR_N, object pRVS, object cODE_MD, object iDSERV, object nschet)
        {
            this.MRFill(mR_N, pRVS, cODE_MD, iDSERV, nschet);
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.MRFill(n[0], n[1], n[2], n[3], n[4]);
        }

        public override string GetCode()
        {
            return IDSERV;
        }
    }
}
