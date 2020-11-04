using ImageMagick;

namespace Converter.Formats
{
    class Jpeg : Format
    {
        public override MagickFormat GetFormat()
        {
            return MagickFormat.Jpeg;
        }
    }
}
