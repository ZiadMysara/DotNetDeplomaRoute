using System.Text;

namespace Session04;

internal static class DemoNotes
{
    public static void Run()
    {
        #region for loop

        //
        // Console.WriteLine($"number 0");
        // Console.WriteLine($"number 1");
        // Console.WriteLine($"number 2");
        // Console.WriteLine($"number 3");
        // // ...
        // // it is much faster than for loop
        // // but it is not maintainable and readable
        //
        // for (int i = 0; i < 10; i++)
        // {
        //     Console.WriteLine($"number {i}");
        // }
        // // it is more readable and maintainable
        // // but it is slower than repeat line of code
        //
        // // if you have a small number of lines of code
        // // it is better to repeat the line of code
        // // if you have a large number of lines of code
        // // it is better to use for loop
        //

        #endregion

        #region for vs foreach

        // int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // for(int i = 0;i < Numbers.Length; i++)
        // {
        //     if (Numbers [i] == 5)
        //     {
        //         continue; // skip the current iteration
        //         break; // exit the loop
        //     }
        //     Console.WriteLine(Numbers[i]);
        // }
        // // Class implienemt interface IEnummrable (Copy of the array)
        // foreach(int Number in Numbers)
        // {   
        //     //Number = Number * 2; // error as Number is read only as it is (Copy of the array) 
        //     Console.WriteLine(Number + 10);
        // }

        #endregion

        #region While - Do While

        // // Do While loop
        // int Number;
        // bool IsNumber;
        // do 
        // {
        //     Console.WriteLine("Enter Even Number ");
        //     IsNumber = int.TryParse(Console.ReadLine(), out Number);
        // } 
        // while (Number % 2 == 1 && !IsNumber);
        //
        // Console.WriteLine($" {Number} is Even");
        // // While loop
        // Number = 3;
        // bool Flag = false;
        // while(Number % 2 == 1 || !Flag)
        // {
        //     Console.WriteLine("Enter Even Number ");
        //     Flag = int. TryParse(Console.ReadLine(), out Number);
        // }
        // Console.WriteLine($" {Number} is Even");

        #endregion

        #region String

        // // Class => Reference Type
        // // immutable Data Type [Value can not be Changed]
        // // Array Of Chars
        // // A H M E D
        // string Name;
        // //Name = new string("Ahmed");
        // Name = "Ahmed"; // Sugar Syntax
        //
        // string Name01 = "Ahmed";
        // string Name02 = "Ahmed";
        // Console.WriteLine(Name01);
        // Console.WriteLine($"Name01 HC {Name01.GetHashCode()}");
        // Console.WriteLine(Name02);
        // Console.WriteLine($"Name02 HC {Name02.GetHashCode()}");
        // // it is the same object in the memory (same hash code)
        // // same value ==> same hash code 
        //
        // Name01 = "Ahmed";
        // Name02 = Name01;
        // Name01 = "Mostafa";
        // Console.WriteLine("********** Name01 = Mostafa ***********");
        // Console.WriteLine(Name01);
        // Console.WriteLine($"Name01 HC {Name01.GetHashCode()}");
        // Console.WriteLine(Name02);
        // Console.WriteLine($"Name02 HC {Name02.GetHashCode()}");
        // // it is different object in the memory (different hash code)
        // // different value ==> different hash code
        // // as string is immutable data type so when we change the value of Name01
        // // it will create a new object in the memory
        //
        // string Message = "Hello";
        // Console.WriteLine("********** Message = Hello ***********");
        // Console.WriteLine (Message);
        // Console.WriteLine(Message.GetHashCode());
        // Message += "Route"; 
        // Console.WriteLine(Message);
        // Console.WriteLine(Message.GetHashCode());
        // // it is different object in the memory (different hash code)
        // // As string is immutable data type so when we change the value of Message
        // // it will create a new object in the memory

        #endregion

        #region StringBuilder

        // // Class => Reference Type
        // // mutable Data Type [Value can be Changed]
        // // linked list of chars
        // // A -> H -> M -> E -> D
        // StringBuilder Message;
        // Message = new StringBuilder("Hello");
        // //Message = "Hello"; // error no sugar syntax
        // Console.WriteLine(Message);
        // Console.WriteLine(Message.GetHashCode());
        //
        // //Message += Route";
        // Message.Append(" Route");
        // Console.WriteLine (Message);
        // Console.WriteLine(Message.GetHashCode());
        // // it is the same object in the memory (same hash code)
        // // it is not about the value here, it is about the object itself
        //
        //
        //

        #endregion

        #region StringBuilder Methods

        // StringBuilder Message = new StringBuilder("Welcome");
        // Message. Append(" To Route");
        // Message. AppendLine(" Mostafa");
        // Message. Append("Hany");
        // Message.Remove(0, 7);
        // Message. Insert(0, "Hello");
        // Console.WriteLine (Message);
        //
        // Console.WriteLine(); 
        // int Age = 10;
        // string Name = "Ali";
        // Message.AppendFormat("Name : {0} Age: {1}", Name, Age);
        // Console.WriteLine(Message);
        // Message.Clear();
        // Message.AppendJoin("/", "Mostafa", "Hany", "Mohammed", 2, "sad" );
        // Console.WriteLine(Message);

        #endregion

        #region Array 1D
        // // Array => Reference Type
        // // Array is a collection of similar data types
        // // Array is a fixed size
        // // sting is immutable data type
        // // Array is mutable data type
        //
        //
        // //int[] Numbers = new int[3] {1, 2, 3};
        // //int[] Numbers = new int[]  {1, 2, 3};
        // //int[] Numbers = {1, 2, 3};
        // int[] Numbers = new int[3];
        // //Numbers[0] = 1;
        // //Numbers[1] = 2;
        // //Numbers[2] = 3;
        //
        // for (int i = 0; i < Numbers.Length; i++)
        // {
        //     Console.WriteLine($"Enter element {i}");
        //     Numbers[i] = int.Parse(Console.ReadLine());
        // }
        //
        // Console.WriteLine();
        // for (int i = 0; i < Numbers.Length; i++)
        // {
        //     Console.WriteLine(Numbers[i]);
        // }
        //
        // Console.WriteLine($"Array lenght: {Numbers.Length}");
        // Console.WriteLine($"Array Rank: {Numbers.Rank}"); // 1D, 2D, 3D
        //
        #endregion

        #region Array 2D
        // 2D Array has 2 types
        // Rectangular Array [,]
        // Jagged Array [][]

        #region Rectangular Array [,] 
        // // all the rows have the same number of columns 
        // // rectangular array [,]
        // int[,] Marks = new int[3, 5];
        // //Console.WriteLine(Marks.Length);
        // //Console.WriteLine(Marks.Rank);
        // //Console.WriteLine(Marks.GetLength(0));
        // //Console.WriteLine(Marks.GetLength(1));
        // for(int i=0;i< Marks.GetLength(0); i++)
        // {
        //     Console.WriteLine($"Enter Grades Student ({i + 1})" ); 
        //     for(int k = 0; k < Marks.GetLength(1); k++)
        //     {
        //         Console.WriteLine($"Enter Grade Subject [{k + 1}]");
        //         Marks [i,k] = int.Parse(Console.ReadLine()); 
        //     }
        // }
        //
        // //Print
        // for (int i = 0; i < Marks.GetLength(0); i++)
        // {
        //     Console.WriteLine($"Grades Student ({i + 1})") ;
        //     for (int k = 0; k < Marks.GetLength(1); k++)
        //     {
        //         Console.Write($"Grade Subject [{k + 1}] : ");
        //         Console.WriteLine(Marks [i, k]);
        //     }
        // }
        //
        // // Another way to print
        // for (int i = 0; i < Marks.Length; i++)
        // {
        //     Console.WriteLine(Marks[i / Marks.GetLength(1), i % Marks.GetLength(1)]);
        // }
        // // note that:
        // // GetLength(1) is the number of columns
        // // GetLength(0) is the number of rows
        // // Jagged Array
        #endregion

        #region Jagged Array [][] 
        // // Customized number of columns for each row
        //
        // int[][] Number = new int[3][];
        // Number[0] = new int[3] {1,2,3};
        // Number[1] = new int[2] {4,5};
        // Number[2] = new int[1] {6};
        // for(int i = 0; i < Number.Length; i++)
        // {
        //     for(int j = 0; j < Number[i].Length; j++)
        //     {
        //         Console.WriteLine();
        //     }
        // }

        #endregion
        #endregion

        #region Notes

        // for loop is slower than repeat line of code
        // but it is more readable and maintainable

        // for loop is faster than foreach

        // foreach is IEnumerable (Copy of the array)
        
        int [] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        foreach (int Number in Numbers)
        {
            // Number = Number * 2; // error as Number is read only as it is (Copy of the array)
            Console.WriteLine(Number + 10);
        }
        
        // Try parse is important in validation
        
        // array is a collection of similar data types
        // array is a fixed size
        // array is a reference type
        // array is mutable data type
        
        // [,] => Rectangular Array
        // [][] => Jagged Array
        
        

        #endregion
    }
}