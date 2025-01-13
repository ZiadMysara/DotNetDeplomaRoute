namespace Demo.Abstraction
{
    internal abstract class RectSquareBase : Shape
    {
        protected RectSquareBase(decimal Dim01, decimal Dim02) : base(Dim01, Dim02)
        {
        }

        public override decimal CalcArea()
        {
            return Dim01 * Dim02;
        }
    }
}
