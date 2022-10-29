using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointDAOServiceApp.Model
{
    internal class Point : IComparable<Point> , IEquatable<Point>
    {
        public int X { get; set; }

        public int CompareTo(Point? other)
        {
            return X - other!.X;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || (GetType() != obj.GetType()))
            {
                return false;
            }

            return CompareTo((Point?)obj) == 0;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X);
        }

        public override string ToString()
        {
            return "{" + X + "}";
        }

        public static bool operator >(Point op1, Point op2)
        {
            return op1.CompareTo(op2) > 0;
        }

        public static bool operator <(Point op1, Point op2)
        {
            return op1.CompareTo(op2) < 0;
        }

        public static bool operator >=(Point op1, Point op2)
        {
            return op1.CompareTo(op2) >= 0;
        }

        public static bool operator <=(Point op1, Point op2)
        {
            return op1.CompareTo(op2) <= 0;
        }

        public static bool operator ==(Point op1, Point op2)
        {
            if (ReferenceEquals(op1, op2)) return true;

            if ((op1 is null) || (op2 is null)) return false;

            return op1.Equals(op2);
        }

        public static bool operator !=(Point op1, Point op2)
        {
            return !op1.Equals(op2);
        }

        public bool Equals(Point? other)
        {
            if (other == null)
            {
                return false;
            }

            return CompareTo(other) == 0;
        }
    }
}
