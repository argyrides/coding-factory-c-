using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    internal abstract class AbstractShape : IShape
    {
        public long Id { get; set; }
        public abstract override string ToString();
    }
}
