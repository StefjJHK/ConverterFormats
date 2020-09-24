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
        public void SaveConvertedImage(File file, IFormat format, string folder)
        {
            FileStream fileStream = new FileStream(file.GetFullPath(), FileMode.Open);
            MagickImage magickImage = new MagickImage(fileStream);

            magickImage.Format = format.GetFormatType();

            Directory.CreateDirectory(file.Path + "\\" + folder + "\\");

            magickImage.Write(file.Path + "\\" + folder + "\\" + file.Name + "." + format.GetFormatToString());

            fileStream.Close();
        }

        //public Bitmap GetBitmap(File file)
        //{
        //    FileStream fileStream = new FileStream(file.GetFullPath(),
        //          FileMode.Open);
        //    MagickImage magickImage = new MagickImage(fileStream);            

        //    byte[] imageBytes = magickImage.ToByteArray();

        //    return (Bitmap)((new ImageConverter()).ConvertFrom(imageBytes));
        //}
    }
}
