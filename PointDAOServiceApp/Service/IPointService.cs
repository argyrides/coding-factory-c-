using PointDAOServiceApp.DTO;
using PointDAOServiceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointDAOServiceApp.Service
{
    internal interface IPointService
    {
        void InsertPoint(PointDTO? pointDTO);
        Point? DeletePoint(PointDTO? pointDTO);
        bool UpdatePoint(PointDTO? pointDTO, int x);
        Point? GetPointFromDatasource(PointDTO? pointDTO);
        List<Point>? GetAllPoints();
    }
}
