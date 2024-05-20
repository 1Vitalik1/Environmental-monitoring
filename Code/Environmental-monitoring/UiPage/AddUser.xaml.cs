using System.Windows;
using System.Windows.Controls;

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
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string lastname = textBoxLastname.Text;
            string firstname = textBox_Firstname.Text;
            string surname = textBoxSurname.Text; 
            string phonenumber = textBox_phonenumber.Text;
            labelStatus.Content = database.addUser(login,password, firstname,lastname, surname,phonenumber);
            textBoxLogin.Text = string.Empty; textBoxPassword.Text = string.Empty; textBoxLastname.Text = string.Empty;
            textBox_Firstname.Text = string.Empty; textBoxSurname.Text = string.Empty; textBox_phonenumber.Text = string.Empty;
        }

        private void btn_delUser_Click(object sender, RoutedEventArgs e)
        {
            labelStatus.Content = database.delUser(textbox_id.Text);
        }
    }

}
