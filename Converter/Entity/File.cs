using ImageMagick;

namespace Converter
{
    class File
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public string Extension { get; private set; }

        public MagickFormat Format { get; private set; }

        public File(string Name, string Path, string Extension)
        {
            this.Name = Name;
            this.Path = Path;
            this.Extension = Extension;
        }

        public string GetFullPath()
        {
            return Path + "\\" + Name + "." + Extension;
        }
    }
}
