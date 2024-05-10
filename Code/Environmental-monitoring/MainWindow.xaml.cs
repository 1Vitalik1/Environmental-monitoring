using Environmental_monitoring.UiWindows;
using System.IO;
using System.Windows;

namespace Environmental_monitoring
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool auth = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void showWindow() => this.Opacity = 1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!auth)
            {
                string path = "authentication.ath";
                if (!File.Exists(path))
                {
                    this.Opacity = 0;
                    var window = new UserLogin();
                    window.Owner = this;
                    window.ShowDialog();
                }
                else auth = true;
            }
        }
    }
}
