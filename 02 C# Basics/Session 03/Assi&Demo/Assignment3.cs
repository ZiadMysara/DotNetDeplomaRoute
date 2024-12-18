namespace Session_03;

class Assignment3
{
    static void Main(string[] args)
    {
         DemoNotes.Run();
         // P1.Run();   // 1
         // P2.Run();   // 2
         // P3.Run();   // 3
         // P4.Run();   // 4
         // P5.Run();   // 5
         // P6.Run();   // 7
         // P7.Run();   // 9
         // P8.Run();   // 10
         // P9.Run();   // 11
         // P10.Run();  // 17
         // P11.Run();  // 18
         // P12.Run();  // 21
         // P13.Run();  // 22
         // P14.Run();  // 23
         // P15.Run();  // 24
         // P16.Run();  // 25
    }
}



internal static class P1
{
    public static void Run()
    {
        // Write a program that takes a number from the user then print yes if that number can be divided by 3 and 4 otherwise print no.
        // Example (1)
        // Input: 12 
        // Output: Yes
        // Example (2)
        // Input: 9 
        // Output: No

        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());

        if (number % 3 == 0 && number % 4 == 0)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

internal static class P2
{
    public static void Run()
    {
        // Write a program that allows the user to insert an integer then print negative if it is negative number otherwise print positive.
        // Example (1)
        // Input: -5
        // Output: negative
        // Example (2)
        // Input: 10
        // Output: positive

        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());

        if (number < 0)
        {
            Console.WriteLine("negative");
        }
        else
        {
            Console.WriteLine("positive");
        }
    }
}

internal static class P3
{
    public static void Run()
    {
        // Write a program that takes 3 integers from the user then prints the max element and the min element.
        // Example (1)
        // Input:7,8,5
        // Output:
        // max element = 8
        // min element = 5
        // Example (2)
        // Input: 3 6 9
        // Outputs:
        // Max element = 9
        // Min element = 3

        Console.WriteLine("Enter 3 numbers:");
        string[] numbers = Console.ReadLine().Split(' ');

        int max = int.Parse(numbers[0]);
        int min = int.Parse(numbers[0]);

        for (int i = 1; i < numbers.Length; i++)
        {
            int number = int.Parse(numbers[i]);

            if (number > max)
            {
                max = number;
            }

            if (number < min)
            {
                min = number;
            }
        }

        Console.WriteLine($"Max element = {max}");
        Console.WriteLine($"Min element = {min}");
    }
}

internal static class P4
{
    public static void Run()
    {
        // Write a program that allows the user to insert an integer number then check
        // If a number is even or odd. 
        int num = int.Parse(Console.ReadLine());
        if (num % 2 == 0)
        {
            Console.WriteLine("Num is even");
        }
        else
        {
            Console.WriteLine("Num is odd");
        }


    }
}

internal static class P5
{
    public static void Run()
    {
        // Write a program that takes character from the user then if it is
        // a vowel chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).
        // Example (1)
        // Input: O
        // Output: vowel
        // Example (2)
        // Input: b
        // Output: Consonant
        // 'A' = 65
        // 'a' = 97
        // 'Z'
        Console.WriteLine("Enter a character:");
        char c = char.Parse(Console.ReadLine());
        if (c >= 'a')
        {
            c -= (char)32;
        }
        if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
        {
            Console.WriteLine("vowel");
        }
        else
        {
            Console.WriteLine("Consonant");
        }

    }
}

internal static class P6
{
    public static void Run()
    {
        // Write a program that allows the user to insert an integer then 
        // print a multiplication table up to 12.
        // Example
        // Input: 5
        // Outputs: 5 10 15 20 25 30 35 40 45 50 55 60
        int num = int.Parse(Console.ReadLine());
        for (int i = 1; i <= 12; i++)
        {
            Console.Write($"{num * i} ");
        }

    }
}

internal static class P7
{
    public static void Run()
    {
        // Write a program that takes two integers then prints the power.
        // Example:
        // Input: 4 3
        // Output: 64
        // Hint: how to calculate 4^3 = 4 * 4 * 4 =64
        string[] numbers = Console.ReadLine().Split(' ');
        int num1 = int.Parse(numbers[0]);
        int num2 = int.Parse(numbers[1]);
        int result = 1;
        for (int i = 0; i < num2; i++)
        {
            result *= num1;
        }
        Console.WriteLine(result);

    }
}

internal static class P8
{
    public static void Run()
    {
        // Write a program to enter marks of five subjects and calculate total,
        // average and percentage.
        // Example
        // Input: - Enter Marks of five subjects: 95 76 58 90 89
        // Output: Total marks = 408
        // Average Marks = 81
        // Percentage = 81
        Console.WriteLine("Enter Marks of five subjects: ");
        string[] marks = Console.ReadLine().Split(' ');
        int total = 0;
        for (int i = 0; i < marks.Length; i++)
        {
            total += int.Parse(marks[i]);
        }
        Console.WriteLine($"Total marks = {total}");
        Console.WriteLine($"Average Marks = {total / marks.Length}");
        Console.WriteLine($"Percentage = {total / marks.Length}");

    }
}

internal static class P9
{
    public static void Run()
    {
        // Write a program to input the month number and print the number of days in that month.
        // Example
        // Input: Month Number: 1
        // Output: Days in Month: 31
        int month = int.Parse(Console.ReadLine());
        DateTime date = new DateTime(2021, month, 1);
        Console.WriteLine(date.AddMonths(1).AddDays(-1).Day);
        
    }
}

internal static class P10
{
    public static void Run()
    {
        /*
         * 17- Create a program that asks the user to input three points
         * (x1, y1), (x2, y2), and (x3, y3), and determines whether these
         * points lie on a single straight line.
         */
        Console.WriteLine("Enter the first point (x1, y1):");
        string[] point1 = Console.ReadLine().Split(' ');
        Console.WriteLine("Enter the second point (x2, y2):");
        string[] point2 = Console.ReadLine().Split(' ');
        Console.WriteLine("Enter the third point (x3, y3):");
        string[] point3 = Console.ReadLine().Split(' ');
        
        double x1 = double.Parse(point1[0]);
        double y1 = double.Parse(point1[1]);
        double x2 = double.Parse(point2[0]);
        double y2 = double.Parse(point2[1]);
        double x3 = double.Parse(point3[0]);
        double y3 = double.Parse(point3[1]);
        
        double slope1 = (y2 - y1) / (x2 - x1);
        double slope2 = (y3 - y2) / (x3 - x2);
        
        if (slope1 == slope2)
        {
            Console.WriteLine("The points lie on a single straight line.");
        }
        else
        {
            Console.WriteLine("The points do not lie on a single straight line.");
        }

    }
}

internal static class P11
{
    public static void Run()
    {
        /*
         * Within a company, the efficiency of workers is evaluated based on the duration
         * required to complete a specific task. A worker's efficiency level is determined
         * as follows: 
            - If the worker completes the job within 2 to 3 hours, they are considered
              highly efficient. 
            - If the worker takes 3 to 4 hours, they are instructed to increase their speed. 
            - If the worker takes 4 to 5 hours, they are provided with training to enhance
              their speed. 
            - If the worker takes more than 5 hours, they are required to leave the company. 
            To calculate the efficiency of a worker, the time taken for the task is obtained
            via user input from the keyboard.
         */
        Console.WriteLine("Enter the time taken to complete the task:");
        double time = double.Parse(Console.ReadLine());
        
        if (time >= 2 && time < 3)
        {
            Console.WriteLine("The worker is highly efficient.");
        }
        else if (time >= 3 && time < 4)
        {
            Console.WriteLine("The worker is instructed to increase their speed.");
        }
        else if (time >= 4 && time < 5)
        {
            Console.WriteLine("The worker is provided with training to enhance their speed.");
        }
        else if (time >= 5)
        {
            Console.WriteLine("The worker is required to leave the company.");
        }

    }
}

internal static class P12
{
    public static void Run()
    {
        /*
         * Write C# program that Assigning one value type variable to another and
         * modifying the value of one variable and mention what will happen
         */
        int a = 5;
        int b = a;
        b = 10;
        Console.WriteLine(a); // 5
        Console.WriteLine(b); // 10
        // The value of a will not change because it is a value type variable.
    }
}

internal static class P13
{
    public static void Run()
    {
        /*
         * Write C# program that Assigning one reference type variable to another and
         * modifying the object through one variable and mention what will happen
         */
        int[] a = { 1, 2, 3 };
        int[] b = a;
        b[0] = 10;
        Console.WriteLine(a[0]); // 10
        Console.WriteLine(b[0]); // 10
        // The value of a will change because it is a reference type variable.

    }
}

internal static class P14
{
    public static void Run()
    {
        /*
         * Which of the following statements is correct about the C#.NET code snippet
         * given below?
         * 
         * int d; 
         * d = Convert.ToInt32( !(30 < 20) );
         * 
         * a) A value 0 will be assigned to d.
         * b) A value 1 will be assigned to d.
         * c) A value -1 will be assigned to d.
         * d) The code reports an error.
         * e) The code snippet will work correctly if ! is replaced by Not.
         */
        int d;
        d = Convert.ToInt32( !(30 < 20) );
        Console.WriteLine(d); // 1
        // b) A value 1 will be assigned to d.
        // as true = 1 and false = 0 and condition is false so !false = true = 1
    }
}

internal static class P15
{
    public static void Run()
    {
        /*
         * Which of the following is the correct output for the C# code given below?
         * 
         * Console.WriteLine(13 / 2 + " " + 13 % 2); 
         * 
         * a) 6.5 1
         * b) 6.5 0
         * c) 6 0
         * d) 6 1
         * e) 6.5 6.5
         */
        Console.WriteLine(13 / 2 + " " + 13 % 2); // 6 1
        // c) 6 1
        // 13 / 2 = 6 and 13 % 2 = 1 so when we concatenate them it will be 6 1

    }
}

internal static class P16
{
    public static void Run()
    {
        /*
         * What will be the output of the C# code given below?
         * 
         * int num = 1, z = 5;
         * 
         * if (!(num <= 0))
         *     Console.WriteLine( ++num + z++ + " " + ++z ); 
         * else
         *     Console.WriteLine( --num + z-- + " " + --z ); 
         * 
         * a) 5 6
         * b) 6 5
         * c) 6 6
         * d) 7 7
         */
        int num = 1, z = 5;

        if (!(num <= 0))
            Console.WriteLine( ++num + z++ + " " + ++z ); 
        else
            Console.WriteLine( --num + z-- + " " + --z ); 
        
        // b) 7 7
        // first condition !(false) = true so it will print 2 + 5 + " " + 7 = 7 7

    }
}