using MySqlConnector;
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
using System.Windows.Shapes;

namespace Environmental_monitoring.UiWindows
{
    /// <summary>
    /// Логика взаимодействия для UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        Database database = new Database();
        public UserLogin()
        {
            InitializeComponent();
            Connect();
           
        }

        private void btn_sand_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).auth = true;
            ((MainWindow)Application.Current.MainWindow).showWindow();
            this.Close();
        }

        private void label_SQL_Status_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Connect();
        }

        public void Connect()
        {
            if (database.ConnectToDatabase()) { label_SQL_Status.Content = "Успешно подключено"; label_SQL_Status.Content = database.readAllAccounts(); }
            else label_SQL_Status.Content = "При подключении произошла ошибка";
        }

    }
}
