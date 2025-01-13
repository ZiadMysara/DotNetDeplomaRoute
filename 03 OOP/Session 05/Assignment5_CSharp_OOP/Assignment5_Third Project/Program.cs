using Assignment5_Third_Project.DiscountTypes;
using Assignment5_Third_Project.UserTypes;

namespace Assignment5_Third_Project
{
    internal class Program
    {
        //o Calculates and displays the total discount and final price after applying the appropriate discount. 
        private static void PrintFinalPrice(decimal price, int quantity, Discount? discount)
        {
            decimal discountAmount = 0;
            if (discount is not null)
            {
                discountAmount = discount.CalculateDiscount(price, quantity);
            }
            decimal finalPrice = price * quantity - discountAmount;
            Console.WriteLine($"Total Discount: {discountAmount}");
            Console.WriteLine($"Final Price: {finalPrice}");
        }

        static void Main(string[] args)
        {
            /*
            Part 4: Integration
            5. Write a program that:
            o Ask the user to input their type (Regular, Premium, or Guest).
             */
            EUserType TheUserType = 0;
            do
            {

                Console.WriteLine("please enter your Type (Regular, Premium, or Guest)");
                string type = Console.ReadLine()!;
                Enum.TryParse<EUserType>(type, true, out TheUserType);
            }

            while (TheUserType == 0);


            // o Allows the user to input product details (price and quantity).

            decimal price = 0m;
            int quantity = 0;
            bool flag = false;
            do
            {
                Console.WriteLine("please enter the price of the product");
                flag = decimal.TryParse(Console.ReadLine(), out price);
            }
            while (!flag);

            do
            {
                Console.WriteLine("please enter the quantity of the product");
                flag = int.TryParse(Console.ReadLine(), out quantity);
            }
            while (!flag);

            /*
            o RegularUser: Applies a PercentageDiscount of 5%.
            o PremiumUser: Applies a FlatDiscount of $100.
            o GuestUser: No discount is applied
            */
            //

            User user = TheUserType switch //impossible to be none here because of the do while loop
            {
                EUserType.Regular => new RegularUser(),
                EUserType.Premium => new PremiumUser(),
                EUserType.Guest => new GuestUser(),
            };

            Discount? discount = user.GetDiscount();

            //o Calculates and displays the total discount and final price after applying the appropriate discount. 
            PrintFinalPrice(price, quantity, discount);

        }
    }
}
