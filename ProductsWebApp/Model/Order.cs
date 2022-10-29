namespace ProductsWebApp.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer? CustomerId { get; set; }
        public decimal TotalCost { get; set; }
    }
}
