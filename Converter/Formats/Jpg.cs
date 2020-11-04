using ImageMagick;

namespace Converter.Formats
{
    class Jpg : Format
    {
        public override MagickFormat GetFormat()
        {
            return MagickFormat.Jpg;
        }
    }
}
