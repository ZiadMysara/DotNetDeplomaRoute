
class Assignment2
{
    static void Main(string[] args)
    {

        //DemoNotes.Run(); //Part 01 in DemoNotes.cs

        // Part2_P1.Run();
        // Part2_P2.Run();

        // Part3_P1.Run();
        // Part3_P2.Run();
        // Part3_P3.Run();
        // Part3_P4.Run();
        // Part3_P5.Run();
        // Part3_P6.Run();
        // Part3_P7.Run();
    }
}
internal static class Part2_P1
{
    private struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public static void Run()
    {
        /*
         1- Define a struct "Person" with properties "Name" and "Age". Create an array 
            of three "Person" objects and populate it with data. Then, write a C# program to 
            display the details of all the persons in the array.
        */

        Person[] persons = new Person[3]
        {
            new Person { Name = "Person 1", Age = 20 },
            new Person { Name = "Person 2", Age = 30 },
            new Person { Name = "Person 3", Age = 40 }
        };

        Array.ForEach(persons, p => Console.WriteLine($"Name: {p.Name}, Age: {p.Age}"));


    }
}

internal static class Part2_P2
{
    private struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public static void Run()
    {
        /*
         2- Create a struct called "Person" with properties "Name" and "Age". Write a C# 
            program that takes details of 3 persons as input from the user and displays the 
            name and age of the oldest person.
        */

        Person[] persons = new Person[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            persons[i] = new Person { Name = name, Age = age };
        }

        Person oldest = persons.OrderByDescending(p => p.Age).First();
        Console.WriteLine($"Oldest Person: Name: {oldest.Name}, Age: {oldest.Age}");
    }
}

// Part 03

#region employees

[Flags]
public enum SecurityPrivileges
{
    Guest = 1, Developer = 2, Secretary = 4, DBA = 8
}
public enum Gender
{ Male, Female }

public class HiringDate
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

}
public class Employee
{
    #region Properties
    public int ID { get; set; }
    public string Name { get; set; }
    public SecurityPrivileges SecurityLevel { get; set; }
    public double Salary { get; set; }
    public HiringDate HireDate { get; set; }
    public Gender Gender { get; set; }
    #endregion

    #region Constructors

    public Employee(int id, string name, SecurityPrivileges securityLevel, double salary, HiringDate hire,
        Gender gender)
    {
        ID = id;
        Name = name;
        SecurityLevel = securityLevel;
        Salary = salary;
        HireDate = hire;
        Gender = gender;
    }

    #endregion

    #region Methods
    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, SecurityLevel: {SecurityLevel}," +
               $" Salary: {String.Format("{0:C}", Salary)}, HireDate: {HireDate.Day}/{HireDate.Month}/{HireDate.Day}," +
               $" Gender: {Gender.ToString()}";
    }
    #endregion
}
#endregion

internal static class Part3_P1
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SecurityLevel { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string gender { get; set; }
    }
    public static void Run()
    {
        /*
         1. Design and implement a Class for the employees in a company:
            ⮚ Employee is identified by an ID, Name, security level, salary, hire date 
            and Gender.
        */


    }
}

internal static class Part3_P2
{
    private class HiringDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

    }
    public static void Run()
    {
        /*
         * 2. Develop a Class to represent the Hiring Date Data:
            ⮚ consisting of fields to hold the day, month and Years.
         */

    }
}

internal static class Part3_P3
{
    private enum Gender
    { Male, Female }

    public static void Run()
    {
        /*
        3. We need to restrict the Gender field to be only M or F [Male or 
        Female] 
        */

    }
}

internal static class Part3_P4
{
    private enum SecurityPrivileges
    {
        Guest, Developer, Secretary, DBA
    }
    public static void Run()
    {
        /*
        4. Assign the following security privileges to the employee (guest, 
        Developer, secretary and DBA) in a form of Enum
        */
    }
}

internal static class Part3_P5
{
    private class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public SecurityPrivileges SecurityLevel { get; set; }
        public double Salary { get; set; }
        public HiringDate HireDate { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, SecurityLevel: {SecurityLevel}," +
                   $" Salary: {String.Format("{0:C}", Salary)}, HireDate: {HireDate.Day}/{HireDate.Month}/{HireDate.Day}," +
                   $" Gender: {Gender.ToString()}";
        }
    }

    public static void Run()
    {

        /*
        5. We want to provide the Employee Class to represent Employee 
        data in a string Form (override ToString ()), display employee 
        salary in a currency format. [ use String.Format Function]
        */

    }
}

internal static class Part3_P6
{
    public static void Run()
    {
        /*
        6. Create an array of Employees with size three a DBA, Guest and 
        the third one is security officer who have full permissions. 
        (Employee [] EmpArr;)
        Notes:
        ⮚ Implement All the Necessary Member Functions on the 
        Class (Getters, Setters)
        ⮚ Define all the Necessary Constructors for the Class
        ⮚ Allow NO RUNTIME errors if the user inputs any data
        ⮚ Write down all the necessary Properties (Instead of 
        setters and getters)
        */
        Employee[] EmpArr = new[]
        {
            new Employee(1, "DBA", SecurityPrivileges.DBA, 1000, new HiringDate() { Day = 1, Month = 1, Year = 2021 },
                Gender.Male),
            new Employee(2, "Guest", SecurityPrivileges.Guest, 2000,
                new HiringDate() { Day = 2, Month = 2, Year = 2021 }, Gender.Female),
            new Employee(3, "Security Officer", SecurityPrivileges.Secretary, 3000,
                new HiringDate() { Day = 3, Month = 3, Year = 2021 }, Gender.Male)
        };



    }
}

internal static class Part3_P7
{
    public static void Run()
    {
        /*
        7. Sort the employees based on their hire date then Print the sorted 
        array.
        ⮚ While sorting (how many times Boxing and Unboxing 
        process has occurred)
        */
        Employee[] EmpArr = new[]
        {
            new Employee(1, "DBA", SecurityPrivileges.DBA, 1000, new HiringDate() { Day = 1, Month = 1, Year = 2021 },
                Gender.Male),
            new Employee(2, "Guest", SecurityPrivileges.Guest, 2000,
                new HiringDate() { Day = 2, Month = 2, Year = 2021 }, Gender.Female),
            new Employee(3, "Security Officer", SecurityPrivileges.Secretary, 3000,
                new HiringDate() { Day = 3, Month = 3, Year = 2021 }, Gender.Male)
        };

        Array.Sort(EmpArr, (e1, e2) =>
        {
            if (e1.HireDate.Year == e2.HireDate.Year)
            {
                if (e1.HireDate.Month == e2.HireDate.Month)
                {
                    return e1.HireDate.Day.CompareTo(e2.HireDate.Day);
                }

                return e1.HireDate.Month.CompareTo(e2.HireDate.Month);
            }

            return e1.HireDate.Year.CompareTo(e2.HireDate.Year);
        });

        Array.ForEach(EmpArr, e => Console.WriteLine(e));

        // Boxing and Unboxing: i don't see any boxing or unboxing in this code ??

    }
}

