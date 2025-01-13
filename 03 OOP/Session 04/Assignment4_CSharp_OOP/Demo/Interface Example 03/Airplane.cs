namespace Demo.Interface_Example_03
{
    internal class Airplane : Vechile, IMoveable, IFlyable
    {
        public override int Speed
        {
            get;
            set;
        }

        void IMoveable.Forward()
        {
            Console.WriteLine("Airplane Go Forward");
        }

        void IFlyable.Forward()
        {
            Console.WriteLine("Airplane Fly Forward");
        }
        public void Backward() // same method name in both interfaces
        {
            Console.WriteLine("Airplane Go Backward");
        }


    }
}
