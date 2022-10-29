namespace ComparerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Description = "Milk", Price = 12.6, Quantity = 10 },
                new Product() { Description = "Honey", Price = 8.6, Quantity = 7 },
                new Product() { Description = "Eggs", Price = 5.0, Quantity = 48 }

            };

            products.Sort();

            products.ForEach(p => Console.WriteLine(p));

            Console.WriteLine();

            products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
            products.ForEach(p => Console.WriteLine(p));
            Console.WriteLine();

            products.Sort((p1, p2) => p1.Quantity - p2.Quantity);
            products.ForEach(p => Console.WriteLine(p));
            Console.WriteLine();
  
        }   
    }
}