using Exercise3.DTO;

namespace Exercise3.Service
{
    public interface IProductService
    {
        void InsertProduct(ProductDTO? productDTO);
        Product? DeleteProduct(ProductDTO? productDTO);
        void UpdateProduct(ProductDTO? productDTO);
        Product? GetProductFromDatasource(ProductDTO? productDTO);
        void PrintAllProducts();
    }
}