namespace Assignment5_Third_Project.DiscountTypes
{
    /*
     2. Implement the following concrete discount classes:
        BuyOneGetOneDiscount:
            ▪ Applies a 50% discount if the quantity is greater than 1.
            ▪ Formula: Discount Amount=(Price/2)×(Quantity÷2)
     */
    internal class BuyOneGetOneDiscount : Discount
    {
        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            //Discount Amount=(Price/2)×(Quantity÷2)
            return quantity > 1 ? (price / 2) * (quantity / 2) : 0;
        }
    }
}
