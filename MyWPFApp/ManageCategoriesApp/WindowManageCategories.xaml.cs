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
using System.Data.SqlClient;
using System.Data;

namespace ManageCategoriesApp
{
    /// <summary>
    /// Interaction logic for WindowManageCategories.xaml

    /// </summary>
    /// 
    
    public partial class WindowManageCategories : Window
    {
        public class MannageCategory
        {
            string connetionString;
            SqlConnection cnn;
            public MannageCategory()
            {
                connetionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=MyStore;User ID=viet080702;Password=nguyenanhviet";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                MessageBox.Show("Connection Open  !");
            }
            public List<Category> GetCategories()
            {
                string sql = "Select CategoryID, CategoryName from Categories";
                List<Category> categories = new List<Category>();
                SqlCommand cmd = new SqlCommand(sql, this.cnn);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category
                            {
                                CategoryID = reader.GetInt32("CategoryID"),
                                CategoryName = reader.GetString("CategoryName")
                            });
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return categories;
            }

        }
        public record Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }
        public WindowManageCategories()
        {
            InitializeComponent();
            MannageCategory mannageCategory = new MannageCategory();
            List<Category> cates= mannageCategory.GetCategories();
            dgCateList.ItemsSource = cates;
        }

        
    }
}
