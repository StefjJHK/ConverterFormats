using ImageMagick;

namespace Converter.Formats
{
    class Png : Format
    {
        public override MagickFormat GetFormat()
        {
            return MagickFormat.Png;
        }
    }
}
