using ProductsWebApp.Model;

namespace ProductsWebApp.DAO
{
    public interface IProductDAO
    {
        void Insert(Product? product);
        void Update(Product? product);
        Product? Delete(Product? product);
        Product? GetProduct(int id);
        List<Product> GetAll();
    }
}
