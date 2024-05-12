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

namespace Environmental_monitoring.UiPage
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
            Database database = new Database();
        public AddUser()
        {
            InitializeComponent();
        }

        private void btn_addUser_Click(object sender, RoutedEventArgs e)
        {
            string login = textBox_login.Text;
            string password = textBox_password.Text;
            string lastname = textBox_lastname.Text;
            string firstname = textBox_firstname.Text;
            string surname = textBox_surname.Text; 
            string phonenumber = textBox_phonenumber.Text;
            label_status.Content = database.addUser(login,password, firstname,lastname, surname,phonenumber);
            textBox_login.Text = string.Empty; textBox_password.Text = string.Empty; textBox_lastname.Text = string.Empty;
            textBox_firstname.Text = string.Empty; textBox_surname.Text = string.Empty; textBox_phonenumber.Text = string.Empty;
        }

        private void btn_delUser_Click(object sender, RoutedEventArgs e)
        {
            label_status.Content = database.delUser(textbox_id.Text);
        }
    }

}
