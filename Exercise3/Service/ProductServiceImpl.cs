using Exercise3.DAO;
using Exercise3.DTO;

namespace Exercise3.Service
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductDAO? dao;

        //dependency injection
        public ProductServiceImpl(IProductDAO? dao)
        {
            this.dao = dao;
        }

        public Product? DeleteProduct(ProductDTO? productDTO)
        {
            Product product = new() { Id = productDTO!.Id, Name = productDTO.Name, Quantity = productDTO.Quantity };

            return dao?.Delete(product.Id);
        }

        public Product? GetProductFromDatasource(ProductDTO? productDTO)
        {
            Product product = new() { Id = productDTO!.Id, Name = productDTO.Name, Quantity = productDTO.Quantity };
            return dao?.GetProduct(product!.Id);
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

        public void UpdateProduct(ProductDTO? productDTO)
        {
            Product product = new() { Id = productDTO!.Id, Name = productDTO.Name, Quantity = productDTO.Quantity };
            dao?.Update(product);
        }

       
    }
}
