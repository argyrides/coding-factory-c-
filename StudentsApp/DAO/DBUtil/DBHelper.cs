using System.Data.SqlClient;

namespace StudentsApp.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;
   
        //No instances of this class should be available
        private DBHelper(){}

        public static SqlConnection? GetConnection()
        {
            try
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                string url = configurationManager.GetConnectionString("DefaultConnection");
                //string url = "Data Source=DESKTOP-M6LRN8N\\SQLEXPRESS;Initial Catalog=StudentsDB;Integrated Security=True";
                conn = new SqlConnection(url);
                return conn;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }

        public static void CloseConnection()
        {
            conn!.Close();
        }
    }
}
