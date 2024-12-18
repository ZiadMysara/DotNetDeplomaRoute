namespace ConsoleApp1;

class Assignment2
{
    static void Main(string[] args)
    {
        // DemoNotes.Run();
        // Problem1.Run();
        // Problem2.Run();
        // Problem3.Run();
    }
}

internal static class Problem1
{
    public static void Run()
    {
        //1- Write a program that allows the user to enter a number then print it.
        int number;
        Console.Write("Enter a number: ");
        number = int.Parse(Console.ReadLine());
        Console.WriteLine($"You entered: {number}");
    }
}

internal static class Problem2
{
    public static void Run()
    {
        /*
         2-Write C# program that Assigning one value type variable to another
         and modifying the value of one variable and mention what will happen
        */
        int x = 5; // value type
        int y = x; // value type
        x = y;
        x = 10;
        Console.WriteLine($"x = {x}, y = {y}");
        // no change in y
    }
}
internal static class Problem3
{
    public static void Run()
    {
        /*
         3- Write C# program that Assigning one reference type variable
         to another and modifying the object through one variable and mention what will happen
        */
        int[] arr1 = { 1, 2, 3 }; // reference type
        int[] arr2 = arr1; // reference type
        arr1[0] = 10;
        Console.WriteLine($"arr1[0] = {arr1[0]}, arr2[0] = {arr2[0]}");
        // arr2[0] will be 10, any change in arr1 will affect arr2
    }
}
