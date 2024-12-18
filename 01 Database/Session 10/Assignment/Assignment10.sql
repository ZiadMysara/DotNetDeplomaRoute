/*
Part 01
-------
Use ITI DB:
• Create an index on column (Hiredate) that allows you to cluster the data
in table Department. What will happen?

• Create an index that allows you to enter unique ages in the student
table. What will happen?

• Try to Create Login Named (RouteStudent) who can access Only student
and Course tables from ITI DB then allow him to select and insert data
into tables and deny Delete and update
———————————————————————————————————
Part 02
-------
Use MyCompany DB:

• Create a table named 'ReturnedBooks' With the Following Structure:
User SSN Book Id Due Date ReturnDate fees

Then:
• create A trigger that instead of inserting the data of returned
book checks if the return date is the due date or not if not so the user
must pay a fee and it will be 20% of the amount that was paid before.

• Create a trigger to prevent anyone from Modifying or Delete or Insert
in the Employee table (Display a message for user to tell him that he
can't take any action with this Table)

• Testing Referential Integrity, Mention What Will Happen When:
Create an index on column (Salary) that allows you to cluster the data
in table Employee.

• Try to Create Login With Your Name And give yourself access Only to
Employee and Floor tables then allow this login to select and insert
data into tables and deny Delete and update (Don't Forget To take
screenshot to every step)
———————————————————————————————————
*/
-- Assignment 10

-- Part 01
----------------
-- Use ITI DB:
USE Assi_ITI

/*
 1- Create an index on column (Hiredate) that allows you to cluster the data
    in table Department. What will happen?
*/
CREATE CLUSTERED INDEX IX_Department_Hiredate
ON Department(Manager_hiredate)
/*
    Cannot create more than one clustered index on table 'Department'.
    Drop the existing clustered index 'PK_Department' before creating
    another
*/

/*
 2- Create an index that allows you to enter unique ages in the student
    table. What will happen?
*/
Create Unique Index IX_Student_Age
on Student(St_Age)
/*
 The CREATE UNIQUE INDEX statement terminated because a duplicate key
 was found for the object name 'dbo. Student' and the index
 name 'IX_Student_Age'. The duplicate key value is (<NULL>).
*/

/*
 3- Try to Create Login Named (RouteStudent) who can access Only student
    and Course tables from ITI DB then allow him to select and insert data
    into tables and deny Delete and update
*/
CREATE login RouteStudent WITH PASSWORD = '123456'
CREATE USER RouteStudent

GRANT SELECT , INSERT ON dbo.Student to RouteStudent
GRANT SELECT , INSERT ON dbo.Course to RouteStudent

DENY DELETE , UPDATE ON dbo.Student TO RouteStudent
DENY DELETE , UPDATE ON dbo.Course TO RouteStudent

-- Part 02
----------------
USE MyCompany
/*
 1- Create a table named 'ReturnedBooks' With the Following Structure:
    User SSN, Book Id, Due Date, Return Date, fees.
*/
CREATE TABLE ReturnedBooks (
 UserSSN VARCHAR(20),
 BookId VARCHAR(20),
 DueDate Date,
 ReturnDate Date,
 fees money
)
/*
then:
 2- create A trigger that instead of inserting the data of returned
    book checks if the return date is the due date or not if not so the user
    must pay a fee and it will be 20% of the amount that was paid before.

 */
GO
CREATE TRIGGER Tri_CheckDate
on ReturnedBooks
INSTEAD OF INSERT
AS
    Declare @RDate Date;
    Declare @DDate Date;
    select @RDate = i.ReturnDate from inserted i
    select @DDate = i.DueDate from inserted i

    if @RDate > @DDate
    insert into ReturnedBooks
    select i.UserSSN, i.BookId, i.DueDate, i.ReturnDate, i.fees*1.2  from inserted i
    else
    insert into ReturnedBooks
    select * from inserted
GO

/*
 3- Create a trigger to prevent anyone from Modifying or Delete or Insert
    in the Employee table (Display a message for user to tell him that he
    can't take any action with this Table)
*/
GO
CREATE TRIGGER Tri_LockEmployee
ON Employee
INSTEAD OF UPDATE , DELETE , INSERT
AS
Print ('You can not take any action with this Table')
GO

/*
 4- Testing Referential Integrity, Mention What Will Happen When:
    Create an index on column (Salary) that allows you to cluster the data
    in table Employee.
*/
Create clustered Index IX_EmpSalary
on Employee(Salary)
/*
 Cannot create more than one clustered index on table 'Employee'.
 Drop the existing clustered index 'PK_Employee' before creating another.
*/

/*
 5- Try to Create Login With Your Name And give yourself access Only to
    Employee and Floor tables then allow this login to select and insert
    data into tables and deny Delete and update (Don't Forget To take
    screenshot to every step)
 */
create login ZiadAssignment with password = '123456'
go
create user ZiadAssignment
go
grant insert, SELECT on dbo.Employee to ZiadAssignment
go





