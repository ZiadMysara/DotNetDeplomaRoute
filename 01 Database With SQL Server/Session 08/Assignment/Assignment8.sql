-- Assignment 08

-- Part 01
----------
/*
1. Create a stored procedure to show the number of students per
   department.[use ITI DB]
*/
USE Assi_ITI;
GO
Create PROC NumOfStdPerDep
As
    select Dept_Id, COUNT(St_Id) as NumOfStudents
    from Student
    group by Dept_Id
GO
-- Execute SP
EXEC NumOfStdPerDep;

/*
2. Create a stored procedure that will check for the Number of employees
   in the project 100 if they are more than 3 print message to the user
   “'The number of employees in the project 100 is 3 or more'” if they are
   less display a message to the user “'The following employees work for
   the project 100'” in addition to the first name and last name of each one.
   [MyCompany DB]
 */
USE MyCompany;
GO
Create PROC NumOfEmpInProject100
As
    Declare @count int
    select @count = count(E.SSN)
    from Employee E, Works_for W, Project P
    where E.SSN = W.ESSn and W.Pno = P.Pnumber and Pnumber = 100
    group by P.Pnumber

    if @count > 3
        print('The number of employees in the project 100 is 3 or more')
    else if @count <= 3
        Print('The following employees work for the project 100')
        select E.Fname , E.Lname
        from Employee E, Works_for W, Project P
        where E.SSN = W.ESSn and W.Pno = P.Pnumber and Pnumber = 100
GO
-- Execute SP
EXEC NumOfEmpInProject100;

/*
3. Create a stored procedure that will be used in case an old employee has
   left the project and a new one becomes his replacement. The procedure
   should take 3 parameters (old Emp. number, new Emp. number and the
   project number) and it will be used to update works_on table.
   [MyCompany DB]
 */
USE MyCompany;
GO
Create PROC UpdateWorksOnTable @oldEmpNo int, @newEmpNo int ,@projectNo int
AS
    Update Works_for
    set ESSn = @newEmpNo
    where ESSn = @oldEmpNo and Pno = @projectNo
GO
-- Execute SP
EXEC UpdateWorksOnTable 112233, 321654, 100;
select * from Works_for where Pno = 100;

-- Part 02
----------
/*
1. Create a stored procedure that calculates the sum of a given
   range of numbers
 */
GO
Create proc CalcRang @start int, @end int
AS
    -- SumBetween2Num = ((b−a+1)⋅(a+b))/ 2
    select ((@end - @start + 1) * (@start + @end))/ 2
GO
-- Execute SP
EXEC CalcRang 1, 3;

/*
2. Create a stored procedure that calculates the area of a circle
   given its radius
*/
GO
Create proc CalcCircleArea @radius float
AS
    -- Area = 3.14 * R * R
    select 3.14 * @radius * @radius
GO
-- Execute SP
EXEC CalcCircleArea 5;

/*
3. Create a stored procedure that calculates the age category based
   on a person's age ( Note: IF Age < 18 then Category is Child and
   if Age >= 18 AND Age < 60 then Category is Adult otherwise
   Category is Senior)
 */
GO
Create OR ALTER proc CalcAgeCategory @age int
AS
    if @age < 18
        select('Child') as Category
    else if @age >= 18 and @age < 60
        select('Adult') as Category
    else
        select('Senior') as Category
GO
-- Execute SP
EXEC CalcAgeCategory 25;

/*
4. Create a stored procedure that determines the maximum,
   minimum, and average of a given set of numbers ( Note : set of
   numbers as Numbers = '5, 10, 15, 20, 25')
 */
GO
Create OR ALTER proc CalcMinMaxAvg
    @numbers varchar(100),
    @max int OUTPUT , @min int OUTPUT, @avg float OUTPUT
AS
    select @max = max(value), @min = min(value), @avg = avg(value)
    from string_split(@numbers, ',')
GO
-- Execute SP
DECLARE @max int, @min int, @avg float
EXEC CalcMinMaxAvg '5, 10, 15, 20, 25', @max OUTPUT, @min OUTPUT, @avg OUTPUT
SELECT @max as Max, @min as Min, @avg as Avg;

-- Part 03
----------
/*
Create a database “by Wizard” named “RouteCompany”
 */
-- Done
/*
 1. Create the following tables with all the required information and load
   the required data as specified in each table using insert statements[at
   least two rows]
 */
use RouteCompany;
Create TABLE Department (
    DeptNo VARCHAR(10) PRIMARY KEY ,
    DeptName VARCHAR(30),
    Location VARCHAR(30)
)
CREATE TABLE Employee (
    EmpNo VARCHAR(10) PRIMARY KEY,
    EmpFName VARCHAR(30) not null ,
    EmpLName VARCHAR(30) not null ,
    DeptNo VARCHAR(10),
    Salary INT unique ,
    FOREIGN KEY (DeptNo) REFERENCES Department(DeptNo)
)
-- CREATE TABLE Project by Wizard
-- Done

-- CREATE TABLE Works_on by Wizard
-- Done

-- Insert Data
INSERT INTO Department
VALUES ('d1', 'Research', 'NY'),
       ('d2', 'Accounting', 'DS'),
       ('d3', 'Marketing', 'KW')

INSERT INTO Employee
VALUES ('25348', 'Mathew', 'Smith', 'd3', 2500),
       ('10102', 'Ann', 'Jones', 'd3', 3000),
       ('18316', 'John', 'Barrymore', 'd1', 2400),
       ('29346', 'James', 'James', 'd2', 2800),
       ('9031', 'Lisa', 'Bertoni', 'd2', 4000),
       ('2581', 'Elisa', 'Hansel', 'd2', 3600),
       ('28559', 'Sybl', 'Moser', 'd1', 2900)

INSERT INTO Works_on
VALUES ('10102', 'p1', 'Analyst', '2006.10.1'),
       ('10102', 'p3', 'Manager', '2012.1.1'),
       ('25348', 'p2', 'Clerk', '2007.2.15'),
       ('18316', 'p2', NULL, '2007.6.1'),
       ('29346', 'p2', NULL, '2006.12.1'),
       ('2581', 'p3', 'Analyst', '2007.10.1'),
       ('9031', 'p1', 'Manager', '2007.4.15'),
       ('28559', 'p1', NULL, '2007.8.1'),
       ('28559', 'p2', 'Clerk', '2012.2.1'),
       ('9031', 'p3', 'Clerk', '2006.11.1'),
       ('29346', 'p1', 'Clerk', '2007.1.4')

-- Testing Referential Integrity
-- 1-Add new employee with EmpNo =11111 In the works_on table [what will happen]
insert into Works_on
values ('11111', 'p1', 'Clerk', '2007.1.4')
/*
 Line 1: The INSERT statement conflicted with the FOREIGN KEY constraint "FK__Works_on__EmpNo__44FF419A".
 The conflict occurred in database "RouteCompany", table "dbo. Employee", column 'EmpNo'.
*/

-- 2-Change the employee number 10102 to 11111 in the works on table [what will happen]
update Works_on
set EmpNo = '11111'
where EmpNo = '10102'
/*
Line 1: The UPDATE statement conflicted with the FOREIGN KEY constraint "FK__Works_on__EmpNo__44FF419A".
The conflict occurred in database "RouteCompany", table "dbo. Employee", column 'EmpNo'.
 */

-- 3-Modify the employee number 10102 in the employee table to 22222. [what will happen]
update Employee
set EmpNo = '22222'
where EmpNo = '10102'
/*
Line 1: The UPDATE statement conflicted with the REFERENCE constraint "FK__Works_on__EmpNo__44FF419A".
The conflict occurred in database "RouteCompany", table "dbo. Works_on", column 'EmpNo'.
*/

-- 4-Delete the employee with id 10102
delete from Employee
where EmpNo = '10102'
/*
 Line 1: The DELETE statement conflicted with the REFERENCE constraint "FK__Works_on__EmpNo__44FF419A".
 The conflict occurred in database "RouteCompany", table "dbo. Works_on", column 'EmpNo'.
 */

-- Table Modification
-- 1-Add TelephoneNumber column to the employee table[programmatically]
ALTER TABLE Employee
ADD TelephoneNumber VARCHAR(15)

-- 2-drop this column[programmatically]
ALTER TABLE Employee
DROP COLUMN TelephoneNumber

-- 3-Build A diagram to show Relations between tables
-- Done

/*
2. Create the following schema and transfer the following tables to it
    a. Company Schema
        i. Department table
        ii. Project table
    b. Human Resource Schema
        i. Employee table
*/
create SCHEMA Company

ALTER SCHEMA Company
TRANSFER dbo.Department

ALTER SCHEMA Company
TRANSFER dbo.Project

create SCHEMA HumanResource
ALTER SCHEMA HumanResource
TRANSFER dbo.Employee

/*
3. Increase the budget of the project where the manager number is 10102
 */
update Company.Project
set Budget = Budget * 1.1
from Works_on W, Company.Project P
where W.ProjectNo = P.ProjectNo and W.EmpNo = '10102'

/*
4. Change the name of the department for which the employee named
   James works.The new department name is Sales.
 */
update Company.Department
set DeptName = 'Sales'
from HumanResource.Employee E, Company.Department D
where E.DeptNo = D.DeptNo and E.EmpFName = 'James'

/*
5. Change the enter date for the projects for those employees who work in
   project p1 and belong to department ‘Sales’. The new date is
   12.12.2007.
 */
update Works_on
set Enter_Date = '2007.12.12'
from Works_on W, HumanResource.Employee E, Company.Department D
where W.EmpNo = E.EmpNo and W.ProjectNo = 'p1' and E.DeptNo = D.DeptNo and D.DeptName = 'Sales'

/*
6. Delete the information in the works_on table for all employees who
   work for the department located in KW.
 */
delete from dbo.Works_on
from dbo.Works_on W, HumanResource.Employee E, Company.Department D
where  W.EmpNo = E.EmpNo and E.DeptNo = D.DeptNo and D.DeptName = 'KW'




