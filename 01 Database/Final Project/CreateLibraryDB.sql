-- I Will create Library DataBase it is copy from Library Database
-- i will not create any stored procedure or function or trigger
-- i will add all foreign key at the end of the script
Create DATABASE Library

-- create tables same as Library Database
use Library

-- create table Authors
CREATE TABLE [dbo].[Author] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- create table Book
CREATE TABLE [dbo].[Book] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Title]        VARCHAR (50) NOT NULL,
    [Cat_id]       INT          NOT NULL,
    [Publisher_id] INT          NOT NULL,
    [Shelf_code]   VARCHAR (3)  NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC),
);

-- create table Book_Author
CREATE TABLE [dbo].[Book_Author] (
    [Book_id]   INT NOT NULL,
    [Author_id] INT NOT NULL,
    CONSTRAINT [PK_Book_Author] PRIMARY KEY CLUSTERED ([Book_id] ASC, [Author_id] ASC),
);

-- create table Borrowing
CREATE TABLE [dbo].[Borrowing] (
    [Emp_id]      INT          NOT NULL,
    [Book_id]     INT          NOT NULL,
    [User_ssn]    VARCHAR (50) NOT NULL,
    [Borrow_date] DATE         NOT NULL,
    [Due_date]    DATE         NOT NULL,
    [Amount]      INT          NULL,
    CONSTRAINT [PK_Borrowing] PRIMARY KEY CLUSTERED ([Book_id] ASC, [Borrow_date] ASC),
);

-- create table Category
CREATE TABLE [dbo].[Category] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Cat_name] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- create table Employee
CREATE TABLE [dbo].[Employee] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Fname]    VARCHAR (50)  NOT NULL,
    [Lname]    VARCHAR (50)  NOT NULL,
    [phone]    VARCHAR (50)  NULL,
    [Email]    VARCHAR (50)  NULL,
    [Address]  VARCHAR (100) NULL,
    [DOB]      DATE          NULL,
    [Salary]   INT           NULL,
    [Bouns]    INT           NULL,
    [Super_id] INT           NULL,
    [Floor_no] INT           NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
);

-- create table Floor
CREATE TABLE [dbo].[Floor] (
    [Number]      INT  NOT NULL,
    [Num_blocks]  INT  NOT NULL,
    [MG_ID]       INT  NULL,
    [Hiring_Date] DATE NULL,
    CONSTRAINT [PK_Floor] PRIMARY KEY CLUSTERED ([Number] ASC),
);

-- create table Publisher
CREATE TABLE [dbo].[Publisher] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- create table Shelf
CREATE TABLE [dbo].[Shelf] (
    [Code]      VARCHAR (3) NOT NULL,
    [Floor_num] INT         NOT NULL,
    CONSTRAINT [PK_Shelf] PRIMARY KEY CLUSTERED ([Code] ASC),
);

-- create table Users
CREATE TABLE [dbo].[Users] (
    [SSN]        VARCHAR (50) NOT NULL,
    [User_Name]  VARCHAR (20) NOT NULL,
    [User_Email] VARCHAR (50) NULL,
    [Emp_id]     INT          NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([SSN] ASC),
);

-- create table User_Phones
CREATE TABLE [dbo].[User_phones] (
    [User_ssn]  VARCHAR (50) NOT NULL,
    [Phone_num] VARCHAR (11) NOT NULL,
    CONSTRAINT [PK_User_phones] PRIMARY KEY CLUSTERED ([User_ssn] ASC, [Phone_num] ASC),
);

-- Now i will add all foreign key

-- Book table
ALTER TABLE [dbo].[Book]
ADD FOREIGN KEY ([Cat_id]) REFERENCES [dbo].[Category] ([Id]),
    FOREIGN KEY ([Publisher_id]) REFERENCES [dbo].[Publisher] ([Id]),
    FOREIGN KEY ([Shelf_code]) REFERENCES [dbo].[Shelf] ([Code])

-- Book_Author table
ALTER TABLE [dbo].[Book_Author]
ADD FOREIGN KEY ([Author_id]) REFERENCES [dbo].[Author] ([Id]),
    FOREIGN KEY ([Book_id]) REFERENCES [dbo].[Book] ([Id])

-- Borrowing table
ALTER TABLE [dbo].[Borrowing]
ADD FOREIGN KEY ([Book_id]) REFERENCES [dbo].[Book] ([Id]),
    FOREIGN KEY ([Emp_id]) REFERENCES [dbo].[Employee] ([Id]),
    FOREIGN KEY ([User_ssn]) REFERENCES [dbo].[Users] ([SSN])

-- Employee table
ALTER TABLE [dbo].[Employee]
ADD FOREIGN KEY ([Super_id]) REFERENCES [dbo].[Employee] ([Id]),
    FOREIGN KEY ([Floor_no]) REFERENCES [dbo].[Floor] ([Number])

-- Floor table
ALTER TABLE [dbo].[Floor]
ADD FOREIGN KEY ([MG_ID]) REFERENCES [dbo].[Employee] ([Id])

-- Shelf table
ALTER TABLE [dbo].[Shelf]
ADD FOREIGN KEY ([Floor_num]) REFERENCES [dbo].[Floor] ([Number])

-- Users table
ALTER TABLE [dbo].[Users]
ADD FOREIGN KEY ([Emp_id]) REFERENCES [dbo].[Employee] ([Id])

-- User_phones table
ALTER TABLE [dbo].[User_phones]
ADD FOREIGN KEY ([User_ssn]) REFERENCES [dbo].[Users] ([SSN])

-- Now i will add some data to the tables
-- i will add data to the tables same as Library Database

-- Author table
INSERT INTO [dbo].[Author] ([Name]) VALUES ('Author1')
INSERT INTO [dbo].[Author] ([Name]) VALUES ('Author2')
INSERT INTO [dbo].[Author] ([Name]) VALUES ('Author3')

-- Category table
INSERT INTO [dbo].[Category] ([Cat_name]) VALUES ('Category1')
INSERT INTO [dbo].[Category] ([Cat_name]) VALUES ('Category2')
INSERT INTO [dbo].[Category] ([Cat_name]) VALUES ('Category3')

-- Publisher table
INSERT INTO [dbo].[Publisher] ([Name]) VALUES ('Publisher1')
INSERT INTO [dbo].[Publisher] ([Name]) VALUES ('Publisher2')
INSERT INTO [dbo].[Publisher] ([Name]) VALUES ('Publisher3')

-- Shelf table
INSERT INTO [dbo].[Shelf] ([Code], [Floor_num]) VALUES ('A1', 1)
INSERT INTO [dbo].[Shelf] ([Code], [Floor_num]) VALUES ('A2', 1)
INSERT INTO [dbo].[Shelf] ([Code], [Floor_num]) VALUES ('A3', 1)

-- Floor table
INSERT INTO [dbo].[Floor] ([Number], [Num_blocks], [MG_ID], [Hiring_Date]) VALUES (1, 2, 1, '2020-01-01')
INSERT INTO [dbo].[Floor] ([Number], [Num_blocks], [MG_ID], [Hiring_Date]) VALUES (2, 2, 2, '2020-01-01')
INSERT INTO [dbo].[Floor] ([Number], [Num_blocks], [MG_ID], [Hiring_Date]) VALUES (3, 2, 3, '2020-01-01')

-- Employee table
INSERT INTO [dbo].[Employee] ([Fname], [Lname], [phone], [Email], [Address], [DOB], [Salary], [Bouns], [Super_id], 
[Floor_no]) 
VALUES ('Emp1', 'Emp1', '1234567890', '', 'Address1', '1990-01-01', 1000, 100, 1, 1) 

INSERT INTO [dbo].[Employee] ([Fname], [Lname], [phone], [Email], [Address], [DOB], [Salary], [Bouns], [Super_id], 
[Floor_no]) 
VALUES ('Emp2', 'Emp2', '1234567890', '', 'Address2', '1990-01-01', 1000, 100, 2, 2) 

INSERT INTO [dbo].[Employee] ([Fname], [Lname], [phone], [Email], [Address], [DOB], [Salary], [Bouns], [Super_id],
[Floor_no])
VALUES ('Emp3', 'Emp3', '1234567890', '', 'Address3', '1990-01-01', 1000, 100, 3, 3)

-- Users table
INSERT INTO [dbo].[Users] ([SSN], [User_Name], [User_Email], [Emp_id]) VALUES ('1234567890', 'User1', '', 1) 
INSERT INTO [dbo].[Users] ([SSN], [User_Name], [User_Email], [Emp_id]) VALUES ('1234567890', 'User2', '', 2) 
INSERT INTO [dbo].[Users] ([SSN], [User_Name], [User_Email], [Emp_id]) VALUES ('1234567890', 'User3', '', 3)

-- User_phones table
INSERT INTO [dbo].[User_phones] ([User_ssn], [Phone_num]) VALUES ('1234567890', '1234567890')
INSERT INTO [dbo].[User_phones] ([User_ssn], [Phone_num]) VALUES ('1234567890', '1234567890')
INSERT INTO [dbo].[User_phones] ([User_ssn], [Phone_num]) VALUES ('1234567890', '1234567890')

-- Book table
INSERT INTO [dbo].[Book] ([Title], [Cat_id], [Publisher_id], [Shelf_code]) VALUES ('Book1', 1, 1, 'A1')
INSERT INTO [dbo].[Book] ([Title], [Cat_id], [Publisher_id], [Shelf_code]) VALUES ('Book2', 2, 2, 'A2')
INSERT INTO [dbo].[Book] ([Title], [Cat_id], [Publisher_id], [Shelf_code]) VALUES ('Book3', 3, 3, 'A3')

-- Book_Author table
INSERT INTO [dbo].[Book_Author] ([Book_id], [Author_id]) VALUES (1, 1)
INSERT INTO [dbo].[Book_Author] ([Book_id], [Author_id]) VALUES (2, 2)
INSERT INTO [dbo].[Book_Author] ([Book_id], [Author_id]) VALUES (3, 3)

-- Borrowing table
INSERT INTO [dbo].[Borrowing] ([Emp_id], [Book_id], [User_ssn], [Borrow_date], [Due_date], [Amount]) VALUES (1, 1, '1234567890', '2020-01-01', '2020-01-01', 1)
INSERT INTO [dbo].[Borrowing] ([Emp_id], [Book_id], [User_ssn], [Borrow_date], [Due_date], [Amount]) VALUES (2, 2, '1234567890', '2020-01-01', '2020-01-01', 1)
INSERT INTO [dbo].[Borrowing] ([Emp_id], [Book_id], [User_ssn], [Borrow_date], [Due_date], [Amount]) VALUES (3, 3, '1234567890', '2020-01-01', '2020-01-01', 1)







