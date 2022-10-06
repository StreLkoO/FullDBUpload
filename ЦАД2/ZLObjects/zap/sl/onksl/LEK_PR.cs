using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl.onksl
{
    public class LEK_PR : IObjects
    {
        public string REGNUM { get; set; } = "Undefined";
        public string CODE_SH { get; set; } = "Undefined";
        [XmlElement]
        public List<string> DATE_INJ { get; set; } = new();
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public LEK_PR() { }

        public LEK_PR(object rEGNUM, object cODE_SH, object dATA_INJ, object sL_ID, object date_1, object date_2)
        {
            this.LEK_PRFill(rEGNUM, cODE_SH, dATA_INJ, sL_ID, date_1, date_2);
        }

        public void LEK_PRFill(object rEGNUM, object cODE_SH, object dATA_INJ, object sL_ID, object date_1, object date_2)
        {
            REGNUM = rEGNUM.ToString()!;
            CODE_SH = cODE_SH.ToString()!;
            string[] list = dATA_INJ.ToString()!.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in list)
            {
                if (DateTime.Parse(date_2.ToString()!) >= DateTime.Parse(str))
                {
                    if (DateTime.Parse(date_1.ToString()!) <= DateTime.Parse(str))
                    {
                        DATE_INJ.Add(str);
                    }
                    else
                    {
                        DATE_INJ.Add(date_1.ToString()!);
                    }
                }
                else
                {
                    DATE_INJ.Add(date_2.ToString()!);
                }
            }
            SL_ID = sL_ID.ToString()!;
        }



        public override void Fill(object[] n, TypeFile t)
        {
            this.LEK_PRFill(n[0], n[1], n[2],
                n[3], n[4], n[5]);
        }

        public override string GetCode()
        {
            return SL_ID;
        }
    }
}
