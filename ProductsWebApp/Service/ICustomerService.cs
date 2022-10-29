using ProductsWebApp.DTO;
using ProductsWebApp.Model;

namespace ProductsWebApp.Service
{
    public interface ICustomerService
    {
        void InsertCustomer(CustomerDTO? dto);
        void UpdateCustomer(CustomerDTO? dto);
        Customer? DeleteCustomer(CustomerDTO? dto);
        Customer? GetCustomer(int id);
        List<Customer> GetAllCustomers();
    }
}
