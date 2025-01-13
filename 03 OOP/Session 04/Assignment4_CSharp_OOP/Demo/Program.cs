using Demo.Bulit_in_interface;
using Demo.Interface_Example_01;
using Demo.Interface_Example_02;

namespace Demo
{
    internal class Program
    {
        /// هبدددددددددددددددددد
        /// static void PrintTenNumbersFromSeries(TypeAS series)
        /// {
        ///     if (series is null)
        ///         return;
        ///   
        ///     for (int i = 1; i <= 10; i++)
        ///     {
        ///         Console.Write(value: $"{series.Current}\t");
        ///         series.GetNext();
        ///     }
        ///     series.Reset();
        ///     Console.WriteLine();
        /// }
        ///   
        /// static void PrintTenNumbersFromSeries(TypeBS series)
        /// {
        ///     if (series is null)
        ///         return;
        ///   
        ///     for (int i = 1; i <= 10; i++)
        ///     {
        ///         Console.Write(value: $"{series.Current}\t");
        ///         series.GetNext();
        ///     }
        ///     series.Reset();
        ///     Console.WriteLine();
        /// }

        // this method is more generic // open closed principle 
        static void PrintTenNumbersFromSeries(ISeries series)
        {
            if (series is null)
                return;

            for (int i = 1; i <= 10; i++)
            {
                Console.Write(value: $"{series.Current}\t");
                series.GetNext();
            }
            series.Reset();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            #region Interface Example 01
            /// IType reference;
            /// // Declare for Reference of type "IType", Containg Garbag Value
            /// // This Reference 'reference' Can Refer to an object of any "Type Implementing IType Interface'
            /// // CLR Will Allocate 4 UnInitialized Bytes in STACK for this Reference.
            /// // CLR Will Allocate 0 Bytes in HEAP.
            ///
            /// // reference = /*new IType()*/ --> INVALID;
            /// reference = new TypeA();
            /// reference.MyProperty = 10;
            /// reference.MyMethod(); // Hello World!
            /// reference.Print2(); // Default Implemented Method
            ///
            /// TypeA typeA = new TypeA();
            /// typeA.MyProperty = 20;
            /// typeA.MyMethod(); // Hello World!
            ///                   //typeA.Print2(); // Default Implemented Method //Invalid
            ///                   // the only way to reach to Default Implemented Method is through the Interface Reference
            ///
            ///
            ///
            #endregion

            #region Interface Example 02
            /// TypeAS seriesByTwo = new TypeAS();
            /// PrintTenNumbersFromSeries(seriesByTwo);
            /// 
            /// TypeBS seriesByThree = new TypeBS();
            /// PrintTenNumbersFromSeries(seriesByThree);
            /// 
            /// 

            #endregion

            #region Interface_Example_03
            /// Vechile vechile = new Car();
            /// vechile.Speed = 100;
            /// // vechile.Forward();  // not found in Class Vechile
            /// // vechile.Backward(); // not found in Class Vechile
            /// 
            /// IMoveable moveable = new Car();
            /// // moveable.Speed = 200; // speed not in Interface IMoveable
            /// moveable.Forward();  // Forward in Interface IMoveable
            /// moveable.Backward(); // Backward in Interface IMoveable
            /// 
            /// Car car = new Car();
            /// car.Speed = 300; // Speed implemented in class Car
            /// car.Forward();   // Forward implemented in class Car
            /// car.Backward();  // Backward implemented in class Car
            /// 
            /// 
            /// Airplane airplane = new Airplane();
            /// airplane.Speed = 500; // Speed implemented in class Airplane
            /// //airplane.Forward();   // I can't call Forward() method directly because it's implemented explicitly
            /// ((IMoveable)airplane).Forward(); // Forward implemented in interface IMoveable
            /// ((IFlyable)airplane).Forward(); // Forward implemented in interface IFlyable
            /// airplane.Backward(); // it same method name in both interfaces Imovable and IFlyable
            /// 
            #endregion

            #region Interface_Example_04
            // I achive Interface Segregation in this example 
            #endregion

            #region Shallow Copy Vs Deep Copy
            int[] Arr01 = [1, 2, 3];
            int[] Arr02 = [4, 5, 6];

            #region Shallow Copy
            // any change in Arr01 will affect Arr02 
            Console.WriteLine($"Arr01.GetHashCode() = {Arr01.GetHashCode()}");
            Console.WriteLine($"Arr02.GetHashCode() = {Arr02.GetHashCode()}");
            Console.WriteLine();
            Arr02 = Arr01; Console.WriteLine("After Shallow Copy --> Arr02 = Arr01;");
            /// Shallow Copy (سطحي)
            /// This Object[1, 2, 3] Has 2 References [Arr01, Arr02] ( اسمين دلع )
            /// This Object [4, 5, 6] Became UnReachable Object.
            Console.WriteLine($"Arr01.GetHashCode() = {Arr01.GetHashCode()}"); //same HashCode 
            Console.WriteLine($"Arr02.GetHashCode() = {Arr02.GetHashCode()}"); //same HashCode

            #endregion

            #region Deep Copy
            // any change in Arr01 will not affect Arr02
            // it will make a new object in the memory 

            Arr02 = (int[])Arr01.Clone();
            Console.WriteLine("Deep Copy --> Arr02 = (int[])Arr01.Clone()");
            /// Deep Copy (عميق)
            /// Clone Method: Will Generate NEW Object with NEW and DIFFERENT Identity
            ///             : This Object Will Have The Same State[Data] of the Caller Object
            Console.WriteLine($"Arr01.GetHashCode() = {Arr01.GetHashCode()}"); //different HashCode
            Console.WriteLine($"Arr02.GetHashCode() = {Arr02.GetHashCode()}"); //different HashCode

            #region Note about Clone Method (Why it say that she make Shallow Copy)
            //Note: if the array contains a reference type class for EX, it will be a shallow copy
            // Mean that if you change the Vlaue of the reference type in Class for EX, it will affect the two arrays

            string[] Names01 = ["Amr", "Mona"];
            string[] Names02 = ["Ahmed", "Yassmin"];
            Console.WriteLine($"Names01.GetHashCode() = {Names01.GetHashCode()}");
            Console.WriteLine($"Names02.GetHashCode() = {Names02.GetHashCode()}");
            Names02 = (string[])Names01.Clone(); Console.WriteLine("After Deep Copy --> (string[])Names01.Clone() ");
            // Clone Method: Will Generate New Object with NEW and DIFFERENT Identity
            //             : This Object Will Have the Same State[Data] of the Original Object [Shallow Copy for the items]
            Console.WriteLine($"Names01.GetHashCode() = {Names01.GetHashCode()}"); //different HashCode
            Console.WriteLine($"Names02.GetHashCode() = {Names02.GetHashCode()}"); //different HashCode

            Console.WriteLine($"Names01[0].GetHashCode() = {Names01[0].GetHashCode()}");//same HashCode
            Console.WriteLine($"Names02[0].GetHashCode() = {Names02[0].GetHashCode()}");//same HashCode

            Names02[0] = "Ali";
            Console.WriteLine($"Names01[0] = {Names01[0]}"); // Amr //as string is immutable
            Console.WriteLine($"Names02[0] = {Names02[0]}"); // Ali //as string is immutable

            #endregion

            #endregion

            #endregion

            #region Built—In Interfaces ICloneable
            // ICloneable is an interface that has one method called Clone
            // it's used to make a deep copy of the object

            Employee employee01 = new Employee() { Id = 10, Name = "Ahmed", Salary = 8_000, department = new Department() { Code = 100, Title = "IS" } };
            Employee employee02 = new Employee() { Id = 20, Name = "Omnia", Salary = 4_000, department = new Department() { Code = 11, Title = "CS" } };

            Console.WriteLine($"employee01.GetHashCode() = {employee01.GetHashCode()}");
            Console.WriteLine($"employee02.GetHashCode() = {employee02.GetHashCode()}");

            employee02 = (Employee)employee01.Clone(); // Deep Copy using Clone method
            // Clone Method: This Method Generates NEW Object with NEW and DIFFERENT Identity
            //             : This Object Will Have The Same State[Data] of the Caller Object

            employee02.Salary = 10_000;
            Console.WriteLine("After Deep Copy");
            Console.WriteLine($"employee01.GetHashCode() = {employee01.GetHashCode()}");
            Console.WriteLine($"employee02.GetHashCode() = {employee02.GetHashCode()}");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Employee01 = {employee01}");
            Console.WriteLine($"Employee02 = {employee02}");

            // Let's change the department of employee02
            if (employee02.department is not null)
                employee02.department.Title = "IT";
            Console.WriteLine("After Changing the Department of Employee02");
            Console.WriteLine($"Employee01 = {employee01.department.Title}");  //IT
            Console.WriteLine($"Employee02 = {employee02.department?.Title}"); //IT
            // AS the Department is a reference type, the change in the department of employee02 will affect the department of employee01
            // if i clone the department object in the clone method, the change will not affect the department of employee01


            employee02 = new Employee(employee01); // 2.2 Deep Copy Using Copy Constructor
            Console.WriteLine("After Deep Copy");
            Console.WriteLine($"employee01.GetHashCode() = {employee01.GetHashCode()}");
            Console.WriteLine($"employee02.GetHashCode() = {employee02.GetHashCode()}");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Employee01 = {employee01}");
            Console.WriteLine($"Employee02 = {employee02}");
            #endregion

            #region Built—In Interfaces IComparable, IComparer
            Employee[] employees =
            {
                new Employee() { Id = 10, Name = "Ahmed", Salary = 8_000},
                new Employee() { Id = 20, Name = "Omnia", Salary = 2_000},
                new Employee() { Id = 30, Name = "Nadia", Salary = 10_000},
                new Employee() { Id = 40, Name = "Omars", Salary = 6_000},
            };
            Array.Sort(employees); // sort by salary

            foreach (Employee employee in employees)
                Console.WriteLine(employee);
            Console.WriteLine("---------------------------");

            Array.Sort(employees, new EmloyeeComperer()); //sort by id
            Array.ForEach(employees, employee => Console.WriteLine(employee));

            // EX2:
            int[] Numbers = [9, 4, 10, 2, 8, 4, 1, 7, 3, 6];
            Array.Sort(Numbers, new IntegareComparer());
            foreach (int number in Numbers)
                Console.Write(number + " ");

            #endregion


            #region Notes
            // 1. Interface is a Reference Type.
            // 2. Interface is a Contract.

            // What You Can Write inside the Interface?
            // 1. Signature for Property
            // 2. Signature for Method
            // 3. Default Implemented Method [C# 8.0 NEW Feature (.NET Core 3.1 [2019])]
            // 4. Static Members [C# 8.0 NEW Feature (.NET Core 3.1 [2019])]

            // "public" Access Modifier is the Default Access Modifier inside the Interface.
            // "Private" Access Modifier is not allowed for the Signatures Only (Property, Method)

            // there was two options to implement the interface
            // 1. Explicit Interface Implementation
            //      when you have a class that implements multiple interfaces and you want to avoid the name conflict
            // 2. Implicit Interface Implementation
            //      the default way to implement the interface

            // Interface Members are Public by Default
            // Interface Members are Abstract by Default
            // Interface Members are Virtual by Default


            // you can't create an instance of an interface
            // IType reference = new IType(); --> INVALID;

            // you can create a reference of an interface
            // IType reference; --> VALID;

            // the only way to reach to Default Implemented Method is through the Interface Reference

            // if signature property in the interface have "get" only, you can add the "set" in the class
            // if signature property in the Abstract Class have "get" only, you can't add the "set" in the Concreate class

            // 10_000 : under score is call digit separator it not affect the value

            // if i need tocompare Desending, i can put "-" like
            // return -this.Salary.CompareTo(other?.Salary);

            #endregion
        }
    }
}
