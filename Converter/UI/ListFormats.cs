using Converter.Formats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Converter.UI
{
    class ListFormats
    {
        ListBox ListBox;

        FormatsType FormatsType = new FormatsType();

        public ListFormats(ListBox ListBox)
        {
            this.ListBox = ListBox;

            ListBox.SelectionChanged += ListBox_SelectionChanged;

            RefereshContent(FormatsType.GetAllFormats());
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.Format = GetSelectedFormat().GetFormatType();
            Properties.Settings.Default.Save();
        }

        private void RefereshContent(IFormat[] formats)
        {
            ListBox.Items.Clear();

            foreach (IFormat format in formats)
            {
                ListBox.Items.Add(GetLabel(format));

                if (Properties.Settings.Default.Format == format.GetFormatType())
                    ListBox.SelectedIndex = ListBox.Items.Count - 1;
            }
        }

        public IFormat GetSelectedFormat()
        {
            if (ListBox.SelectedItem != null)
                return (IFormat)((Label)ListBox.SelectedItem).Tag;

            return new Png();
        }        

        private Label GetLabel(IFormat format)
        {
            Label label = new Label();

            label.Content = format.GetFormatToString();
            label.Tag = format;
            label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF424242"));
            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE2E2E2"));
            label.FontSize = 14;

            return label;
        }
    }
}
