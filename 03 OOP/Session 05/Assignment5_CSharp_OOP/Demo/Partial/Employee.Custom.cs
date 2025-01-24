namespace Demo.Partial
{
    // Devoloper 2
    internal partial class Employee
    {
        public string? Address { get; set; }

        // i can access Id, Name, Age that are in Employee.cs file
        // as Employee is a partial class
        override public string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Age = {Age}, Address = {Address}";
        }

        // Partial Method
        partial void DoSomeCode()
        {
            Console.WriteLine("DoSomeCode");
        }

    }
}
