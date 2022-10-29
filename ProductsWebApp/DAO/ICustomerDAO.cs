using ProductsWebApp.Model;

namespace ProductsWebApp.DAO
{
    public interface ICustomerDAO
    {
        void Insert(Customer? customer);
        void Update(Customer? customer);
        Customer? Delete(Customer? customer);
        Customer? GetCustomer(int id);
        List<Customer> GetAll();
    }
}
