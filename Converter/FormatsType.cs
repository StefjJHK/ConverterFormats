using Converter.Formats;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class FormatsType
    {
        //Список всех поддерживаемых форматов
        //Данный клас был создан с целью экономии ресурсов системы, посколько получить формат изображения
        //из названия файла куда экономнее, чем делать это через FileStream
        Format[] Formats = new Format[]
            {
                new Png(),
                new Jpg(),
                new Jpeg(),
                new Cr2(),
                new Ico()
            };

        public Format[] GetAllFormats()
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
