using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using $safeprojectname$.ViewModels;

namespace $safeprojectname$.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow : Window
    {
        internal static MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ExceptionSetting();

            ViewModel = new();
            DataContext = ViewModel;

        }

        private void ExceptionSetting()
        {
            Dispatcher.UnhandledException += (s, e) =>
            {
                e.Handled = true;
                MessageBox.Show(e.Exception.ToString(), "UI.Dispatcher.UnhandledException");
            };

            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                MessageBox.Show(e.Exception.ToString(), "TaskScheduler.UnobservedTaskException");
                e.SetObserved();
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                StringBuilder sb = new();
                if (e.ExceptionObject is Exception ex)
                {
                    sb.Append(ex.ToString());
                }
                else
                {
                    sb.Append(e.ExceptionObject);
                }
                MessageBox.Show(sb.ToString(), "CurrentDomain.UnhandledException");
            };

        }
    }
}
