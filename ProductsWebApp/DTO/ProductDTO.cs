namespace ProductsWebApp.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return "{" + Id + "," + ProductName + "," + Quantity + "," + Price + "}";
        }
    }
}
