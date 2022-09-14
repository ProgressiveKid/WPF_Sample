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
            MessageBox.Show("");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            


        }
    }
}
