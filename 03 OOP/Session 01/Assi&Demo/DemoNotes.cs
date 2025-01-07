using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Claims;

internal static class DemoNotes
{

    #region Exception Handling

    private static void DoSomeCode()
    {
        try
        {
            int X, Y, Z;
            X = int.Parse(Console.ReadLine()); // FormatException
            Y = int.Parse(Console.ReadLine());
            Z = X / Y;// DivideByZeroException
            int[] Numbers = { 1, 2, 3 };
            Numbers[10] = 100;// IndexOutOfRangeException
        }
        // CLR Create Object From Exception

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            // Log in file
            // Store DB
        }
    }

    private static void DoSomeProtectiveCode()
    {
        int X, Y, Z;
        bool IsParsed = false;
        do
        {
            Console.WriteLine("Enter First Number");
            IsParsed = int.TryParse(Console.ReadLine(), out X); // FormatException // Now is protected
        }
        while (!IsParsed);
        do
        {
            Console.WriteLine("Enter Second Number");
            IsParsed = int.TryParse(Console.ReadLine(), out Y); // FormatException // Now is protected
        }
        while (!IsParsed || Y == 0);

        Z = X / Y;// DivideByZeroException // Now is protected

        int[] Numbers = { 1, 2, 3 };

        if (Numbers?.Length > 10) // NullReferenceException // Now is protected
            Numbers[10] = 100;// IndexOutOfRangeException  // Now is protected
    }

    #endregion

    #region Access Modifiers
    internal interface Itype
    {
        /*
         * What i can Write in Interface?
            1. Signature For Property => C# 7.0
            2. Signature For Method => C# 7.0
            3. Default Implemented Method => C# 8.0 Feature.Net Core 3.1 [2019]
         */
        public int X { get; set; }
        public void DoSomeThing();
        public void DoSomeThingElse();


    }

    internal enum Typez
    {
        /*
         * What i can Write in Enum?
            1. Labels
         
         */

        // no access modifier in enum

    }

    private static int x; // class scope only
    internal static int y; // class and in the same project
    public static int z; // it can be accessed from any thing

    #endregion

    #region enum
    internal enum Day : int
    {
        Saturday,   // 0
        Sunday,     // 1
        Monday,     // 2
        Tuesday,    // 3
        Wednesday,  // 4
        Thursday,   // 5
        Friday,     // 6
    }

    enum Branches : byte // 0: 255
    {
        NasrCity, // 0

        Maadi = 252,
        // it will count from 252
        ALex,  // 253
        Dokki, // 254
        Enhaas // 255
               // if you add more than 255 it will give you an error
    }
    #endregion


    #region Enum permision
    [Flags]
    internal enum permision
    {
        Read = 1,
        Write = 2,
        Delete = 4,
        Update = 8,
    }


    #endregion

    #region Struct
    internal struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Print()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}";
        }
    }
    #endregion

    public static void Run()
    {
        #region Exception Handling
        // Exceptions
        // 1. System Exceptions
        //  1.1 Format Exception
        //  1.2 Index Out Of Range Exception
        //  1.3 Null Reference Exception
        //  1.4 Invalid Operation Exception
        //  1.5 Arithmetic Exception
        //  1.5.1 Divided By Zero Exception
        //  1.5.2 Overflow Exception
        // 2. Application Exception

        //DoSomeCode();

        try
        {
            //DoSomeProtectiveCode();
        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex.Message);
        }
        finally // it will preformed if there is an exception or not
        {
            // Close - Free - Delete - Dealocate Unmanged Recources
            //like
            // Close File
            // Close DB Connection
            // Close Network Connection
        }



        #endregion

        #region Access Modifiers
        // Access Modifiers
        // * Private            : Only the class that contains the member can access it.
        // * Private Protected  : Only the class that contains the member can access it, and classes that derive from the class can access it.
        // * Protected          : Only the class that contains the member can access it, and classes that derive from the class can access it.
        // * Internal           : Only code in the same assembly(project) can access it.
        // * Protected Internal : Only code in the same assembly(project) can access it, and classes that derive from the class can access it.
        // * Public             : Any code can access it.
        // * file    //its new  : Only code in the same file can access it.





        #endregion


        #region enum

        #region enum
        Day d = Day.Sunday;


        // enum casting
        d = (Day)1; // Sunday // explicit casting

        d = (Day)10; // 10 
                     // if the value is not exist in the enum it will take the value as it is

        #region Ex03
        // not safe casting
        // if the value is not exist in the enum it will throw an exception
        Day day = (Day)Enum.Parse(typeof(Day), Console.ReadLine());// casting from string to object to enum


        // safe casting
        Enum.TryParse(typeof(Day), Console.ReadLine(), out object result); // casting from string to object to enum
        day = (Day)result;


        // safe casting
        Enum.TryParse<Day>(Console.ReadLine(), true, out Day result2);// casting from string to object to enum
        day = result2;

        Day day1 = new Day(); // day1 = 0 => Saturday
        Console.WriteLine(day1); // Saturday
        #endregion


        #endregion

        #region Enum permision
        permision p = permision.Read | permision.Write;

        // Add or Remove Permission if it is existed
        p = p ^ permision.Write; // ^ => XOR

        // add permission
        p = p | permision.Delete; // | => OR

        // remove permission
        p = p & ~permision.Delete; // &~ => AND NOT


        // Check if Permission is existed
        if ((p & permision.Write) == permision.Write) // & => AND
        {
            Console.WriteLine("Write Permission is existed");
        }
        else
        {
            Console.WriteLine("Write Permission is not existed");
        }


        #endregion
        #endregion

        #region Struct
        // What You Can Write Inside The Struct Or Class
        //1. Attributes[Fields] => Member Variable
        //2. Functions[Constructor, Getter Setter, Method]
        //3. Properties[Full Property, Automatic Property, Indexer]
        //4. Events


        //Access Modifier Allowed Inside Struct?
        //1. Private[Default]
        //2. Internal
        //3. Public

        Point pp = new Point(10, 20);

        Console.WriteLine(pp);// defult will print DemoNotes.Point // but now it will call the ToString() method
        Console.WriteLine(pp.ToString());// it more faster than the above line as no boxing



        #endregion

        #region Notes

        // Try - Catch is the last defense line against exceptions

        // Access Modifiers that allow with
        // * Struct     :   Internal, Public, private(Default)
        // * Interface  :   public, internal
        // * Namespace  :   Public, Internal(Default)
        // * Enum       :   No Access Modifier

        // * Class      :   Private(Default), PrivateProtected, Protected, Internal, Protected Internal, Public

        // default access modifier for class is internal
        // default access modifier in class is private 

        // with class vs in class // important defference


        // if you need to use class or ect from other project to this project
        // you have to put his reffrence first in your project
        // and you have to use it like: use common;


        // enum by defult is int
        // enum start count after the last value
        // enum is a value type
        // exciplict casting in enum will return defult value if the value is not exist
        // enum is a predefined constant

        // [Flags] is used to make the enum as a bit field
        // [Flags] is annotation 

        // struct has no inheritance
        // Although struct inherits from object 

        // struct is value type
        // class is reference type

        // struct is stack
        // class is heap

        // struct is faster than class
        // struct is used for small data
        // struct is used for immutable data

        // Exception is class

        //unmanaged CLR:
        // 1. File
        // 2. Network
        // 3. DB

        #endregion
    }
}
