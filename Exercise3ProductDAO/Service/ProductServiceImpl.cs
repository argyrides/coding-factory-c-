using Exercise3ProductDAO.DAO;
using Exercise3ProductDAO.DTO;
using Exercise3ProductDAO.Model;

namespace Exercise3ProductDAO.Service
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductDAO? dao;

        //dependency injection
        public ProductServiceImpl(IProductDAO? dao)
        {
            this.dao = dao;
        }

        public Product? DeleteProduct(int productKey)
        {
            return dao?.Delete(productKey);
        }

        public Product? GetProductFromDatasource(int productKey)
        {
            return dao?.GetProduct(productKey);
        }

        public void InsertProduct(ProductDTO? productDTO)
        {
            Product product = new() { Id = productDTO!.Id, Name = productDTO.Name, Quantity = productDTO.Quantity };
            dao?.Insert(product);
        }

        public void PrintAllProducts()
        {
            dao?.PrintDictionary();
        }

        public void UpdateProduct(int ProductIdToUpdate, ProductDTO? productDTO)
        {
            Product product = new() { Id = productDTO!.Id, Name = productDTO.Name, Quantity = productDTO.Quantity };
            dao?.Update(ProductIdToUpdate,product);
        }

       
    }
}
