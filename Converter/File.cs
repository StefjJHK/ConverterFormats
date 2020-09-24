using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class File
    {
        public string Name { get; private set; }
        public string Path { get; private set; }

        public string FormatToString { get; private set; }
        public MagickFormat FormatType { get; private set; }

        public File(string Name, string Path, string FormatToString)
        {
            this.Name = Name;
            this.Path = Path;

            this.FormatToString = FormatToString;
        }

        public string GetFullPath()
        {
            return Path + "\\" + Name + "." + FormatToString;
        }
    }
}
