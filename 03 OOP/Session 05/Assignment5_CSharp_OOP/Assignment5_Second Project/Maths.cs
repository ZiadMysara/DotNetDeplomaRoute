namespace Assignment5_Second_Project
{
    //Define Class Maths that has four methods: Add, Subtract, Multiply, and Divide, each of them takes 
    //two parameters.

    // Modify the program so that you do not have to create an instance of class to call the four methods.
    // i made it static so that i can call the methods without creating an instance of the class
    internal static class Maths
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
        public static int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
