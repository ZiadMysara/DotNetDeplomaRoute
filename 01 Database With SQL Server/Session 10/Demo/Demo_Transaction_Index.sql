--=================================================================--
--------------------------- 02 Transaction --------------------------
--=================================================================--
use Assi_ITI
-- 2.1 Implicit Transaction (DML Query [Insert, Update, Delete])
----------------------------------------------------------------
insert into Student(St_Id, St_Fname) -- Implicit Transaction
Values(	3030, 'Aya'), (2020, 'Ahmed')

Update Student -- Implicit Transaction
set St_Age = 30
where St_Age = 20
-- 2.2 Explicit Transaction (Set Of Implicit Transactions)
----------------------------------------------------------
Create Table Parent(
    Id int Primary Key
)
Create Table Child(
    Id int Primary Key,
    Parent_Id int References Parent (Id) on Delete Cascade
)

insert into Parent
Values (1), (2), (3)
insert into Child
values (1,2), (2,1), (3,3)

-- transaction structure
/*
Begin Transaction
-- Set of Implicit Transactions
Commit Tran || Rollback Tran
*/

-- 2.2.1 Commit Transaction
Begin Transaction
insert into Child values (7,2) -- this will success
insert into Child values (8,10) -- this will fail only
insert into Child values (9,3) -- this will success
Commit Tran
-- if some of the queries failed, the successful queries will be done and the failed queries will be failed

-- 2.2.2 Rollback Transaction
Begin Transaction
insert into Child values (7,2)
insert into Child values (8,10)
insert into Child values (9,3)
Rollback Tran
-- the transaction will be rolled back no matter what happened (all queries will be failed)

-- 2.2.3 Try Catch Block
Begin Try
    Begin Transaction
        insert into Child	values (10,2)
        insert into Child	values (11,10)	-- Error
        insert into Child	values (12,3)
    Commit Tran
End Try
Begin Catch
    Rollback Tran
End Catch
-- if any of the queries failed, the transaction will be rolled back (all queries will be failed)
-- else the transaction will be committed (all queries will be done)

-- 2.2.4 Save Point
-- Ex1:
Begin Try
    Begin Transaction
        insert into Child	values (10,2)
        insert into Child	values (11,10)	-- Error
        save Tran SavePoint1
        insert into Child	values (12,3)
    Commit Tran
End Try
Begin Catch
    Rollback Tran SavePoint1
End Catch
-- if any of the queries failed, the transaction will be rolled back
-- to the save point 1 (all queries after save point 1 will be failed)

-- Ex2:
Begin Transaction
insert into Child values (13,2)
Save Tran SavePoint1
insert into Child values (14,10)
insert into Child values (15,3)
Save Tran SavePoint2
insert into Child values (16,2)
insert into Child values (17,10)
insert into Child values (18,3)
-- no save point
Rollback Tran SavePoint1
-- the transaction will be rolled back to the save point 1 (all queries after save point 1 will be failed)

--=================================================================--
------------------------------ 03 Index -----------------------------
--=================================================================--
-- 3.1 Clustered Index
-------------------------
Create CLUSTERED INDEX IX_Student_St_Name
on Student(St_Fname)

-- 3.2 Non-Clustered Index
-------------------------
Create NONCLUSTERED INDEX IX_Student_St_Name
on Student(St_Fname)

-- Primary Key	 -- Constraint	--- > Clustered Index
-- Unique Key	 -- Constraint	--- > NonClustered Index
-- Unique Accept Null only one time

Create Unique Index IX_Age -- == Create Unique nonClustered IX_Age
on Student(ST_Age)
-- Will Make 2 Things If There is No Repeated Values
-- 1. Make Unique Constrains On St_Age
-- 2. Make Non-Clustered Index On St_Age


--=================================================================--
-------------------------- 04 Indexed View --------------------------
--=================================================================--

-- Indexed View : Put Index On The View
----------------------------------------
GO
Create OR ALTER View StudentDepartmentView
with Encryption, schemabinding -- SCHEMABINDING : Can't Change The Table Structure
         as
         Select s.St_Id,S.St_Fname,D.Dept_Name
         from dbo.Student S, dbo.Department D
         where S. Dept_Id = D. Dept_Id
GO
select * from StudentDepartmentView
/*
    SchemaBinding : Can't Change The Table Structure
    if table structure changed, the view will be dropped
*/
--Indexed View Put Index On The View
Create Unique Clustered Index IX_StudentDepartmentView_St_Id -- == Create Clustered IX_StudentDepartmentView_St_Id
on StudentDepartmentView(St_Id)

--=================================================================--
------------------------------ 04 DCL -------------------------------
--=================================================================--
-- DCL (Data Control Language)
--
-- [Login]      Server (Ziad)
-- [User]       DB Route (Ziad)
-- [Schema]     Sales [Department, Instructor]
-- Permissions  Grant [select, insert]Deny [delete Update]

-- 4.1 Login
create login Ziad3 with password = '123'

-- 4.2 User
create user Ziad3


-- 4.3 Schema
create schema Sales3
create table Sales3.Department3(
    Dept_Id int Primary Key,
    Dept_Name nvarchar(50)
)
create table Sales3.Instructor3(
    Ins_Id int Primary Key,
    Ins_Name nvarchar(50)
)

-- 4.4 Permissions
grant select, insert on Sales3.Department3 to Ziad3
deny delete, update on Sales3.Department3 to Ziad3
--=================================================================--
----------------------- additional information ----------------------
--=================================================================--
use agma 
-- IF EXISTS
--example:

IF EXISTS (SELECT 1 FROM Companys WHERE Comp_id = 0)
BEGIN
    SELECT 'Record Exists'
END
ELSE
BEGIN
    SELECT 'Record Does Not Exist'
END

-- why we use it?
-- if we want to check if the record exists or not
-- Time Complexity: O(1) (if Comp_id is indexed) else in worst case O(n) 
-- IF EXISTS is optimized by SQL Server; it stops searching as soon as it finds the first matching row, making it efficient.