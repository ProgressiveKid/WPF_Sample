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
using Newtonsoft.Json;
using LiveCharts;
using LiveCharts.Wpf;




namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public SeriesCollection SeriesCollection { get; }

        public MainWindow()
        {
            InitializeComponent();
        }
    

      private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReaderFromJson readerFromJson = new ReaderFromJson();
            List<UserInTable> listPeople = readerFromJson.ReadFromJsonFile();          
            DataGridView.ItemsSource = listPeople;
            //DataGridView.Row
        }
      

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGridView.Columns.Add("newColumnName", "Column Name in Text");
        }

       
            private void DataGridView_Loaded(object sender, RoutedEventArgs e)
        {
            ReaderFromJson readerFromJson = new ReaderFromJson();
             List<UserInTable> listPeople = readerFromJson.ReadFromJsonFile();
            DataGridView.ItemsSource = listPeople;
        }
     
        private void DataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show("");
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // логика построения графика
        {
            ReaderFromJson readerFromJson = new ReaderFromJson();
            // readerFromJson.ShowChart();
            List <UserInTable> ChartList = readerFromJson.ReadFromJsonFile();
            //Chart.Series.Clear();
            SeriesCollection series = new SeriesCollection();
            var years = (from o in ChartList as List<UserInTable> select new { years = o.CountDay }).Distinct();
            foreach (var year in years)
            {
                List<double> values = new List<double>();
                for (int i = 0; i < 10; i++)
                {
                    int iss = 5;
                    values.Add(iss+i*0.3); 
                
                }
                    series.Add(new LineSeries() { Title = year.years.ToString(), Values = new ChartValues<double>(values) });
            }
            Chart.Series = series;
        }
        // нужен метод который считыват строку выбирает от туда имя пользователя ищет его в бигюзере потом идёт в метод на верху
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Chart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Month",
                Labels = new[] {"Jan","Feb", "Хочяеь 3 месяц", "4 сццц"}
            }
            );
            Chart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "revenur",
                LabelFormatter = value => value.ToString("C")
            }
            );
            Chart.LegendLocation = LiveCharts.LegendLocation.Right;
        }

        
    }
}
