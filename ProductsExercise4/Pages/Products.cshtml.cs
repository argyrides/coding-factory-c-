using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductsExercise4.Pages
{
    public class ProductsModel : PageModel
    {
        public IEnumerable<string>? ProductsList { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Products";

            ProductsList = new[]
            {
                "Milk","Bread","Oranges","Apples","Cookies"
            };
        }
    }
}
