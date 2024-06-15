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

        public string File
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void TxtFile_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            File = txtFile.Text;
        }

        public string Path
        {
            get
            {
                string fullPath = (string)GetValue(TextProperty);
                var x = new System.IO.FileInfo(fullPath);
                return x.DirectoryName;
            }
        }

        public string FileName
        {
            get
            {
                string fullPath = (string)GetValue(TextProperty);
                var x = new System.IO.FileInfo(fullPath);
                return x.Name;
            }
        }
    }
}
