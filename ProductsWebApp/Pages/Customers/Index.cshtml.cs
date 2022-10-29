using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsWebApp.DAO;
using ProductsWebApp.Model;
using ProductsWebApp.Service;

namespace ProductsWebApp.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerDAO customerDAO = new CustomerDAOImpl();
        private readonly ICustomerService? service;

        public List<Customer> Customers = new();

        public IndexModel()
        {
            service = new ICustomerServiceImpl(customerDAO);
        }

        public IActionResult OnGet()
        {
            try
            {
                Customers = service!.GetAllCustomers();
                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
