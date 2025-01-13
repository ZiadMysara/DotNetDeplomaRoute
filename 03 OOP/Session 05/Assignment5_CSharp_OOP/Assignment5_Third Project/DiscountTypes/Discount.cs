namespace Assignment5_Third_Project.DiscountTypes
{
    /*
     1. Create an abstract class Discount with:
        o An abstract method CalculateDiscount(decimal price, int quantity) that returns the 
        discount amount based on the original price and quantity.
        o A Name property to store the type of discount.
    */
    internal abstract class Discount
    {
        public string? TypeOfDiscount { get; set; }
        public abstract decimal CalculateDiscount(decimal price, int quantity);

    }
}
