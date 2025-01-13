using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface_Example_04
{
    internal class Penguin : IBird
    {
        public void Walk()
        {
            Console.WriteLine("Penguin is walking");
        }
        public void Eat()
        {
            Console.WriteLine("Penguin is eating");
        }
    }
}
