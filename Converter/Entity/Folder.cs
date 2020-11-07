using System.Collections;
using System.Collections.Generic;

namespace Converter
{
    class Folder
    {
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

        public IEnumerable GetFiles()
        {
            List<string> extensions = FormatsType.GetAllExtensions();

            foreach (string file in System.IO.Directory.GetFiles(Path))
            {
                var extension = file.Substring(file.LastIndexOf('.') + 1).ToLower();                
                if (extensions.Contains(extension))
                {
                    int start_position = file.LastIndexOf("\\") + 1;
                    
                    string name = file.Substring(start_position, file.LastIndexOf('.') - start_position);
                    string path = file.Substring(0, start_position - 1);

                    yield return new File(name, path, extension);
                }
            }
        }
    }
}
