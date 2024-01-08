using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository;
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

namespace AutomobileWPFApp
{
    /// <summary>
    /// Interaction logic for WindowCarManagement.xaml
    /// </summary>
    public partial class WindowCarManagement : Window
    {
        ICarRepository carRepository;
        public WindowCarManagement(ICarRepository carRepository)
        {
            InitializeComponent();
            this.carRepository= carRepository;
            LoadCarList();
        }
        private void ShowMessageHandler(string ErrStr, string title)
        {
            MessageBox.Show(ErrStr);
        }
        private Car GetCarObject()
        {
            Car car = null;
            try
            {
                car = new Car
                {
                    CarId = int.Parse(txtCarId.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleasedYear.Text),
                };
            }catch(Exception ex)
            {
                ShowMessageHandler(ex.Message, "Get Car");
            }
            return car;
        }
        //----------------------------------------------------------
        public void LoadCarList()
        {
            var cars= carRepository.GetCars();
            lvCars.ItemsSource = cars;
        }
        //----------------------------------------------------------
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }
        //----------------------------------------------------------
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCarList();
            }catch(Exception ex)
            {
                ShowMessageHandler(ex.Message, "Load Car");
            }
        }
        //----------------------------------------------------------
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var car = GetCarObject();
                car.CarId = 0;
                carRepository.AddCar(car);
                LoadCarList();
                ShowMessageHandler($"{car.CarName} was inserted successfully", "Insert Car");
            }
            catch (Exception ex)
            {
                ShowMessageHandler(ex.Message, "Insert Car");
            }
        }
        //----------------------------------------------------------
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var car = GetCarObject();
                carRepository.UpdateCar(car);
                LoadCarList();
                ShowMessageHandler($"{car.CarName} was Updated successfully", "Update Car");
            }
            catch (Exception ex)
            {
                ShowMessageHandler(ex.Message, "Update Car");
            }
        }
        //----------------------------------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var car = GetCarObject();
                carRepository.RemoveCar(car.CarId);
                LoadCarList();
                ShowMessageHandler($"{car.CarName} was Deleted successfully", "Delete Car");
            }
            catch (Exception ex)
            {
                ShowMessageHandler(ex.Message, "Delete Car");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
