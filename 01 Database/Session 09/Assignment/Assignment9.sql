-- Assignment 09

-- Part 01
Use Assi_ITI
/*
 1. Create a trigger to prevent anyone from inserting a new record in
    the Department table ( Display a message for user to tell him that
    he can’t insert a new record in that table )
*/
go
Create Trigger Tri_PreventInsert
    ON Department
    INSTEAD OF INSERT
    AS
    print ('you can not insert a new record in this table')
go
-- test
insert into Department(Dept_Id, Dept_Name)
values (1, 'IT')

/*
 2. Create a table named “StudentAudit”. Its Columns are
    (Server User Name , Date, Note)

    Create a trigger on student table after insert to add Row in
    StudentAudit table
    ● The Name of User Has Inserted the New Student
    ● Date
    ● Note that will be like ([username] Insert New Row with Key =
      [Student Id] in table [table name]
*/
-- Create Table
GO
 create TABLE StudentAudit
(
    ServerUserName varchar(250),
    Date           DATE,
    Note           varchar(max)
)
-- Create Triggers
GO
create OR ALTER trigger Tri_StudentAudit
on dbo.Student
AFTER insert
AS
    insert into StudentAudit (ServerUserName, Date, Note)
    select Suser_name(),getdate(),
            (concat(Suser_name(),' Insert New Row with Key = ', St_Id,' in table Student'))
    from inserted
GO
-- Test
insert into Student(St_Id, St_FName, St_Lname)
values (27, 'Ahmed', 'Ali')
select * from StudentAudit
/*
 3. Create a trigger on student table instead of delete to add Row in
    StudentAudit table
    (The Name of User Has Inserted the New Student, Date, and note
    that will be like “try to delete Row with id = [Student Id]” )
*/
go
create trigger Tri_StudentAuditDelete
on dbo.Student
instead of delete
AS
    insert into StudentAudit
    select SUSER_NAME(),getdate(),
            concat('try to delete Row with id = ', St_Id)
    from deleted
go
-- Test
delete from Student
where St_Id = 27
select * from StudentAudit

-- Part 02
Use MyCompany

/*
 1. Create a trigger that prevents the insertion Process for Employee
    table in March.
*/
go
create OR ALTER trigger Tri_PrevInsertEmpInMarch
on Employee
INSTEAD OF insert
AS
    insert into Employee
    select *
    from  inserted I
    where format(getdate(), 'MMMM') != 'March'
go
-- test
insert into Employee(SSN, FName, LName, Salary, Bdate,Sex,  Dno, Superssn)
values (6, 'Ahmed', 'Ali', 5000, getdate(), 'male', 20,'512463')

------------------------------------------
use [SD32-Company]
/*
 1. Create an Audit table with the following structure

        ProjectNo   UserName  ModifiedDate  Budget_Old  Budget_New
        p2          Dbo       2008-01-31    95000       200000

        This table will be used to audit the update trials on the Budget
        column (Project table, Company DB)

        If a user updated the budget column then the project number,
        username that made that update, the date of the modification and
        the value of the old and the new budget will be inserted into the
        Audit table

        (Note: This process will take place only if the user updated the
        budget column)
 */
-- create table
go
CREATE TABLE Audit
(
    ProjectNo  INT  ,
    UserName  VARCHAR(50),
    ModifiedDate DATE,
    Budget_Old  int,
    Budget_New int
)
-- create trigger
go
create OR ALTER trigger HR.Tri_Audit
on HR.Project
AFTER UPDATE
AS
    declare @oldP int, @newP int;
    select @oldP = deleted.Budget
           from deleted
    select @newP = inserted.Budget
           from inserted
    if @oldP != @newP
    insert into Audit
    select D.ProjectNo, SUSER_NAME(), getdate(),
           D.Budget, I.Budget
    from deleted D, inserted I
go
-- test
update HR.Project
set Budget = 200000
where ProjectNo = 2
select * from Audit




