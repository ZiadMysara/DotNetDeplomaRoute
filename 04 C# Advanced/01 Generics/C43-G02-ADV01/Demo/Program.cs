namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Generic SWAP — Example 01
            // // int swap example
            // int x = 10;
            // int y = 20;
            // Console.WriteLine("----------------------");
            // Console.WriteLine($"X = {x}");
            // Console.WriteLine($"Y = {y}");
            // Helper.Swap(ref x, ref y);
            // Console.WriteLine("======== Swap ========");
            // Console.WriteLine($"X = {x}");
            // Console.WriteLine($"Y = {y}");
            // Console.WriteLine("----------------------");
            // 
            // // double  swap example
            // double a = 10.5;
            // double b = 20.5;
            // Console.WriteLine($"A = {a}");
            // Console.WriteLine($"B = {b}");
            // Helper.Swap(ref a, ref b);
            // Console.WriteLine("======== Swap ========");
            // Console.WriteLine($"A = {a}");
            // Console.WriteLine($"B = {b}");
            // Console.WriteLine("----------------------");
            // 
            // // Point swap example
            // Point p1 = new Point(10, 20);
            // Point p2 = new Point(30, 40);
            // Console.WriteLine($"P1 = {p1}");
            // Console.WriteLine($"P2 = {p2}");
            // Helper.Swap(ref p1, ref p2);
            // Console.WriteLine("======== Swap ========");
            // Console.WriteLine($"P1 = {p1}");
            // Console.WriteLine($"P2 = {p2}");
            // Console.WriteLine("----------------------");
            // 
            // // object swap example
            // Console.WriteLine("Object swap example");
            // Console.WriteLine("----------------------");
            // object obj1 = 10; // boxing
            // object obj2 = 20;
            // Console.WriteLine($"Obj1 = {obj1}");
            // Console.WriteLine($"Obj2 = {obj2}");
            // Helper.Swap(ref obj1, ref obj2); // un safe
            // Console.WriteLine("======== Swap ========");
            // Console.WriteLine($"Obj1 = {obj1}");
            // Console.WriteLine($"Obj2 = {obj2}");
            // Console.WriteLine("----------------------");
            // 
            // object p3 = new Point(50, 60); // boxing
            // object p4 = new Point(70, 80);
            // Console.WriteLine($"P3 = {p3}");
            // Console.WriteLine($"P4 = {p4}");
            // Helper.Swap(ref p3, ref p4); // un safe
            // Console.WriteLine("======== Swap ========");
            // Console.WriteLine($"P3 = {p3}");
            // Console.WriteLine($"P4 = {p4}");
            // Console.WriteLine("----------------------");
            // 
            // // generics swap example
            // Console.WriteLine("Generics swap example");
            // Console.WriteLine("----------------------");
            // int m = 10; // no boxing
            // int n = 20;
            // Console.WriteLine($"M = {m}");
            // Console.WriteLine($"N = {n}");
            // Helper.Swap/*<int>*/(ref m, ref n); // safe
            // //in Case the Generic Type "T" is Declared On Method Level !(Class, Struct, Interface)
            // Console.WriteLine("======== Swap ========");
            // Console.WriteLine($"M = {m}");
            // Console.WriteLine($"N = {n}");
            // Console.WriteLine("----------------------");
            // 
            // double c = 10.5; // no boxing
            // double d = 20.5;
            // Console.WriteLine($"C = {c}");
            // Console.WriteLine($"D = {d}");
            // Helper.Swap/*<double>*/(ref c, ref d); // safe
            // //<double> not important in Case the Generic Type "T" is Declared On Method Level !(Class, Struct, Interface)
            // //co
            // Console.WriteLine("======== Swap ========");
            // Console.WriteLine($"C = {c}");
            // Console.WriteLine($"D = {d}");
            // Console.WriteLine("----------------------");
            #endregion

            #region Genaric Search - Example 02
            //int[] numbers = [10, 20, 30, 40, 50]; //[] syntax sugar for new int[] { 10, 20, 30, 40, 50 } start from C# 12 
            //int index = Helper<int>.Search(numbers, 30);
            //Console.WriteLine($"Index = {index}");

            //Employee employee01 = new Employee(10, "Ahmed", 6_000);
            //Employee employee02 = new Employee(20, "Omnia", 4_000);

            //if (employee01 == employee02) // i had to overload 
            //    Console.WriteLine("EQUALS");
            //else
            //    Console.WriteLine("! EQUALS");

            //if (employee01.Equals(employee02)) // it is already work 
            //    Console.WriteLine("EQUALS");
            //else
            //    Console.WriteLine("! EQUALS");

            //Employee[] employees = { employee01, employee02 };
            //index = Helper<Employee>.Search(employees, new Employee(20, "Omnia", 4_001));
            //Console.WriteLine($"Index = {index}"); // -1 as expected Salary to be 4_000 but i search for 4_001
            #endregion

            #region Equality and GetHashCode
            Employee employee01 = new Employee(10, "Ahmed", 6_000);
            Employee employee02 = new Employee(10, "Ahmed", 6_000);
            //Console.WriteLine($"employee01.GetHashCode(): {employee01.GetHashCode()}");
            //Console.WriteLine($"employee02.GetHashCode(): {employee02.GetHashCode()}");
            //if (employee01== employee02)
            if (employee01.Equals(employee02))
                Console.WriteLine("EQUALS");
            else
                Console.WriteLine("! EQUALS");

            HashSet<Employee> employeess = new HashSet<Employee>();
            employeess.Add(employee01);
            employeess.Add(employee02);

            // print just one employee as i implement GetHashCode and Equals
            foreach (Employee e in employeess)
            {
                Console.WriteLine(e);
            }





            #endregion

            #region bubble sort
            //int[] Numbers = [7, 2, 10, 9, 1, 8, 5, 3, 6, 4];
            //Helper<int>.Sort(Numbers);

            //foreach (int number in Numbers)
            //    Console.WriteLine(number);

            //Employee[] employees =
            //{
            //    new Employee(10, "Ahmed", 6_000),
            //    new Employee(20, "Omnia", 2000),
            //    new Employee(40, "Omars", 10_000),
            //    new Employee (50, "Nadia", 4_000),
            //};
            //Helper<Employee>.Sort(employees); // sort by salary
            //Array.ForEach<Employee>(employees, e => Console.WriteLine(e));
            #endregion

            #region Note

            // start from C# 6 in Constractor compile implicitly give the default value to the variable

            // genarics can be based on class or method

            // i can define more than one genaric Ex" <T1, T2, T3> 

            // [10, 20, 30, 40, 50] syntax sugar for new int[] { 10, 20, 30, 40, 50 } start from C# 12

            // struct dosen't have defult implementation for "==" and "!="
            // but class have defult implementation for "==" and "!="

            // value base equality is not the same as reference base equality
            // Ex: Employee e1 = new Employee(1, "Ahmed", 1000);
            //     Employee e2 = new Employee(1, "Ahmed", 1000);
            //     Console.WriteLine(e1 == e2); // false // because it's reference base equality
            //     Console.WriteLine(e1.Equals(e2)); // true  // because it's value base equality

            // Value base equality in struct EX: 
            /*
                internal struct Point
                {
                    int X ;
                    int Y ;
                    // ... ect
                }

               int x = 10, y = 20, A = 10, B = 30;
               point p1 = new Point(x, y); //(10, 20)
               point p2 = new Point(A, B); //(10, 30)
               
               p1.Equals(p2); // mean (x == A && y == B && ...) // false
             */

            // Reference base equality in class EX:
            /*
                internal class Employee
                {
                    int Id;
                    string Name;
                    double Salary;
                }
               Employee e1 = new Employee(1, "Ahmed", 1000);
               Employee e2 = new Employee(1, "Ahmed", 1000);
               
               e1.Equals(e2); // mean (e1_Ref == e2_Ref) // false
             */

            // in class "==" and "!=" are reference base equality
            // in struct not have defult implementation for "==" and "!="

            // i let "==" in class to be reference base equality
            // and i override .Equals() to be value base equality

            // T Must be Class or Struct Implementing the built-in Interface "IComparable"
            /// Primary Constraint [0: 1]
            /// 1.General Primary Constarint
            ///     class       => T Must Be Class
            ///     struct      => T Must Be Struct
            ///     notnull     => T Must be Not Nullable(C# 8.0)
            ///     default     =>
            ///     unmanaged   =>
            ///     Enum        => T Must Be Enum (C# 7.3)  // i can consider it special primary constraint as Enum is a class which all enums inherit from it
            /// 2. Special Primary Constarint (User-Defined Class (Except Sealed)) // except Sealed as if it's sealed so why i need to use genaric just use the class
            ///     Point => T Must Be Point Or Another Class Inherits From Point
            ///     

            /// Secondary Constraint (Interface Constarint) [0: M]
            /// IComparable<T>
            /// T Must Be Class/Struct Implementing ICompareable
            /// 

            /// Parameterless Constructor Constraint [0:1]
            /// T Must be Datatype Having Accessable [Non-Private] Parameterless Constructor
            /// Till C# 12.0 Only One Constructor Constraint
            /// Can't Use new() [Constructor Constraint] With struct [Special Primary Constraint]

            //                                               Primary   Secondary   Constructor    Primary         primary
            /// EX: internal class Helper <T, T2, T3 where T: class, IComparable<T>, new() where T2 class where T : Point
            /// 

            /// Calculate HashCode evaluation
            /// // used way now  // start from C# 7.3 from .Net Core 2.1
            /// return HashCode.Combine(this.Id, this.Name, this.Salary);
            /// 
            /// //true way and if we use ^ it will be faster
            /// int hashValue = 11;
            /// hashValue = (hashValue * 7) + Id.GetHashCode();
            /// hashValue = (hashValue * 7) + Name?.GetHashCode() ?? default(int);
            /// hashValue = (hashValue * 7) + Salary.GetHashCode();
            /// return hashValue;
            /// 
            /// //faster but false way
            /// return this.Id.GetHashCode() ^ this.Name?.GetHashCode()?? default(int) ^ this.Salary.GetHashCode(); 
            ///  false way
            /// return this.Id.GetHashCode() + this.Name?.GetHashCode()?? default(int) + this.Salary.GetHashCode();
            #endregion
        }
    }
}
