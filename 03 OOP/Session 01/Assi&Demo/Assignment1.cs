
using System.Linq.Expressions;
using System.Reflection;

class Assignment1
{
    static void Main(string[] args)
    {
        // DemoNotes.Run();
        // P1.Run();
        // P2.Run();
         P3.Run();
        // P4.Run();
        // P5.Run();
    }
}

internal static class P1
{
    private enum WeekDays : byte
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public static void Run()
    {
        /*
         1. Create an enum called "WeekDays" with the days of the week (Monday
            to Sunday) as its members. Then, write a C# program that prints out all
            the days of the week using this enum.
        */
        for (int i = 0; i < 7; i++)
        {
            WeekDays weekDays = (WeekDays)i;
            Console.WriteLine(weekDays);
        }

    }
}
internal static class P2
{
    enum Season : byte
    {
        Spring = 1,
        Summer = 2,
        Autumn = 3,
        Winter = 4,
        InvalidSeason = 0,
    }
    public static void Run()
    {
        /*
         2. Create an enum called "Season" with the four seasons (Spring, Summer, 
         Autumn, Winter) as its members. Write a C# program that takes a season 
         name as input from the user and displays the corresponding month range 
         for that season. Note range for seasons ( spring march to may , summer 
         june to august , autumn September to November , winter December to 
         February)
        */
        Console.WriteLine("Enter a season: ");
        string season = Console.ReadLine();
        Enum.TryParse<Season>(season, true, out Season Result);

        // Display the corresponding month range
        switch (Result)
        {
            case Season.Spring:
                Console.WriteLine("Spring: March to May");
                break;
            case Season.Summer:
                Console.WriteLine("Summer: June to August");
                break;
            case Season.Autumn:
                Console.WriteLine("Autumn: September to November");
                break;
            case Season.Winter:
                Console.WriteLine("Winter: December to February");
                break;
            default:
                Console.WriteLine("Invalid season entered.");
                break;
        }

    }
}

internal static class P3
{
    [Flags] // This attribute called Data Annotation
    private enum Permissions : byte
    {
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8,
        invalidPermission = 0
    }

    public static void Run()
    {
        /*
         3. Assign the following Permissions (Read, write, Delete, Execute) in a form 
         of Enum.
         ⮚ Create Variable from previous Enum to Add and Remove Permission 
         from variable, check if specific Permission is existed inside variable
        */
        Permissions permissions = Permissions.Read | Permissions.Write | Permissions.Delete;

        Console.WriteLine("Enter premtion that you want to add or remove ");
        string permission = Console.ReadLine();
        Enum.TryParse<Permissions>(permission, true, out Permissions Result);

        permissions = permissions ^ Result;

        Console.WriteLine($"permissions: {permissions}");

    }
}
internal static class P4
{
    private enum Colors : byte
    {
        Red = 1,
        Green = 2,
        Blue = 3,
        InvalidColor = 0
    }
    public static void Run()
    {
        /*
         4. Create an enum called "Colors" with the basic colors (Red, Green, Blue) as 
         its members. Write a C# program that takes a color name as input from 
         the user and displays a message indicating whether the input color is a 
         primary color or not.
        */
        Console.WriteLine("Enter a Color: ");
        string color = Console.ReadLine();
        Enum.TryParse<Colors>(color, true, out Colors Result);

        switch(Result)
        {
            case Colors.Red:
            case Colors.Green:
            case Colors.Blue:
                Console.WriteLine("Primary Color");
                break;
            default:
                Console.WriteLine("Not a Primary Color");
                break;
            }
        }
        
}
internal static class P5
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public static void Run()
    {
        /*
         5. Create a struct called "Point" to represent a 2D point with properties "X" 
         and "Y". Write a C# program that takes two points as input from the user 
         and calculates the distance between them.
        */
        Point point1 = new Point();
        Point point2 = new Point();
        Console.WriteLine("Enter the X and Y coordinates of the first point: ");
        int[] ints = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        point1.X = ints[0];
        point1.Y = ints[1];

        Console.WriteLine("Enter the X and Y coordinates of the second point: ");
        ints = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        point2.X = ints[0];
        point2.Y = ints[1];

        double distance = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));

        Console.WriteLine($"The distance between the two points is: {distance}");

    }
}
