using Demo.Abstraction;
using Demo.Partial;

namespace Demo
{



    internal class Program
    {

        private static void drawShape(IDraw2D shape)
        {
            shape.Draw();
        }

        static void Main(string[] args)
        {
            #region Abstraction [Abstract Class, Abstract Method, Abstract property]

            ////Shape s = new Shape(); // can't create instance of abstract class
            ////RectSquareBase rs = new RectSquareBase(); // can't create instance of abstract class

            //Shape shape = new Rect(10, 20);
            //decimal rectPeri = shape.Perimeter;
            //decimal rectArea = shape.CalcArea();
            //Console.WriteLine($"Rect Peri = {rectPeri}");
            //Console.WriteLine($"Rect Area = {rectArea}");
            //Console.WriteLine();

            //shape = new Square(10);
            //decimal squarePeri = shape.Perimeter;
            //decimal squareArea = shape.CalcArea();
            //Console.WriteLine($"Square Peri = {squarePeri}");
            //Console.WriteLine($"Square Area = {squareArea}");
            //Console.WriteLine();

            //shape = new Circle(10);
            //decimal circlePeri = shape.Perimeter;
            //decimal circleArea = shape.CalcArea();
            //Console.WriteLine($"Circle Peri = {circlePeri}");
            //Console.WriteLine($"Circle Area = {circleArea}");
            //Console.WriteLine();

            //// shape can be Rect, Square, Circle, ... etc

            //drawShape(shape);


            #endregion

            #region Static [Class, Attribute, Property, Constructor, Method] and Constants

            //// The Result of Catting this Method will not be different By the Difference of the object state [Data](x, Y)
            ////Utility utility01 = new Utility(10, 20);
            ////Utility utility02 = new Utility(5, 7);
            ////Console.WriteLine($"CmToInch = {utility01.CmToInch(254)}"); // 100 
            ////Console.WriteLine($"CmToInch = {utility02.CmToInch(254)}"); // 100 

            //Console.WriteLine($"InchToCm = {Utility.InchToCm(100)}"); // 254 //static
            //Console.WriteLine($"PI = {Utility.PI}"); // 3.14 //static


            #endregion

            #region Sealed [Class, Property, Method]
            // Class Type
            #endregion

            #region Partial [class, Struct, Interface, Method]
            Employee employee = new Employee()
            {
                Id = 1,             // Attribute from Employee file
                Name = "Ahmed",     // Attribute from Employee file
                Age = 30,           // Attribute from Employee file
                Address = "Cairo",  // Attributes from Employee.Custom file
            };
            // all attributes are accessible in one object

            // ToString is onlt Write in Employee.Custom file
            Console.WriteLine(employee.ToString()); // Id = 1, Name = Ahmed, Age = 30, Address = Cairo
                                                    // print all attributes in Employee 
            #endregion

            #region Class Summary Types
            // 1.Concrete Class
            // 2.StaticClass
            // 3.Abstract Class
            // 4.SealedClass
            // 5.Partial Class
            #endregion
            #region Note
            /// Abstract Class
            /// is a Partial Implementation for Other Classes.
            /// is a Container for Common Code [Implemented Members, Abstract Members] among many Classes.
            /// U Can't Create an Object from Abstract Class [it is not fully implemented].
            /// Abstract Class not acutally exist in business model.

            // if i implemment interface i can add get or set to the property if it is not exist in the interface
            // if i implement abstract class i can't add get or set to the property if it is not exist in the abstract class
            // if only get exist i have to add get only, i can't add set

            // Interface is a contract between the class and the outside world to provide a specific behavior.

            // Abstract Class can have constructors, interfaces can't have constructors

            /// Struct vs Class in C#
            ///
            /// Key Differences:
            /// 1. Structs are VALUE types (stored on the stack),               while Classes are REFERENCE types (stored on the heap).
            /// 2. Structs are passed by VALUE (copied),                        while Classes are passed by REFERENCE (pointers).
            /// 3. Structs cannot have explicit parameterless constructors,     while Classes can.
            /// 4. Structs do NOT support inheritance (only interfaces),        while Classes do.
            /// 5. Structs are generally more memory-efficient for small data,  while Classes are better for large, complex objects.
            /// 6. Structs cannot be null (unless Nullable<T> is used),         but Classes can.
            ///
            /// When to Use Struct:
            /// ✅ Use when the object is small, short-lived, and immutable.
            /// ✅ Use when you don’t need inheritance.
            /// ✅ Use when value-type behavior (copying) is required.
            /// ✅ Use for performance-sensitive operations to reduce heap allocation.
            ///
            /// When to Use Class:
            /// ✅ Use when you need reference-type behavior (shared instances).
            /// ✅ Use for large, complex objects that require modification.
            /// ✅ Use when inheritance or polymorphism is needed.
            /// ✅ Use when the object should be shared across multiple parts of an application.
            ///
            /// Rule of Thumb:
            /// Prefer struct for small, immutable, frequently used objects. Use class otherwise.

            // when class or struct be static, it will be just contaner for some methods or Attrpuis that help us.

            // static class Examples: Math, Console, Convert, ...
            // static struct Examples: Guid,...

            // Rule of Thumb:
            // if the (method, Propertie) will not be Different from object to other object, it should be static [Class Member Method]
            // if the (method, Propertie) will be Different from object to other object, it should be non-static [Object Member Method]

            /// Class Member Property: Static Property: [Must Deal With One Of the Following]:
            /// 1. Static Attribute
            /// 2. Constant

            // if the attribute readonly, it will take the value from the constructor or the declaration only, and can't be changed after 

            /// const vs readonly
            /// const: 
            /// 1. must be initialized at the time of declaration
            /// 2. can't be changed after that
            /// 3. can't be static
            /// 4. can't be readonly
            ///
            /// readonly:
            /// 1. can be initialized at the time of declaration or in the constructor
            /// 2. can be changed after that
            /// 3. can be static
            ///
            /// i can initialize readonly in the constructor,
            /// but i can't initialize const in the constructor
            /// 

            /// Static Class
            /// is a just Container For Static Members [Attribute, Property, Constructor, Method]
            /// and Constants
            /// You Can't Create Object From This Class (Helper Class)
            /// No Inheritance for this Class 

            /// Rule of Thumb:
            /// if all members in the class are static or const, it should be static class
            /// if at least one member in the class is non-static or const, it should be non-static class

            // staic constructor will be called once per class lifetime before the first usage of the class

            // sealed class benefits:
            // 1. prevent inheritance
            // 2. prevent overriding
            // 3. more efficient as CLR will not search for the method in the child class

            // sealed be used with:
            // 1. class
            // 2. method
            // 3. property

            /// partial: keyword used to split the [class, struct, interface] into multiple files
            /// why we use partial:
            /// 1- to make the code more organized and easy to read
            /// 2- as more than one developer work on the same class
            /// 3- to separate the auto-generated code from the developer code
            /// as the if i change in generated code will be overwritten when the code is generated again

            /// Partial use with:
            /// 1. class
            /// 2. struct
            /// 3. interface
            /// 4. method

            /// Partial Method:
            /// 1. it is a method that doesn't have a body
            /// 2. it is used to allow the developer to implement the method or not
            ///
            /// if it not implemented:
            /// 1. the method Can't have access modifier
            /// 2. the method Can't have parameters
            /// 3. the method Can't have return type






            // if i need to link application with the database, i need to use ORM
            // ORM: Object Relational Mapping
            // Entity Framework Core: ORM

            // i have to aproach:
            // 1. Code First: i will create the classes and the database will be generated from the classes
            // 2. Database First: i will create the database and the classes will be generated from the database

            // DB                ORM     Class
            // Employees Table   ---->   Employee Class
            //                                                                                  Class     DB
            // Note that the class name should be singular and the table name should be plural "Employee, Employees"

            /// Class Summary Types
            /// 1.Concrete Class
            /// 2.StaticClass
            /// 3.Abstract Class
            /// 4.SealedClass
            /// 5.Partial Class

            // there was new thing in oop called "record" 
            // we should Search for it

            #endregion

        }
    }
}
