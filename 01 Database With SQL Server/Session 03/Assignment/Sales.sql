CREATE DATABASE Sales
use Sales


Create Table Sales_Office
(
    Number int Primary Key identity(1,1),
    Location varchar(15),
    Emp_ID int,
)

Create Table Employee
(
    ID int Primary Key identity(1,1),
    Name varchar(15),
    Off_Number int,
)

Create Table Property
(
    ID int Primary Key identity(1,1),
    Address varchar(15),
    City varchar(15),
    State varchar(15),
    Code varchar(15),
    Off_Number int,
)

Create Table Owner
(
    ID int Primary Key identity(1,1),
    Name varchar(15),
)

Create Table Prop_Owner
(
    Prop_ID int,
    Owner_ID int,
    Precent int,
    primary key(Prop_ID, Owner_ID),
)

-- lets put foreign keys
Alter Table Sales_Office
Add FOREIGN KEY (Emp_ID) References Employee(ID)

Alter Table Employee
Add FOREIGN KEY (Off_Number) References Sales_Office(Number)

Alter Table Property
Add FOREIGN KEY (Off_Number) References Sales_Office(Number)

Alter Table Prop_Owner
Add FOREIGN KEY (Prop_ID) References Property(ID)

Alter Table Prop_Owner
Add FOREIGN KEY (Owner_ID) References Owner(ID)

--=========================================================