using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GenericClassLibrary.Logging;

namespace GenericWPFLibrary.Usercontrol.WpfScreenLogger
{
    /// <summary>
    /// Interaction logic for ScreenLogger.xaml
    /// </summary>
    public partial class WpfScreenLogger : System.Windows.Controls.UserControl
    {
        private ScreenLogger screenLogger;
        public WpfScreenLogger()
        {
            InitializeComponent();
            Reset();            
        }

        public void Reset()
        {
            if(screenLogger != null)
            {
                Logger.Remove(screenLogger);
            }
            screenLogger = new ScreenLogger(AddLog);
            Logger.AddLogger(screenLogger);
        }
        #region logging
        public void UpdateLogText(string line)
        {
            LogContent.Text += line;
        }

        public delegate void UpdateLogTextDelegate(string line);
        //see https://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-3

        public void AddLog(object sender, ScreenLogEventArgs logThis)
        {
            string line = "\r\n" + DateTime.Now.ToString() + " " + logThis.Level.ToString() + ": " + logThis.Value;
            this.Dispatcher.Invoke(new UpdateLogTextDelegate(UpdateLogText), line);
        }
        #endregion
    }
}
