namespace Demo
{
    internal struct Point 
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }


        public override string ToString()
        {
            return $"({X}, {Y})";
        }


    }
}
