namespace Demo.Bulit_in_interface
{
    internal class Department : ICloneable
    {
        public int Code { get; set; }
        public string? Title { get; set; }

        public object Clone()
        {
            return new Department() { Code = this.Code, Title = this.Title };

        }
    }
}
