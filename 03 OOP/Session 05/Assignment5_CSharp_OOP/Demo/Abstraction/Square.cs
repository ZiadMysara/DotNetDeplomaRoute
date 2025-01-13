namespace Demo.Abstraction
{
    internal class Square : RectSquareBase
    {
        public override decimal Perimeter
        {
            get
            {
                return 4 * Dim01;
            }
        }

        public Square(int Dim) : base(Dim, Dim)
        {
        }

        //public override decimal CalcArea()
        //{
        //    return Dim01 * Dim02;
        //}
        // we don't need to implement CalcArea() here because it is already implemented in RectSquareBase
    }

}
