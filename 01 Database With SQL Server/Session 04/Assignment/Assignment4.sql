
--=====================================================================================================--
---------------------------------------------  Assignment 4 ---------------------------------------------
--=====================================================================================================--

-- Part 01
-- 1) From The Previous Assignment insert at least 2 rows per table.
use Sales
INSERT INTO [Owner]
VALUES('ziad')

use Sales
INSERT INTO Sales_Office
VALUES ('bashtel', Null)

-- 2) Data Manipulation Language:
-- 1.Insert your personal data to the student table as a new Student in department number 30.
use ITI
INSERT into Departments 
VALUES('CS', '06-22-2014', NULL)

INSERT into Students
VALUES('ziad', 'mysara', 21, 'basthel',1 )

/* 2.Insert Instructor with personal data 
of your friend as new Instructor in department number 30,
Salary= 4000, but don’t enter any value for bonus. */

-- Instructors: [Name] ,[Address] ,[Bouns] ,[Salary] ,[Hour_Rate] ,[Dep_Id]
INSERT into Instructors
VALUES('mostafa', 'maddy', null , 4000, 20, 30)

-- 3.Upgrade Instructor salary by 20 % of its last value.
UPDATE Instructors
set Salary += Salary*.2

---------------------------------------------------------------------------
---------------------------------------------------------------------------

-- Part 02
----------
--Restore MyCompany Database and then: Try to create the following Queries:
use MyCompany

-- 1.Display all the employees Data.
SELECT *
FROM Employee

-- 2.Display the employee First name, last name, Salary and Department number.
SELECT Fname, Lname, Address, Dno
from Employee

/* 
 3. Display all the projects names,
    locations and the department which is responsible for it.
*/
SELECT Pname, Plocation, Dnum
from Project

/*
 4. If you know that the company policy is to pay an annual
    commission for each employee with specific percent equals 10% of
    his/her annual salary .Display each employee full name and his
    annual commission in an ANNUAL COMM column (alias).
*/
SELECT Fname + ' ' + Lname as FullName, Salary*.1 [ANNUAL COMM]
from Employee

-- 5. Display the employees Id, name who earns more than 1000 LE monthly.
SELECT SSN, Fname + ' ' + Lname as Name 
from Employee
WHERE Salary > 1000

-- 6. Display the employees Id, name who earns more than 10000 LE annually.
SELECT SSN, Fname + ' ' + Lname as Name
from Employee
WHERE Salary*12 > 10000

-- 7. Display the names and salaries
SELECT Fname + ' ' + Lname as Name, Salary
from Employee
WHERE SEX = 'F'

/*
 8. Display each department id, name
    which is managed by a manager with id equals 968574.
*/
SELECT Dnum, Dname
FROM Departments
WHERE MGRSSN = 968574

/*
 9. Display the ids, names and locations of
    the projects which are controlled with department 10.
*/
SELECT Pnumber, Pname, Plocation
FROM Project
WHERE Dnum = 10

---------------------------------------------------------------------------
---------------------------------------------------------------------------

-- Part 03
----------
-- Restore ITI Database and then:
use Assi_ITI

-- 1. Get all instructors Names without repetition
SELECT DISTINCT Ins_Name
FROM Instructor

-- 2. Display instructor Name and Department Name
-- Note: display all the instructors if they are attached to a department or not
SELECT Ins_Name, Dept_Name
FROM Instructor left outer join Department
ON Instructor.Dept_Id = Department.Dept_Id

-- 3. Display student full name and the name of the course he is taking
SELECT St_Fname + ' ' + St_Lname as FullName, Course.Crs_Name
FROM Student, Course, Stud_Course
where Student.St_Id = Stud_Course.St_Id and Course.Crs_Id = Stud_Course.Crs_Id AND Grade IS NOT NULL

-- Bouns
/*
Display results of the following two statements and 
explain what is the meaning of @@AnyExpression

select @@VERSION
select @@SERVERNAME
*/


SELECT @@VERSION
SELECT @@SERVERNAME

--select @@AnyExpression
-- @@AnyExpression is a system function that returns the value of the specified global variable.

---------------------------------------------------------------------------
---------------------------------------------------------------------------

-- Part 04
----------
-- Using MyCompany Database and try to create the following Queries:
use MyCompany

-- 1. Display the Department id, name and id and the name of its manager.
SELECT Dnum, Dname, MGRSSN, Fname + ' ' + Lname as ManagerName
FROM Departments, Employee
WHERE MGRSSN = SSN

/*
 2. Display the name of the departments and 
    the name of the projects under its control.
*/
SELECT Dname, Pname
from Departments D, Project P
WHERE  p.Dnum = D.Dnum 

/*
 3. Display the full data about all the dependence 
    associated with the name of the employee they depend on.
*/
SELECT D.*, E.Fname
FROM Dependent D, Employee E
WHERE D.ESSN = E.SSN

/*
 4. Display the Id, name and location of the projects in Cairo or Alex city.
*/
SELECT Pnumber, Pname, city
FROM Project
WHERE city = 'Cairo' OR city = 'Alex'

/*
 5. Display the Projects full data of the projects
    with a name starting with "a" letter.
*/
SELECT *
FROM Project
WHERE Pname LIKE 'a%'

/*
 6. display all the employees in department 30 whose 
    salary from 1000 to 2000 LE monthly
*/
SELECT *
FROM Employee
WHERE Dno = 30 AND Salary BETWEEN 1000 AND 2000

/*
 7. Retrieve the names of all employees in department 10 
    who work more than or equal 10 hours per week on the 
    "AL Rabwah" project.
*/
SELECT Fname + ' ' + Lname [Full Name]  
from Employee E , Works_for W, Project P
WHERE E.Dno = 10 AND E.SSN = W.ESSn and W.Hours >= 10 and
W.Pno = P.Pnumber and P.Pname = 'AL Rabwah'

/*
 8. Retrieve the names of all employees and the names of the projects 
    they are working on, sorted by the project name.
*/
SELECT Fname + ' ' + Lname [Full Name], Pname
from Employee E , Works_for W, Project P
WHERE E.SSN = W.ESSn and W.Pno = P.Pnumber
ORDER BY Pname

/*
 9. For each project located in Cairo City , find the project number, 
    the controlling department name ,the department manager last name ,
    address and birthdate.
*/
SELECT P.Pnumber, D.Dname, E.Lname , E.Address, E.Bdate
FROM Project P, Departments D, Employee E 
WHERE P.City = 'Cairo' and P.Dnum = D.Dnum and D.MGRSSN = E.SSN

--=====================================================================================================--
--=====================================================================================================--












