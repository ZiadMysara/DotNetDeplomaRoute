namespace Demo.Abstraction
{
    internal class Rect : RectSquareBase
    {
        public override decimal Perimeter
        {
            get
            {
                return 2 * (Dim01 + Dim02);
            }
        }

        public Rect(decimal dimo01, decimal dimo02) : base(dimo01, dimo02)
        {
        }

        //public override decimal CalcArea()
        //{
        //    return Dim01 * Dim02;
        //}
        // we don't need to implement CalcArea() here because it is already implemented in RectSquareBase
    }


    // Reback about virtual and override
    // virtual: to allow the method to be overridden in a derived class.
    // override: to provide a new implementation of a member that is inherited from a base class.
    /// Example
    class Parent
    {

        public virtual int Salary { get; set; } // virtual property


        public virtual void Print()
        {
            Console.WriteLine("I am Parent");
        }
    }

    class Child : Parent
    {
        public override int Salary // override property
        {
            get
            {
                return base.Salary;
            }
            set
            {
                base.Salary = value + 2000;
            }
        }
        public override void Print() // override method
        {
            Console.WriteLine("I am Child");
        }
    }
}
