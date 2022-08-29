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
            //DataGridView.RowBackground;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReaderFromJson readerFromJson = new ReaderFromJson();
        
            User user = new User();

            MessageBox.Show(readerFromJson.ReadFromFile());
            TextBox1.Text = "Button has been pressed";
            MessageBox.Show((string)readerFromJson.ReadFromJsonFile());
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
