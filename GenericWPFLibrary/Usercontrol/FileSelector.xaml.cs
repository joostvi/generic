using System;
using System.Windows;
using System.Windows.Forms;

namespace GenericWPFLibrary.Usercontrol
{
    /// <summary>
    /// Interaction logic for FileSelector.xaml
    /// </summary>
    public partial class FileSelector : System.Windows.Controls.UserControl
    {
        public FileSelector()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextProperty =
DependencyProperty.Register("File", typeof(string), typeof(FileSelector), new UIPropertyMetadata(null, Text_PropertyChanged));

        private static void Text_PropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ((FileSelector)source).txtFile.Text = (string)e.NewValue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!WindowsVersionChecker.RunningOnWindows() ||  WindowsVersionChecker.IsWindowsVersionAfter61())
            {


                var dialog = new OpenFileDialog
                {
                    FileName = txtFile.Text
                };
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    File = dialog.FileName;
                }
            }
            else
            {
                var dialog = new Microsoft.Win32.OpenFileDialog
                {
                    FileName = txtFile.Text
                };
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    File = dialog.FileName;
                }
            }
        }

        public string File
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void TxtFile_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            File = txtFile.Text;
        }

        public SelectedFileInfo FileInfo
        {
            get
            {
                string fullPath = (string)GetValue(TextProperty);
                return new SelectedFileInfo(fullPath);
            }
        }
    }

    public readonly struct SelectedFileInfo
    {
        public string FileLocation { get; }
        public string FullFileName { get; }
        public string Extension { get; }
        public string File { get; }

        public SelectedFileInfo(string file)
        {
            File = file;
            var fileInfo = new System.IO.FileInfo(file);
            FileLocation = fileInfo.DirectoryName;
            FullFileName = fileInfo.Name;
            Extension = fileInfo.Extension;
        }

    }

    public static class WindowsVersionChecker
    {
        public static bool IsWindowsVersionAfter61()
        {
            Version currentVersion = Environment.OSVersion.Version;
            Version targetVersion = new Version(6, 1);

            return currentVersion > targetVersion;
        }
        public static bool RunningOnWindows()
        {
            var platform = Environment.OSVersion.Platform;
            return platform == PlatformID.Win32NT || platform == PlatformID.Win32Windows;
        }
    }
}
