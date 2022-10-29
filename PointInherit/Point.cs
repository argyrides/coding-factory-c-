using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInherit
{
    internal class Point
    {

        public int X { get; set; }

        public static Point GetPoint()
        {
            return new Point();
        }

        public virtual void Move5()
        {
            X += 5;
        }

        public override string ToString() => "{x" + X + "}";
    }
}
