using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsWebApp.DAO;
using ProductsWebApp.DTO;
using ProductsWebApp.Model;
using ProductsWebApp.Service;

namespace ProductsWebApp.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductDAO? productDAO = new ProductDAOImpl();
        private readonly IProductService? service;

        public DeleteModel()
        {
            service = new ProductServiceImpl(productDAO);
        }


        internal ProductDTO productDTO = new ProductDTO();
        public string ErrorMessage = "";

        public void OnGet()
        {
            try
            {
                Product? product;

                int id = int.Parse(Request.Query["id"]);
                productDTO.Id = id;
                product = service!.DeleteProduct(productDTO);
                Response.Redirect("/Products/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }
    }
}
