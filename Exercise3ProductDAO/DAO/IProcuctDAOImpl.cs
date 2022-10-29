using Exercise3ProductDAO.Model;

namespace Exercise3ProductDAO.DAO
{
    public class IProcuctDAOImpl : IProductDAO
    {
        private static Dictionary<int, Product> dict = new();
        public Product? Delete(int productId)
        {
            Product? product = GetProduct(productId);
            if(!dict.Remove(productId))
                return null;

            return product;
        }

        public void PrintDictionary()
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"Key:{item.Key}, Product Name:{item.Value.Name}, Quantity:{item.Value.Quantity}");
            }
        }

        public Product? GetProduct(int id)
        {
            return (dict.ContainsKey(id)) ? dict[id] : null;
        }

        public void Insert(Product? product)
        {
            dict.Add(product!.Id, product);
        }

        public void Update(int idToUpdate, Product? product)
        {
            if (dict.ContainsKey(idToUpdate))
            {
                dict[idToUpdate] = product!;
            }
                
        }
    }
}
