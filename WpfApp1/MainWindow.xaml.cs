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
using System.Reflection.Emit;
using LiveCharts.Definitions.Charts;

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
           // DataGridView.Columns[0].HeaderText = "название столбца";
        }

        public int [] DataForChart()
        {
            UserInTable userInTable = (UserInTable)DataGridView.SelectedItem;
            string nameFromGridView = userInTable.UserName;

            ReaderFromJson readerFromJson = new ReaderFromJson();
            var BigUser = readerFromJson.ReadFromJsonFile();
            var ListForGrid = ReaderFromJson.ListForGridView; // Копия BigUser - лист со всеми значениями ищ папки JSON
            int[] DayWithValue = new int[userInTable.CountDay];
            int countDay = 0;
            foreach (var Data in ListForGrid)
            {
                if (Data.UserName == nameFromGridView)
                {
                    DayWithValue[countDay] = Data.Steps;
                    countDay++;
                }
            }
            return DayWithValue;
        }

        private void DataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show("");


            int[] ints = DataForChart();
            int n = ints[4];
            MessageBox.Show(Convert.ToString(n));
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
            /*
            Chart.Series.Add(new VerticalLineSeries
            {
                Values = new ChartValues<double> { 3, 5, 2, 6, 2, 7, 1 }
            });

            Chart.Series.Add(new RowSeries
            {
                Values = new ChartValues<double> { 6, 2, 6, 3, 2, 7, 2 }
            });

            Chart.AxisY.Add(new Axis
            {
               // Separator = new Separator { Step = 1 }
            });

            Chart.AxisX.Add(new Axis
            {
                MinValue = 0
            });

            var tooltip = new DefaultTooltip
            {
                SelectionMode = TooltipSelectionMode.SharedYValues
            };

            Chart.DataTooltip = tooltip;
            // int[] ints = DataForChart();
            //int CountDay = ints.Count();
            /*
            Chart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "День",
                
                Labels = new[] {
                 
                    "Jan","Feb", "Хочяеь 3 месяц", "4 сццц"}
            }
            );
            Chart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Значения",
                LabelFormatter = value => value.ToString("C")
            }
            );
            */
            Chart.LegendLocation = LiveCharts.LegendLocation.Right;
        }

        
    }
}
