-- demo.sql
use Assi_ITI

--===================================================================--
------------------------ 01 Relationship Rules ------------------------
--===================================================================--

-- 1. Delete Rule
-- Delete Department With Id = 30
Delete
from Department
where Dept_Id = 30

-- Before Delete Department No (30) With Its Instructors and Students:
-- Firstly, For Students
-- 1. Transfer Students Of Department No (30) to another Department
Update Student
set Dept_Id = 20
where Dept_Id = 30

-- 2. Transfer Students Of Department No (30) To No Department (Null)
Update Student
set Dept_Id = Null
where Dept_Id = 30

-- 3. Remove Students Of Department No (30)
Delete
from Student
where Dept_Id = 30

-- Secondly, For Instructors
-- 1. Transfer Instructors Of Department No (30) to another Department
Update Instructor
set Dept_Id = 20
where Dept_Id = 30

-- 2. Transfer Instructors Of Department No (30) To No Department (Null)
Update Instructor
set Dept_Id = Null
where Dept_Id = 30

-- 3. Remove Instructors Of Department No (30)
Delete
from Instructor
where Dept_Id = 30

-- Finally, Delete Department No (30)
Delete
from Department
where Dept_Id = 30

-- 2. Update Rule [The Same Idea Of Delete Rule]
-- update Department Id = 20
Update Department
set Dept_Id = 90
where Dept_Id = 20

-- Before update Department No (20) With Its Instructors and Students:
-- Firstly, For Students
Update Student
set Dept_Id = Null
where Dept_Id = 20

-- Secondly, For Instructors
Update Instructor
set Dept_Id = Null
where Dept_Id = 20

-- Finally, Update Department No (20)
Update Department
set Dept_Id = 90
where Dept_Id = 20

---------------------------------------------------------------------
-- [Wizard]
/*
    1. No Action
    2. Cascade
    3. Set Null
    4. Set Default
 */

-- 1. No Action
/*
    - No Action is the default option.
    - It means that the deletion or update of the parent record will not affect the child record.
    - If you try to delete or update a record in a parent table, and this record has a related record in a child table, you will get an error.
 */

-- 2. Cascade
/*
    - Cascade means that the deletion or update of the parent record will automatically delete or update the child record.
    - If you delete or update a record in a parent table, and this record has a related record in a child table, the related record in the child table will also be deleted or updated.
 */

-- 3. Set Null
/*
    - Set Null means that the deletion or update of the parent record will set the foreign key in the child table to NULL.
    - If you delete or update a record in a parent table, and this record has a related record in a child table, the foreign key in the child table will be set to NULL.
 */

-- 4. Set Default
/*
    - Set Default means that the deletion or update of the parent record will set the foreign key in the child table to its default value.
    - If you delete or update a record in a parent table, and this record has a related record in a child table, the foreign key in the child table will be set to its default value.
 */

--===================================================================--
--------------------- Delete Vs Truncate Vs Drop ----------------------
--===================================================================--
/*
            | --------------------------------------------------------------------------------- |
            | DELETE Command            | DROP Command         | TRUNCATE Command               |
----------- | ------------------------- | -------------------- | ------------------------------ |
            | The DELETE command	    | The DROP command is  | The TRUNCATE command           |
  Language  | is Data Manipulation      | Data Definition      | is a Data Definition           |
	        | Language Command.	        | Language Command.	   | Language Command.              |
            |    (DML)                  |    (DDL)             |    (DDL)                       |
----------- | ------------------------- | -------------------- | ------------------------------ |
	        | The DELETE command	    | The DROP Command	   | The TRUNCATE Command           |
    Use     | deletes one or more	    | drops the complete   | deletes all the rows from      |
	        | existing records from the | table from the       | the existing table,leaving     |
            | Use table in the database.| database.		       | the row with the column names. |
----------- | --------------------------------------------------------------------------------- |

*/
use Assi_ITI
select * into NewStudent
from Student
-- Delete Command
Delete
from Student
-- try to insert new record have identity value it will continue from the last value

-- Truncate Command
Truncate Table NewStudent
-- try to insert new record have identity value it will start from the first value

--===================================================================--
-------------------------- 03 Stored Procedure ------------------------
--===================================================================--
-- Benefits Of SP:
-- 1. Improved Performance
-- 2. Stronger Security (Hide Meta Data)
-- 3. Hide Business Rules
-- 4. Network Wise (Reduced server/ client network traffic)
-- 5. Handle Errors (SP Contain DML)
-- 6. Accept Input And Out Parameteres => Make It More Flexible


-- Ex 01
-- SP_GetStudentById
Create or ALTER Procedure SP_GetStudentById @Id int
as
Begin
    Select St_Id, Concat(St_FName, ' ' ,St_Lname) as Name, St_Age
    from Student
    where St_Id = @Id
End
-- Execute SP
declare @Id int = 1
Exec SP_GetStudentById @Id  -- i must use Exec if run proc with another statement

-- Ex 02
-- SP_DeleteTopicById
create or alter proc SP_DeleteTopicById @TopId int
with Encryption
as
Begin Try
    Delete from Topic
    where Top_Id = @TopId
End Try
Begin Catch
    Select 'Error Occured'
End Catch
-- Execute SP
EXEC SP_DeleteTopicById 1

-- Ex 03 [Passing By Parameters]
-- SP_SumData
Create or alter Proc SP_SumData @X int = 5 , @Y varchar(20) = '7'
as
    select @X + @Y
-- Execute SP
Exec SP_SumData 5, '7'       -- 12
Exec SP_SumData '5', 7       -- 12
Exec SP_SumData 5, 'Hamada'  -- error
EXEC SP_SumData  @Y = '5', @X = '7'  -- 12
EXEC SP_SumData  @Y = '12'           -- 17

-- Using SP in Dynamic Queries
------------------------------

-- SP GetData
Create or ALTER Proc SP_GetData @TableName varchar(20), @ColumnName varchar(20)
as
    -- Select @ColumnName from @TableName
    Execute( 'Select ' + @ColumnName + ' From ' + @TableName)

-- Execute SP
Exec SP_GetData 'Student', 'St_FName'
--(Worst Security[Objects Names are Known])

-- Insert Based On SP
------------------------------
-- SP_GetStudentByAddress
Create Proc SP_GetStudentByAddress @Address varchar(20)
as
    Select St_Id , St_Fname , St_Address
    from Student
    where St_Address = @Address

Create Table StudentALex
(
    St_ID int Primary Key,
    Name varchar(20),
    Address varchar(20)
)
-- Insert Based On SP (execute)
Insert into StudentALex
Exec SP_GetStudentByAddress 'Alex'

select * from StudentALex

-- Return Of SP :
-- SP_GetStudentNameAndAgeById
Create or ALTER Proc SP_GetStudentNameAndAgeById @StdId int, @Name varchar(20) output, @Age int output
as
Begin
    Select @Name = Concat(St_FName, ' ' ,St_Lname), @Age = St_Age
    from Student
    where St_Id = @StdId
End
-- Execute SP
declare @Name varchar(20), @Age int
Exec SP_GetStudentNameAndAgeById 1, @Name output, @Age output
select @Name as 'Name', @Age as 'Age'

-- SP_GetStudentNameAndAgeByIdV02
Create or ALTER Proc SP_GetStudentNameAndAgeByIdV02 @StdData int out, @Name varchar(20) output
as
Begin
    Select @Name = Concat(St_FName, ' ' ,St_Lname), @StdData = St_Age
    from Student
    where St_Id = @StdData
End
-- Execute SP
declare @Name varchar(20), @Age int = 1
Exec SP_GetStudentNameAndAgeByIdV02 @Age output, @Name output
select @Name as 'Name', @Age as 'Age'
