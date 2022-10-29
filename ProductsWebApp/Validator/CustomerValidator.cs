using ProductsWebApp.DTO;

namespace ProductsWebApp.Validator
{
    public class CustomerValidator
    {
        private CustomerValidator() { }

        public static string Validate(CustomerDTO? dto)
        {
            string message = "";
            if (dto!.Name!.Length == 0 || dto!.Surname!.Length == 0)
            {
                message += "Customer name or surname can not be Empty.";
            }
           
            return message;
        }
    }
}
