
-- Demo SQL Queries


--Database: Assi_ITI
use Assi_ITI

--===========================================================
------------------- 1. Aggregate Functions ------------------
--===========================================================
--  Return Value That Not Existed In Database
--  [ Count, Sum, Avg, Max, Min]
Select COUNT(*) [Num of Students]
from Student

-- The Count of Students That have Ages (Not Null)
Select COUNT(*) , COUNT(St_Id), COUNT(st_Age) ,COUNT (St_Lname)
from Student

Select Sum(Salary)
from Instructor

select AVG( Salary)
from Instructor

Select SUM(Salary) / COUNT(Salary)
from Instructor

Select max(Salary)	[Max Salary], MIN(Salary) [Min Salary]
from Instructor


--===========================================================
----------------------- 2. Group By -------------------------
--===========================================================


-- Minimum Salary For Each Department
--------------------------------------

Select Dept_Id , MIN(Salary)[Min Salary]
from Instructor
group by Dept_Id

-- Will Group Here With Which Column?
Select Dept_Id , St_Address, COUNT(St_Id)
from Student
group by Dept_Id, St_Address

-- If You Select Columns With Aggregate Functions,
-- You Must Group By With The Same Columns



-- Get Number Of Student For Each Department [that has more than 3 students]
-- -Dept_ld -Dept_Name -Number Of Students -
Select Dept_Id , COUNT(St_Id)
from Student
where COUNT (St_Id) > 3
group by Dept_Id
--- invalid query


SELECT Dept_Id, COUNT(St_Id)
from Student
group by Dept_Id
having COUNT (St_Id) > 3

Select S. Dept_Id , D.Dept_Name	, COUNT(S.St_Id)
from Student s, Department D
where D.Dept_Id = s.Dept_Id
group by S.Dept_Id 
having COUNT (S.St_Id) > 3

-- You Can't Use Agg Functions Inside Where Clause (Not Valid)
-- Because Aggreagate Generate Groups That 'Having' Works With it
-- Where Works With Rows => in order to Make Filteration

-- Get Number Of Student For Each Department [Need Join?]
---------------------------------------------------------



-- Get Sum of Salary of Instructors For Each Department [Which has more than 1 Instructors] 
-- Dept_ld - Count Of instructor - Sum Of Salary
------------------------------------------------------------------
select  Dept_Id, Sum(Salary), COUNT(Ins_Id)
from Instructor
group by Dept_Id
having COUNT (Ins_Id) >1

-- You Can Use Having Without GroupBy Only In Case Of Selecting Just Agg Functions
Select Sum(Salary)
from Instructor
having COUNT(Ins_Id) > 1


----------------------------------------------------------------------------------------------
-- Group By With Self Join
---------------------------

-- Get Count of Students for each Supervisor
-- Super Name - Number Of Students
---------------------------------------
Select Super.St_Fname, COUNT(S.St_Id)  
from Student S , Student Super
where Super.St_Id =  S.St_super
group By Super.St_Fname


--======================================================================
------------------- 3. Built-in Functions (continued) ------------------
--======================================================================
-- 1. Null Functions
---------------------
-- 1.1 ISNULL
select isnull(St_Lname,	'Not Found')
from Student

-- 1.2 COALESCE
select COALESCE(St_Lname, St_Address, 'Not Found')
from Student

-- 2. Casting Functionsl
-------------------------
-- 2.1 convert [convert from any type to any type]
-- convert(data_type(length), expression, style)

select St_Fname + ' ' + CONVERT(varchar(2), St_Age)
from student

-- note: String + Null = Null
Select St_Fname	+ ' ' + CONVERT (varchar(2), ISNULL(St_Age, 0))
from student

-- 2.2 Concat
-- Concat (string1, string2, ..., string_n)

select CONCAT(St_Fname, ' ', St_Lname)
from Student

-- 2.3 Cast [convert from any type to any type]
-- cast(expression as data_type)

select cast(getdate() as varchar(50))


/*
Convert Take Third Argument If You Casting From Date To String
For Specifying The Date Format You Need
*/

select convert (Varchar (50), getdate(), 100)
select convert (varchar (50), getdate(), 101)
select convert (varchar (50), getdate(), 102)
select convert (varchar (50), getdate(), 110)
select convert (varchar (50), getdate(), 111)

---------------------------------------------
-- 2.4 casting with format

/*
d	        Days as 1-31	                25
dd	        Days as 01-31	                09
ddd	        Days as Sat-Fri	                wed
dddd	    Days as Saturday-Friday	        wednesday

M	        Month as 1-12                   1
MM	        Month as 01-12	                01
MMM	        Month as Jan- Dec	            Jan
MMMM	    Month as January-December	    January

yy	        Years as 00-99	                23
yyyy	    Years as 1990-9999	            2023

hh	        Hours as 1-12	                2
HH          Hours as 00-23	                14

mm	        Minutes as 00-59	            46

ss	        Seconds as 00-59	            23

tt      	AM/PM                           PM
*/

-- select format(value, format, culture)
-- Examples:
SELECT format(123456789, '##-###-####')                             -- 12-345-6789
select format(getdate(), 'dd-MM-yyyy')                              -- 25-07-2021
select format(getdate(), 'dddd MMMM yyyy')                          -- Sunday July 2021
select format(getdate(), 'ddd MMM yy')                              -- Sun Jul 21
select format(getdate(), 'hh:mm:ss')                                -- 02:46:23
select format(getdate(), 'hh tt')                                   -- 02 PM
select format(getdate(), 'HH')                                      -- 14
select format(getdate(), 'ddd MMM yy hh:mm:ss tt')                  -- Sun Jul 21 02:46:23 PM
select format(getdate(), 'ddd MMM yy hh:mm:ss tt', 'en-US')         -- Sun Jul 21 02:46:23 PM
select format(getdate(), 'ddd MMM yy hh:mm:ss tt', 'ar-EG')         -- الأحد يوليو 21 02:46:23 م


--===========================================================================================--
------------------------------------ 4. DateTime Functions ------------------------------------
--===========================================================================================--

-- 1.1 GetDate
select getdate()

-- 1.2 DatePart
select  DAY('1999-01-05'),                      -- 5
        MONTH('1999-01-05'),                    -- 1
        YEAR('1999-01-01')                      -- 1999

select datepart(year, getdate())

-- 1.3 DateName
select datename(month, getdate())

-- 1.4 DateAdd
select dateadd(day, 1, getdate())

-- 1.5 DateDiff
select datediff(hour, '1999-01-01', getdate())

-- 1.6 EOMonth
select eomonth(getdate())                               -- Last Day of the Month
select eomonth(getdate(), 1)                            -- Last Day of the Next Month
select format(eomonth(getdate(), 2), 'dd')              -- Last Day only of the Next 2 Months

-- 1.7 FirstDay
select dateadd(day, 1 - datepart(day, getdate()), getdate())

-- 1.8 DayOfYear
select datepart(dayofyear, getdate())

-- 1.9 WeekOfYear
select datepart(week, getdate())

-- 1.10 MonthofYear
select datepart(month, getdate())

-- 1.11 WeekDay
select datepart(weekday, getdate())  -- 1: Sunday, 2: Monday, ..., 7: Saturday

-- 1.12 MonthNumber
select datepart(MONTH, getdate()) 




--===========================================================================================--
------------------------------------ 5. String Functions --------------------------------------
--===========================================================================================--

Select LOWER(St_Fname)
from Student

Select UPPER(St_Fname)
from Student

Select SUBSTRING(St_Fname, 1, 3)
from Student

select LEN(St_Fname)
from Student


--===========================================================================================--
-------------------------------------- 6. Math Functions --------------------------------------
--===========================================================================================--

Select POWER(3, 2)          -- 9
select ABS(-550)            -- 550
Select PI()                 -- 3.14159265358979
SELECT RAND()               -- Random Number Between 0 and 1
SELECT ROUND(123.456, 2)    -- 123.46
SELECT CEILING(123.456)     -- 124
SELECT FLOOR(123.456)       -- 123
SELECT SQRT(25)             -- 5
SELECT SIGN(-5)             -- Sign of Number (-1, 0, 1)     -- -1
SELECT LOG(10)              -- Natural Logarithm of Number  -- 2.30258509299405
SELECT LOG10(10)            -- Base 10 Logarithm of Number  -- 1
SELECT LOG(2, 8)            -- Logarithm of Number with Base -- 3
SELECT DEGREES(PI())        -- Radians to Degrees           -- 180
SELECT RADIANS(180)         -- Degrees to Radians           -- 3.14159265358979


--===========================================================================================--
--------------------------------------- 7. System Functions -----------------------------------
--===========================================================================================--

Select @@VERSION        -- SQL Server Version
Select @@SERVERNAME     -- Server Name
Select @@LANGUAGE       -- Language
Select @@SERVICENAME    -- Service Name
SELECT DB_NAME()        -- Database Name
SELECT HOST_NAME()      -- Host Name
SELECT SUSER_NAME()     -- Current User
SELECT SYSTEM_USER      -- Current User

--===========================================================================================--
--------------------------------------- 8. Subquery -------------------------------------------
--===========================================================================================--
-- Output Of Sub Query[lnner] As Input To Another Query[Outer]
--^ SubQuery Is Very Slow (Not Recommended Except Some Cases)
-- Students that AGE > AVG (Age)

use Assi_ITI

Select *
from Student
HAVING St_Age > Avg(St_Age)	-- invalid

Select *
from Student
where St_Age > (Select AVG(St_Age) from Student)

Select * ,(Select COUNT(*) from Student) 
from Student


-- SubQuery Vs Join
-- Get Departments Names That Have Students Without Repeat
Select DISTINCT Dept_Name
from Department
where Dept_Id in (Select Dept_Id from Student
                  where Dept_Id is not null)

Select DISTINCT D.Dept_Name
from Department D, Student S
where D.Dept_Id = S.Dept_Id

-- SubQuery With DML
-- SubQuery With Delete
--Delete Students Grades Who Are Living in Cairo

DELETE SC
from Student S inner join Stud_Course SC
on S.St_id = SC.St_Id and St_Address = 'Cairo'

Delete 
from Stud_Course
where St_Id in 
      ( Select St_Id
        from Student
        where St_Address = 'Cairo'
      )


