using ProductsWebApp.DAO.DBUtil;
using ProductsWebApp.Model;
using System.Data.SqlClient;

namespace ProductsWebApp.DAO
{
    public class ProductDAOImpl : IProductDAO
    {
        public Product? Delete(Product? product)
        {
            if (product == null) return null;

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "DELETE FROM PRODUCTS WHERE ID=@id";
                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", product.Id);

                int rowsDeleted = command.ExecuteNonQuery();

                return (rowsDeleted > 0) ? product : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "SELECT * FROM PRODUCTS";

                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.Quantity = reader.GetInt32(2);
                    product.Price = reader.GetDouble(3);

                    products.Add(product);
                }

                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public Product? GetProduct(int id)
        {
            Product? product = null;

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "SELECT * FROM PRODUCTS WHERE ID=@id";
                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    product = new Product()
                    {
                        Id = dataReader.GetInt32(0),
                        ProductName = dataReader.GetString(1),
                        Quantity = dataReader.GetInt32(2),
                        Price = dataReader.GetDouble(3)
                    };
                }
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void Insert(Product? product)
        {
            if (product == null) return;

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "INSERT INTO PRODUCTS (PRODUCT_NAME, QUANTITY, PRICE) VALUES (@productName, @quantity, @price)";
                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@productName", product.ProductName);
                command.Parameters.AddWithValue("@quantity", product.Quantity);
                command.Parameters.AddWithValue("@price", product.Price);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void Update(Product? product)
        {
            if (product == null) return;

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "UPDATE PRODUCTS SET PRODUCT_NAME = @productName, QUANTITY = @quantity, PRICE = @price WHERE ID=@id ";
                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@productName", product.ProductName);
                command.Parameters.AddWithValue("@quantity", product.Quantity);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@id", product.Id);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
