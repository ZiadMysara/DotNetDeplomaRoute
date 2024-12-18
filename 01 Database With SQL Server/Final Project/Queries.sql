-- Exam part 02
Use Library

/*
1. Write a query that displays Full name of an employee who has more than
   3 letters in his/her First Name
*/
select concat(Fname, ' ', Lname) as FullName
from Employee
where Fname like '___%'

/*
2. Write a query to display the total number of Programming books
   available in the library with alias name ‘NO OF PROGRAMMING
   BOOKS’
*/
select count(B.Id) as ['NO OF PROGRAMMING BOOKS']
from Book B, Category C
where C.Cat_name = 'programming' and B.Cat_id = C.Id

/*
3. Write a query to display the number of books published by
   (HarperCollins) with the alias name 'NO_OF_BOOKS'
*/
select COUNT(B.Publisher_id)
from Book B, Publisher P
where P.Name = 'HarperCollins' and P.Id = B.Publisher_id

/*
4. Write a query to display the User SSN and name, date of borrowing
   and due date of the User whose due date is before July 2022
*/
select U.SSN, U.User_Name, B.Borrow_date
from Users U, Borrowing B
where Borrow_date < '2022-07-01' and U.SSN = B.User_ssn

/*
5. Write a query to display book title, author name and display in the
   following format:
   '[Book Title] is written by [Author Name]'
*/
select concat(B.Title,' is written by ',A.Name)
from Book B, Book_Author BA, Author A
where B.Id = BA.Book_id and BA.Author_id = A.Id

/*
6. Write a query to display the name of users who have letter 'A' in their
   names
 */
select User_Name
from Users
where User_Name like '%A%'

/*
7. Write a query that display user SSN who makes the most borrowing
*/
select top 1 User_ssn
from Borrowing
group by User_ssn
order by count(User_ssn) desc

/*
8. Write a query that displays the total amount of money that each user paid
   for borrowing books
*/
select User_ssn, sum(Amount)
from Borrowing
GROUP BY User_ssn

/*
9. write a query that displays the category which has the book that has the
   minimum amount of money for borrowing
 */
select C.Cat_name
from Book B, Category C
where B.Cat_id = C.Id and B.Id = (select top 1 Book_id
                                  from Borrowing
                                  GROUP BY Book_id
                                  order by sum(Amount))

/*
10. write a query that displays the email of an employee if it's not found,
    display address if it's not found, display date of birthday
 */
select COALESCE(Email, Address, CONVERT(varchar, DOB, 120), 'notFound')
from Employee

/*
11. Write a query to list the category and number of books in each category
    with the alias name 'Count Of Books'
 */
select Cat_id, count(Id) as 'Count Of Books'
from Book
group by Cat_id

/*
12. Write a query that display books id which is not found in floor num = 1
    and shelf-code = A1
 */
select B.Id
from Book B, Shelf S, Floor F
where B.Shelf_code = S.Code and S.Floor_num = F.Number
  and B.Id not in
                (
                    select B.Id
                    from Book B, Shelf S, Floor F
                    where B.Shelf_code = S.Code and S.Floor_num = F.Number and Floor_num = 1 and Shelf_code = 'A1'
                )

/*
13. Write a query that displays the floor number , Number of Blocks and
    number of employees working on that floor
 */
select F.Number, F.Num_blocks, count(E.Id) as 'number of employees'
from Floor F, Employee E
where E.Floor_no = F.Number
group by F.Number, F.Num_blocks

/*
14. Display Book Title and User Name to designate Borrowing that occurred
    within the period ‘3/1/2022’ and ‘10/1/2022’
 */
select B.Title, U.User_Name
from Users U, Book B, Borrowing W
where U.Emp_id = W.Emp_id and W.User_ssn = U.SSN
  and w.Due_date between '3/1/2022' and '10/1/2022'

/*
15. Display Employee Full Name and Name Of his/her Supervisor as
    Supervisor Name
 */
select concat(E.Fname, ' ', E.Lname) as EmployeeName, concat(Super.Fname, ' ', Super.Lname) as SupervisorName
from Employee E, Employee Super
where E.Super_id = Super.Id

/*
16. Select Employee name and his/her salary but if there is no salary display
    Employee bonus
 */
select concat(E.Fname, ' ', E.Lname) as EmployeeName, isnull(E.Salary, E.Bouns) as EmployeeSalary
from Employee E

/*
17. Display max and min salary for Employees
 */
select max(Salary) as MaxSalary , min(Salary) as MinSalary
from Employee

/*
18. Write a function that take Number and display if it is even or odd
 */
GO
create function evenOrOdd (@x int)
RETURNS varchar(20) as
    begin
        Declare @Res varchar(20)
        if (@x % 2 = 0)
            set @Res = 'even'
        else
            set @Res = 'odd'
        return @Res
    end
GO
-- Call the function
select dbo.evenOrOdd(12)

/*
19. write a function that take category name and display Title of books in that
    category
 */
GO
create Function Title_of_books_in_category(@CatName varchar(20))
RETURNS table As
return (
        select Title
        from Book, Category
        where Book.Cat_id = Category.Id and Cat_name = @CatName
    )
GO
-- Call the function
select * from dbo.Title_of_books_in_category('programming')

/*
20. write a function that takes the phone of the user and displays Book Title ,
    user-name, amount of money and due-date
 */
GO
Create FUNCTION BorrowDataFromPhoneNum(@ThePhoneNum varchar(11))
RETURNS TABLE as
return (
    select Book.Title, U.User_Name, B.Amount, B.Borrow_date
    from Users U,User_phones UP, Borrowing B, Book
    where UP.User_ssn = U.SSN and U.SSN = B.User_ssn and B.Book_id = Book.Id and UP.Phone_num = @ThePhoneNum
    )
GO
-- Call the function
select * from dbo.BorrowDataFromPhoneNum('0123654122')

/*
21. Write a function that take user name and check if it's duplicated
    return Message in the following format ([User Name] is Repeated
    [Count] times) if it's not duplicated display msg with this format [user
    name] is not duplicated,if it's not Found Return [User Name] is Not
    Found
 */
GO
Create FUNCTION checkUserNameDuplicated(@UserName varchar(25))
RETURNS varchar(60) as
begin
    declare @CountOfUserName varchar(25)
    declare @ReturnMessage varchar(60)
    select @CountOfUserName = count(User_Name)
    from Users
    where User_Name = @UserName
    if @CountOfUserName >= 2
    set @ReturnMessage = concat(@UserName,' is Repeated ',@CountOfUserName,' times')
    else if @CountOfUserName = 1
    set @ReturnMessage = concat(@UserName,' is not duplicated')
    else
    set @ReturnMessage = concat(@UserName,' is Not Found')
    return @ReturnMessage
end
GO
-- Call the function
select dbo.checkUserNameDuplicated('Amr Ahmed')

/*
22. Create a scalar function that takes date and Format to return Date With
    That Format
 */
GO
Create OR ALTER FUNCTION DateWithSpasticFormat(@TheDate Date, @Formate int)
RETURNS Varchar (50) as
    begin
        Declare @Res VARCHAR(50)
        select @Res = convert(Varchar (50), @TheDate, @Formate )
        return @Res
    end
GO
-- Call the function
select dbo.DateWithSpasticFormat('2024-12-04', 101)

/*
23. Create a stored procedure to show the number of books per Category
 */
GO
Create OR ALTER PROCEDURE NumberOfBooksPerCategory
AS
    begin
        select Cat_name, count(Book.Id) as 'Number of Books'
        from Book, Category
        where Book.Cat_id = Category.Id
        group by Cat_name
    end
GO
-- Call the procedure
exec NumberOfBooksPerCategory

/*
24. Create a stored procedure that will be used in case there is an old manager
    who has left the floor and a new one becomes his replacement. The
    procedure should take 3 parameters (old Emp.id, new Emp.id and the
    floor number) and it will be used to update the floor table
 */
GO
Create OR ALTER PROCEDURE UpdateFloorManager
    @OldEmpId int,
    @NewEmpId int,
    @FloorNum int
AS
    begin
        update Floor
        set MG_ID = @NewEmpId
        where MG_ID = @OldEmpId and Number = @FloorNum
    end
GO
-- Call the procedure
exec UpdateFloorManager 5, 12, 7

/*
25. Create a view AlexAndCairoEmp that displays Employee data for users
    who live in Alex or Cairo
 */
GO
Create VIEW AlexAndCairoEmp
AS
    SELECT *
    from Employee
    where Address = 'Cairo' or Address = 'Alex'
GO
-- Call the view
select * from AlexAndCairoEmp

/*
26. create a view "V2" That displays number of books per shelf
 */
GO
Create or Alter VIEW V2
AS
    select B.Shelf_code ,Count(B.id) as NumberOfBooks
    from Book B
    group by B.Shelf_code
GO
-- Call the view
select * from V2

/*
27. create a view "V3" That display the shelf code that have maximum
    number of books using the previous view "V2"
 */
GO
Create or Alter VIEW V3
AS
   select top 1 V2.Shelf_code
   from V2
   order by V2.NumberOfBooks desc
GO
-- Call the view
select * from V3

/*
28. Create a table named ‘ReturnedBooks’ With the Following Structure :
    User SSN, BookId ,DueDate ,ReturnDate, fees
    then create A trigger that instead of inserting the data of returned book
    checks if the return date is the due date or not if not so the user must pay
    a fee and it will be 20% of the amount that was paid before
 */
-- Create the table
GO
Create Table ReturnedBooks
(
    User_SSN int,
    Book_Id int,
    Due_Date Date,
    Return_Date Date,
    Fees money
)
GO
-- Create the trigger
GO
Create Trigger CheckReturnDate
ON ReturnedBooks
INSTEAD OF INSERT
AS
    begin
        declare @DueDate Date
        declare @ReturnDate Date
        declare @Fees money
        select @DueDate = Due_Date, @ReturnDate = Return_Date
        from inserted
        if @ReturnDate > @DueDate
            set @Fees =  0.2
        else
            set @Fees = 0
        insert into ReturnedBooks
        select User_SSN, Book_Id, Due_Date, Return_Date, @Fees
        from inserted
    end
GO
-- Test the trigger
-- INSERT INTO
    insert into ReturnedBooks
    values (1, 1, '2022-12-12', '2022-12-13', 0)
-- SELECT
    select * from ReturnedBooks

/*
29. In the Floor table insert new Floor With Number of blocks 2 , employee
    with SSN = 20 as a manager for this Floor,The start date for this manager
    is Now. Do what is required if you know that : Mr.Omar Amr(SSN=5)
    moved to be the manager of the new Floor (id = 7), and they give Mr. Ali
    Mohamed(his SSN =12) His position
 */
-- Insert new Floor
INSERT INTO Floor
VALUES (7 ,2, 20, GETDATE())

-- Mr. Ali Mohamed Get his position
update Floor
set MG_ID = 12
where MG_ID = 5

-- Mr.Omar Amr Get the new position
update Floor
set MG_ID = 5
where Number = 7

/*
30. Create view name (v_2006_check) that will display Manager id, Floor
    Number where he/she works , Number of Blocks and the Hiring Date
    which must be from the first of March and the end of May 2022.this view
    will be used to insert data so make sure that the coming new data must
    match the condition then try to insert this 2 rows and
    Mention What will happen
    Employee Id, Floor Number, Number of Blocks, Hiring Date
        2       ,   6        ,      2          ,  7-8-2023
        4       ,   7        ,      1          ,  4-8-2022
 */
-- Create the view
GO
create or ALTER view v_2006_check
as
    select MG_ID, Number, Num_blocks, Hiring_Date
    from Floor
    where Hiring_Date between '2022-03-01' and eomonth('2022-03-01')
    WITH CHECK OPTION ;
GO
-- Insert the first row
insert into v_2006_check
values (8, 8, 2, '2022-03-07')
-- Insert the second row
insert into v_2006_check
values (9, 9, 4, '2022-08-04') -- HERE will give Error AS the date is not in the range

/*
31. Create a trigger to prevent anyone from Modifying or Delete or Insert in
    the Employee table ( Display a message for user to tell him that he can’t
    take any action with this Table)
 */
-- Create the trigger
GO
Create or ALTER Trigger PreventEmployeeActions
ON Employee
FOR INSERT, DELETE, UPDATE
AS
    begin
        RAISERROR ('You can''t take any action with this Table', 16, 1)
        ROLLBACK TRANSACTION
    end
GO
-- Test the trigger
-- INSERT INTO
    insert into Employee
    values ( 'Ahmed', 'Ali', 'Cairo',
            '0123654122', 'Cairo', '2003-1-6',
            '1000', 500, 2, '5')

/*
32. Testing Referential Integrity , Mention What Will Happen When:
    A. Add a new User Phone Number with User_SSN = 50 in
    User_Phones Table
 */
-- Add a new User Phone Number with User_SSN = 50 in User_Phones Table
insert into User_Phones
values (50, '0123654122')
/*[23000][547] Line 1: The INSERT statement conflicted with the FOREIGN KEY
  constraint "FK_User_phones_User". The conflict occurred in database "Library",
  table "dbo. Users", column 'SSN'.*/
-- B. Modify the employee id 20 in the employee table to 21
update Employee
set Id = 21
where Id = 20
/*
[S0001][8102] Line 1: Cannot update identity column 'Id'.
*/
-- C. Delete the employee with id 1
delete from Employee
where Id = 1
/*
 [23000][547] Line 1: The DELETE statement conflicted with
 the REFERENCE constraint "FK_Borrowing_Employee".
 The conflict occurred in database "Library",
 table "dbo. Borrowing", column 'Emp_id'.
 */
-- D. Delete the employee with id 12
delete from Employee
where Id = 12
/*
 [23000][547] Line 1: The DELETE statement conflicted with the REFERENCE constraint
 "FK_Borrowing_Employee". The conflict occurred in database "Library",
 table "dbo. Borrowing", column 'Emp_id'.
 */
-- E. Create an index on column (Salary) that allows you to cluster the data in table Employee
CREATE CLUSTERED INDEX IX_Salary
ON Employee (Salary)
/*
[S0003][1902] Line 1: Cannot create more than one clustered index on table 'Employee'.
Drop the existing clustered index 'PK_Employee' before creating another.
*/

/*
33. Try to Create Login With Your Name And give yourself access Only to
    Employee and Floor tables then allow this login to select and insert data
    into tables and deny Delete and update (Don't Forget To take screenshot
    to every step)
 */

CREATE or alter LOGIN ziad WITH PASSWORD = 'P@ssw0rd';






















