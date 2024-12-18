namespace ConsoleApp1;

public static class DemoNotes
{
    
    public static void Run()
    {
        #region Errors

        #region Syntax Error
        int s = 5
        // Syntax error: missing semicolon
        #endregion

        #region Logical Error
        int a = 5;
        int b = 5;
        int sum = a - b;
        Console.WriteLine(sum);
        // Logical error: sum should be a + b
        #endregion

        #region Run Time Error
        int x = 5;
        int y = 0;
        Console.WriteLine(x / y);
        // Run time error: division by zero
        #endregion

        #region Warning
        int z = 5;
        // Warning: unused variable
        #endregion

        #endregion

        #region Variable Declaration
        int number;
        // number will be 0 by default
        #endregion
        
        #region CTS - CLS
        int X = 5; // 4 Byte
        string Name = "test" ; // 8 Byte string Name As each character is 2 byte
        Name = "Ali"; // 6 byte 
        // CTS: Common Type System
        // CLS: Common Language Specification
       
        /*
            Type	Size  System Type	CIS-Complitmt
            sbyte	8	System.SByte	No
            short	16	System.Int16	Yes
            int	    32	System.Int32	Yes
            long	64	System.Int64	Yes
            byte	8	System.Byte	    Yes
            ushort	16	System.Uint16   No
            uint	32	System.Uint32	No
            ulong	64	System.UInt64	No
            char	16	System.Char	    Yes
            bool	8	System.Boolean  Yes
            float	32	System.Single	Yes
            double	64	System.Double	Yes
            decimal	128	System.Decimal	Yes
            string	N/A	System.String	Yes
	        Object  N/A	System.Object 	Yes
         
         */

        #endregion
        
        #region Value Type
        int i = 5; // value type
        int j = i; // value type
        i = j;
        i = 10;
        Console.WriteLine($"x = {i}, y = {j}");
        // no change in y
        #endregion
        
        #region Reference Type
        int[] arr1 = { 1, 2, 3 }; // reference type
        int[] arr2 = arr1; // reference type
        arr1[0] = 10;
        Console.WriteLine($"arr1[0] = {arr1[0]}, arr2[0] = {arr2[0]}");
        // arr2[0] will be 10, any change in arr1 will affect arr2
        #endregion

        #region object
        // object is a reference type
        // object is a base class for all classes
        // object can store any type of data
        // object is made to have a common functionality for all classes
        object obj01 = new object() ; 
        obj01 = 5;
        obj01 = "Hello";
        obj01 = 'A';
        obj01 = true;
        object obj02 = new object(); 
        Console.WriteLine (obj01.GetHashCode()) ;
        Console.WriteLine (obj02.GetHashCode()) ;
        obj02 = obj01;
        Console.WriteLine("************************");
        Console.WriteLine (obj01.GetHashCode()) ;
        Console.WriteLine (obj02.GetHashCode()) ;
        #endregion
        
        #region Fractions and Discard
        // int Num01 = 123364144444; // it show the error As Num is too large
        long Num02 = 123364414444;
        double Num03 = 22.2;
        float Num04 = 22.2F; // any float Must end with F
        decimal Num05 = 22.2m; // any decimal Must end with m
        int Num06 = 1000_000_000; // it is the same as 1000000000
        Console.WriteLine(Num06); 
        #endregion

        #region Notes
        // there was two memory Stack and Heap
        // Stack: store value type
        // Heap: store reference type
        /*
         ******************************
         *          | Stack  |  Heap  *
         * Arr(ref) |  ref   |  value *
         * Var(val) |  value |        *
         * ****************************
         */
        // Value type: int, float, double, char, bool
        // Reference type: array, class, interface, delegate
        // Value type: store the value itself in stack
        // Reference type: store the address of the value in stack and the value in heap
        
        // in c# there was default value for each type
        // Example: int: 0, string: null, bool: false, etc.
        
        // there Common functions for all classes
        // Example: ToString(), GetHashCode(), GetType(), Equals()

        #endregion
    }
    
}