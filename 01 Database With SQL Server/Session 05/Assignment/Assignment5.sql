use Assi_ITI

-- 1.	Retrieve a number of students who have a value in their age.
Select COUNT(St_Age)
from Student

-- 2.	Display number of courses for each topic name
SELECT Top_Name, COUNT(Crs_Id)
FROM Course c, Topic t
WHERE c.Top_Id = t.Top_Id
GROUP by Top_Name

-- 3.	Select Student first name and the data of his supervisor
SELECT n.St_Fname, s.*
FROM Student n, Student s 
WHERE n.St_super = s.St_Id

-- 4.	Display student with the following Format (use isNull function)
-- Student ID	Student Full Name	Department name
SELECT St_Id, ISNULL(St_Fname + ' ' + St_Lname, 'No Name') [Full Name], isnull(D.Dept_Name, 'No Department') [Department Name]
FROM Student s, Department d
WHERE s.Dept_Id = d.Dept_Id

-- 5.	Select instructor name and his salary but if there is no salary display value ‘0000’ . “use one of Null Function”
SELECT Ins_Name, ISNULL(Salary, '0000')
FROM Instructor

-- 6.	Select Supervisor first name and the count of students who supervises on them
SELECT s.St_Fname, COUNT(n.St_Id)
FROM Student s, Student n
WHERE s.St_Id = n.St_super
GROUP BY s.St_Fname

-- 7.	Display max and min salary for instructors
SELECT MAX(Salary) [Max Salary], MIN(Salary) [Min Salary]
FROM Instructor

-- 8.	Select Average Salary for instructors
SELECT AVG(Salary) [Average Salary]
FROM Instructor

-- 9.	Display instructors who have salaries less than the average salary of all instructors.
SELECT Ins_Name
FROM Instructor
WHERE Salary < (SELECT AVG(Salary) FROM Instructor)

-- 10.	Display the Department name that contains the instructor who receives the minimum salary
SELECT Dept_Name
FROM Department D
WHERE D.Dept_Id in (
    SELECT II.Dept_Id
    from Instructor II
    WHERE Salary = (
    SELECT MIN(I.Salary)
    from Instructor I)
)

-- Part 02
--------------------------------
USE MyCompany

-- DQL
-------
/*
1.  For each project,
    list the project name and the total hours per week 
    (for all employees) spent on that project.
*/
SELECT P.Pname, SUM(W.Hours)
FROM Project P, Works_for W, Employee E
WHERE P.Pnumber = W.Pno AND W.ESSn = E.SSN
GROUP BY P.Pname

/*
2.  For each department,
    retrieve the department name and the maximum, minimum and average salary of its employees.
*/
SELECT D.Dname, MAX(E.Salary) [Max Salary], MIN(E.Salary) [Min Salary], AVG(E.Salary) [Average Salary]
FROM Departments D, Employee E
WHERE D.Dnum = E.Dno
GROUP BY D.Dname

/*
3.  Retrieve a list of employees and the projects they are working on 
    ordered by department and within each department, 
    ordered alphabetically by last name, first name.
*/
SELECT E.Fname, E.Lname, P.Pname
FROM Employee E, Works_for W, Project P
WHERE E.SSN = W.ESSn AND W.Pno = P.Pnumber
ORDER BY E.Dno, E.Lname, E.Fname

/*
4.  Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%
*/
UPDATE Employee
SET Salary = Salary * 1.3
WHERE SSN IN (
    SELECT ESSn
    FROM Works_for
    WHERE Pno = (
        SELECT Pnumber
        FROM Project
        WHERE Pname = 'Al Rabwah'
    )
)

-- DML
-------
/*
1.  In the department table insert a new department called "DEPT IT" , 
    with id 100, employee with SSN = 112233 as a manager for this department. 
    The start date for this manager is '1-11-2006'.
*/
INSERT INTO Departments
VALUES ( 'DEPT IT', 100, 112233, '1-11-2006')

/*
2.  Do what is required if you know that : 
    Mrs.Noha Mohamed(SSN=968574)  moved to be the manager of the new department (id = 100), 
    and they give you(your SSN =102672) her position (Dept. 20 manager)
*/
/*
    First try to update her record in the department table
*/
UPDATE Departments
SET MGRSSN = 102672
WHERE Dnum = 20

UPDATE Departments
SET MGRSSN = 968574
WHERE Dnum = 100

--! dont now how to answer
/*
    3. Unfortunatly the company ended the contract with  Mr.Kamel Mohamed (SSN=223344)
    so try to delete him from your database in case you know that you will be temporarily in his position.
    Hint: (Check if Mr. Kamel has dependents, works as a department manager,
    supervises any employees or works in any projects and handles these cases).
*/ 

-- Check if Mr. Kamel works as a department manager
SELECT *
FROM Departments
WHERE MGRSSN = 223344

-- it's supervisor fo Dnum = 10
-- remove him from the supervisor
UPDATE Departments
SET MGRSSN = NULL
WHERE MGRSSN = 223344

-- remove him from the Works_for
DELETE Works_for
WHERE ESSn = 223344

-- remove him from the Employee suprevisor
update Employee
SET Superssn = NULL
WHERE Superssn = 223344

-- remove him from the Employee
DELETE Employee
WHERE SSN = 223344


-- Part 03
--------------------------------
USE MyCompany

/*
 1. Retrieve the names of all employees in department 10 
    who work more than or equal 10 hours per week on
*/
SELECT Fname
from Employee E, Works_for W
WHERE E.Dno = 10 and E.SSN = W.ESSn AND W.Hours > 10  

/*
 2. Retrieve the names of all employees and the names of the projects they are working on, 
    sorted by the project name
*/
SELECT E.Fname, P.Pname
FROM Employee E, Works_for W, Project P
WHERE E.SSN = W.ESSn AND W.Pno = P.Pnumber

/*
 3. For each project located in Cairo City , 
    find the project number, the controlling department name ,
    the department manager last name ,address and birthdate.
*/
SELECT P.Pnumber, D.Dname, E.Lname , E.Address, E.Bdate
FROM Project P, Departments D, Employee E 
WHERE P.City = 'Cairo' and P.Dnum = D.Dnum and D.MGRSSN = E.SSN

/*
 4. Display the data of the department which has the smallest employee ID over all employees' ID.
*/
SELECT *
FROM Departments
WHERE Dnum = (
    SELECT MIN(Dno)
    FROM Employee
)

/*
 5. List the last name of all managers who have no dependents
*/
SELECT DISTINCT S.Lname 
FROM Employee E, Employee S
WHERE E.Superssn = S.SSN and S.SSN NOT in (SELECT ESSN from Dependent)

/*
 6. For each department-- if its average salary is less than the average salary of all employees 
    display its number, name and number of its employees.
*/
SELECT D.Dnum, D.Dname, COUNT(E.SSN)
FROM Departments D, Employee E
WHERE D.Dnum = E.Dno
GROUP BY D.Dnum, D.Dname
HAVING AVG(E.Salary) < (SELECT AVG(Salary) FROM Employee)

/*
 7. Try to get the max 2 salaries using subquery
*/
SELECT (SELECT MAX(Salary) FROM Employee ),  MAX(Salary)
FROM Employee
WHERE Salary < (SELECT MAX(Salary) FROM Employee)

























