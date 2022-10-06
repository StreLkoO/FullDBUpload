using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ЦАД2.Objects.zap.sl.ONKSL
{
    public class CONS : IObjects
    {
        public string PR_CONS { get; set; } = "Undefined";
        public string? DT_CONS { get; set; }
        [XmlIgnore]
        public string SL_ID { get; set; } = "Undefined";

        public CONS() { }

        public CONS(object pr_cons, object dt_cons, object sl_id)
        {
            this.CONSFill(pr_cons, dt_cons, sl_id);
        }

        public void CONSFill(object pr_cons, object dt_cons, object sl_id)
        {
            PR_CONS = string.IsNullOrEmpty(pr_cons.ToString()) ? "0" : pr_cons.ToString()!;
            if (PR_CONS != "1" && PR_CONS != "4")
            {
                DT_CONS = dt_cons.ToString();
            }
            SL_ID = sl_id.ToString()!;
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.CONSFill(n[0], n[1], n[2]);
        }
    }
}
