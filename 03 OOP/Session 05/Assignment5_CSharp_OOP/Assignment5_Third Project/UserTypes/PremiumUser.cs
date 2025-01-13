using Assignment5_Third_Project.DiscountTypes;

namespace Assignment5_Third_Project.UserTypes
{
    //PremiumUser: Applies a FlatDiscount of $100
    internal class PremiumUser : User
    {
        public override Discount? GetDiscount()
        {
            return new FlatDiscount(100);
        }
    }
}
