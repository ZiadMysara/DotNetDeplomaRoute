namespace Demo.Abstraction
{
    /// Abstract Class
    /// is a Partial Implementation for Other Classes.
    /// is a Container for Common Code [Implemented Members, Abstract Members] among many Classes.
    /// U Can't Create an Object from Abstract Class [it is not fully implemented].
    /// Abstract Class not acutally exist in business model.
    abstract class Shape : IDraw2D, IDraw3D
    {
        public decimal Dim01 { get; set; }

        public decimal Dim02 { get; set; }


        protected Shape(decimal Dim01, decimal Dim02)
        {
            this.Dim01 = Dim01;
            this.Dim02 = Dim02;
        }



        //! don't say something like this in interview
        // Abstract Property like virtual property but without implementation
        public abstract decimal Perimeter { get; }

        //! don't say something like this in interview
        // Abstract Method like virtual method but without implementation
        public abstract decimal CalcArea();

        public void Draw()
        {
            Console.WriteLine("Draw 2D");
        }

        public void Draw3D()
        {
            Console.WriteLine("Draw 3D");
        }
    }

    public interface IDraw2D
    {
        void Draw();

    }

    public interface IDraw3D
    {
        void Draw();
    }

}
