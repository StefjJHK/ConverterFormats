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
        //из названия файлы куда экономнее, чем делать это через FileStream

        Dictionary<string, MagickFormat> Formats = new Dictionary<string, MagickFormat>();
        IFormat[] IFormats = new IFormat[]
            {
                new Png(),
                new Jpg(),
                new Jpeg(),
                new Cr2(),
                new Ico()
            };

        public FormatsType()
        {            
            foreach(IFormat format in IFormats)
            {
                Formats.Add(format.GetFormatToString(), format.GetFormatType());
            }
        }

        public IFormat[] GetAllFormats()
        {
            return IFormats;
        }

        public List<string> GetAllFormatsToString()
        {
            List<string> formats = new List<string>();

            foreach(string format in Formats.Keys)
            {
                formats.Add(format);
            }

            return formats;
        }

        public MagickFormat GetFormatByString(string format_string)
        {
            if (Formats.ContainsKey(format_string))
                return (Formats[format_string]);

            return MagickFormat.Png;
        }
    }
}
