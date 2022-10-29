using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInherit
{
    internal class Point3D : Point2D
    {
        public int Z { get; set; }

        public Point3D(): base(){}
        public static Point3D GetPoint3D()
        {
            return new Point3D();
        }

        public override void Move5()
        {
            base.Move5();
            Z += 5;
        }

        public override string ToString() => "{" + $"{X}, {Y}, {Z}" + "}";
    }
}
