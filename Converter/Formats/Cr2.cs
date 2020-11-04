using ImageMagick;

namespace Converter.Formats
{
    class Cr2 : Format
    {
        public override MagickFormat GetFormat()
        {
            return MagickFormat.Cr2;
        }
    }
}
