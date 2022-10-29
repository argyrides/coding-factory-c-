using Exercise3ProductDAO.Model;
using Exercise3ProductDAO.DAO;
using Exercise3ProductDAO.Service;
using Exercise3ProductDAO.DTO;

internal class Program
{
    static readonly IProductDAO dao = new IProcuctDAOImpl();
    static readonly IProductService service = new ProductServiceImpl(dao);
    static void Main(string[] args)
    {
        ProductDTO p1 = new() { Id = 1, Name="Eggs", Quantity=20 };
        ProductDTO p2 = new() { Id = 2, Name = "Milk", Quantity = 45 };
        ProductDTO p3 = new() { Id = 3, Name = "Apples", Quantity = 123 };
        ProductDTO p4 = new() { Id = 4, Name = "Bread", Quantity = 10 };

        service.InsertProduct(p1);
        service.InsertProduct(p2);
        service.InsertProduct(p3);
        service.InsertProduct(p4);

        service.DeleteProduct(p1.Id);

        p2 = new() { Id = 10, Name = "Oranges", Quantity = 50 };
        service.UpdateProduct(2, p2);

        service.PrintAllProducts();
    }
}