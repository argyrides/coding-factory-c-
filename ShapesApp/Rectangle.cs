using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    internal class Rectangle : AbstractShape, ITwoDimensional
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double GetArea()
        {
            return (Width * Height);
        }

        public override string ToString()
        {
            return $"({Id}, {Width}, {Height})";
        }
    }
}
