namespace Demo.Interface_Example_03
{
    internal class Car : Vechile, IMoveable
    {
        public override int Speed { get; set; }

        public void Backward()
        {
            Console.WriteLine("Car Go Backward");
        }

        public void Forward()
        {
            Console.WriteLine("Car Go Forward");
        }

    }
}
