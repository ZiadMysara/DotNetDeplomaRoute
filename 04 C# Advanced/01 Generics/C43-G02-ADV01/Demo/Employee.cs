namespace Demo
{
    internal class Employee : IComparable
    {

        #region Properties
        public int Id { get; set; }

        public string? Name { get; set; }

        public double Salary { get; set; }
        #endregion

        #region Constructors
        public Employee(int id, string? name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Salary: {Salary:c}";
        }

        public static bool operator ==(Employee e1, Employee e2)
        {
            return e1.Equals(e2); // this is also valid and its value base equality
            return (e1.Id == e2.Id) && (e1.Name == e2.Name) && (e1.Salary == e2.Salary);
        }

        public static bool operator !=(Employee e1, Employee e2)
        {
            return (e1.Id != e2.Id) || (e1.Name != e2.Name) || (e1.Salary != e2.Salary);
            return !(e1 == e2); // this is also valid
        }

        public override int GetHashCode()
        {
            // used way now 
            return HashCode.Combine(this.Id, this.Name, this.Salary);

            // true way and if we use ^ it will be faster
            //int hashValue = 11;
            //hashValue = (hashValue * 7) + Id.GetHashCode();
            //hashValue = (hashValue * 7) + Name?.GetHashCode() ?? default(int);
            //hashValue = (hashValue * 7) + Salary.GetHashCode();
            //return hashValue;

            // faster but false way
            //return this.Id.GetHashCode() ^ this.Name?.GetHashCode()?? default(int) ^ this.Salary.GetHashCode();

            // false way
            //return this.Id.GetHashCode() + this.Name?.GetHashCode()?? default(int) + this.Salary.GetHashCode();
        }


        public int CompareTo(object? obj)
        {
            Employee? other = (Employee?)obj;// Explicit Casting
                                             // UnSafe Casting --> May Throw Exception [Invalild Cast Exception]
            return this.Salary.CompareTo(other?.Salary);
            //if(other == null) return 1;
        }

        public override bool Equals(object? obj)
        {
            //Employee? other = (Employee?)obj; // Explicit Casting
            //                                  // UnSafe Casting --> May Throw Exception [Invalild Cast Exception]

            Employee? other = obj as Employee; // Safe Casting

            if (other is null) return false;

            return (this.Id == other?.Id) && (this.Name == other?.Name) && (this.Salary == other.Salary);

        }

        #endregion
    }
}
