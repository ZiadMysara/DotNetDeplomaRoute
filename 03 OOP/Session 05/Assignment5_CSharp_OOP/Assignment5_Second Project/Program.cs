namespace Assignment5_Second_Project
{
    /*
    Define Class Maths that has four methods: Add, Subtract, Multiply, and Divide, each of them takes 
    two parameters. Call each method in Main ().
    Modify the program so that you do not have to create an instance of class to call the four methods.
    */
    internal class Program
    {
        //Call each method in Main ().
        static void Main(string[] args)
        {
            int X = 10;
            int Y = 5;

            Console.WriteLine($"Addition: {Maths.Add(X, Y)}");
            Console.WriteLine($"Subtraction: {Maths.Subtract(X, Y)}");
            Console.WriteLine($"Multiplication: {Maths.Multiply(X, Y)}");
            Console.WriteLine($"Division: {Maths.Divide(X, Y)}");

        }
    }
}
