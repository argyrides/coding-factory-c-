using StudentsApp.DTO;
using StudentsApp.Model;

namespace StudentsApp.Service
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student? GetStudent(int id);
        void InsertStudent(StudentDTO studentDTO);
        void UpdateStudent(StudentDTO studentDTO);
        Student? DeleteStudent(StudentDTO studentDTO);
    }
}
