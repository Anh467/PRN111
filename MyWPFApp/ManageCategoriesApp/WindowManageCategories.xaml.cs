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
                    MessageBox.Show(ex.Message);
                }
                cnn.Close();
                return categories;
            }
            public void InsertCategory(Category category)
            {
                cnn.Open();
                string sql = "Insert into Categories (CategoryName) values(@CategoryName)";
                SqlCommand cmd = new SqlCommand(sql, this.cnn);
                try
                {
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    cmd.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cnn.Close();
            }
            public void UpdateCategory(Category category)
            {
                cnn.Open();
                string sql = "Update Categories set CategoryName = @CategoryName where CategoryID = @CategoryID ";
                SqlCommand cmd = new SqlCommand(sql, this.cnn);
                try
                {
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cnn.Close();
            }
            public void DeleteCategory(Category category)
            {
                cnn.Open();
                string sql = "Delete from Categories where CategoryID = @CategoryID ";
                SqlCommand cmd = new SqlCommand(sql, this.cnn);
                try
                {
                    cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cnn.Close();
            }
        }
        public record Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }
        MannageCategory mannageCategory = new MannageCategory();
        
        private Category GetCategory()
        {
            int categoryID = 0;
            Int32.TryParse(txtCategoryID.Text, out categoryID);
            return new Category
            {
                CategoryID = categoryID,
                CategoryName = txtCategoryName.Text,
            };
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            mannageCategory.DeleteCategory(GetCategory());
            dgCateList.ItemsSource = mannageCategory.GetCategories();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            mannageCategory.UpdateCategory(GetCategory());
            dgCateList.ItemsSource = mannageCategory.GetCategories();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            mannageCategory.InsertCategory(GetCategory());
            dgCateList.ItemsSource = mannageCategory.GetCategories();
        }

        public WindowManageCategories()
        {
            InitializeComponent();
            List<Category> categories = mannageCategory.GetCategories();

            dgCateList.ItemsSource = categories;
        }

        
    }
}
