namespace Assignment5_Third_Project.DiscountTypes
{
    /*
    2. Implement the following concrete discount classes:
    o PercentageDiscount:
        ▪ Accepts a percentage (e.g., 10%).
        ▪ Formula: Discount Amount=Price×Quantity×(Percentage/100)
     */
    internal class PercentageDiscount : Discount
    {
        public decimal Percentage { get; set; }

        public PercentageDiscount(decimal percentage)
        {
            Percentage = percentage;
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            //Discount Amount=Price×Quantity×(Percentage/100)
            return price * quantity * (Percentage / 100);
        }
    }
}
