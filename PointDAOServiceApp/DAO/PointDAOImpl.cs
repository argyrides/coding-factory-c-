using PointDAOServiceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointDAOServiceApp.DAO
{
    internal class PointDAOImpl : IPointDAO
    {
        private static List<Point> points = new();
        public static List<Point> Points { get { return new List<Point>(points); }}
        public Point? Delete(Point? point)
        {
            if (!points.Remove(point!)){
                return null;
            }

            return point;
        }

        public Point? GetPointOrNull(Point? point)
        {
            return (points.Contains(point!) ? points[GetPointPosition(point!)] : null);
        }

        public void Insert(Point? point)
        {
            points.Add(point!);
        }

        public bool Update(Point? point, int x)
        {
            int positionToUpdate = GetPointPosition(point!);

            if (positionToUpdate < 0) return false;

            points[positionToUpdate].X = x;
            return true;
        }

        private int GetPointPosition(Point point) => points.IndexOf(point);

       
    }
}
