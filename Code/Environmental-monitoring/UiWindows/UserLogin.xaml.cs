using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Environmental_monitoring.UiWindows
{
    /// <summary>
    /// Логика взаимодействия для UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        Database database = new Database();
        string fileIdentification = "Identification.idf";
        public UserLogin()
        {
            InitializeComponent();
            label_SQL_Status.Content = database.statusConnectToDatabase();
        }

        private void btn_sand_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string login = TextBox_login.Text;
            string password = TextBox_password.Text;
            if (database.identification(login, password))
            {
                if (!File.Exists(fileIdentification))
                {
                    File.WriteAllLines(fileIdentification, new string[] {($"{login}%{password}")});
                }
                ((App)Application.Current).isAuthorized = true;
                ((MainWindow)Application.Current.MainWindow).showWindow();
                this.Close();
            }
            else label_SQL_Status.Content = "Неправильно введён логин или пароль!";
            
        }

    }
}
