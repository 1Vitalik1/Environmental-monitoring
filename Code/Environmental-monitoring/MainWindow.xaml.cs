using Environmental_monitoring.UiPage;
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
        AllUsers allUser = new AllUsers();
        AddUser addUser = new AddUser();
        ShowAllReport showAllReport = new ShowAllReport();
        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(allUser);
        }
        public void showWindow() => this.Opacity = 1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string fileIdentification = "Identification.idf";
            Database database = new Database();
            if (File.Exists(fileIdentification))
            {
                string file = File.ReadAllText(fileIdentification);
                string login = file.Split('%')[0];
                string password = (file.Split('%')[1]).Replace("\r\n", string.Empty);
                if (database.identification(login, password)) ((App)Application.Current).isAuthorized = true;
                else File.Delete(fileIdentification);
                
            }

            if (((App)Application.Current).isAuthorized == false)
            {
                this.Opacity = 0;
                var window = new UserLogin();    
                window.Owner = this;
                window.ShowDialog();
            }
        }

        private void btn_addUser_Click(object sender, RoutedEventArgs e) => frame.Navigate(addUser);
        private void btn_allUsers_Click(object sender, RoutedEventArgs e) { allUser = new AllUsers(); frame.Navigate(allUser); } 
        private void btn_showAllReport_Click(object sender, RoutedEventArgs e) => frame.Navigate(showAllReport);
    }
}
