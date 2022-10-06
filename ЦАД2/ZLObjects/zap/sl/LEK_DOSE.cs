using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЦАД2.Objects.zap.sl
{
    public class LEK_DOSE
    {
        public string? ED_IZM { get; set; }
        public string? DOSE_INJ { get; set; }
        public string? METHOD_INJ { get; set; }
        public string? COL_INJ { get; set; }

        public LEK_DOSE(object eD_IZM, object dOSE_INJ, object mETHOD_INJ, object cOL_INJ)
        {
            ED_IZM = eD_IZM.ToString();
            DOSE_INJ = dOSE_INJ.ToString()!.Replace(",", ".");
            METHOD_INJ = mETHOD_INJ.ToString();
            COL_INJ = cOL_INJ.ToString();
        }

        public LEK_DOSE() { }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(ED_IZM) && string.IsNullOrEmpty(DOSE_INJ) && string.IsNullOrEmpty(METHOD_INJ);
        }
    }
}
