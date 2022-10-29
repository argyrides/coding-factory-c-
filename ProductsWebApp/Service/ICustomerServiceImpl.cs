using ProductsWebApp.DAO;
using ProductsWebApp.DTO;
using ProductsWebApp.Model;

namespace ProductsWebApp.Service
{
    public class ICustomerServiceImpl : ICustomerService
    {
        private readonly ICustomerDAO dao;

        public ICustomerServiceImpl(ICustomerDAO dao) { this.dao = dao; }
        public Customer? DeleteCustomer(CustomerDTO? dto)
        {
            if (dto == null) return null;

            Customer? customer;
            customer = Convert(dto);

            try
            {
                return dao.Delete(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }

        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return new List<Customer>();
            }
        }

        public Customer? GetCustomer(int id)
        {
            try
            {
                return dao.GetCustomer(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void InsertCustomer(CustomerDTO? dto)
        {
            if (dto == null) return;

            Customer? customer;
            customer = Convert(dto);

            try
            {
                dao.Insert(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void UpdateCustomer(CustomerDTO? dto)
        {
            if (dto == null) return;

            Customer? customer;
            customer = Convert(dto);

            try
            {
                dao.Update(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        private Customer Convert(CustomerDTO? dto)
        {
            if (dto == null) return null;
            return new Customer()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname
            };
        }
    }
}
