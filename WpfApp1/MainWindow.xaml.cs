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



namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

      private void Button_Click(object sender, RoutedEventArgs e)
        {
           // ReaderFromJson readerFromJson = new ReaderFromJson();
          //  MessageBox.Show(Convert.ToString(readerFromJson.message));
            ReaderFromJson readerFromJson = new ReaderFromJson();
            List<UserInTable> listPeople = readerFromJson.ReadFromJsonFile();
            //List <UserInTable> listPeople = ProcessingData();
            // listPeople.GroupBy(v => v).Where(g => g.Count() > 1).Select(g => g.Key);
            // var uniq = listPeople.Distinct();

            DataGridView.ItemsSource = listPeople;
            //MessageBox.Show((string)readerFromJson.ReadFromJsonFile());
        }
       
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGridView.Columns.Add("newColumnName", "Column Name in Text");
        }
        private List<UserInTable> ProcessingData()
        {
            ReaderFromJson readerFromJson = new ReaderFromJson();
            // List<User> BigUser = readerFromJson.ReadFromJsonFile();
            List<UserInTable> BigUser = readerFromJson.ReadFromJsonFile();
            List<UserInTable> userInTables = new List<UserInTable>();
          //  List<User> NewBigUser = BigUser;
            int count = 0;
            for (int i = 0; i < BigUser.Count; i++)
            {
                //Если элемент уже входит в userInTable
                if (userInTables[i].UserName == BigUser[i].UserName)
                {
                    userInTables[count].CountDay = count++;

                }
                else // Если не входит 
                {

                    userInTables[count].UserName = BigUser[i].UserName;
                    userInTables[count].CountDay = count++;

                   

                }
                count++;

            }
          
            return userInTables;
        }
        private void DataGridView_Loaded(object sender, RoutedEventArgs e)
        {
            ReaderFromJson readerFromJson = new ReaderFromJson();
             List<UserInTable> listPeople = readerFromJson.ReadFromJsonFile();
            //List <UserInTable> listPeople = ProcessingData();
            // listPeople.GroupBy(v => v).Where(g => g.Count() > 1).Select(g => g.Key);
           // var uniq = listPeople.Distinct();
            
            DataGridView.ItemsSource = listPeople;
        }
       // public event System.Windows.Forms.DataGridViewCellEventHandler CellDoubleClick;
        private void DataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("");
        }
       
    }
}
