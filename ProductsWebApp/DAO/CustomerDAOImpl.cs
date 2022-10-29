using ProductsWebApp.DAO.DBUtil;
using ProductsWebApp.Model;
using System.Data.SqlClient;

namespace ProductsWebApp.DAO
{
    public class CustomerDAOImpl : ICustomerDAO
    {
        public Customer? Delete(Customer? customer)
        {
            if (customer == null) return null;

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "DELETE FROM CUSTOMERS WHERE ID=@id";
                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", customer.Id);

                int rowsDeleted = command.ExecuteNonQuery();

                return (rowsDeleted > 0) ? customer : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "SELECT * FROM CUSTOMERS";

                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = reader.GetInt32(0);
                    customer.Name = reader.GetString(1);
                    customer.Surname = reader.GetString(2);

                    customers.Add(customer);
                }

                return customers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public Customer? GetCustomer(int id)
        {
            Customer? customer = null;

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "SELECT * FROM CUSTOMERS WHERE ID=@id";
                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    customer = new Customer()
                    {
                        Id = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        Surname = dataReader.GetString(2)

                    };
                }
                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void Insert(Customer? customer)
        {
            if (customer == null) return;

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "INSERT INTO CUSTOMERS (NAME, SURNAME) VALUES (@name, @sname)";
                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@name", customer.Name);
                command.Parameters.AddWithValue("@sname", customer.Surname);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void Update(Customer? customer)
        {
            if (customer == null) return;

            try
            {
                using SqlConnection? connection = DBHelper.GetSqlConnection();

                connection!.Open();
                string sql = "UPDATE CUSTOMERS SET NAME = @name, SURNAME = @sname WHERE ID=@id ";
                using SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@name", customer.Name);
                command.Parameters.AddWithValue("@sname", customer.Surname);
                command.Parameters.AddWithValue("@id", customer.Id);

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
