using ADOBasics.Model;
using ADOBasics.Utility;
using System.Data.SqlClient;

using System.Text;

namespace ADOBasics.Repository
{
    internal class ProductRepository:IProductRepository
    {
        //Sql Connection and Sql Command

        //SqlConnection sqlConnection = null;
        public string connectionString;
        SqlCommand cmd = null;

        //constructor
        public ProductRepository()
        {
            
            //sqlConnection = new SqlConnection("Server=DESKTOP-0TE71RT;Database=PRODUCTAPPDB;Trusted_Connection=True");
            connectionString=DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from ProductTbl";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                   
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ProductId = (int)reader["Product_Id"];
                        product.ProductName = (string)reader["Product_Name"];
                        product.Price = (int)reader["Price"];
                        product.CategoryId = (int)reader["Category_Id"];
                        product.Rating = (float)(double)reader["Rating"];
                        products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products;

        }

        public int AddProduct(Product product)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into ProductTbl values(@Name,@Price,@CatId,@Rating)";
                cmd.Parameters.AddWithValue("@Name", product.ProductName);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@CatId", product.CategoryId);
                cmd.Parameters.AddWithValue("@Rating", product.Rating);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addProductStatus=cmd.ExecuteNonQuery();
                return addProductStatus;
            }
        }

        public int DeleteProduct(int productId)
        {
            using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                cmd.CommandText = "Delete from ProductTbl Where Product_Id=@ProductId";
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Connection=sqlConnection;
                sqlConnection.Open();
                int deleteProductStatus=cmd.ExecuteNonQuery();
                return deleteProductStatus;
            }
        }


        public List<object> GetProductsAndCategoryName()
        {
            List<object> productWithCategories = new List<object>();
            try
            {
                using(SqlConnection sqlconnection=new SqlConnection(connectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Select p.Product_Id, p.Product_Name, p.Price, p.Category_Id, c.Category_Name ");
                    sb.Append("From ProductTbl p ");
                    sb.Append("Inner Join CategoryTbl c On p.Category_Id=c.Id");
                    cmd.CommandText= sb.ToString();
                    //cmd.CommandText = "Select p.Product_Id,p.Product_Name,p.Price,p.Category_Id,c.Category_Name" +
                    //                  " From ProductTbl p " +
                    //                " Inner Join CategoryTbl c On p.Category_Id=c.Id";
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        
                        var productWithCategory = new
                        {
                            ProductId = (int)reader["Product_Id"],
                            ProductName = (string)reader["Product_Name"],
                            Price = (int)reader["Price"],
                            CategoryId = (int)reader["Category_Id"],
                            CategoryName = (string)reader["Category_Name"]

                        };
                                                                  
                        productWithCategories.Add(productWithCategory);
                        
                    }
                 
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return productWithCategories;
        }
    }
}
