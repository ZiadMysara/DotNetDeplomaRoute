namespace Assignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1: Optimizing the Bubble Sort Algorithm
            /*
              1. The Bubble Sort algorithm has a time complexity of O(n^2) in its worst 
                 and average cases, which makes it inefficient for large datasets. How we 
                 can optimise the Bubble Sort algorithm 
                 And implement the code of this optimised bubble sort algorithm
            */
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            Console.Write("Original Array: { ");
            Array.ForEach(arr, x => Console.Write(x + " "));
            Console.WriteLine("}");

            Helper<int>.BubbleSort(arr);
            Console.Write("\nSorted Array: { ");
            Array.ForEach(arr, x => Console.Write(x + " "));
            Console.WriteLine("}");
            #endregion

            #region Task 2: Implementing a Generic `Range<T>` Class
            /*
             2. create a generic Range<T> class that represents a range of values from a 
                minimum value to a maximum value. The range should support basic 
                operations such as checking if a value is within the range and 
                determining the length of the range.
                Requirements:
                1. Create a generic class named Range<T> where T represents the type 
                of values.
                2. Implement a constructor that takes the minimum and maximum 
                values to define the range.
                3. Implement a method IsInRange(T value) that returns true if the given 
                value is within the range, otherwise false.
                4. Implement a method Length() that returns the length of the range 
                (the difference between the maximum and minimum values).
                5. Note: You can assume that the type T used in the Range<T> class 
                implements the IComparable<T> interface to allow for comparisons.

            */
            Range<int> range = new Range<int>(10, 20);
            Console.WriteLine($"\nIs 15 in range? {range.IsInRange(15)}"); // true
            Console.WriteLine($"Is 25 in range? {range.IsInRange(25)}"); // false
            Console.WriteLine($"Length of range: {range.Length()}"); // 10
            #endregion

            #region Task 3: Reversing an `ArrayList` In-Place

            /*
             3. You are given an ArrayList containing a sequence of elements. try to 
                reverse the order of elements in the ArrayList in-place(in the same 
                arrayList) without using the built-in Reverse. Implement a function that 
                takes the ArrayList as input and modifies it to have the reversed order of 
                elements.
            */
            int[] list = { 1, 2, 3, 4, 5 };
            Helper<int>.ReverseArrayList(list);

            Console.Write("\nReversed Array: { ");
            Array.ForEach(list, x => Console.Write(x + " "));
            Console.WriteLine("}");
            #endregion

            #region Task 4: Filtering Even Numbers from a List

            /*
             4. You are given a list of integers. Implement a function that finds and 
                returns a new list containing only the even numbers from the given list.
            */
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evenNumbers = Helper<int>.FilterEvenNumbers(numbers);
            Console.Write("\nEven Numbers: { ");
            evenNumbers.ForEach(x => Console.Write(x + " "));
            Console.WriteLine("}");
            #endregion

            #region Task 5: Implementing a Custom `FixedSizeList<T>` Class

            /*
             5. Create a custom list FixedSizeList<T> with a predetermined capacity. This 
                list should restrict the number of elements added to its fixed capacity and 
                throw clear error messages if an attempt is made to exceed the capacity or 
                access invalid indices.
                Requirements:
                1. Create a generic class FixedSizeList<T>.
                2. Implement a constructor that takes the fixed capacity of the list as a 
                parameter.
                3. Implement an Add method that adds an element to the list but throws an 
                exception if the list is already full.
                4. Implement a Get method that retrieves an element at a specific index but 
                throws an exception for invalid indices.
            */
            FixedSizeList<int> fixedList = new FixedSizeList<int>(3);
            fixedList.Add(1);
            fixedList.Add(2);
            fixedList.Add(3);
            //fixedList.Add(4); // throws exception
            Console.WriteLine($"\nElement at index 1: is {fixedList.Get(1)}");
            //Console.WriteLine(fixedList.Get(3)); // throws exception
            #endregion

            #region Task 6: Finding the First Non-Repeated Character in a String
            /*
             6. Given a string, implement a function that finds the first non - repeated
                character and returns its index.If no such character exists, return -1.
                Hint: You can use a dictionary to track character frequencies.
            */
            string str = "hello";
            Console.WriteLine($"\nFirst non-repeated character index: {Helper<char>.FirstNonRepeatedCharIndex(str)}"); // 0
            #endregion
        }
    }
}
