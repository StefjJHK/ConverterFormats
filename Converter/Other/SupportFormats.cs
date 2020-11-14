using Converter.Formats;
using ImageMagick;
using System.Collections.Generic;

namespace Converter
{
    class SupportFormats
    {
        //Список всех поддерживаемых форматов
        //Данный клас был создан с целью экономии ресурсов системы, посколько получить формат изображения
        //из названия файла куда экономнее, чем делать это через FileStream
        List<Format> Formats = new List<Format>
            {
                new Png(),
                new Jpg(),
                new Jpeg(),
                new Cr2(),
                new Ico()
            };

        public List<Format> GetAllFormats()
        {
            return Formats;
        }

        public List<string> GetAllExtensions()
        {
            List<string> extensions = new List<string>();

            foreach(Format format in Formats)
            {
                extensions.Add(format.GetExtension());
            }

            return extensions;
        }

        public MagickFormat GetFormatByExtension(string extension)
        {
            foreach(Format format in Formats)
            {
                if (format.GetExtension() == extension)
                    return format.GetFormat();
            }

            return MagickFormat.Png;
        }
    }
}
