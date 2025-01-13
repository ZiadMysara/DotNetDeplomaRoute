namespace Demo.Interface_Example_02
{
    internal class TypeAS : ISeries
    {

        private int current;

        public int Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }


        public void GetNext()
        {
            Current += 2;
        }

        // not required to implement as it is already implemented in ISeries
        //public void Reset()
        //{
        //    Current = 0;
        //}
    }
}
