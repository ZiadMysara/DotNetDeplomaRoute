namespace Demo.Bulit_in_interface
{
    internal class Employee : ICloneable, IComparable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }

        public Department? department { get; set; }

        public Employee() { }

        //Copy Constructor: is a Special Constructor Used to Make a Deep Copy for the ReferenceType Object
        public Employee(Employee employeeCopy)
        {
            this.Id = employeeCopy.Id;
            this.Name = employeeCopy.Name;
            this.Salary = employeeCopy.Salary;
            // Deep Copy
            this.department = (Department?)employeeCopy?.department?.Clone();
        }

        public object Clone()
        {
            // it used Copy constractor to copy 
            return new Employee(this);

            //anothe way
            return new Employee
            {
                Id = this.Id,
                Name = this.Name,
                Salary = this.Salary,
                department = this.department
            };
        }

        public override string ToString()
        {
            return $"Id {Id}, Name {Name}, Salary {Salary:c}";
        }

        // +Ve: this.Salary > obj.Salary
        // -Ve: this.Salary < obj.Salary
        //  0 : this.Salary = obj.Salary
        public int CompareTo(object? obj)
        {
            Employee? other = (Employee?)obj; // Explicit Casting


            // - means compare descending order
            return -this.Salary.CompareTo(other?.Salary);

            //Another way
            other = (Employee?)obj; // Explicit Casting
            if (other is null)
                return 1;
            if (this.Salary > other.Salary)
                return 1;
            else if (this.Salary < other.Salary)
                return -1;
            return 0;
        }
    }
}
