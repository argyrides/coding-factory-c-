using System.Data.SqlClient;

namespace ProductsWebApp.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? connection;

        private DBHelper() { }

        public static SqlConnection? GetSqlConnection()
        {
            try
            {
                ConfigurationManager cm = new ConfigurationManager();
                cm.AddJsonFile("appsettings.json");

                string url = cm.GetConnectionString("DefaultConnection");

                connection = new SqlConnection(url);
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }

        public static void CloseConnection()
        {
            connection?.Close();
        }
    }
}
