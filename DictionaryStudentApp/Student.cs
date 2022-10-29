using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryStudentApp
{
    internal class Student : IComparable<Student>
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public int CompareTo(Student? other)
        {
            if ((Lastname is null) || (other?.Lastname is null) ||
                (Firstname is null) || (other?.Firstname is null))
            {
                throw new ArgumentNullException(Lastname);
            }

            return Lastname.CompareTo(other.Lastname);
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || (GetType() != obj.GetType()))
            {
                return false;
            }
            
            Student other = (Student)obj;

            return ((Id.Equals(other.Id)) && (Firstname!.Equals(other.Firstname)) && (Lastname!.Equals(other.Lastname)));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Firstname, Lastname); 
        }

        public override string? ToString()
        {
            return $"{Id}, {Firstname},{Lastname}";
        }
    }
}
