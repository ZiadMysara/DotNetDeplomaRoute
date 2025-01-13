namespace Demo.Abstraction
{
    internal class Triangle : Shape
    {

        public decimal Dim03 { get; set; }

        public Triangle(decimal Dim01, int Dim02, int Dim03) : base(Dim01, Dim02)
        {
            this.Dim03 = Dim03;
        }

        public override decimal Perimeter => throw new NotImplementedException();

        public override decimal CalcArea()
        {
            throw new NotImplementedException();
        }
    }
}
