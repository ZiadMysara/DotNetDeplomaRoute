namespace Demo.Sealed
{

    class Parent
    {
        public virtual int Salary { get; set; }

        public virtual void print()
        {
            Console.WriteLine("Parent");
        }
    }
    class Child : Parent
    {
        // Sealed property
        public sealed override int Salary
        {
            get { return base.Salary; }
            set { base.Salary = value < 5000 ? 5000 : value; }
        }

        // Sealed Method
        public sealed override void print()
        {
            Console.WriteLine("Child");
        }

    }
    // Sealed class
    sealed class GrandChild : Child
    {
        //public override int Salary // error as Child.Salary is sealed
        //{
        //    get { return base.Salary; }
        //    set { base.Salary = value < 10000 ? 10000 : value; }
        //}

        //public override void print() // error as Child.print is sealed
        //{
        //    Console.WriteLine("GrandChild");
        //}

        public new void print() // new keyword to hide the sealed method
        {
            Console.WriteLine("GrandChild");
        }
    }

    //class Test : GrandChild // error as GrandChild is sealed
}
