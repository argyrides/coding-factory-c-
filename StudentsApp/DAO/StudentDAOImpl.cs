using StudentsApp.DAO.DBUtil;
using StudentsApp.Model;
using System.Data.SqlClient;

namespace StudentsApp.DAO
{
    public class StudentDAOImpl : IStudentDAO
    {
        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "SELECT * FROM STUDENTS";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                    };

                    students.Add(student);
                }

                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public Student? Delete(Student? student)
        {
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "DELETE FROM STUDENTS " + 
                             "WHERE ID=@id";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", student!.Id);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1) return student;
                else return null;   
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                throw;
            }
        }

        public Student? GetStudent(int id)
        {
            Student? student = null;
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "SELECT * FROM STUDENTS " +
                             "WHERE ID=@id";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    student = new()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2),
                    };

                }
                return student;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                throw;
            }

        }
      
        public void Insert(Student? student)
        {
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "INSERT INTO STUDENTS " + 
                             "(FIRSTNAME,LASTNAME) VALUES " + 
                             "(@firstname, @lastname)";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstname", student!.Firstname);
                cmd.Parameters.AddWithValue("@lastname", student!.Lastname);

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                throw;
            }
        }

        public void Update(Student? student)
        {
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "UPDATE STUDENTS SET " +
                             "FIRSTNAME = @firstname, LASTNAME = @lastname WHERE ID=@id";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("@id", student!.Id);
                cmd.Parameters.AddWithValue("@firstname", student!.Firstname);
                cmd.Parameters.AddWithValue("@lastname", student!.Lastname);

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                throw;
            }
        }
    }
}
