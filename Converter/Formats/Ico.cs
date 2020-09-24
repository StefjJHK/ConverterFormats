using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Formats
{
    class Ico : IFormat
    {
        public override MagickFormat GetFormatType()
        {
            return MagickFormat.Ico;
        }
    }
}
