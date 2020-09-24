using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Formats
{
    class Cr2: IFormat
    {
        public override MagickFormat GetFormatType()
        {
            return MagickFormat.Cr2;
        }
    }
}
