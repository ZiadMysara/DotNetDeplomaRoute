using Assignment5_Third_Project.DiscountTypes;

namespace Assignment5_Third_Project.UserTypes
{
    //GuestUser: No discount is applied
    internal class GuestUser : User
    {
        public override Discount? GetDiscount()
        {
            return null;
        }
    }
}
