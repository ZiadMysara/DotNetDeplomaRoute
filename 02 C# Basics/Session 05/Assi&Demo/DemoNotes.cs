namespace Session_05;

internal static class DemoNotes
{

    public static void Run()
    {
         #region casting [boxing_unboxing]
         /* refrence type => from reference to reference */
         //boxing casting => from value type to refrence {safe casting}/
         //unboxing casting => from refrence type to value  {unsafe casting}/

         #region Boxing
         // // Parent Child
         // // Dog is Animal
         // object obj = new object();
         // obj = "mostafa"; /*refrence type */
         // obj = 2; /*boxing casting*/
         //     
         // int x = 10;
         // object obj01 = new object();  /*boxing*/
         // obj01 = x ;
         //
         #endregion
         
         #region Unboxing 
         // // Child Parent
         // // Animals is Dogs
         // x = 10; 
         // obj01 = new object();    
         // // x = obj01;        /*not valid */ /*unboxing*/ 
         //
         // // we can fix it by typing
         // x = (int)obj01; //but not safe 
         #endregion
         #endregion

         
         #region nullable data type 

         #region value type 
        //  //int x = null;  // number only 
        //  int ? xN = null; // int number and null // this is syntax sugar 
        //
        //  Nullable<int> number; /*we can write as that but not usable now days */
        // // int ? xN == Nullable<int> xN; // this is syntax sugar only
        //   
        //  int x = 10;
        //  int? yN = /*(int?)*/x;
        //
        //  xN = null;
        //  // int y  = xN; // error
        //  int y = (int)xN ; // IT IS LIKE I SWEAR TO HIM THAT IT IS NOT NULL
        //                    // BUT IF IT IS NULL IT WILL THROW AN EXCEPTION  
        //
        //  if (xN != null) 
        //      y = (int)xN; // safe casting
        //  else 
        //      y = 0;
        //  
        //
        //  y = xN.HasValue? xN.Value : 0; // xN.Value => int
        //
        //
        //  Console.WriteLine(y);
         #endregion

         #region reference type
         // string name = null;
         //
         // string? nameN = null; // compile inhance only use nullable  
         //
         // string nameF = null!; //  compile inhance only use null forgiving operator
         //

         #endregion

         #endregion

         #region Null propagation operator 
         // int[] numbers = null; 
         //
         //
         // for (int i = 0;numbers != null && i < numbers?.Length; i++)
         // {
         //     Console.WriteLine(numbers[i]);
         // }
         //
         //
         //
         //
         // // i < numbers?.length 
         // /*
         //  numbers  => object [length]
         //  numbers => null [null]
         // */
         // int length = numbers?.Length ?? 0; // if numbers is null return 0
         //
         // Console.WriteLine(length);
         //
         // //Console.WriteLine(Length);
         // Employee Emp = new Employee();
         // Emp. Department = new Department();
         // /*
         // if(Emp != null)
         // { 
         //    if(Emp. Department != null)
         //    {
         //        Console.WriteLine(Emp. Department.Name);
         //    }
         // }
         // */
         //
         // Console.WriteLine(Emp?.Department?.Name ?? "Not Found");
         // // this what we use in the real life

         #endregion

         #region Functions 

         // DemoNotes.PrintShape(10 , "(-)"); // passing by order
         //
         // DemoNotes.PrintShape(count:10 , pattern:"fkdsm"); // passing by name
         //
         // Console.WriteLine("hello \n ahmed "); // new line 
         // Console.WriteLine("hello \t ahmed "); // four spaces (tap) 
         // Console.WriteLine("hello \\ ahmed "); // print "\"  // skip meaning of "\"
         // Console.WriteLine(@"hello \ ahmed "); // print "\"  // skip meaning of "\"

         #endregion

         #region value Type (int, float, double, char, bool, ...)
         #region send by (value, refrence)
         // // value
         // int A = 5;
         // int B = 10;
         // Console.WriteLine(A);
         // Console.WriteLine(B);
         //
         // DemoNotes.Swap(A , B);
         // Console.WriteLine(A); // 5 // not changed
         // Console.WriteLine(B); // 10 // not changed
         
         // // refrence
         // A = 5;
         // B = 10;
         // Console.WriteLine(A);
         // Console.WriteLine(B);
         //
         // DemoNotes.SwapByRef( ref A, ref B);
         // Console.WriteLine(A); // 10 // changed
         // Console.WriteLine(B); // 5 // changed
         #endregion
         #endregion



         #region refrence type (array, ...)
         #region send by (value, refrence)

         #region Example 1
         // // Value 
         // int[] numbers = { 1, 2, 3 };
         // Console.WriteLine(DemoNotes.SumArr(numbers)); // 105
         // Console.WriteLine(numbers[0]); // 100
         //
         // // refrence
         // Console.WriteLine(DemoNotes.SumArrRef(ref numbers)); // 105
         // Console.WriteLine(numbers[0]); // 100
         //
         // // here no deference between value and reference
         #endregion
         
         #region Example 2
         // // Value 
         // int[] numbers = { 1, 2, 3 };
         // Console.WriteLine(DemoNotes.SumArr2(numbers)); // 15
         // Console.WriteLine(numbers[0]); // 1
         //
         // // refrence
         // Console.WriteLine(DemoNotes.SumArrRef2(ref numbers)); // 15
         // Console.WriteLine(numbers[0]); // 4
         //
         // // Here we can see the deference between value and reference
            
         #endregion
         #endregion
         #endregion

         #region Functions - passing by out 
         // int A = 10; 
         // int B = 20;
         // int sum = 0;
         // int mul = 0;
         //
         // DemoNotes.SumMul (A , B , out sum, out mul); // out (output)
         //
         // Console.WriteLine(sum);            /* value */
         // Console.WriteLine(mul);
         //
         // A = 10; 
         // B = 20;
         // sum = 0;
         // mul = 0;
         //
         // DemoNotes.SumMulRef (A , B , ref sum, ref mul); // ref (input and output)
         //
         // Console.WriteLine(sum);            /* refrence */
         // Console.WriteLine(mul);

         #endregion

         #region function params 

         // Console.WriteLine(DemoNotes.SumArr(1, 2, 3, 4, 5, 6, 7, 8, 9, 10 /* ,... */));
         //
         // int a = 12 , b = 13 , c = 14 ;
         // Console.WriteLine("A : {0} , b: {1} , c :  {2} " , a , b, c);// build in params in WriteLine
         //
         //
         #endregion

        #region  Notes
        // ? => nullable
        // ?? => null coalescing operator
        // ?. => null propagation operator
        // ! => null forgiving operator
        
        // 15 < null => false
        // x < null => false
        // null in comparison with any number is always false
        
        // anything accepts null is you have to check it before using it
        
        //Console.WriteLine(Emp?.Department?.Name ?? "Not Found");
        // this what we use in the real life
        // ?? means if the left side is null return the right side ("Not Found")
        
        /*
         * NameSpace can have
         * 1- Classes
         * 2- Interfaces
         * 3- Enums
         * 4- Delegates
         * 5- Structs
         */
        
        /*
         * Class can have
         * Data
         * Functions
         */
        
        /*
         * Types of Function
         * 1. Class Member Function [static Function]
         * 2. object Member Function [non Static Function]
         */
        
        // ref => input and output
        // out => output only
        // params => take a lot of values and put it in array
        
        // Default value given in (class, array, ...) not in main function 
        // Nullable Check is a new feature in (.NET 6.0)
        
        
        #endregion

    }
    
    
    public static void Swap(int x, int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }
    public static void SwapByRef(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }
    public static int SumArr(params int[] arr) // params take a lot of values and put it in array
    {
        int sum = 0;
        arr[0] = 100;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;

    }
    public static int SumArrRef(ref int[] arr)
    {
        int sum = 0;
        arr[0] = 100;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;

    }
    public static int SumArr2(params int[] arr)
    {
        int sum = 0;
        arr = new int [] {4, 5, 6 };
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;

    }
    public static int SumArrRef2(ref int[] arr)
    {
        int sum = 0;
        arr = new[] { 4, 5, 6 };
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;

    }
    public static void SumMul(int x, int y, out int sum, out int mul)

    {
        sum = x + y;
        mul = x * y;
    }
    public static void SumMulRef(int x, int y, ref int sum, ref int mul)

    {
        sum = x + y;
        mul = x * y;
    }
    public static void PrintShape(int count, string pattern)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(pattern);
        }
    }
    
}

internal class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int ID { get; set; }
    public Department Department { get; set; }
}

internal class Department
{
    public string Name { get; set; }
    
}