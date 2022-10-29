using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsApp.DAO;
using StudentsApp.DTO;
using StudentsApp.Model;
using StudentsApp.Service;
using StudentsApp.Validator;

namespace StudentsApp.Pages.Students
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService? service;

        public UpdateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO StudentDto = new StudentDTO();
        public string ErrorMessage = "";

        public void OnGet()
        {
            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                student = service!.GetStudent(id);
                StudentDto = ConvertToDto(student!);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            ErrorMessage = "";

            // Get DTO
            StudentDto.Id = int.Parse(Request.Form["id"]);
            StudentDto.Firstname = Request.Form["firstname"];
            StudentDto.Lastname = Request.Form["lastname"];

            // Validate DTO
            ErrorMessage = StudentValidator.Validate(StudentDto);

            // If Error return
            if (!ErrorMessage.Equals("")) return;

            // Update student  
            try
            {
                service!.UpdateStudent(StudentDto);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private StudentDTO ConvertToDto(Student student)
        {
            StudentDTO dto = new StudentDTO();
            dto.Id = student.Id;
            dto.Firstname = student.Firstname;
            dto.Lastname = student.Lastname;

            return dto;
        }
    }
}
