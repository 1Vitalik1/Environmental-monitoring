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
            comboBoxAllReport.Items.Clear();
            foreach(report report in database.reports) comboBoxAllReport.Items.Add(report.date);

        }

        private void btn_readData_Click(object sender, RoutedEventArgs e)
        {
            int selectedId = comboBoxAllReport.SelectedIndex;
            report report = database.reports[selectedId];
            listBoxReport.Items.Clear();
            listBoxReport.Items.Add($"Дата: {report.date}");
            listBoxReport.Items.Add($"Описание: {report.description}");
            listBoxReport.Items.Add($"Вода: {database.readData($"SELECT * FROM `watterdata` WHERE Id_WaterData={selectedId + 1}")}");
            listBoxReport.Items.Add($"Радиация: {database.readData($"SELECT * FROM `radioactivedata` WHERE Id_RadioactiveData={selectedId + 1}")}");
            listBoxReport.Items.Add($"Воздух: {database.readData($"SELECT * FROM `airdata` WHERE Id_airData={selectedId + 1}")}");
            listBoxReport.Items.Add($"Почва: {database.readData($"SELECT * FROM `soildata` WHERE Id_soilData={selectedId + 1}")}");
        }
    }
}
