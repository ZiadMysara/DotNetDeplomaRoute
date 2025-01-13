using Assignment5_Third_Project.DiscountTypes;

namespace Assignment5_Third_Project.UserTypes
{
    //RegularUser: Applies a PercentageDiscount of 5%.
    internal class RegularUser : User
    {
        public override Discount? GetDiscount()
        {
            return new PercentageDiscount(5);
        }
    }
}
