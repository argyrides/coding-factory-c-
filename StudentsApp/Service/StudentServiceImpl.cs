using StudentsApp.DAO;
using StudentsApp.DTO;
using StudentsApp.Model;

namespace StudentsApp.Service
{
    public class StudentServiceImpl : IStudentService
    {
        private readonly IStudentDAO dao;

        //dependency injection
        public StudentServiceImpl(IStudentDAO dao)
        {
            this.dao = dao;
        }

        public Student? DeleteStudent(StudentDTO studentDTO)
        {
            Student student = Convert(studentDTO);

            try
            {
                return dao.Delete(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Student? GetStudent(int id)
        {
            try
            {
                return dao.GetStudent(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void InsertStudent(StudentDTO dto)
        {
            Student student = Convert(dto);

            try
            {
                dao.Insert(student);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void UpdateStudent(StudentDTO studentDTO)
        {
            Student student = Convert(studentDTO);

            try
            {
                dao.Update(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        private Student Convert(StudentDTO dto)
        {
            return new Student()
            {
                Id = dto!.Id,
                Firstname = dto!.Firstname!,
                Lastname = dto!.Lastname!
            };
        }
    }
}
