using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface_Example_04
{
    internal class Eagle : IFlyableBird
    {
        public void Walk()
        {
            Console.WriteLine("Eagle is walking");
        }
        public void Eat()
        {
            Console.WriteLine("Eagle is eating");
        }
        public void Fly()
        {
            Console.WriteLine("Eagle is flying");
        }

    }
}
