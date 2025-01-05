namespace Session_05;

class Assignment5
{
    static void Main(string[] args)
    {
        //P1.Run();
        //P2.Run();
        //P3.Run();
        //P4.Run();
        //P5.Run();
        //P6.Run();
        //P7.Run();
        //P8.Run();
        DemoNotes.Run();
        
    }
}
/*
 Functions 
 
1- Explain the difference between passing (Value type 
parameters) by value and by reference then write a suitable c# 
example.

2- Explain the difference between passing (Reference type 
parameters) by value and by reference then write a suitable c# 
example.

3- Write a c# Function that accept 4 parameters from user and 
return result of summation and subtracting of two numbers

4- Write a program in C# Sharp to create a function to calculate the sum of 
the individual digits of a given number.
 Output should be like 
 Enter a number: 25 
 The sum of the digits of the number 25 is: 7

5- Create a function named "IsPrime", which receives an integer number 
and retuns true if it is prime, or false if it is not:

6- Create a function named MinMaxArray, to return the minimum and 
maximum values stored in an array, using reference parameters

7- Create an iterative (non-recursive) function to calculate the factorial 
of the number specified as parameter

8- Create a function named "ChangeChar" to modify a letter in a certain 
position (0 based) of a string, replacing it with a different letter
 
 */
internal static class P1
{
    private static void swap(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    private static void swapRef(ref int a,ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    public static void Run()
    {
       /*
        1- Explain the difference between passing (Value type
        parameters) by value and by reference then write a suitable c#
        example.
        */
        // by value
        Console.WriteLine("By Value");
        Console.WriteLine("*********");
        int x = 10, y = 20;
        Console.WriteLine($"Before swap x = {x} , y = {y}");
        swap(x, y);
        Console.WriteLine($"After swap x = {x} , y = {y}");
       
        // by reference
        Console.WriteLine("By Reference");
        Console.WriteLine("*************");
        x = 10; y = 20;
        Console.WriteLine($"Before swap x = {x} , y = {y}");
        swapRef(ref x, ref y);
        Console.WriteLine($"After swap x = {x} , y = {y}");
        
        // when we pass by value the original value is not changed
        // when we pass by reference the original value is changed
    }
}
internal static class P2
{
    private static void SumArr2(int[] arr)
    {
        arr = new int[] { 1, 2, 3}; // this will not change the original array
        arr[0] = 100;
    }
    private static void SumArrRef2(ref int[] arr)
    {
        arr = new int[] { 1, 2, 3 }; // this will change the address of the original array
        arr[0] = 4;
    }
    
    public static void Run()
    {
        /*
        2- Explain the difference between passing (Reference type
        parameters) by value and by reference then write a suitable c#
        example.
        */
        // by value
        Console.WriteLine("By Value");
        Console.WriteLine("*********");
        int[] numbers = { 1, 2, 3 };
        Console.WriteLine($"Before change numbers[0] = {numbers[0]}");
        SumArr2(numbers);
        Console.WriteLine($"After change numbers[0] = {numbers[0]}");
        
        // by reference
        Console.WriteLine("By Reference");
        Console.WriteLine("*************");
        numbers = new int[] { 1, 2, 3 };
        Console.WriteLine($"Before change numbers[0] = {numbers[0]}");
        SumArrRef2(ref numbers);
        Console.WriteLine($"After change numbers[0] = {numbers[0]}");
       
    }
}
internal static class P3
{
    private static void Sum(params int[] x)
    {
        Console.WriteLine("Summation of first two numbers: " + (x[0] + x[1]));
    }
    private static void Subtract(params int[] x)
    {
        Console.WriteLine("Subtraction of last two numbers: " + (x[2] - x[3]));
    }
    public static void Run()
    {
        /*
        3- Write a c# Function that accept 4 parameters from user and
        return result of summation and subtracting of two numbers
        */
        int a, b, c, d;
        int []tempArr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        a = tempArr[0];
        b = tempArr[1];
        c = tempArr[2];
        d = tempArr[3];
        
        Sum(a, b, c, d);
        Subtract(a, b, c, d);

    }
}
internal static class P4
{
    private static void sumOfDigites(int num)
    {
        int CopyNum = num;
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        Console.WriteLine($"The sum of the digits of the number {CopyNum} is: {sum}");
    }
    public static void Run()
    {
        /*
        4- Write a program in C# Sharp to create a function to calculate the sum of
        the individual digits of a given number.
        Output should be like
        Enter a number: 25
        The sum of the digits of the number 25 is: 7    
        */
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        sumOfDigites(num);

        
       
    }
}
internal static class P5
{
    private static void IsPrime(int num)
    {
        bool isPrime = true;
        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        Console.WriteLine(isPrime);
    }
    public static void Run()
    {
        /*
        5- Create a function named "IsPrime", which receives an integer number
        and retuns true if it is prime, or false if it is not:
        */
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        IsPrime(num);
       
    }
}
internal static class P6
{
    private static void MinMaxArray(int[] arr, ref int min, ref int max)
    {
        min = arr[0];
        max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        
    }
    public static void Run()
    {
        /*
        6- Create a function named MinMaxArray, to return the minimum and
        maximum values stored in an array, using reference parameters
        */
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int min = 0, max = 0;
        MinMaxArray(arr, ref min, ref max);
        Console.WriteLine($"Min = {min} , Max = {max}");
        
    }
}
internal static class P7
{
    private static void Factorial(int num)
    {
        int fact = 1;
        for (int i = 1; i <= num; i++)
        {
            fact *= i;
        }
        Console.WriteLine(fact);
    }
    public static void Run()
    {
        /*
        7- Create an iterative (non-recursive) function to calculate the factorial
        of the number specified as parameter
        */
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        Factorial(num);
       
    }
}
internal static class P8
{
    private static void ChangeChar(ref string str, int index, char ch)
    {
        char[] temp = str.ToCharArray();
        temp[index] = ch;
        str = new string(temp);
    }
    public static void Run()
    {
        /*
        8- Create a function named "ChangeChar" to modify a letter in a certain
        position (0 based) of a string, replacing it with a different letter
        */
        Console.Write("Enter the word: ");
        string str = Console.ReadLine();
        Console.Write("Enter the index: ");
        int index = int.Parse(Console.ReadLine());
        Console.Write("Enter the character: ");
        char ch = char.Parse(Console.ReadLine());
        ChangeChar(ref str, index, ch);
        Console.WriteLine(str);
       
    }
}
