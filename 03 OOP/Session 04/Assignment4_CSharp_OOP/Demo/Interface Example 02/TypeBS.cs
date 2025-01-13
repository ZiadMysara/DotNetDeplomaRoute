namespace Demo.Interface_Example_02
{
    internal class TypeBS : ISeries
    {
        public int Current
        {
            get;
            set;
        }

        public void GetNext()
        {
            Current += 3;
        }

        // not required to implement as it is already implemented in ISeries
        //public void Reset()
        //{
        //    Current = 0;
        //}
    }
}
