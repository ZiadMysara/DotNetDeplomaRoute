CREATE DATABASE ITI 
use ITI
Create Table Students
(
ID int Primary Key identity(1,1),
FName varchar(15) ,
LName varchar(15),
Age tinyint,
Address varchar(100),
Dep_ID int,
)

Create Table Departments
(
ID int Primary Key identity(1,1),
Name varchar(15),
Hiring_Date date,
Ins_id int,
)

create Table Instructors
(
Id int Primary key identity(1,1),
Name varchar(15),
Address varchar(100),
Bouns money,
Salary money,
Hour_Rate money,
Dep_Id int,
)

CREATE TABLE Courses
(
ID int Primary Key identity(1,1),
Name varchar(15),
Duration TIME,
description VARCHAR(150),
top_id int,
)

CREATE TABLE Topics
(
ID int Primary Key identity(1,1),
Name varchar(15),
)

CREATE TABLE Student_Course
(
Stu_ID int,
Course_ID int,
Grade int,

primary key(Stu_ID, Course_ID),
)

CREATE TABLE Course_Instructor
(
Course_ID int,
Ins_ID int,
Evaluation int,
primary key(Course_ID, Ins_ID),
)

-- lets put foreign keys
Alter Table Students
Add FOREIGN KEY (Dep_ID) References Departments(ID)

Alter Table Departments
Add FOREIGN KEY (Ins_id) References Instructors(Id)

Alter Table Instructors
Add FOREIGN KEY (Dep_Id) References Departments(ID)

Alter Table Courses
Add FOREIGN KEY (top_id) References Topics(ID)

Alter Table Student_Course
Add FOREIGN KEY (Stu_ID) References Students(ID)

Alter Table Student_Course
Add FOREIGN KEY (Course_ID) References Courses(ID)

Alter Table Course_Instructor
Add FOREIGN KEY (Course_ID) References Courses(ID)

Alter Table Course_Instructor
Add FOREIGN KEY (Ins_ID) References Instructors(Id)

--=========================================================