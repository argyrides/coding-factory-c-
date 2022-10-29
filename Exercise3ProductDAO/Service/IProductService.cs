using Exercise3ProductDAO.DTO;
using Exercise3ProductDAO.Model;

namespace Exercise3ProductDAO.Service
{
    public interface IProductService
    {
        void InsertProduct(ProductDTO? productDTO);
        Product? DeleteProduct(int productDTOKey);
        void UpdateProduct(int ProductIdToUpdate,ProductDTO? productDTO);
        Product? GetProductFromDatasource(int productDTOKey);
        void PrintAllProducts();
    }
}