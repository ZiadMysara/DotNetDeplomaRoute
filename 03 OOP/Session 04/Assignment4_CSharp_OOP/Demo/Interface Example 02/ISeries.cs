namespace Demo.Interface_Example_02
{
    internal interface ISeries
    {
        public int Current { get; set; }

        public void GetNext();

        // if the Function is the same for all classes, make it default implementation 
        public void Reset()
        {
            Current = 0;
        }
    }
}
