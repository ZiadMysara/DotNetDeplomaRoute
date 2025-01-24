
namespace Assignment01
{
    #region Task 5: Implementing a Custom `FixedSizeList<T>` Class
    internal class FixedSizeList<T> //1. Create a generic class FixedSizeList<T>.
    {

        public List<T> List { get; set; }

        public int FixedCapacity { get; }


        public FixedSizeList(int FixedCapacity) //2. Implement a constructor that takes the fixed capacity of the list as a parameter.
        {
            this.FixedCapacity = FixedCapacity;
            List = new List<T>(FixedCapacity);
        }

        // 3. Implement an Add method that adds an element to the list but throws an exception if the list is already full.
        internal void Add(T v)
        {
            if (List.Count >= FixedCapacity)
            {
                // throw exception
                throw new Exception("List is already full");
            }
            List.Add(v);
        }

        internal T Get(int index)
        {
            if (index >= List.Count)
            {
                // throw exception
                throw new Exception("Invalid index");
            }
            else
            {
                return List[index];
            }
        }
    }
    #endregion
}