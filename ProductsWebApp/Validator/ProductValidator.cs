using ProductsWebApp.DTO;

namespace ProductsWebApp.Validator
{
    public class ProductValidator
    {
        private ProductValidator() { }

        public static string Validate(ProductDTO? dto)
        {
            string message = "";
            if (dto!.ProductName!.Length == 0)
            {
                message += "Product name can not be Empty.";
            }
            if ((dto!.Quantity! < 0) || (dto!.Price < 0))
            {
                message += "Quantity or Price must be a positive number";
            }

            return message;
        }
    }
}
