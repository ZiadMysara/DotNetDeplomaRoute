// < generate Code >
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Partial
{
    // Devoloper 1
    internal partial class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }

        // Partial Method
        partial void DoSomeCode(); // this function Devoloper 2 will implement it
        public void Test()
        {
            DoSomeCode(); // as i made it partial i can call it here  //and devoloper 2 will implement it at any time //my work doesn't stop 
        }
    }
}
