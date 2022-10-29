using PointDAOServiceApp.DAO;
using PointDAOServiceApp.DTO;
using PointDAOServiceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointDAOServiceApp.Service
{
    internal class PointServiceImpl : IPointService
    {
        private readonly IPointDAO? dao;

        // Dependency injection
        public PointServiceImpl(IPointDAO? dao)
        {
            this.dao = dao;
        }

        public Point? DeletePoint(PointDTO? pointDTO)
        {
            Point point = new() { X = pointDTO!.X };
            return dao!.Delete(point);
        }

        public List<Point>? GetAllPoints()
        {
            return PointDAOImpl.Points;
        }

        public Point? GetPointFromDatasource(PointDTO? pointDTO)
        {
            Point point = new() { X = pointDTO!.X };
            return dao?.GetPointOrNull(point);
        }

        public void InsertPoint(PointDTO? pointDTO)
        {
            Point point = new() { X = pointDTO!.X };
            dao!.Insert(point);

        }

        public bool UpdatePoint(PointDTO? pointDTO, int x)
        {
            Point point = new() { X = pointDTO!.X };
            return dao!.Update(point, x);
        }
    }
}
