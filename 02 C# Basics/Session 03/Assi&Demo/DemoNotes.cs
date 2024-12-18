using System.Collections;

namespace Session_03;

public static class DemoNotes
{

    public static void Run()
    {
        #region Value Type Casting

        #region Implicit Casting — Safe Casting

        // int x = 4; // 4 Bytes
        // long Y = /*(long)*/x; // 8 Bytes
        // // here casting from int to long is done implicitly because long is bigger than int

        #endregion

        #region Explict Casting — UnSafe Castihg

        // long X = 101010101010; // 8 Bytes
        // int Y = (int)X;
        // Console.WriteLine(Y);
        // // here casting from long to int is done explicitly because int is smaller than long
        // // if the value of X is bigger than the max value of int, there will be an exception overflow

        #endregion

        #endregion

        #region Parse [Convert from String to any Datatype]

        // int Number = int.Parse(Console.ReadLine());
        // Console. WriteLine("Enter Data User");
        // Console.WriteLine("Enter Name: ");
        // string Name = Console.ReadLine();
        // Console.WriteLine("Enter Age: ");
        // int Age = Int32.Parse(Console.ReadLine());
        // // int = Int32
        // Console.WriteLine("Enter Salary: ");
        // double Salary = double.Parse(Console.ReadLine());
        // // each datatype has a parse method to convert from string to the datatype

        #endregion

        #region Convert [Convert from Any Datatype to Any DateType]

        // int Number = Convert.ToInt32(Console.ReadLine());
        // Console. WriteLine("Enter Data User");
        // Console.WriteLine("Enter Name: ");
        // string Name = Console.ReadLine();
        // Console.WriteLine("Enter Age: ");
        // int Age = Convert.ToInt32(Console.ReadLine());
        // // int = Int32
        // Console.WriteLine("Enter Salary: ");
        // double Salary = Convert.ToDouble(Console.ReadLine());
        // // each datatype has a parse method to convert from string to the datatype

        #endregion

        #region Opreators

        #region Unary Operators [++, --]

        // int X = 5;
        // X++; // X = X + 1;
        // --X; // X = X - 1;
        // Console.WriteLine(++X); // 5 //print then add 1
        // Console.WriteLine(X++); // 7 //add 1 then print 

        #endregion

        #region Binary Operators [+, -, *, /, %]
        // int Sum, Mul, Sub, Div, Mod;
        // int X = 5, Y = 3;
        // Sum = X + Y;// 8
        // Mul = X * Y;// 15
        // Sub = X - Y;// 2
        // Div = X / Y;// 1
        // Mod = X % Y;// 2
        // // mod is the remainder of the division

        #endregion

        #region Assignment Operator

        //
        // int X = 10;
        // X += 10; // x = x + 10
        // X -= 10; 
        // X *= 10;
        // X /= 10;
        // X %= 10;

        #endregion

        #region Comparison Operator

        // int X = 5, Y = 3;
        // bool IsEqual = X == Y; // false
        // bool IsNotEqual = X != Y; // true
        // bool IsGreater = X > Y; // true
        // bool IsLess = X < Y; // false
        // bool IsGreaterOrEqual = X >= Y; // true

        #endregion

        #region Logical Operator [Short Circuit]

        // bool IsTrue = true, IsFalse = false;
        // // AND
        // // true && true = true
        // // true && false = false
        // // false && true = false
        // // false && false = false
        //
        // // OR
        // // true || true = true
        // // true || false = true
        // // false || true = true
        // // false || false = false

        #endregion

        #region Bitwise Operator [Long Circuit]

        // bool IsTrue = true, IsFalse = false;
        // // AND
        // // true  & true = true
        // // true  & false = false
        // // false &  true = false
        // // false &  false = false
        //
        // // OR
        // // true  | true = true
        // // true  | false = true
        // // false |  true = true
        // // false |  false = false

        #endregion

        #region Ternary Operator [Condition Operator]

        // int X = 4;
        // string Message = X > 4 ? "X Greater Than 4" : "X Less than Or Equal 4";
        // Console.WriteLine(Message);
        // // nested ternary operator
        // Message = X > 4 ? "X Greater Than 4" : X < 4 ? "X Less than 4" : "X Equal 4";

        #endregion
        #endregion

        #region Operator Periorety

        // /*
        // 1. Unary Operator [PreFix]
        // 2. ()
        // 3. * / %
        // 4. + -
        // */
        // int A = 20;
        // int B = 15;
        // int C = 10;
        // int D = 5;
        // int Result; 
        // Result = (A + B) * C / D;// 70
        // Result = A++ * C; // 200
        // Console.WriteLine(Result);

        #endregion

        #region String Formating

        // // Equation = X + Y = Result
        // // Equation = 10 + 5 = 15
        // int X = 5;
        // int Y = 10;
        // int Result = X + Y;

        #region 0. Normal Way

        // Console.WriteLine("Equation: "+ X + " + " + Y+" = "+Result);

        #endregion

        #region 1. Composite Format

        // String.Format("Equation = {0} + {1} = {2}", X, Y, Result);

        #endregion

        #region 2.String Manipolition

        // // string Interpolation => $
        // Console.WriteLine($"Equation = {X} + {Y} = {Result}");

        #endregion

        #endregion

        #region IF Else - Switch Case

        // Console.WriteLine("Enter Month Number");
        //  int MonthNumber = int.Parse(Console.ReadLine());
        // // 1 => Month is Jan
        // // 2 => Month is Feb
        // // 3 => Month is Mar
        // // Invalid Input

        #region IF Else

        // if (MonthNumber == 1)
        // {
        //     Console.WriteLine("Month is Jan");
        // }
        // else if (MonthNumber == 2)
        // {
        //     Console.WriteLine("Month is Feb");
        // }
        // else if (MonthNumber == 3)
        // {
        //     Console.WriteLine("Month is Mar");
        // }
        // else
        // {
        //     Console.WriteLine("Invalid Input");
        // }

        #endregion

        #region Switch Case

        // switch (MonthNumber)
        // {
        //     case 1:
        //         Console.WriteLine("Month is Jan");
        //         break;
        //     case 2:
        //         Console.WriteLine("Month is Feb");
        //         break;
        //     case 3:
        //         Console.WriteLine("Month is Mar");
        //         break;
        //     default:
        //         Console.WriteLine("Invalid Input");
        //         break;
        // }

        #endregion

        // switch case is faster than if else
        // as switch case is implemented using jump table
        // if else is implemented using if else ladder

        #region Switch Case with String

        // Console.WriteLine("Enter Name");
        // string Name = Console.ReadLine();
        // switch (Name)
        // {
        //     case "Mostafa":
        //     case "mostafa": // it like OR (Mostafa || mostafa)
        //         Console.WriteLine("Hello Mostafa");
        //         break;
        //     case "Aliaa":
        //         Console.WriteLine("Hello Aliaa");
        //         break;
        //     case "Ahmed":
        //         Console.WriteLine("Hello Ahmed");
        //         break;
        //     default:
        //         Console.WriteLine("Hello Stranger");
        //         break;
        // }
        // // switch case with string not created using jump table if it is smaller than 5 cases
        // // if it is bigger than 5 cases, it will be created using jump table
        // // in numeric switch case, jump table is created with no conditions

        #endregion

        #region GoTo

        // // GoTo is a keyword to jump to a specific label
        // goto here;
        // Console.WriteLine("false");
        // here:
        // Console.WriteLine("true");
        // Console.WriteLine("Enter Option");
        // // 3000 => "Option 01", "Option 02". "Option 03"
        // // 2000 => "Option 01", "Option 02"
        // // 1000 => "Option 01"
        //
        //
        // int Option = int.Parse(Console.ReadLine());
        // switch (Option)
        // {
        //     case 3000:
        //         Console.WriteLine("Option 03");
        //         goto case 2000;
        //     case 2000:
        //         Console.WriteLine("Option 02");
        //         goto case 1000;
        //     case 1000:
        //         Console.WriteLine("Option 01");
        //         break;
        // }

        #endregion

        #region Evaluation Of Switch Case

        // https://mihirdave95.medium.com/evaluation-of-switch-in-c-be587f7de47c

        #region C# 6.0

        // // in C# 6.0, switch case can evaluate the condition
        // Console.WriteLine("Enter Age");
        // int Age = int.Parse(Console.ReadLine());
        // switch(Age)
        // {
        //     case > 22:
        //         Console.WriteLine("Age Greater Than 22");
        //         break;
        //     case < 22:
        //         Console.WriteLine("Age Less Than 22");
        //         break;
        //     default:
        //         Console.WriteLine("Age Equal 22");
        //         break;
        // }

        #endregion

        #region C# 7.0

        // object obj = new object();
        // obj = "Mostafa";
        // obj = 10;
        // obj = true;
        // switch(obj)
        // {
        //     case int Number when Number > 10 && Number < 20:
        //         Console.WriteLine($"{Number} is int");
        //         break;
        //     case string Name:
        //         Console.WriteLine($"{Name} is String");
        //         break;
        //     case bool IsTrue:
        //         Console.WriteLine($"{IsTrue} is Boolean");
        //         break;
        //     default:
        //         Console.WriteLine("Unknown Type");
        //         break;
        // }

        #endregion

        #region C# 8.0

        #region EXample 01

        // Console.WriteLine("Enter Option");
        // int Opation = int.Parse(Console.ReadLine());
        // // Switch Expression
        // string Message = Opation switch
        // {
        //     1 => "Option 01",
        //     2 => "Option 02",
        //     3 => "Option 03",
        //     _ => "Invalid"
        // };
        // Console.WriteLine(Message);

        #endregion

        #region Example 02
        // Empolyee E01 = new Empolyee();
        // E01.Name = "Ali";
        // E01.Id = 10;
        // E01. Age = 22;
        // string Massege = E01 switch
        // {
        //     { Id:10, Name: "Alaa", Age: 22}=>$"{E01.Id} {E01.Name} {E01.Age}",
        //     { Id:10, Name: "Ali", Age: 22}=> $"Do Something",
        //     { Id:20, Name: "Mona", Age: 20}=> $"{E01.Id} : {E01.Name} {E01.Age}"
        // };

        #endregion
        #endregion

        #region C# 9.0 
        // // tha add Relational patterns and Logical patterns
        // Empolyee E01 = new Empolyee();
        // E01.Name = "Ali";
        // E01.Id = 10;
        // E01. Age = 22;
        // string Massege = E01 switch
        // {
        //     {  Age: > 22 and < 26}=>$"{E01.Id} {E01.Name} {E01.Age}",
        //     { Id:10, Name: "Ali", Age: 22 or 30}=> $"Do Something",
        //     { Id:20, Name: "Mona", Age: 20}=> $"{E01.Id} : {E01.Name} {E01.Age}"
        // };
        #endregion
        #endregion



        #endregion
        
        #region Notes
        // // any implicit casting is a safe casting
        // // string is emutable
        // // _ is used to ignore the value it call Discard
        //
        //
        // // Switch case is faster than if else as it use jump table
        // // if else is slower than switch case as it use if else ladder
        // // Switch case is working with string in C#
        // // Box and UnBox
        // // Box => Convert Value Type to Reference Type
        // // UnBox => Convert Reference Type to Value Type
        // // Boxing is slower than UnBoxing
        // //Ex 01:
        // int X = 10;
        // object obj = X; // Boxing
        // int Y = (int)obj; // UnBoxing
        //
        // //Ex 02:
        // string Chicken = "chicken";
        // int Fish = 1;
        // ArrayList Truck = new ArrayList();
        // Truck.Add(Chicken); // Boxing  //it will convert the string to object
        // Truck.Add(Fish);    // Boxing
        // Truck[1] = (int)Truck[1] + 1; // UnBoxing //it will convert the object to int 
        //
        // // Boxing is slower than UnBoxing
        
        
        
        #endregion
        
    }

}
internal class Empolyee
{

    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }
}