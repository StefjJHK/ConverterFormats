using System;
using System.Collections.Generic;
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

        public ListFiles(ListBox ListBox)
        {
            this.ListBox = ListBox;
        }

        public void RefereshContent(File[] files)
        {
            ListBox.Items.Clear();

            foreach(File file in files)
            {
                ListBox.Items.Add(GetLabel(file));
            }
        }

        public File[] GetSelectedFiles()
        {
            List<File> files = new List<File>();

            foreach(Label label in ListBox.SelectedItems)
            {
                files.Add((File)label.Tag);
            }

            return files.ToArray();
        }

        private Label GetLabel(File file)
        {
            Label label = new Label();

            label.Content = file.Name + "." + file.FormatToString;
            label.Tag = file;
            label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF424242"));
            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE2E2E2"));
            label.FontSize = 14;

            return label;
        }
    }
}
