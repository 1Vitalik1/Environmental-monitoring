using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

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
