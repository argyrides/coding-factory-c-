using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsApp.DAO;
using StudentsApp.DTO;
using StudentsApp.Service;
using StudentsApp.Validator;

namespace StudentsApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        public CreateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO StudentDto = new StudentDTO();
        public string ErrorMessage = "";
        public string SuccessMessage = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            ErrorMessage = "";
            SuccessMessage = "";

            // Get DTO
            StudentDto.Firstname = Request.Form["firstname"];
            StudentDto.Lastname = Request.Form["lastname"];

            // Validate DTO
            ErrorMessage = StudentValidator.Validate(StudentDto);

            // If Error return
            if (!ErrorMessage.Equals("")) return;

            // Insert student  
            try
            {
                service.InsertStudent(StudentDto);
                /*
                 * All the following comments hold if we stay
                 * in page
                 * SuccessMessage = "New Student inserted successfuly";
                 * //If success reset fields for the new insert
                 *  ResetFields();
                 */

                // On Success
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private void ResetFields()
        {
            StudentDto.Firstname = "";
            StudentDto.Lastname = "";
        }
    }
}

