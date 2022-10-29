using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsWebApp.DAO;
using ProductsWebApp.DTO;
using ProductsWebApp.Model;
using ProductsWebApp.Service;
using ProductsWebApp.Validator;

namespace ProductsWebApp.Pages.Products
{
    public class UpdateModel : PageModel
    {
        private readonly IProductDAO dao = new ProductDAOImpl();
        private readonly IProductService? service;

        public UpdateModel()
        {
            service = new ProductServiceImpl(dao);
        }

        internal ProductDTO productDTO = new ProductDTO();
        public string ErrorMessage = "";
        public string SuccessMessage = "";
        public void OnGet()
        {
            try
            {
                Product? product;

                int id = int.Parse(Request.Query["id"]);
                product = service!.GetProduct(id);
                productDTO = ConvertToDto(product!);
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
            productDTO.Id = int.Parse(Request.Form["id"]);
            productDTO.ProductName = Request.Form["productName"];
            productDTO.Quantity = Convert.ToInt32(Request.Form["quantity"]);
            productDTO.Price = Convert.ToDouble(Request.Form["price"]);

            // Validate DTO
            ErrorMessage = ProductValidator.Validate(productDTO);

            // If Error return
            if (!ErrorMessage.Equals("")) return;

            // Update student  
            try
            {
                service!.UpdateProduct(productDTO);
                SuccessMessage = "Product Modified Successfully.";
                
                //Response.Redirect("/Products/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private ProductDTO ConvertToDto(Product product)
        {
            ProductDTO dto = new ProductDTO();
            dto.Id = product.Id;
            dto.ProductName = product.ProductName;
            dto.Price = product.Price;
            dto.Quantity = product.Quantity;

            return dto;
        }
    }
}
