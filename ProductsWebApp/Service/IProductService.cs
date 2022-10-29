using ProductsWebApp.DTO;
using ProductsWebApp.Model;

namespace ProductsWebApp.Service
{
    public interface IProductService
    {
        void InsertProduct(ProductDTO? dto);
        void UpdateProduct(ProductDTO? dto);
        Product? DeleteProduct(ProductDTO? dto);
        Product? GetProduct(int id);
        List<Product> GetAllProducts();
    }
}
