using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    abstract class IFormat
    {
        public abstract MagickFormat GetFormatType();

        public virtual string GetFormatToString()
        {
            return GetFormatType().ToString().ToLower();
        }
    }
}
