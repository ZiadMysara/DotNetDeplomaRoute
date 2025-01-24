using System.Numerics;

namespace Assignment01
{
    internal class Range<T> where T : IComparable<T>, ISubtractionOperators<T, T, T> // 5. Note: You can assume that the type T used in the Range<T> class implements the IComparable<T> interface to allow for comparisons.
    {
        #region Properties

        public T Min { get; set; }
        public T Max { get; set; }

        #endregion

        #region Constructors
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }
        #endregion

        #region Methods
        /*
        3. Implement a method IsInRange(T value) that returns true if the given 
        value is within the range, otherwise false.
        */
        public bool IsInRange(T value)
        {
            return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
        }

        /*
        4. Implement a method Length() that returns the length of the range 
        (the difference between the maximum and minimum values).
        */
        public T Length()
        {
            return Max - Min;
        }

        #endregion



    }
}