namespace Session04;

class Assignment4
{
    static void Main(string[] args)
    {
        //DemoNotes.Run();
        //ArrayMethods.Run();

        #region Assignment 4 
        P1.Run();
        // P2.Run();
        // P3.Run();
        // P4.Run();
        // P5.Run();
        // P6.Run();
        // P7.Run();
        // P8.Run();
        // P9.Run();
        // P10.Run();
        // P11.Run();
        // P12.Run();
        // P13.Run();
        // P14.Run();
        // P15.Run();
        // P16.Run();
        // P17.Run();
        // P18.Run();
        // P19.Run();
        

        #endregion
        
    }
}

/*
 Assignment 4 
1- Write a program that allows the user to insert an integer then print all numbers between 1 to that number.
    Example 
    Input: 5
    Output: 1, 2, 3, 4, 5

2- Write a program that allows the user to insert an integer then 
print a multiplication table up to 12.
    Example
    Input: 5
    Outputs: 5 10 15 20 25 30 35 40 45 50 55 60

3- Write a program that allows to user to insert number then print all even numbers between 1 to this number
    Example:
    Input: 15
 Output: 2 4 6 8 10 12 14


4- Write a program that takes two integers then prints the power.
    Example:
    Input: 4 3
    Output: 64
    Hint: how to calculate 4^3 = 4 * 4 * 4 =64
5- Write a program to allow the user to enter a string and print the REVERSE of it.

6- Write a program in C# Sharp to find prime numbers within a range of numbers.

Test Data :
Input starting number of range: 1
Input ending number of range : 50

Expected Output :
The prime number between 1 and 50 are :
2 3 5 7 11 13 17 19 23 29 31 37 41 43 47


7- . Write a program in C# Sharp to convert a decimal number into binary without using an array.
Test Data :
Enter a number to convert : 25
Expected Output :
The Binary of 25 is 11001.


8- . Write a program that prints an identity matrix using for loop, in other words takes a value n from the user and shows the identity table of size n * n.

9- Write C# program that Extract a substring from a given string.
   



10- Write C# program that take two string variables and print them as one variable 


11- . Write a program that prints an identity matrix using for loop, in other words takes a value n from the user and shows the identity table of size n * n.


12- Write a program in C# Sharp to find the sum of all elements of the array.



13- Write a program in C# Sharp to merge two arrays of the same size sorted in ascending order.


14- Write a program in C# Sharp to count the frequency of each element of an array.


15- Write a program in C# Sharp to find maximum and minimum element in an array


16- Write a program in C# Sharp to find the second largest element in an array.


17-. Consider an Array of Integer values with size N, having values as    
 in this Example

7	   0	0	0	0	5	6	7	5	0	7	5	3

write a program find the longest distance between Two equal cells. In this example. The distance is measured by the number Of cells- for example, the distance between the first and the fourth cell is 2 (cell 2 and cell 3).

In the example above, the longest distance is between the first 7 and the
10th 7, with a distance of 8 cells, i.e. the number of cells between the 1st
And the 10th 7s.

Note:
- Array values will be taken from the user
- If you have input like 1111111 then the distance is the number of
Cells between the first and the last cell.


18- Write a program to create two multidimensional arrays of same size. Accept value from user and store them in first array. Now copy all the elements of first array on second array and print second array.



19- Write a Program to Print One Dimensional Array in Reverse Order

 */
internal static class P1
{
    public static void Run()
    {
        /*
         1- Write a program that allows the user to insert an integer then 
            print all numbers between 1 to that number.
            Example
            Input: 5
            Output: 1, 2, 3, 4, 5
         */
        int n;
        n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i != n)
                Console.Write(i + ", ");
            else
                Console.Write(i);
        }
    }
}

internal static class P2
{
    public static void Run()
    {
        /*
            2- Write a program that allows the user to insert an integer then 
                print a multiplication table up to 12.
                Example
                Input: 5
                Outputs: 5 10 15 20 25 30 35 40 45 50 55 60
        */
        int n;
        n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= 12; i++)
        {
            if (i != 12)
                Console.Write(n * i + " ");
            else
                Console.Write(n * i);
        }
    }
}

internal static class P3
{
    public static void Run()
    {
        /*
            3- Write a program that allows to user to insert number then print 
                all even numbers between 1 to this number
                Example:
                Input: 15
                Output: 2 4 6 8 10 12 14
        */
        int n;
        n = int.Parse(Console.ReadLine());
        for (int i = 2; i <= n; i += 2)
        {
            if (i != n)
                Console.Write(i + " ");
            else
                Console.Write(i);
        }
        
    }
}

internal static class P4
{
    public static void Run()
    {
        /*
            4- Write a program that takes two integers then prints the power.
                Example:
                Input: 4 3
                Output: 64
                Hint: how to calculate 4^3 = 4 * 4 * 4 =64
        */
        int x, y;
        x = int.Parse(Console.ReadLine());
        y = int.Parse(Console.ReadLine());
        int result = 1;
        for (int i = 0; i < y; i++)
        {
            result *= x;
        }
        Console.WriteLine(result);
        
    }
}

internal static class P5
{
    public static void Run()
    {
        /*
         5- Write a program to allow the user to enter a string and print the REVERSE of it.
         */
        string str = Console.ReadLine();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
    }
}

internal static class P6
{
    public static void Run()
    {
        /*
         6- Write a program in C# Sharp to find prime numbers within a range of numbers.
            Test Data :
            Input starting number of range: 1
            Input ending number of range : 50
            Expected Output :
            The prime number between 1 and 50 are :
            2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
         */
        int start, end;
        start = int.Parse(Console.ReadLine());
        end = int.Parse(Console.ReadLine());
        for (int i = start; i <= end; i++)
        {
            if (IsPrime(i))
            {
                Console.Write(i + " ");
            }
        }
    }

    static bool IsPrime(int n)
    {
        if (n == 1) return false;
        if (n == 2) return true;
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}

internal static class P7
{
    public static void Run()
    {
        /*
         7- Write a program in C# Sharp to convert a decimal number into binary without using an array.
            Test Data :
            Enter a number to convert : 25
            Expected Output :
            The Binary of 25 is 11001.
         */
        int n;
        n = int.Parse(Console.ReadLine());
        string binary = "";
        while (n > 0)
        {
            binary = (n % 2) + binary;
            n /= 2;
        }
        Console.WriteLine(binary);
        
    }
}

internal static class P8
{
    public static void Run()
    {
        /*
         8- Write a program that prints an identity matrix using for loop,
            in other words takes a value n from the user and shows the
            identity table of size n * n.
         */
        int n;
        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                    Console.Write("1 ");
                else
                    Console.Write("0 ");
            }
            Console.WriteLine();
        }
        
    }
}

internal static class P9
{
    public static void Run()
    {
        /*
         9- Write C# program that Extract a substring from a given string.
         */
        string str = Console.ReadLine();
        int start, end;
        start = int.Parse(Console.ReadLine());
        end = int.Parse(Console.ReadLine());
        Console.WriteLine(str.Substring(start, end - start + 1));
    }
}

internal static class P10
{
    public static void Run()
    {
        /*
         10- Write C# program that take two string variables and print them as one variable
         */
        string str1 = Console.ReadLine();
        string str2 = Console.ReadLine();
        Console.WriteLine(str1 + str2);
        
    }
}

internal static class P11
{
    public static void Run()
    {
        /*
         11- Write a program that prints an identity matrix using for loop,
             in other words takes a value n from the user and shows the
            identity table of size n * n.
         */
        
        // Same as P8
        
    }
}

internal static class P12
{
    public static void Run()
    {
        /*
         12- Write a program in C# Sharp to find the sum of all elements of the array.
         */
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int sum = 0;
        Array.ForEach(arr, x => sum += x);
        Console.WriteLine(sum);
        
    }
}

internal static class P13
{
    public static void Run()
    {
        /*
         13- Write a program in C# Sharp to merge two arrays of the same size sorted in ascending order.
         */
        int[] arr1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] arr2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] arr3 = new int[arr1.Length + arr2.Length];
        Array.Copy(arr1, arr3, arr1.Length);
        Array.Copy(arr2, 0, arr3, arr1.Length, arr2.Length);
        Array.Sort(arr3);
        Array.ForEach(arr3, x => Console.Write(x + " "));
        
    }
}

internal static class P14
{
    public static void Run()
    {
        /*
         14- Write a program in C# Sharp to count the frequency of each element of an array.
         */
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] freq = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            freq[i] = 1;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    freq[i]++;
                    arr[j] = -1;
                }
            }
        }
        Array.ForEach(freq, x => Console.Write(x + " "));
    }
}

internal static class P15
{
    public static void Run()
    {
        /*
         15- Write a program in C# Sharp to find maximum and minimum element in an array
         */
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int max = arr[0], min = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
            if (arr[i] < min)
                min = arr[i];
        }
        Console.WriteLine($"Max: {max}, Min: {min}");
        
    }
}

internal static class P16
{
    public static void Run()
    {
        /*
         16- Write a program in C# Sharp to find the second largest element in an array.
         */
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int max = arr[0], secondMax = int.MinValue;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                secondMax = max;
                max = arr[i];
            }
            else if (arr[i] > secondMax && arr[i] != max)
            {
                secondMax = arr[i];
            }
        }
        Console.WriteLine(secondMax);
        
    }
}

internal static class P17
{
    public static void Run()
    {
        /*
         17-. Consider an Array of Integer values with size N, having values as    
            in this Example

            7   0	0	0	0	5	6	7	5	0	7	5	3

            write a program find the longest distance between Two equal cells. In this example.The
            distance is measured by the number Of cells-for example, the distance between the first and
            the fourth cell is 2 (cell 2 and cell 3).

            In the example above, the longest distance is between the first 7 and the
            10th 7, with a distance of 8 cells, i.e. the number of cells between the 1st
            And the 10th 7s.

            Note:
            - Array values will be taken from the user
            - If you have input like 1111111 then the distance is the number of
            Cells between the first and the last cell.
         */
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int maxDistance = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    maxDistance = Math.Max(maxDistance, j - i);
                }
            }
        }
        Console.WriteLine(maxDistance);
        
    }
}

internal static class P18
{
    public static void Run()
    {
        /*
         18- Write a program to create two multidimensional arrays of same size. 
            Accept value from user and store them in first array. Now copy all the elements of first array on second array and print second array.
         */
        int n, m;
        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());
        int[,] arr1 = new int[n, m];
        int[,] arr2 = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr1[i, j] = int.Parse(Console.ReadLine());
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr2[i, j] = arr1[i, j];
            }
        }
        // Print
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(arr2[i, j] + " ");
            }
            Console.WriteLine();
        }
        
    }
}

internal static class P19
{
    public static void Run()
    {
        /*
         19- Write a Program to Print One Dimensional Array in Reverse Order
         */
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.Write(arr[i] + " ");
        }
    }
}
