using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl
{
    public class MED_DEV : IObjects
    {
        public string? DATE_MED { get; set; } 
        public string? CODE_MEDDEV { get; set; }
        public string? NUMBER_SER { get; set; }
        [XmlIgnore]
        public string IDSERV { get; set; } = "";

        public MED_DEV() { }

        public void MedDevFill(object dateMed, object codeMedDev, object numberSer, object IDserv)
        {
            DATE_MED = dateMed.ToString()!;
            CODE_MEDDEV = codeMedDev.ToString()!;
            NUMBER_SER = numberSer.ToString()!;
            IDSERV = IDserv.ToString()!;
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.MedDevFill(n[0], n[1], n[2], n[3]);
        }

        public override string GetCode()
        {
            return IDSERV;
        }
    }
}
