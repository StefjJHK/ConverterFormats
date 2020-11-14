using ImageMagick;
using System.IO;

namespace Converter
{
    class ConverterFile
    {                
        public MagickImage ConvertFile(File file, Format format)
        {
            FileStream fileStream = new FileStream(file.GetFullPath(), FileMode.Open);
            MagickImage magickImage = new MagickImage(fileStream);
            
            magickImage.Format = format.GetFormat();

            return magickImage;
        }   
    }
}
