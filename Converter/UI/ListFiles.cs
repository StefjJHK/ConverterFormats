using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Converter.UI
{
    class ListFiles
    {
        ListBox ListBox;
        List<File> Files = new List<File>(); 

        public ListFiles(ListBox ListBox)
        {
            this.ListBox = ListBox;
        }

        public void ClearFiles()
        {
            ListBox.Items.Clear();
            Files.Clear();
        }

        public void AddFile(File file)
        {
            Files.Add(file);
            ListBox.Items.Add(CreateLabel(file, Files.Count()));
        }

        public List<File> GetSelectedFiles()
        {
            List<File> files = new List<File>();

            foreach(Label label in ListBox.SelectedItems)
            {
                files.Add(Files[(int)label.Tag]);
            }

            return files;
        }

        private Label CreateLabel(File file, int pos)
        {
            Label label = new Label();

            label.Content = file.Name + "." + file.Extension;
            label.Tag = pos;
            label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF424242"));
            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE2E2E2"));
            label.FontSize = 14;

            return label;
        }
    }
}
