using System.Windows;
using System.Windows.Controls;

namespace Environmental_monitoring.UiPage
{
    /// <summary>
    /// Логика взаимодействия для showAllReport.xaml
    /// </summary>
    public partial class ShowAllReport : Page
    {
        Database database = new Database();
        public ShowAllReport()
        {
            InitializeComponent();
            ShowAllReportInCombobox();
        }

        private void ShowAllReportInCombobox()
        {
            comboBox_allReport.Items.Clear();
            foreach(report report in database.reports)
            {
                comboBox_allReport.Items.Add(report.date);
            }

        }

        private void btn_readData_Click(object sender, RoutedEventArgs e)
        {
            int selectedId = comboBox_allReport.SelectedIndex;
            report report = database.reports[selectedId];
            listBox_report.Items.Clear();
            listBox_report.Items.Add($"Дата: {report.date}");
            listBox_report.Items.Add($"Описание: {report.description}");
            listBox_report.Items.Add($"Вода: {database.readData($"SELECT * FROM `watterdata` WHERE Id_WaterData={selectedId + 1}")}");
            listBox_report.Items.Add($"Радиация: {database.readData($"SELECT * FROM `radioactivedata` WHERE Id_RadioactiveData={selectedId + 1}")}");
            listBox_report.Items.Add($"Воздух: {database.readData($"SELECT * FROM `airdata` WHERE Id_airData={selectedId + 1}")}");
            listBox_report.Items.Add($"Почва: {database.readData($"SELECT * FROM `soildata` WHERE Id_soilData={selectedId + 1}")}");
            //            listBox_report.Items.Add($"Радиация: {report.radioactiveData}");
        }
    }
}
