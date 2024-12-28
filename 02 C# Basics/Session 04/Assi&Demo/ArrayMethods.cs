namespace Session04;

internal static class ArrayMethods
{
    public static void Run()
    {
        // Array 17 Methods
        
        #region IndexOf
        
        // This returns the start index of an item inside the array – in our case 2 for lemon 🍋
        // If the item is not found, it returns -1.
        var fruits = new[] { "melon", "coconut", "lemon", "lemon" };
        
        var result = Array.IndexOf(fruits, "lemon");
        Console.WriteLine(result); // 2
        
        #endregion
        
        #region Exists
        
        // It checks to see whether or not an item exists in an array (this accepts a Predicate):
        fruits = new[] { "melon", "coconut", "lemon" };
        var existsResult = Array.Exists(fruits, fruit => fruit.Contains("l"));
        Console.WriteLine(existsResult);
        
        #endregion
        
        #region Find
        
        // This simply find the first item in an array that matches a certain condition:
        // if not found, it returns the default value of the type.
        fruits = new[] { "melon", "coconut", "lemon" };
        var findResult = Array.Find(fruits, fruit => fruit.Contains("l"));
        Console.WriteLine(findResult);
        
        #endregion
        
        #region FindLast
        
        // As the Find method, but this starts from the end of the array:
        // if not found, it returns the default value of the type.
        fruits = new[] { "melon", "coconut", "lemon" };
        var findLastResult = Array.FindLast(fruits, fruit => fruit.Contains("l"));
        Console.WriteLine(findLastResult);
        
        #endregion
        
        #region FindIndex
        
        // We can also find the index of an item by using a Predicate:
        fruits = new[] { "melon", "coconut", "lemon" };
        var findIndexResult = Array.FindIndex(fruits, fruit => fruit.Contains("l"));
        Console.WriteLine(findIndexResult);
        
        #endregion
        
        #region FindAll
        
        // We can find all the items that pass a certain condition:
        fruits = new[] { "melon", "coconut", "lemon" };
        var findAllResult = Array.FindAll(fruits, fruit => fruit.Contains("l"));
        foreach (var fruit in findAllResult)
        {
            Console.WriteLine(fruit);
        }
        
        #endregion
        
        #region Reverse
        
        // We can reverse the items in an array:
        fruits = new[] { "melon", "coconut", "lemon" };
        Array.Reverse(fruits);
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
        
        #endregion
        
        #region Copy vs ConstrainedCopy
        // Copy
        // We can copy the items of an array to another one.
        // The third argument is to specify how many items you want to copy:
        fruits = new[] { "melon", "coconut", "lemon" };
        var fruits2 = new string[fruits.Length];
        Array.Copy(fruits, fruits2, 2); // just copy the first two items
        // TIP: To copy all the items, just pass fruits.Length as the third argument.
        
        // ConstrainedCopy
        // This method is similar to Copy,
        // but if the copy throws an exception, the destination array will not be modified.
        
        fruits = new[] { "melon", "coconut", "lemon" };
        var fruits3 = new Object[fruits.Length];
        
        Array.ConstrainedCopy(fruits, 0, fruits3, 0, fruits.Length);
        
        #endregion
        
        #region Sort
        
        // And one of the most important things is to sort an array:
        fruits = new[] { "melon", "coconut", "lemon" };
        Array.Sort(fruits);
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
        
        // Maybe we want to reverse the order (descending).
        // in this case make class which implements the IComparer interface: as line 149
        // And then, just pass an instance of this class as an argument:
        fruits = new[] {
            "melon", "coconut", "lemon"
        };
        
        Array.Sort(fruits, new ReverseComparer());
            
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
        
        #endregion
        
        #region BinarySearch
        
        // You can search for an element in a sorted array (make sure to sort the array in ascending order before applying this algorithm):
        fruits = new[] {
            "melon", "coconut", "lemon"
        };
        
        Array.Sort(fruits);
        
        var index = Array.BinarySearch(fruits, "coconut");
        if (index == -1)
            Console.WriteLine("nothing");
        else
            Console.WriteLine(index);
            
        // Duplicates: If an array contains duplicate elements (which have the same value), 
        // BinarySearch will return the index of one of those elements.
        
        #endregion
        
        #region ConvertAll
        // ConvertAll is a method that converts all the items in an array to another type.
        
        // For example, we can convert all the items in an array of strings to integers:
        int [] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        
        #endregion
        
        #region Clear Vs Empty
        // Clear: This method sets all the items in an array to their default value.
        // Empty: This is a static property that returns an empty array of the same type.
        
        // Clear
        var nums = new[] { 1, 2, 3};
        Array.Clear(nums, 0, nums.Length); // clear all the items
        foreach (var num in nums)
        {
            Console.WriteLine(num); // 0 0 0
        }
        
        // Empty
        nums = Array.Empty<int>();
        
        foreach (var num in nums)
        {
            Console.WriteLine(num);
        }
        
        #endregion

        #region foreach
        // We can use the foreach loop to iterate over the items of an array:
        
        fruits = new[] { "melon", "coconut", "lemon" };
        // add 's' for each fruit
        Array.ForEach(fruits, fruit => Console.WriteLine(fruit + "s"));
        // or we can use the method group
        Array.ForEach(fruits, Console.WriteLine);
        

        #endregion

        #region Fill
        // Fill: This method fills an array with a specific value.
        
        // Fill
        nums = new[] { 1, 2, 3};
        Array.Fill(nums, 0);
        Array.ForEach(nums, Console.WriteLine); // 0 0 0
        
        #endregion
        
        #region Resize
        // Resize: This method resizes an array to a new size.
        
        // Resize
        nums = new[] { 1, 2, 3};
        Array.Resize(ref nums, 2);
        Array.ForEach(nums, Console.WriteLine); // 1 2
      
        Array.Resize(ref nums, 4);
        Array.ForEach(nums, Console.WriteLine); // 1 2 0 0
        #endregion
        
        #region TrueForAll
        // TrueForAll: This method checks to see if all the items in an array pass a certain condition.
        fruits = new[] { "melon", "coconut", "lemon" };
        var trueForAllResult = Array.TrueForAll(fruits, fruit => fruit.Contains("l"));
        Console.WriteLine(trueForAllResult);
        #endregion
        
        #region AsReadOnly
        // AsReadOnly: This method returns a read-only wrapper for an array.
        
        // AsReadOnly
        fruits = new[] { "melon", "coconut", "lemon" };
        var readOnlyFruits = Array.AsReadOnly(fruits);
        // readOnlyFruits.Add("apple"); // this will throw an exception
        #endregion

    }
}
// Maybe we want to reverse the order (descending).
// In this case, we need to create a new class which implements the IComparer interface:
public class ReverseComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return y.CompareTo(x);
    }
}