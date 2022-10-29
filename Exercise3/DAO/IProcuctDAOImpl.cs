namespace Exercise3.DAO
{
    public class IProcuctDAOImpl : IProductDAO
    {
        private static Dictionary<int, Product> dict = new();
        public Product? Delete(int productId)
        {
            if(!dict.Remove(productId))
                return null;

            return dict[productId];
        }

        public void PrintDictionary()
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"Key {item.Key}, Value {item.Value}");
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

        public void Update(Product? product)
        {
            if (dict.ContainsKey(product!.Id))
            {
                dict[product!.Id] = product;
            }
                
        }
    }
}
