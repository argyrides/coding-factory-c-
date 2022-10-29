namespace PointInherit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>()
            {
                new Point(){ X = 1}, new Point2D() { X = 1, Y = 2}, new Point3D(){X=6, Y=8, Z=9}
            }; 


            Point p1 = Point.GetPoint();
            Point2D p2 = Point2D.GetPoint2D();
            Point3D p3 = Point3D.GetPoint3D();

            //p1.Move5();
            //p2.Move5();
            //p3.Move5();

            MakeMove5(p1);
            MakeMove5(p2);
            MakeMove5(p3);


            foreach (Point point in points)
            {
                Console.WriteLine(point.ToString());
            }


        }

        public static void MakeMove5(Point point)
        {
            point.Move5();
        }
    }
}