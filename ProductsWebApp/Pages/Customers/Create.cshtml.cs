using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsWebApp.DAO;
using ProductsWebApp.DTO;
using ProductsWebApp.Service;
using ProductsWebApp.Validator;

namespace ProductsWebApp.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerDAO customerDAO = new CustomerDAOImpl();
        private readonly ICustomerService? service;

        public CreateModel()
        {
            service = new ICustomerServiceImpl(customerDAO);
        }
        internal CustomerDTO customerDTO = new();
        public string ErrorMessage = "";
        public string SuccessMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            customerDTO.Name = Request.Form["name"];
            customerDTO.Surname = Request.Form["sname"];

            ErrorMessage = CustomerValidator.Validate(customerDTO);

            if (!ErrorMessage.Equals("")) return;
            try
            {
                service!.InsertCustomer(customerDTO);
                SuccessMessage = "Customer Inserted Successfully.";
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
            customerDTO.Name = "";
            customerDTO.Surname = "";
        }
    }
}
