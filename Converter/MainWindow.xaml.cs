using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Converter.UI;
using System.Threading;
using System.Diagnostics;

namespace Converter
{
    public delegate void PathChanged(string path);

    public partial class MainWindow : Window
    {
        enum STATUS
        {
            Waiting,
            Converting
        }

        Folder Folder;
        ConverterFiles ConverterFiles = new ConverterFiles();
        
        ListFiles ListFiles;
        ListFormats ListFormats;

        CancellationTokenSource CancellationTokenSource;        

        STATUS _Status;
        STATUS Status {
            get
            { 
                return _Status; 
            } 
            set 
            {
                StatusChanged(value); 
                _Status = value; 
            } 
        }        

        public MainWindow()
        {
            InitializeComponent();

            CheckDisk CheckDisk = new CheckDisk();

            ListFiles = new ListFiles(list_box_files_info);
            ListFormats = new ListFormats(list_box_formats);

            Folder = new Folder(new PathChanged(ChangeFolderInfo));
            Folder.ChangePath(Properties.Settings.Default.Path);

            LoadUI();
        }

        private void LoadUI()
        {
            text_folder.Text = Properties.Settings.Default.Folder;
            label_path_info.Content = Properties.Settings.Default.Path + "\\" + Properties.Settings.Default.Folder;

            Status = STATUS.Waiting;
        }

        private void StatusChanged(STATUS value)
        {
            switch(value)
            {
                case STATUS.Waiting:
                    {
                        button_path_change.IsEnabled = true;
                        text_folder.IsEnabled = true;

                        button_start_converting.Content = "Start Converting";

                        ChangeStatusConverting(action: "", max_value: 10);

                        break;
                    }
                case STATUS.Converting:
                    {
                        button_path_change.IsEnabled = false;
                        text_folder.IsEnabled = false;

                        button_start_converting.Content = "Stop Converting";

                        break;
                    }
            }
        }

        private void ChangeFolderInfo(string path)
        {
            label_path_info.Content = path;

            ListFiles.RefereshContent(Folder.GetFiles());
        }

        private void ChangeStatusConverting(string action = "[null]", int step_progress = 0, int max_value = -1, string obj = "")
        {
            if (action != "[null]")
                label_status_type.Dispatcher.Invoke(() => label_status_type.Content = action);

            if(max_value != -1)
            {
                progress_bar.Dispatcher.Invoke(() => progress_bar.Maximum = max_value - 1);
                progress_bar.Dispatcher.Invoke(() => progress_bar.Value = 0);
            }

            progress_bar.Dispatcher.Invoke(() => progress_bar.Value += step_progress);
            label_status_converting.Dispatcher.Invoke(() => label_status_converting.Content = obj);
        }

        private void button_path_change_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.Path;

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Folder.ChangePath(folderBrowserDialog.SelectedPath);
            }
        }

        private void button_start_converting_Click(object sender, RoutedEventArgs e)
        {
            switch(Status)
            {
                case STATUS.Converting:
                    {
                        CancellationTokenSource.Cancel();
                        Status = STATUS.Waiting;

                        break;
                    }
                case STATUS.Waiting:
                    {
                        CancellationTokenSource = new CancellationTokenSource();

                        Status = STATUS.Converting;
                        
                        asyncStartConverting(CancellationTokenSource.Token);

                        break;
                    }
            }            
        }
        
        async private void asyncStartConverting(CancellationToken cancellationToken)
        {
            File[] files = ListFiles.GetSelectedFiles();
            Format format = ListFormats.GetSelectedFormat();

            ChangeStatusConverting(action: "Converting", max_value: files.Length);

            string folder = "";
            foreach (File file in files)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                ChangeStatusConverting(action: "Converting", obj: file.Name + "." + file.Extension);

                text_folder.Dispatcher.Invoke(() => folder = text_folder.Text);

                await Task.Run(() => ConverterFiles.SaveConvertedImage(file, format, folder));

                ChangeStatusConverting(step_progress: 1);
            }

            Status = STATUS.Waiting;            

            System.Windows.MessageBox.Show("Completed!");

            list_box_files_info.SelectedItem = null;
        }

        private void text_folder_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            label_path_info.Content = Properties.Settings.Default.Path + "\\" + text_folder.Text;

            Properties.Settings.Default.Folder = text_folder.Text;
            Properties.Settings.Default.Save();
        }

        private void button_author_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/id427181930");
        }
    }
}