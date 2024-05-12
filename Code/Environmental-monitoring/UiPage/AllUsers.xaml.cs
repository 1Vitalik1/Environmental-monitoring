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
    /// Логика взаимодействия для AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Page
    {
        public AllUsers()
        {
            InitializeComponent();
            Database database = new Database();
            foreach(user user in database.users)
            {
                listBox_allUsers.Items.Add(user.ToString());
            }
        }
    }
}
