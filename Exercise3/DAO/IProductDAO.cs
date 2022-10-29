namespace Exercise3.DAO
{
    public interface IProductDAO
    {
        void Insert(Product? product);
        void Update(Product? product);
        Product? Delete(int productKey);
        Product? GetProduct(int id);
        void PrintDictionary();
    }
}
