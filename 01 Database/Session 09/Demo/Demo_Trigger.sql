--==============================================================--
-------------------------- 1. Triggers ---------------------------
--==============================================================--
use Assi_ITI
GO
-- Types of SP :
----------------
-- 1. User defined
SP_GetStudentByAddress 'dsddds'; SP_Getdata; SP_SumData 10, 20;

-- 2. Built-In SP
Sp_helptext 'object_name'; Sp_Rename 'object name', 'new name';

Sp_Rename 'StudentITI' , 'Student';

Sp_Rename 'Student.Id' , 'St_id';

-- 3.Trigger (Special Stored Procedure)
-- Can't Call
-- Can't take parameters
-- trigger is in the same schema of the table that it is created on
insert into Instructor(Ins_Id, Ins_Name)
values(16, 'Ahmed')
-- Types of Triggers (Through Its Level)
-- 1. Server Level
-- 2. DB Level
-- 3. Table Level (Our Interest)
-- Actions In Table? (Insert, Update, Delete) [Events]
-- (Select Truncate) Not Logged In Log File

Select *
from Student
-------------------------------------------
-- Examples of Triggers:
------------------------
-- Ex01:
/*
   Create Welcome Trigger on Table Student That Fire After Insert into Table
   That Display Welcome Message
*/
Create Trigger Tri_Welcome
on Student
After Insert
as
Begin -- not necessary
   Print 'Welcome To Route'
End -- not necessary

-- try to insert
Insert into Student(St_Id, St_FName,St_Lname)
values(1010, 'Ahmed', 'Ali')

-- if i change the table to another schema
create schema HR
alter schema HR transfer Student
-- Alter Trigger must choose the schema
GO
Create or ALter Trigger HR.Tri_Welcome
on HR.Student
AFTER Insert
as
    Select 'Welcome To Route'
GO
alter schema dbo transfer HR.Student

-- Ex02:
-- Create Trigger After Update on Table Student Get Date And User

go
Create Trigger Tri_UpdateStudent
on Student
After Update
as
    Select GetDate() [Date], Suser_Name() [User]
go
-- Update
Update Student
Set St_FName = 'Mohamed'
Where St_Id = 1010

-- Ex03:
-- Prevent Delete of Records In Student Table
go
Create Trigger Tri_PreventDeleteStudent
on Student
instead of Delete
as
    Print 'You Can not Delete From this Table'
go
-- Delete
Delete from Student
Where St_Id = 1010

-- Ex04:
-- Prevent Delete, Update, Insert of Department Table
go
Create or alter Trigger Tri_LockDepartmentTable
on Department
Instead of Insert, Update, Delete
as
    Select SUSER_NAME() + 'Can not Do Any Operation on this Table'
go
-- test
-- Insert
Insert into Department(Dept_Id, Dept_Name)
values(3, 'IT')

-- Update
Update Department
set Dept_Name = 'ITI'
Where Dept_Id = 3

-- Note:
go
create TRIGGER Tri_Lockinsert
on Department
Instead of Insert
as
    print 'You Can not Insert'
go
-- Can't Create Trigger as There is Another Trigger with the Same Event

-- Drop | Disable | Enable Trigger
-----------------------------------
-- Drop Trigger
Drop Trigger Tri_LockDepartmentTable
-- Disable Trigger
ALTER TABLE Department
Disable Trigger Tri_LockDepartmentTable
-- Enable Trigger
ALTER TABLE Department
Enable Trigger Tri_LockDepartmentTable

-- Notes:
---------
-- When You Write Trigger, You Must Write Its Schema (Except Default [dbo])
-- Trigger Take By Default The Schema Of Its Table In Creation
-- When You Change The Schema Of Table, All Its Triggers Will Follow

-- The Most Important Point Of Trigger:
----------------------------------------
-- 2 Tables: Inserted & Deleted Will Be Created With Each Fire Of Trigger
-- In Case Of Delete:   Deleted Table Will Contain Deleted Values
-- In Case Of Insert:	Inserted Table Will Contain Inserted Values
-- In Case Of Update:	Deleted Table Will Contain Old Values
--                      Inserted Table Will Contain New Values

-- Error (Have No Meaning Without Trigger): Just Created at Run Time
select * from Inserted
select * from Deleted

-- Ex05 :
---------
-- with Trigger
go
Create OR ALTER Trigger tri05
on Course
After Update, Insert
as
    SeLect * from inserted
    SeLect * from deleted
go
-- Update
Update dbo.Course
Set Crs_Name = 'C Progamming'
Where Crs_Id = 200


insert into Course(Crs_Id, Crs_Name)
values(1400,'Scala')
-- Ex06:
---------
go
Create or alter Trigger Tri06
on Course
Instead of Delete
as
    Select 'You Can Not Delete Course '	+(SELECT Crs_Name from deleted) + ' from this Table'
go
-- Delete
Delete from Course
Where Crs_Id = 100

-- Ex07:
---------
Create Table UpdatedTopics(
Top_id int Primary key,
Top_Name varchar(20))

create or alter Trigger Tri_UpdatedTopics
on Topic
After Update
as
    Insert into UpdatedTopics
    Select Top_id, Top_Name
    from deleted
go
-- Update
Update Topic
Set Top_Name = 'Programming'
Where Top_id = 1

-- Ex08:
---------
go
Create or alter Trigger Tri_PreventDeleteStudent
on Student
instead of Delete
as
    if format(GETDATE(), 'dddd') = 'wednesday'
    Delete from Student
    where St_Id in (Select St_Id from deleted)
go
-- Delete
Delete from Student
Where St_Id = 9832





