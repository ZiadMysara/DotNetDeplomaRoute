namespace Demo.Interface_Example_01
{
    internal class TypeA : IType
    {
        private int myProperty;
        public int MyProperty
        {
            get
            {
                return myProperty;
            }
            set
            {
                myProperty = value;
            }
        }

        public void MyMethod()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
