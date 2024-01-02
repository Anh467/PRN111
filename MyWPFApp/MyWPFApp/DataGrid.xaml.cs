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
using System.Windows.Shapes;

namespace MyWPFApp
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    /// 

    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();
            Loaded += DemoDataGrid_Loaded;
        }
        private void DemoDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            List<dynamic> cars = new List<dynamic> {
                new {CarName = "A6", Color="White", Brand="Audi"},
                new {CarName = "Lexus 570", Color="Black", Brand="Toyota"},
                new {CarName = "Ford Ranger Raptor", Color="White", Brand="Ford"}
            };
            dgCarList.ItemsSource = cars;
        }
    }
}
