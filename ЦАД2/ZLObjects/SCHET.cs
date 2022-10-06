using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЦАД2.Objects
{
    public class SCHET : IObjects
    {
        public string CODE { get; set; } = "Undefined";
        public string CODE_MO { get; set; } = "Undefined";
        public string YEAR { get; set; } = "Undefined";
        public string MONTH { get; set; } = "Undefined";
        public string NSCHET { get; set; } = "Undefined";
        public string DSCHET { get; set; } = "Undefined";
        public string? PLAT { get; set; } = "";
        public string? SUMMAV { get; set; } = "";
        public string? COMENTS { get; set; } = "";
        public string? SUMMAP { get; set; } = "";
        public string? SANK_MEK { get; set; }
        public string? SANK_MEE { get; set; }
        public string? SANK_EKMP { get; set; }
        public string? DISP { get; set; }

        public SCHET() { }

        public SCHET(TypeFile type, object num, object codemo, object year, object month, object name, object accountDate, object smo,
           object summamo, object comment, object summa, object underf, object underf2, object dvn)
        {
            this.SCHETFill(type, num, codemo, year, month, name, accountDate, smo,
           summamo, comment, summa, underf, underf2, dvn);
        }

        public override void Fill(object[] n, TypeFile t)
        {
            this.SCHETFill(t, n[0], n[1], n[2], n[3], n[4], n[5], n[6], n[7],
           n[8], n[9], n[10], n[11], n[12]);
        }

        public void SCHETFill(TypeFile type, object num, object codemo, object year, object month, object name, object accountDate, object smo,
            object summamo, object comment, object summa, object underf, object underf2, object dvn)
        {
            CODE = num.ToString()!;
            CODE_MO = codemo.ToString()!;
            YEAR = year.ToString()!;
            MONTH = month.ToString()!;
            NSCHET = name.ToString()!;
            DSCHET = accountDate.ToString()!;
            PLAT = smo.ToString();
            SUMMAV = summamo.ToString()!.Replace(",", ".");
            COMENTS = comment.ToString();
            SUMMAP = summa.ToString()!.Replace(",", ".");
            SANK_MEE = String.IsNullOrEmpty(underf.ToString()) || underf.ToString()!.Equals("0") ? null : underf.ToString()!.Replace(",", ".");
            SANK_EKMP = String.IsNullOrEmpty(underf2.ToString()) || underf2.ToString()!.Equals("0") ? null : underf2.ToString()!.Replace(",", ".");
            if (type == TypeFile.DVN)
            {
                DISP = dvn.ToString();
            }
        }

        public override string GetCode()
        {
            return NSCHET;
        }
    }
}
