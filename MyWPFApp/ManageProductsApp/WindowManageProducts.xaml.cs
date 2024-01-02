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
using System.IO;
-
    namespace ManageProductsApp
{
    /// <summary>
    /// Interaction logic for WindowManageProducts.xaml
    /// </summary>
    public partial class WindowManageProducts : Window
    {
        MannageProducts mannageProducts= new MannageProducts();
        public record Product
        {
            public int ProductID { get; set;}
            public string ProductName { get; set;}
        }
        public class MannageProducts
        {
            string filename = "ProductList.json";
            List<Product> products = new List<Product>();
            public List<Product>GetProducts()
            {
                GetDataFromFile();
                return products;
            }
            public void GetDataFromFile()
            {
                try
                {
                    if (File.Exists(filename))
                    {
                        string jsonData = File.ReadAllText(filename);
                        products = JsonSerializer.Deserialize<List<Product>>(jsonData);
                    }
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public void StoreToFile()
            {
                try
                {
                    string jsonData = JsonSerializer.Serialize(products
                        , new JsonSerializerOptions{
                                WriteIndented = true,
                            }
                    );
                    File.WriteAllText(filename, jsonData );
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public void insert(Product product)
            {
                try
                {
                    Product p = products.SingleOrDefault(p => p.ProductID == product.ProductID);
                    if (p != null)
                    {
                        throw new Exception("Product already exist");
                    }
                    products.Add(p);
                    StoreToFile();
                }catch(Exception ex )
                {
                    throw new Exception (ex.Message);
                }
            }
            public void Update(Product product)
            {
                try
                {
                    Product p = products.SingleOrDefault(p => p.ProductID == product.ProductID);
                    if (p == null)
                    {
                        throw new Exception("Product is not exist");
                    }
                    p.ProductName = product.ProductName;
                    StoreToFile();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            mannageProducts.insert(Product{
            });
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        public WindowManageProducts()
        {
            InitializeComponent();
            List<Product> products = mannageProducts.GetProducts();
            lvProducts.ItemsSource = products;
        }
    }
}
