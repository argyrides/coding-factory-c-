using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsApp.DAO;
using StudentsApp.DTO;
using StudentsApp.Model;
using StudentsApp.Service;

namespace StudentsApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentDAO? studentDAO = new StudentDAOImpl();
        private readonly IStudentService? service;

        public DeleteModel()
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
                StudentDto.Id = id;
                student = service!.DeleteStudent(StudentDto);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }
    }
}
