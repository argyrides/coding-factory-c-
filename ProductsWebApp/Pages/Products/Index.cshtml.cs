using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsWebApp.DAO;
using ProductsWebApp.Model;
using ProductsWebApp.Service;

namespace ProductsWebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductDAO productDAO = new ProductDAOImpl();
        private readonly IProductService? service;

        public List<Product> Products = new();

        public IndexModel()
        {
            service = new ProductServiceImpl(productDAO);
        }

        public IActionResult OnGet()
        {
            try
            {
                Products = service!.GetAllProducts();
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
