using ProductsWebApp.DAO;
using ProductsWebApp.DTO;
using ProductsWebApp.Model;

namespace ProductsWebApp.Service
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductDAO dao;

        public ProductServiceImpl(IProductDAO dao)
        {
            this.dao = dao;
        }

        public Product? DeleteProduct(ProductDTO? dto)
        {
            if (dto == null) return null;

            Product? product;
            product = Convert(dto);

            try
            {
                return dao.Delete(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return new List<Product>();
            }
        }

        public Product? GetProduct(int id)
        {
            try
            {
                return dao.GetProduct(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void InsertProduct(ProductDTO? dto)
        {
            if (dto == null) return;

            Product? product;
            product = Convert(dto);

            try
            {
                dao.Insert(product);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public void UpdateProduct(ProductDTO? dto)
        {
            if (dto == null) return;

            Product? product;
            product = Convert(dto);

            try
            {
                dao.Update(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        private Product? Convert(ProductDTO? dto)
        {
            if (dto == null) return null;
            return new Product()
            {
                Id = dto.Id,
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                Price = dto.Price
            };
        }
    }
}
