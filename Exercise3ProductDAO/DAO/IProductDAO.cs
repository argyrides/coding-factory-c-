using Exercise3ProductDAO.Model;

namespace Exercise3ProductDAO.DAO
{
    public interface IProductDAO
    {
        void Insert(Product? product);
        void Update(int idToUpdate, Product? product);
        Product? Delete(int productKey);
        Product? GetProduct(int id);
        void PrintDictionary();
    }
}
