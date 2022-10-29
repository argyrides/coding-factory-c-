using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsWebApp.DAO;
using ProductsWebApp.DTO;
using ProductsWebApp.Service;
using ProductsWebApp.Validator;

namespace ProductsWebApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductDAO productDAO = new ProductDAOImpl();
        private readonly IProductService? service;
        public CreateModel()
        {
            service = new ProductServiceImpl(productDAO);
        }

        internal ProductDTO productDTO = new();
        public string ErrorMessage = "";
        public string SuccessMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            productDTO.ProductName = Request.Form["productName"];
            productDTO.Quantity = Convert.ToInt32(Request.Form["quantity"]);
            productDTO.Price = Convert.ToDouble(Request.Form["price"]);

            ErrorMessage = ProductValidator.Validate(productDTO);

            if (!ErrorMessage.Equals("")) return;
            try
            {
                service!.InsertProduct(productDTO);
                SuccessMessage = "Product Inserted Successfully.";
                ClearFields();
                //Response.Redirect("/Products/Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

        }

        public void ClearFields()
        {
            productDTO.ProductName = "";
            productDTO.Price = 0;
            productDTO.Quantity = 0;
        }
    }
}
