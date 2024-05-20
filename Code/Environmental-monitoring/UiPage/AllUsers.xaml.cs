using System.Windows.Controls;

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
                listBoxAllUsers.Items.Add(user.ToString());
            }
        }
    }
}
