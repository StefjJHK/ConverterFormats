using ImageMagick;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{    
    class ConverterFiles
    {                
        public void SaveConvertedImage(File file, Format format, string folder)
        {
            FileStream fileStream = new FileStream(file.GetFullPath(), FileMode.Open);
            MagickImage magickImage = new MagickImage(fileStream);

            magickImage.Format = format.GetFormat();

            Directory.CreateDirectory(file.Path + "\\" + folder + "\\");

            magickImage.Write(file.Path + "\\" + folder + "\\" + file.Name + "." + format.GetFormat().ToString().ToLower());

            fileStream.Close();
        }
    }
}
