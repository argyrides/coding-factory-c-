using PointDAOServiceApp.DAO;
using PointDAOServiceApp.DTO;
using PointDAOServiceApp.Model;
using PointDAOServiceApp.Service;

namespace PointDAOServiceApp
{
    internal class Program
    {
        static readonly IPointDAO dao = new PointDAOImpl();
        static readonly IPointService service = new PointServiceImpl(dao);
        static void Main(string[] args)
        {
            PointDTO p1 = new() { X = 1 };
            PointDTO p2 = new() { X = 2 };
            PointDTO p3 = new() { X = 3 };
            PointDTO p4 = new() { X = 4 };
            PointDTO p5 = new() { X = 5 };

            service.InsertPoint(p1);
            service.InsertPoint(p2);
            service.InsertPoint(p3);
            service.InsertPoint(p4);
            service.InsertPoint(p5);

            foreach (Point p in service.GetAllPoints()!)
            {
                Console.WriteLine(p);
            }

            List<Point> list = service.GetAllPoints()!;
            list.Sort();

            foreach (Point p in list)
            {
                Console.WriteLine(p);
            }

            list.Reverse();
            
            foreach (Point p in list)
            {
                Console.WriteLine(p);
            }
        }
    }
}