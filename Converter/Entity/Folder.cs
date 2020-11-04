using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Folder
    {
        //fix branch
        string _Path;
        string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;

                PathChanged(value);

                Properties.Settings.Default.Path = value;
                Properties.Settings.Default.Save();
            }
        }

        FormatsType FormatsType = new FormatsType();

        PathChanged PathChanged;

        public Folder(PathChanged PathChanged)
        {
            this.PathChanged = PathChanged;            
        }

        public void ChangePath(string Path)
        {
            this.Path = Path; 
        }

        public File[] GetFiles()
        {
            List<File> files = new List<File>();
            List<string> formats = FormatsType.GetAllExtensions();

            string format;
            foreach (string file in System.IO.Directory.GetFiles(Path))
            {
                format = file.Substring(file.LastIndexOf('.') + 1).ToLower();                
                if (formats.Contains(format))
                {
                    int start_position = file.LastIndexOf("\\") + 1;
                    
                    string name = file.Substring(start_position, file.LastIndexOf('.') - start_position);
                    string path = file.Substring(0, start_position - 1);

                    files.Add(new File(name, path, format));
                }
            }

            return files.ToArray();
        }
    }
}
