CREATE DATABASE Airline
use Airline

Create Table Aircraft
(
    ID int Primary Key identity(1,1),
    capacity int,
    Model varchar(15),
    Maj_pilot int,
    Assistant int,
    Host1 int,
    Host2 int,
    AL_ID int,
)

Create Table Airline
(
    ID int Primary Key identity(1,1),
    Name varchar(15),
    Address varchar(100),
    Cont_person varchar(15),
)

Create Table Airline_Phones
(
    AL_ID int,
    Phones varchar(15),
    primary key(AL_ID, Phones),
)

Create Table Transactions
(
    ID int Primary Key identity(1,1),
    Description varchar(15),
    Amout money,
    Date date,
    AL_ID int,
)

CREATE TABLE Employee
(
    ID int Primary Key identity(1,1),
    Name varchar(15),
    Address varchar(100),
    gender varchar(15),
    Position varchar(15),
    BD_Year int,
    BD_Month int,
    BD_Day int,
    AL_ID int,
)

Create Table Emp_QuaIifications
(
    Emp_ID int,
    Qualifications varchar(15),
    primary key(Emp_ID, Qualifications),
)

Create Table Route
(
    ID int Primary Key identity(1,1),
    Distance int,
    Destination varchar(15),
    Origin varchar(15),
    Classification varchar(15),
)

Create Table Aircraft_Routes
(
    AC_ID int,
    Route_ID int,
    Departure date,
    Num_Of_Pass int,
    Price money,
    Arrival date,
    primary key(AC_ID, Route_ID, Departure),
)

-- lets put foreign keys

Alter Table Aircraft
Add FOREIGN KEY (AL_ID) References Airline(ID)

Alter Table Airline_Phones
Add FOREIGN KEY (AL_ID) References Airline(ID)

Alter Table Transactions
Add FOREIGN KEY (AL_ID) References Airline(ID)

Alter Table Employee
Add FOREIGN KEY (AL_ID) References Airline(ID)

Alter Table Emp_QuaIifications
Add FOREIGN KEY (Emp_ID) References Employee(ID)

Alter Table Aircraft_Routes
Add FOREIGN KEY (AC_ID) References Aircraft(ID)

Alter Table Aircraft_Routes
Add FOREIGN KEY (Route_ID) References Route(ID)

--=========================================================