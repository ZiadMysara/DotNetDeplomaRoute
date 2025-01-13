using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface_Example_01
{
    internal interface IType
    {

        // "public" Access Modifier is the Default Access Modifier inside the Interface.
        // "Private" Access Modifier is not allowed for the Signatures Only (Property, Method)

        // What You Can Write inside the Interface?
        // 1. Signature for Property
        public int MyProperty { get; set; }
        
        // 2. Signature for Method
        public void MyMethod();

        // 3. Default Implemented Method [C# 8.0 NEW Feature (.NET Core 3.1 [2019])]
        private void Print()
        {
            Console.WriteLine("Default Implemented Method");
        }

        public void Print2()
        {
            Console.WriteLine("Default Implemented Method");
        }

        /// 4. Static Members [C# 8.0 NEW Feature (.NET Core 3.1 [2019])]
        /// // 4.1 Static Fields
        /// // 4.2 Static Properties
        /// // 4.3 Static Methods
        /// // 4.4 Static Events

        //int x; // Error: Interfaces cannot contain fields

    }
}
