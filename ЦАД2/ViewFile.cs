using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЦАД2
{
    public class ViewFile
    {
        public TypeFile TypeFile { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Version { get; set; }
        public string Disp { get; set; }

        public ViewFile(TypeFile typeFile, string name, string text, string version, string disp)
        {
            TypeFile = typeFile;
            Name = name;
            Text = text;
            Version = version;
            Disp = disp;
        }
    }
}
