namespace Demo.Abstraction
{
    internal class Circle : Shape
    {
        public Circle(int radius) : base(radius, radius)
        {
        }
        public override decimal Perimeter
        {
            get
            {
                return 2 * (decimal)Math.PI * Dim01;
            }
        }

        public override decimal CalcArea()
        {
            return (decimal)Math.PI * Dim01 * Dim02;
        }
    }
}
