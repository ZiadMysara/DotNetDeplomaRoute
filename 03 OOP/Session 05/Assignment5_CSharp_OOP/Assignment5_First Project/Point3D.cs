namespace Assignment5_First_Project
{

    // 1-Define 3D Point Class and the basic Constructors (use chaining in constructors).
    // 6-Implement ICloneable interface to be able to clone the object.
    internal class Point3D : IComparable<Point3D>, ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point3D(int x, int y) : this(x, y, 0) // Chaining
        {
        }

        public Point3D()
        {
        }

        //2-Override the ToString Function to produce this output:
        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public int CompareTo(Point3D? other)
        {
            if (other is not null)
            {
                int sum1 = this.X + this.Y;
                int sum2 = other.X + other.Y;
                return sum1.CompareTo(sum2);
            }
            else
            {
                return 1;
            }
        }

        public object Clone()
        {
            return new Point3D(this.X, this.Y, this.Z);
        }
    }
}
