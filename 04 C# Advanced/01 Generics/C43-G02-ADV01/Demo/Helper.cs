using System.Collections;

namespace Demo
{
    internal class Helper<T> where T : IComparable
    {

        #region Swap
        // swap two numbers
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        // swap two double numbers
        public static void Swap(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }
        // swap two Point objects
        public static void Swap(ref Point a, ref Point b)
        {
            Point temp = a;
            a = b;
            b = temp;
        }
        // so we can use the same method to swap different types of variables
        // using object
        public static void Swap(ref object a, ref object b) // unsafe // boxing and unboxing
        {
            object temp = a;
            a = b;
            b = temp;
        }

        // so now we know why we need to use generics
        // so we can use the same method to swap different types of variables
        // using generics
        public static void Swap<T>(ref T a, ref T b) // where T : class // i can also put conditions 
        {
            T temp = a;
            a = b;
            b = temp;
        }
        // this is better than using object
        // because it is type safe
        // and it is faster 
        #endregion

        public static int Search(T[] Arr, T Value)
        {
            if (Arr is not null && Value is not null)
            {
                for (int i = 0; i < Arr.Length; i++)
                {
                    if (Value.Equals(Arr[i]))
                        return i;
                }
            }
            return -1;
        }

        public static void Sort(T[] Arr)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                for (int j = 0; j < Arr.Length - 1 - i; j++)
                {
                    if (Arr[j].CompareTo(Arr[j + 1]) == 1)
                        Helper<int>.Swap(ref Arr[j], ref Arr[j + 1]);
                }
            }
        }

        public static void Sort(T[] Arr, IComparer comparer)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                for (int j = 0; j < Arr.Length - 1 - i; j++)
                {
                    //if (Arr[j] > Arr[j + 1])
                    if (comparer.Compare(Arr[j], Arr[j + 1]) == 1)
                        Swap(ref Arr[j], ref Arr[j + 1]);
                }
            }
        }

    }
}
