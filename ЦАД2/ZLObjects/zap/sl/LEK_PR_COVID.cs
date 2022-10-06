using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl
{
    public class LEK_PR_COVID : IObjects
    {
        [XmlElement]
        public List<string> DATA_INJ { get; set; } = new();
        public string? CODE_SH { get; set; }
        public string? REGNUM { get; set; }
        public string? COD_MARK { get; set; }
        public LEK_DOSE? LEK_DOSE { get; set; }
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public LEK_PR_COVID() { }

        public LEK_PR_COVID(object dATA_INJ, object cODE_SH, object rEGNUM, object cOD_MARK, object sL_ID, LEK_DOSE ld, object date_1, object date_2)
        {
            this.LEKFill(dATA_INJ, cODE_SH, rEGNUM, cOD_MARK, sL_ID, ld, date_1, date_2);
        }
        public void LEKFill(object dATA_INJ, object cODE_SH, object rEGNUM, object cOD_MARK, object sL_ID, LEK_DOSE ld, object date_1, object date_2)
        {
            string[] list = dATA_INJ.ToString()!.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in list)
            {
                if (DateTime.Parse(date_2.ToString()!) >= DateTime.Parse(str))
                {
                    if (DateTime.Parse(date_1.ToString()!) <= DateTime.Parse(str))
                    {
                        DATA_INJ.Add(str);
                    }
                    else
                    {
                        DATA_INJ.Add(date_1.ToString()!);
                    }
                }
                else
                {
                    DATA_INJ.Add(date_2.ToString()!);
                }
            }
            CODE_SH = string.IsNullOrEmpty(cODE_SH.ToString()) ? null : cODE_SH.ToString()!;
            REGNUM = string.IsNullOrEmpty(rEGNUM.ToString()) ? null : rEGNUM.ToString()!;
            COD_MARK = string.IsNullOrEmpty(cOD_MARK.ToString()) ? null : cOD_MARK.ToString()!;
            SL_ID = sL_ID.ToString()!;
            if (!ld.IsEmpty())
            {
                LEK_DOSE = ld;
            }
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.LEKFill(n[0], n[1], n[2], n[3], n[4],
                        new(n[5], n[6], n[7], n[8]), n[9], n[10]);
        }

        public override string GetCode()
        {
            return SL_ID;
        }
    }
}
