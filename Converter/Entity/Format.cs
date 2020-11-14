using ImageMagick;

namespace Converter
{
    abstract class Format
    {
        abstract public MagickFormat GetFormat();

        public string GetExtension()
        {
            return GetFormat().ToString().ToLower();
        }
    }
}
