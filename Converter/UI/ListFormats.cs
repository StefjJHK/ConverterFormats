﻿using Converter.Formats;
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
        List<Format> Formats;

        public ListFormats(ListBox ListBox)
        {
            this.ListBox = ListBox;
            ListBox.SelectionChanged += ListBox_SelectionChanged;

            FormatsType FormatsType = new FormatsType();
            Formats = FormatsType.GetAllFormats();

            RefereshContent(FormatsType.GetAllFormats());
        }

        private void RefereshContent(List<Format> formats)
        {
            ListBox.Items.Clear();

            int count = 0;
            for(int j = 0; j < Formats.Count(); j++)
            {
                ListBox.Items.Add(CreateLabel(Formats[j], j));

                count++;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.Format = GetSelectedFormat().GetFormat();
            Properties.Settings.Default.Save();
        }

        public Format GetSelectedFormat()
        {
            if (ListBox.SelectedItem != null)
                return Formats[(int)((Label)ListBox.SelectedItem).Tag];

            return Formats[0];
        }        

        private Label CreateLabel(Format format, int index)
        {
            Label label = new Label();

            label.Content = format.GetExtension();
            label.Tag = index;
            label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF424242"));
            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE2E2E2"));
            label.FontSize = 14;

            return label;
        }
    }
}
