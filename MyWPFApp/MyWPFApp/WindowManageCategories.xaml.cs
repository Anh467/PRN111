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
                
                MessageBox.Show("Connection Open  !");
            }
            public List<Category> GetCategories()
            {
                cnn.Open();
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
                            categories.Add(new Category(
                                reader.GetInt32("CategoryID"),
                                reader.GetString("CategoryName")
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                cnn.Close();
                return categories;
                
            }
            public void InsertCategories(Category cate)
            {
                cnn.Open();
                string sql = "INSERT INTO Categories(CategoryName) values (@CategoryName)";
                SqlCommand cmd = new SqlCommand(sql, this.cnn);
                try
                {
                    cmd.Parameters.AddWithValue("@CategoryName", cate.CategoryName);
                    cmd.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                cnn.Close();
            }
            public void UpdateCategories(Category cate)
            {
                cnn.Open();
                string sql = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID;";
                SqlCommand cmd = new SqlCommand(sql, this.cnn);
                try
                {
                    cmd.Parameters.AddWithValue("@CategoryName", cate.CategoryName);
                    cmd.Parameters.AddWithValue("@CategoryID", cate.CategoryID);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                cnn.Close();
            }

            public void DeleteCategories(Category cate)
            {
                cnn.Open();
                string sql = "delete Categories WHERE CategoryID = @CategoryID;";
                SqlCommand cmd = new SqlCommand(sql, this.cnn);
                try
                {
                    cmd.Parameters.AddWithValue("@CategoryID", cate.CategoryID);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                cnn.Close();
            }
        }
        public record Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public Category(int CategoryID, string CategoryName)
            {
                this.CategoryID = CategoryID;
                this.CategoryName = CategoryName;
            }
        }
        MannageCategory mannageCategory = new MannageCategory();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private Category GetCategory()
        {
            string name = txtCategoryName.Text;
            int categoryID = 0;
            Int32.TryParse(txtCategoryID.Text, out categoryID);

            return new Category(categoryID, name);
        }
        private void btnInsert_Click_1(object sender, RoutedEventArgs e)
        {
            mannageCategory.InsertCategories(GetCategory());
            List<Category> cates = mannageCategory.GetCategories();
            lvCategories.ItemsSource = cates;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            mannageCategory.UpdateCategories(GetCategory());
            List<Category> cates = mannageCategory.GetCategories();
            lvCategories.ItemsSource = cates;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            mannageCategory.DeleteCategories(GetCategory());
            List<Category> cates = mannageCategory.GetCategories();
            lvCategories.ItemsSource = cates;
        }

        public WindowManageCategories()
        {
            InitializeComponent();
            List<Category> cates = mannageCategory.GetCategories();
            lvCategories.ItemsSource = cates;
        }


    }
}
