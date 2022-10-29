using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInherit
{
    internal class Point2D : Point
    {
        public int Y { get; set; }

        public Point2D() : base()
        {
            
        }

        public static Point2D GetPoint2D()
        {
            return new Point2D();
        }

        public override void Move5()
        {
            base.Move5();
            Y += 5;
        }

        public override string ToString() => "{" + $"{X}, {Y}" + "}";
    }
}
