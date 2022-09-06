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
            ReaderFromJson readerFromJson = new ReaderFromJson();
           
          
            //MessageBox.Show((string)readerFromJson.ReadFromJsonFile());
        }
       
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGridView.Columns.Add("newColumnName", "Column Name in Text");
        }
        private List<User> ProcessingData()
        {
            ReaderFromJson readerFromJson = new ReaderFromJson();
            List<User> BigUser = readerFromJson.ReadFromJsonFile();
            List<UserInTable> userInTables = new List<UserInTable>();
            List<User> NewBigUser = BigUser;
            foreach (User Data in BigUser)
            {

                List<User> result = Data.GroupBy(x => x)
                         .Where(g => g.Count() > 1)
                         .Select(x => x.Key)
                         .ToList();
                string nameForSearch = Data.UserName;

              // как сделать так чтобы все значения объеденились
                //в одно и все вхождения в эжто значения ссумировались

                /*
                //string name = BigUser.FindAll(Data);
                if (BigUser.Contains(Data) && )
                {
                }
                else
                {
                    new UserInTable()
                    {
                        UserName = Data.UserName
                    };                 
                                      //BigUser.Add(Data);
            
                }
                */
                if (nameForSearch == NewBigUser)
                {
                
                
                }



            
            }



            return BigUser;
        }
        private void DataGridView_Loaded(object sender, RoutedEventArgs e)
        {
            ReaderFromJson readerFromJson = new ReaderFromJson();
            List<User> listPeople = readerFromJson.ReadFromJsonFile();
            listPeople.GroupBy(v => v).Where(g => g.Count() > 1).Select(g => g.Key);
            DataGridView.ItemsSource = listPeople;
        }

     
    }
}
