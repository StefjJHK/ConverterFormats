using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace Converter
{
    class Folder
    {
        public string Name { get; private set; }
        public string Path { get; private set; }

        SupportFormats SupportFormats = new SupportFormats();

        Label PathInfo;
        TextBox TextFolder;

        public Folder(Label PathInfo, TextBox TextFolder)
        {
            this.PathInfo = PathInfo;
            this.TextFolder = TextFolder;

            TextFolder.KeyUp += TextFolder_KeyUp;
        }

        private void TextFolder_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Name = TextFolder.Text; 
        }

        public void ChangePath(string Path)
        {
            this.Path = Path;

            PathInfo.Content = Path;

            Properties.Settings.Default.Path = Path;
            Properties.Settings.Default.Save();
        }

        public void SaveImage(ImageMagick.MagickImage magickImage, File file, string folder = "test")
        {
            Directory.CreateDirectory(file.Path + "\\" + folder + "\\");

            magickImage.Write(file.Path + "\\" + folder + "\\" + file.Name + "." + magickImage.Format.ToString().ToLower());
        }

        public IEnumerable GetFiles()
        {            
            List<string> extensions = SupportFormats.GetAllExtensions();

            foreach (string file in Directory.GetFiles(Path))
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
