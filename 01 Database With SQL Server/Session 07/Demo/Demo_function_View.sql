-- demo.sql
use Assi_ITI

--===================================================================--
--------------------------- 01 Union Family ---------------------------
--===================================================================--

-- Union Family (union | union all | intersect | except) 
-- Have 2 Conditions:
-- 1- The Same Datatype
-- 2- The Same Number Of Selected Columns


-- Union Without Repetition
SELECT St_Id, St_Fname from Student
UNION
SELECT Ins_Id, Ins_Name from Instructor

-- Union ALL With Repetition
SELECT St_Id, St_Fname from Student
UNION ALL
SELECT Ins_Id, Ins_Name from Instructor

-- Get Common Data
SELECT St_Id, St_Fname from Student
INTERSECT
SELECT Ins_Id, Ins_Name from Instructor

-- Get Data that Exists in First Result Set And Not in Second Result Set
SELECT St_Id, St_Fname from Student
EXCEPT
SELECT Ins_Id, Ins_Name from Instructor

--===================================================================--
------------- 02 select Into Table, Insert Based On Select ------------
--===================================================================--
-- DDL [Create, Alter, Drop, Select Into]

-- Create Copy of Table
SELECT * into NewEmployee2
from [MyCompany].[dbo].Employee

drop table NewEmployee

-- Create Just The Structure Without Data
SELECT * into NewEmployee
from [MyCompany].[dbo].Employee
where 1=0

-- Take Just The Data Without Table Structure, 
-- but 2 tables must have same structure (Insert Based On Select)
INSERT INTO NewEmployee 
SELECT * from [MyCompany].[dbo].Employee


--===================================================================--
---------------------- 03 User Defined Function -----------------------
--===================================================================--
/*
Types Of User Defined Functions:
---------------------------------
1. Scalar Function :
    [Return Just Only One Value]

2. Inline Table Valued Function:
    [Return Table]

3. Multi-Statement Table Valued Functions :
    [Return Table]
*/

-- Any User Defined Function must return value
-- Specify Type Of User Defined Function That U Want Based On The Type Of Ret
-- User Defined Function Consist Of
--- 1. Signature (Name, Parameters, ReturnType)
--- 2. Body
-- Body Of Function Must be Select Statement Or Insert Based On Select
-- May Take Parameters Or Not


-- 3.1 Scalar Functions (Return One Value)
-------------------------------------------
-- GetStudentNameByStudentId
GO
Create Function GetStudentNameByStudentId(@StId int)
returns varchar(20)
    Begin
        declare @StudentName varchar(20)
        Select @StudentName = St_Fname
        from Student
        where St_Id = @StId
        return @StudentName
    end
Go
-- Call Function
select dbo.GetStudentNameByStudentId(10)

-- - GetDepartmentManagerNameByDepartmentName
use MyCompany
GO
Create Function GetDepartmentManagerNameByDepartmentName(@DeptName varchar(20))
returns varchar(20)
    Begin
        declare @ManagerName varchar(20)
        Select @ManagerName = E.Fname + ' ' + E.Lname
        from Departments D, Employee E
        where D.Dname = @DeptName and D.MGRSSN = E.SSN 
        return @ManagerName
    end
Go
-- Call Function
select dbo.GetDepartmentManagerNameByDepartmentName('DP2')

-- 3.2. Inline Table Functions (Return Table)
----------------------------------------------
-- GetDepartmenInstructorsByDepartmentId
use Assi_ITI
GO
CREATE or ALTER Function GetDepartmenInstructorsByDepartmentId(@DeptId int)
returns table
    as
    return
    (
        Select Ins_Id, Ins_Name
        from Instructor I, Department D
        where D.Dept_Id = @DeptId and I.Dept_Id = D.Dept_Id
    )
Go
-- Call Function
select * from dbo.GetDepartmenInstructorsByDepartmentId(10)

-- 3.3. Multi-Statement Table Functions (Return Table)
------------------------------------------------------
-- Return Table With Logic [Declare,If, While] Inside Its Body
-- GetStudentDataBasedPassedFormat
GO
Create Function GetStudentDataBasedPassedFormat(@Format int)
Returns @StudentData Table
(
    St_Id int,
    St_name varchar(20)
)
As
Begin
    if @Format = 'First'
        insert into @StudentData
        Select St_Id, St_Fname
        from Student
    else if @Format = 'Last'
        insert into @StudentData
        select St_Id, St_Lname
        from Student  
    Else if @Format = 'FullName'
        insert into @StudentData
        Select St_Id ,CONCAT( St_Fname , ' ' , St_Lname) as St_FullName
        from Student
    return
End




--===================================================================--
------------------------------ 04 Views -------------------------------
--===================================================================--
-- 4.1 Standard View (Contains Just Only One Select Statement)
--------------------------------------------------------------
-- Get All Students
Go
Create View GetAllStudentsView
As
    Select *
    from Student
Go
-- Call View
select * from GetAllStudentsView

-- Get All Students Who live in Alex
-- with Encryption
Go
Create or Alter View GetAllStudentsInAlexView (ID, Name, Address)
with Encryption
As
    Select St_Id, St_Fname, St_Address
    from Student
    where St_Address = 'Alex'
    WITH CHECK OPTION; -- it will not allow to insert record with address not equal to Alex
Go
-- Call View
select * from GetAllStudentsInAlexView;

EXEC sp_helptext 'GetAllStudentsInAlexView'

-- Get All Students Who live in Cairo
Go
Create or Alter View GetAllStudentsInCairoView (ID, Name, Address)
As
    Select St_Id, St_Fname, St_Address
    from Student
    where St_Address = 'Cairo'
Go
-- Call View
select * from GetAllStudentsInCairoView

-- Get All Students and Department Name Who live in Cairo
Go
Create or Alter View GetAllDepartmentAndStudentsInCairoView
As
    Select St_Id, St_Fname, St_Address, D.Dept_Name
    from Student S, Department D
    where S.St_Address = 'Cairo' and S.Dept_Id = D.Dept_Id
Go
-- Call View
select * from GetAllDepartmentAndStudentsInCairoView

-- 2. Partitioned View (Contains More Than One Select Statement)
----------------------------------------------------------------
-- Students In Cairo and Alex
Go
Create or Alter View GetAllStudentsInCairoAndAlexView (ID, Name, Address)
As
    Select * from GetAllStudentsInCairoView
    Union
    Select * from GetAllStudentsInAlexView
Go
-- Call View
select * from GetAllStudentsInCairoAndAlexView

-- Hierarchy Of	Database?
---------------------------
-- Server   Level   => Database
-- Database Level   => Schemas
-- Schema   Level   => Database Objects (Table,	View, SP, and etc)
-- Table    Level   => Columns, Constraints

Create Schema Sales
Alter Schema Sales
Transfer GetAllStudentsInCairoAndAlexView


-- View + DMI
----------------
-- View => One Table
----------------------
-- Insert
Go
INSERT INTO GetAllStudentsInCairoView
Values (101, 'Mohammed', 'Cairo')
Go
-- Call View
SELECT * from GetAllStudentsInCairoView

-- Update
Update GetAllStudentsInCairoView
Set Name = 'Ali'
Where ID = 101
-- Call View
SELECT * from GetAllStudentsInCairoView

-- Delete
Delete from GetAllStudentsInCairoView
Where ID = 101
-- Call View
SELECT * from GetAllStudentsInCairoView

-- View => Multi Table
------------------------
select * from GetAllDepartmentAndStudentsInCairoView
-- Insert
Go
INSERT INTO GetAllDepartmentAndStudentsInCairoView
Values (101, 'Mohammed', 'Cairo', 'DP1')
Go -- Error, As View Contains More Than One Table

GO
INSERT INTO GetAllDepartmentAndStudentsInCairoView(St_Id, St_Fname)
Values (101, 'Mohammed')
Go -- Accept, As We identified Just Only One Table

-- Update
Update GetAllDepartmentAndStudentsInCairoView
Set St_Fname = 'Ali'
Where St_Id = 101 -- it will not affect as we insert this record with View

Update GetAllDepartmentAndStudentsInCairoView
Set St_Fname = 'Ali'
Where St_Id = 6 -- it will affect as we insert this record with Table
-- Call View
SELECT * from GetAllDepartmentAndStudentsInCairoView

-- Delete
Delete from GetAllDepartmentAndStudentsInCairoView
Where St_Id = 6 -- invalid, you can't delete from view contains more than one table



USE Assi_ITI



