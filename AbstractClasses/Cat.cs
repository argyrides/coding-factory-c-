using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    internal class Cat : AbstractAnimal
    {
        public override void Speak()
        {
            Console.WriteLine("Meoowwww!!");
        }

        public override string ToString()
        {
            return "Id: " + Id + ",Name: " + Name + ",Age: " + Age;
        }

        public override void Eat()
        {
            Console.WriteLine("Cat is eating fish.");
        }
    }
}
