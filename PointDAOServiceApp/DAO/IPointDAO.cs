using PointDAOServiceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointDAOServiceApp.DAO
{
    internal interface IPointDAO
    {
        void Insert(Point? point);
        bool Update(Point? point, int x);
        Point? Delete(Point? point);
        Point? GetPointOrNull(Point? point);
    }
}
