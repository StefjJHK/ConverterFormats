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
            Properties.Settings.Default.Format = GetSelectedFormat().GetFormat();
            Properties.Settings.Default.Save();
        }

        private void RefereshContent(Format[] formats)
        {
            ListBox.Items.Clear();

            foreach (Format format in formats)
            {
                ListBox.Items.Add(GetLabel(format));

                if (Properties.Settings.Default.Format == format.GetFormat())
                    ListBox.SelectedIndex = ListBox.Items.Count - 1;
            }
        }

        public Format GetSelectedFormat()
        {
            if (ListBox.SelectedItem != null)
                return (Format)((Label)ListBox.SelectedItem).Tag;

            return new Png();
        }        

        private Label GetLabel(Format format)
        {
            Label label = new Label();

            label.Content = format.GetExtension();
            label.Tag = format;
            label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF424242"));
            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE2E2E2"));
            label.FontSize = 14;

            return label;
        }
    }
}
