namespace Assignment5_Third_Project.DiscountTypes
{
    /*
    2. Implement the following concrete discount classes:
        o FlatDiscount:
            ▪ Accepts a fixed amount to be deducted (e.g., $50).
            ▪ Formula: Discount Amount=Flat Amount×min(Quantity,1)
    */
    internal class FlatDiscount : Discount
    {
        #region Prop
        public decimal FlatAmount { get; set; }
        #endregion

        #region Constractors
        public FlatDiscount(decimal flatAmount)
        {
            FlatAmount = flatAmount;
        }
        #endregion


        #region Methodes
        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            //Formula: Discount Amount=Flat Amount×min(Quantity,1)
            return FlatAmount * Math.Min(quantity, 1);
        }
        #endregion
    }
}
