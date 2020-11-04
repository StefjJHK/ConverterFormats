using ImageMagick;

namespace Converter.Formats
{
    class Ico : Format
    {
        public override MagickFormat GetFormat()
        {
            return MagickFormat.Ico;
        }
    }
}
