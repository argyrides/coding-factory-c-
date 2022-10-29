using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    internal class Line : AbstractShape
    {
        public double Length { get; set; }
        public override string ToString()
        {
           return $"{Id}, {Length}";
        }
    }
}
