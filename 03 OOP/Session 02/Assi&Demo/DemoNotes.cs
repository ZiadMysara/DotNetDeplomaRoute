
internal static class DemoNotes
{
    public static void Run()
    {

        #region Encapsulation Ex 1
        Employee employee = new Employee(1, "John Doe", 1000);

        Console.WriteLine(employee); // more readable
        Console.WriteLine(employee.ToString()); // more faster as no boxing and unboxing

        employee.SetId(2);
        employee.SetName("Jane Doe");
        employee.SetSalary(2000);

        Console.WriteLine(employee.GetId());
        Console.WriteLine(employee.GetName());
        Console.WriteLine(employee.GetSalary());

        Console.WriteLine(employee);
        #endregion

        #region Encapsulation Ex 2 [indexer]
        PhoneBook phoneBook = new PhoneBook(100);
        phoneBook.AddPerson(0, "John Doe", 123456789);
        phoneBook.AddPerson(1, "Jane Doe", 987654321);
        phoneBook.AddPerson(2, "John Smith", 123456789);

        int number = phoneBook.GetNumber("Jane Doe");
        Console.WriteLine(number);

        phoneBook.SetNumber("Jane Doe", 123456569);
        number = phoneBook.GetNumber("Jane Doe");
        Console.WriteLine(number);

        // indexer
        Console.WriteLine(phoneBook["Jane Doe"]);
        phoneBook["Jane Doe"] = 123;
        Console.WriteLine(phoneBook["Jane Doe"]);

        Console.WriteLine(phoneBook[1]);

        #endregion

        #region Class
        // Class : reference type
        // Class : can be inherited
        // Class : can be abstract
        // Class : can be sealed // no one can inherit from it
        // Class : can be static

        // What You Can Write Inside The Class
        // 1.Attributes[Fields] => Member Variable
        // 2.Functions Constructor, Getter Setter, Method]
        // 3.Properties[Full Property, Automatic Property, Indexer]
        // 4.Events



        Car car = new Car(1);
        System.Console.WriteLine(car.Model);
        #endregion

        #region Notes
        // null Reference Exception : when you try to access reference that refers to null

        // Encapsulation : hide the data from the user and provide the access to it through the methods

        // Properties : are used to access the attributes of a class or struct

        // Properties : some thing we use to sprate the data definition from the data access
        // why we use properties : 1- if we rename the attribute we don't need to change the code that access it  (coupling)
        //                         2- we can add constrains and validations
        //                         3- we can add some logic to the getter and setter or remove setter or getter (Lock the attribute)

        // Properties : 1- Full Property 2- Auto-Implemented Property 3- Derived Property 4- Indexer

        // First Char of the Property Name should be Capital

        // Indexer : special type of property that allows you to access elements in a class or struct as if they were in an array

        //        Stack             vs            Heap
        // fixed size, faster                dynamic size, slower
        // value type                         reference type
        // memory is managed automatically    memory is managed manually
        // memory is released automatically   memory is released manually
        // no null value                      can have null value   //! ????????? 
        // life time is limited               life time is unlimited

        // struct always have a default constructor
        // class if you define a constructor, the default constructor will not be created

        // new in struct vs new in class
        // new in struct : chose the constructor to call
        // new in class : alocating memory in heap, chose the constructor to call, calling the constructor, make the reference point to the object in the heap

        /*
        -------------------------------------------------------------------------------
	    |        	   Class                |                 Struct                  |
        |-----------------------------------|-----------------------------------------|    
        |    Reference Type		            |       Value Type                        |
        |-----------------------------------|-----------------------------------------|
        |    Support 4 Pillars Of OOP		|       Support Encapsulation and         |
        |                                   |       Overloading in Polymorphism       |
        |-----------------------------------|-----------------------------------------|
        |    More Flexible                  |       Less Flexible                     |
        |-----------------------------------|-----------------------------------------|                            
        |    Does Support Inheritance		|       Doesn't Support Inheritance       |
        |-----------------------------------|-----------------------------------------|                    
        |    6 Access Modifier Allowed		|       3 Access Modifier Allowed         |
        |    Inside It		                |       Inside It                         |
        |-----------------------------------|-----------------------------------------|                        
        |    If You Defined a user defined	|       If You Defined a user defined     |
        |    Constructor , Compiler Will    |       Constructor, Compiler Will        |
        |    nolonger Generate Empty        |       always Generate                   |
        |    Parameterless Constructor      |       Parameterless Constructor         |                 
        -------------------------------------------------------------------------------
        */

        // Value Type : int, float, double, char, bool, struct
        // Reference Type : class, interface, delegate, array, string

        // :C => 1.000.000 $ //it used to format the number as currency

        // Constractor Chaining : calling one constructor from another constructor 
        // ex: public Car(int id, string model) : this(id, model, 20) // this will call the first constructor then this constructor


        #endregion
        Console.ReadLine();
    }
}

file struct Employee
{
    #region attributes
    private int id;
    private string? name;
    private decimal salary;
    #endregion

    #region Properties

    #region Full Property
    // Full Property
    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string? Name
    {
        get => name;
        set => name = value?.Length > 5 ? value.Substring(0, 5) : value;
    }
    public decimal Salary
    {
        get => salary;
        set
        {
            salary = value > 5000 ? 5000 : value;
        }
    }

    #endregion

    #region Auto-Implemented Property
    // Auto-Implemented Property
    public int Age { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }

    // derived properties
    public decimal Deduction
    {
        get { return Salary * 0.2m; }
    }
    #endregion
    #endregion

    #region Constructors
    public Employee(int id, string name, decimal salary)
    {
        // i put Properties in constructor not attributes to make constrains and validations
        // if i put them in attributes there will not be constrains or validations
        Id = id;
        Name = name;
        Salary = salary;
    }
    #endregion

    #region Getters and Setters
    public int GetId()
    {
        return id;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public string? GetName()
    {
        return name;
    }

    public void SetName(string? name)
    {
        this.name = name?.Length > 5 ? name.Substring(0, 5) : name;
    }

    public decimal GetSalary()
    {
        return salary;
    }

    public void SetSalary(decimal salary)
    {
        this.salary = salary;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        return $"Id: {id}\nName: {name}\nSalary: {salary}";
    }
    #endregion
}

file struct PhoneBook
{

    #region Attributes
    string[] Names;
    int[] Numbers;
    int Size;
    #endregion

    #region Constructors
    public PhoneBook(int Size)
    {
        Names = new string[Size];
        Numbers = new int[Size];
        this.Size = Size;
    }
    #endregion
    public void AddPerson(int Position, string Name, int Number)
    {
        if (Names is not null && Numbers is not null && Position < Size) // Protective code
        {
            Names[Position] = Name;
            Numbers[Position] = Number;
        }
    }

    public int GetIndexByName(string Name)
    {
        for (int i = 0; i < Names.Length; i++)
        {
            if (Names[i] == Name)
            {
                return i;
            }
        }
        return -1;
    }

    public int GetNumber(string Name)
    {
        int i = GetIndexByName(Name);

        return i != -1 ? Numbers[i] : -1;
    }

    public void SetNumber(string Name, int Number)
    {
        int i = GetIndexByName(Name);
        if (i != -1)
            Numbers[i] = Number;
        else
            Console.WriteLine("Name not found");
    }

    #region Indexers
    public int this[string index]
    {
        get
        {
            int i = GetIndexByName(index);
            return i != -1 ? Numbers[i] : -1;
        }
        set
        {
            int i = GetIndexByName(index);
            if (i != -1)
                Numbers[i] = value;
            else
                Console.WriteLine("Name not found");
        }
    }

    #region test


    public int MyProperty // here no attribute acutally created  //we can use it as drived property
    {
        get { return 10; }
        set { }
    }
    public int Sprop { get; set; } // here there attribute created with the same name of the property "sprop"
    #endregion

    // Indexer Overloading

    public string this[int index]
    {
        get { return $"{index} :: {Names[index]} :: {Numbers[index]}"; }
    }
    #endregion
}

file class Car
{

    #region Properties
    public int Id { get; set; }
    public string Model { get; set; }
    public int Speed { get; set; }

    #endregion

    #region Constructors
    // Constructor Chaining
    public Car(int Id, string Model, int Speed) // now default constructor will not be created
    {
        this.Id = Id;
        this.Model = Model;
        this.Speed = Speed;
        System.Console.WriteLine("CTOR01");
    }

    public Car(int id, string model) : this(id, model, 20) // this will call the first constructor then this constructor
    {
        System.Console.WriteLine("CTOR02");
    }

    public Car(int id) : this(id, "BMW") // this will call the second constructor then this constructor
    {
        System.Console.WriteLine("CTOR03");
    }

    public Car() // this will be created if i didn't create any constructor in class
    {
        Id = 0;
        Model = null;
        Speed = 0;
    }

    #endregion

}