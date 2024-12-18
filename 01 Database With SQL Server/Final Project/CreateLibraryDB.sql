-- Create Library Database
Create Database Library;

-- Use the Library Database
Use Library;

-- Create Table Authors
Create Table Author
(
    Id   Int Identity (1, 1) Not Null,
    Name Varchar(50)         Not Null,
    Constraint PK_Author Primary Key Clustered (Id Asc)
);

-- Create Table Book
Create Table Book
(
    Id          Int Identity (1, 1) Not Null,
    Title       Varchar(50)         Not Null,
    CatId       Int                 Not Null,
    PublisherId Int                 Not Null,
    ShelfCode   Varchar(3)          Not Null,
    Constraint PK_Book Primary Key Clustered (Id Asc)
);

-- Create Table BookAuthor
Create Table BookAuthor
(
    BookId   Int Not Null,
    AuthorId Int Not Null,
    Constraint PK_BookAuthor Primary Key Clustered (BookId Asc, AuthorId Asc)
);

-- Create Table Borrowing
Create Table Borrowing
(
    EmpId      Int         Not Null,
    BookId     Int         Not Null,
    UserSsn    Varchar(50) Not Null,
    BorrowDate Date        Not Null,
    DueDate    Date        Not Null,
    Amount     Int         Null,
    Constraint PK_Borrowing Primary Key Clustered (BookId Asc, BorrowDate Asc)
);

-- Create Table Category
Create Table Category
(
    Id      Int Identity (1, 1) Not Null,
    CatName Varchar(50)         Not Null,
    Constraint PK_Category Primary Key Clustered (Id Asc)
);

-- Create Table Employee
Create Table Employee
(
    Id      Int Identity (1, 1) Not Null,
    FName   Varchar(50)         Not Null,
    LName   Varchar(50)         Not Null,
    Phone   Varchar(50)         Null,
    Email   Varchar(50)         Null,
    Address Varchar(100)        Null,
    Dob     Date                Null,
    Salary  Int                 Null,
    Bonus   Int                 Null,
    SuperId Int                 Null,
    FloorNo Int                 Null,
    Constraint PK_Employee Primary Key Clustered (Id Asc)
);

-- Create Table Floor
Create Table Floor
(
    Number     Int  Not Null,
    NumBlocks  Int  Not Null,
    MgId       Int  Null,
    HiringDate Date Null,
    Constraint PK_Floor Primary Key Clustered (Number Asc)
);

-- Create Table Publisher
Create Table Publisher
(
    Id   Int Identity (1, 1) Not Null,
    Name Varchar(50)         Not Null,
    Constraint PK_Publisher Primary Key Clustered (Id Asc)
);

-- Create Table Shelf
Create Table Shelf
(
    Code     Varchar(3) Not Null,
    FloorNum Int        Not Null,
    Constraint PK_Shelf Primary Key Clustered (Code Asc)
);

-- Create Table Users
Create Table Users
(
    Ssn       Varchar(50) Not Null,
    UserName  Varchar(20) Not Null,
    UserEmail Varchar(50) Null,
    EmpId     Int         Not Null,
    Constraint PK_User Primary Key Clustered (Ssn Asc)
);

-- Create Table UserPhones
Create Table UserPhones
(
    UserSsn  Varchar(50) Not Null,
    PhoneNum Varchar(11) Not Null,
    Constraint PK_UserPhones Primary Key Clustered (UserSsn Asc, PhoneNum Asc)
);

-- Add Foreign Keys

-- Book Table
Alter Table Book
    Add Foreign Key (CatId) References Category (Id),
        Foreign Key (PublisherId) References Publisher (Id),
        Foreign Key (ShelfCode) References Shelf (Code);

-- BookAuthor Table
Alter Table BookAuthor
    Add Foreign Key (AuthorId) References Author (Id),
        Foreign Key (BookId) References Book (Id);

-- Borrowing Table
Alter Table Borrowing
    Add Foreign Key (BookId) References Book (Id),
        Foreign Key (EmpId) References Employee (Id),
        Foreign Key (UserSsn) References Users (Ssn);

-- Employee Table
Alter Table Employee
    Add Foreign Key (SuperId) References Employee (Id),
        Foreign Key (FloorNo) References Floor (Number);

-- Floor Table
Alter Table Floor
    Add Foreign Key (MgId) References Employee (Id);

-- Shelf Table
Alter Table Shelf
    Add Foreign Key (FloorNum) References Floor (Number);

-- Users Table
Alter Table Users
    Add Foreign Key (EmpId) References Employee (Id);

-- UserPhones Table
Alter Table UserPhones
    Add Foreign Key (UserSsn) References Users (Ssn);

-- Insert Data

-- Author Table
Insert Into Author (Name)
Values ('Author1'),
       ('Author2'),
       ('Author3');

-- Category Table
Insert Into Category (CatName)
Values ('Category1'),
       ('Category2'),
       ('Category3');

-- Publisher Table
Insert Into Publisher (Name)
Values ('Publisher1'),
       ('Publisher2'),
       ('Publisher3');

-- Shelf Table
Insert Into Shelf (Code, FloorNum)
Values ('A1', 1),
       ('A2', 1),
       ('A3', 1);

-- Floor Table
Insert Into Floor (Number, NumBlocks, MgId, HiringDate)
Values (1, 2, 1, '2020-01-01'),
       (2, 2, 2, '2020-01-01'),
       (3, 2, 3, '2020-01-01');

-- Employee Table
Insert Into Employee (FName, LName, Phone, Email, Address, Dob, Salary, Bonus, SuperId, FloorNo)
Values ('Emp1', 'Emp1', '1234567890', '', 'Address1', '1990-01-01', 1000, 100, 1, 1),
       ('Emp2', 'Emp2', '1234567890', '', 'Address2', '1990-01-01', 1000, 100, 2, 2),
       ('Emp3', 'Emp3', '1234567890', '', 'Address3', '1990-01-01', 1000, 100, 3, 3);

-- Users Table
Insert Into Users (Ssn, UserName, UserEmail, EmpId)
Values ('1234567890', 'User1', '', 1),
       ('1234567890', 'User2', '', 2),
       ('1234567890', 'User3', '', 3);

-- UserPhones Table
Insert Into UserPhones (UserSsn, PhoneNum)
Values ('1234567890', '1234567890'),
       ('1234567890', '1234567890'),
       ('1234567890', '1234567890');

-- Book Table
Insert Into Book (Title, CatId, PublisherId, ShelfCode)
Values ('Book1', 1, 1, 'A1'),
       ('Book2', 2, 2, 'A2'),
       ('Book3', 3, 3, 'A3');

-- BookAuthor Table
Insert Into BookAuthor (BookId, AuthorId)
Values (1, 1),
       (2, 2),
       (3, 3);

-- Borrowing Table
Insert Into Borrowing (EmpId, BookId, UserSsn, BorrowDate, DueDate, Amount)
Values (1, 1, '1234567890', '2020-01-01', '2020-01-01', 1),
       (2, 2, '1234567890', '2020-01-01', '2020-01-01', 1),
       (3, 3, '1234567890', '2020-01-01', '2020-01-01', 1);
