using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsApp.DAO;
using StudentsApp.Model;
using StudentsApp.Service;

namespace StudentsApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentDAO dao = new StudentDAOImpl();
        private readonly IStudentService service;

        public List<Student> Students = new List<Student>();
        
        public IndexModel()
        {
            service = new StudentServiceImpl(dao);
        }

        public IActionResult OnGet()
        {
            try
            {
                Students = service.GetAllStudents();
                return Page();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
