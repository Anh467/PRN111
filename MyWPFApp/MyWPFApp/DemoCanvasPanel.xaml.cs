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
using System.Xml.Linq;

namespace MyWPFApp
{
    /// <summary>
    /// Interaction logic for DemoCanvasPanel.xaml
    /// </summary>
    public partial class DemoCanvasPanel : Window
    {
        public DemoCanvasPanel()
        {
            InitializeComponent();
        }
        class Car
        {
            public string name;
            public string color;
            public string brand;
            public Car(string name, string color, string brand)
            {
                this.name = name;
                this.color = color;
                this.brand = brand;
            }
            public string ToString(){
                return "Car Name: " + this.name + "\n" + "Color: " + this.color + "\n" + "Brand: " + this.brand;
            }
        }
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            Car car= new Car(txtCarName.Text, txtColor.Text, txtBrand.Text);
            MessageBox.Show(car.ToString(), "Car Details");
        }
    }
}
