namespace Demo.Static
{
    // Static Class
    // is a just Container For Static Members [Attribute, Property, Constructor, Method]
    // and Constants
    // You Can't Create Object From This Class (Helper Class)
    // No Inheritance for this Class 
    internal static class Utility
    {

        #region Properties
        #region Opject Memper [Instance]
        //public int X { get; set; }
        //public int Y { get; set; }
        #endregion


        #region Fields
        // 1. Class Member Attribute: Static Attribute
        private static readonly  double pi = 3.14;
        // CLR will Initilize Each and Every Static Attribute with its Datatype Default Value
        // Before the First Usage of the Class.

        // 2. Constant
        private const double e = 2.71;
        #endregion



        /// Class Member Property: Static Property: [Must Deal With One Of the Following]:
        /// 1. Static Attribute
        /// 2. Constant
        #region Class Memper [Static]
        public static double PI
        {
            //set { pi = value; } // as it is readonly, i can't set it
            get { return pi; }
        }
        #endregion
        #endregion

        #region Constructor
        // Object Member Constructor: Non—Static Constructor
        //public Utility(int x, int y)
        //{
        //    X = x;
        //    Y = y;
        //    // pi = 3.14; // error as it is readonly

        //}
        // Static Constructor [Max Only One Per Class]
        // U Can't Specify Access Modifier OR Parameters for the Static Constructor
        // Will be Called Once Per Class Lifetime Before the First Usage of the Class
        /// The Usages of the Class as following:
        /// 1. Create Object from this Class OR from another Class "Inheriting from this Class".
        /// 2. Call Static Property
        /// 3. Call Static Method
        static Utility()
        {
            pi = 3.14; // although it is readonly, i can set it in the static constructor
            // e = 2.71; // error as it is constant
        }
        #endregion

        #region Methods
        //public override string ToString()
        //{
        //    return $"X = {X}, Y = {Y}";
        //}

        // Object Member Method: Non-Static Method
        //public double CmToInch(double Cm)
        //{
        //    return Cm / 2.54;
        //}

        // Class Member Method: Static Method
        public static double InchToCm(double Inch)
        {
            return Inch * 2.54;
        }

        #endregion
    }

}
