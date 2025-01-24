

namespace Assignment01
{
    internal static class Helper<T> where T : IComparable
    {
        public static void Swap(ref T i, ref T j)
        {
            T temp = i;
            i = j;
            j = temp;
        }

        #region Task 1: Optimizing the Bubble Sort Algorithm
        /*
        The Bubble Sort algorithm has a time complexity of O(n^2) in its worst 
        and average cases, which makes it inefficient for large datasets. How we 
        can optimise the Bubble Sort algorithm 
        And implement the code of this optimised bubble sort algorithm
        */
        public static void BubbleSort(T[] arr)
        {
            int n = arr.Length;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }

        // Optimised Bubble Sort Algorithm
        // complexity of O(n^2) in its worst and average cases
        // complexity of O(n) in its best case 
        // when the array is already sorted 
        #endregion

        #region Task 3: Reversing an `ArrayList` In-Place
        internal static void ReverseArrayList(T[] list)
        {
            int n = list.Length;
            for (int i = 0; i < n / 2; i++)
            {
                Swap(ref list[i], ref list[n - i - 1]);
            }

        }

        #endregion

        #region Task 4: Filtering Even Numbers from a List
        internal static List<int> FilterEvenNumbers(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return evenNumbers;

            // other way to filter even numbers
            // using built-in FindAll method that we take in session 2
            return numbers.FindAll(x => x % 2 == 0);
        }


        #endregion
        #region Task 6: Finding the First Non-Repeated Character in a String
        /*
         6. Given a string, implement a function that finds the first non - repeated
            character and returns its index.If no such character exists, return -1.
            Hint: You can use a dictionary to track character frequencies.
        */
        internal static int FirstNonRepeatedCharIndex(string str)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (charCount[str[i]] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}
