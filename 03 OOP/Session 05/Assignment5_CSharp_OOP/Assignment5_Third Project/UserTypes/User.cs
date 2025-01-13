using Assignment5_Third_Project.DiscountTypes;


namespace Assignment5_Third_Project.UserTypes
{
    /*
     3. Create an abstract class User with:
        o A Name property to store the user name.
        o An abstract method GetDiscount() that returns a Discount object.

     */
    internal abstract class User
    {
        public int Name { get; set; }

        public abstract Discount? GetDiscount();
    }
}
