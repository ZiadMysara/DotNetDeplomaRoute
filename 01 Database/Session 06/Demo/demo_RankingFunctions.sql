-- demo
--=============================================================--
---------------------------- 1. Top -----------------------------
--=============================================================--
use Assi_ITI

SELECT *
from Student
where St_Id < 5

Select Top(5) *
from Student

-- Last 5 Students From Table
SELECT Top(5) *
from Student
order by St_Id Desc

-- Get The Maximum 2 Salaries From Instructors Table
SELECT Top(2) *
from Instructor
Order by Salary DESC

-- Get The 2 Maximum Salaries From Instructors Table
select MAX(Salary)
from Instructor
where Salary <> (select MAX( Salary) from Instructor)

-- Top With Ties, Must Used With Order by
-- Get Top 5 student Age
Select Top(5) with TIES St_Age -- it can return more than 5, the repeated last value will be returned
from Student
where St_Age is not null
order by St_Age desc


-- Randomly Select
-- (Globaly Unique Identifier) 32 digit [0-9] [a-f]
-- hexadecimal characters Grouped as 8-4-4-4-12 and Seperated by Four Hyphens
SELECT NEWID() as RandomID

SELECT St_Fname , NEWID() as RandomID
from Student

-- get 5 Random Students
SELECT Top(5) *
from Student
order by NEWID()

--=============================================================--
------------------------- 2. Ranking Functions ------------------
--=============================================================--
-- 1. Row_Number
-----------------
-- 1 - 2 - 3 - 4 - 5 - 6 - 7 - 8 - 9 - 10

SELECT *, ROW_NUMBER() over (order by Salary desc) as Rrank
from Instructor

-- 2. Dense_Rank
-----------------
-- 1 - 2 - 2 - 3 - 3 - 3 - 4 - 4 - 5 - 6

SELECT *, DENSE_RANK() over (order by Salary desc) as Drank
from Instructor

-- 3. Rank
-----------------
-- 1 - 2 - 2 - 4 - 4 - 4 - 7 - 7 - 9 - 10

SELECT *, RANK() over (order by Salary desc) as Rank
from Instructor

-- Get The 2 Older Students at Students Table
-- St_Fname, St_Age, Dept_ld
-- Using Ranking
Select *
from (Select St_Fname, St_Age, Dept_Id, ROW_NUMBER() over ( order by ST_Age desc) as RN
from Student) as NewTab1e
where RN <= 2

-- Using Top(Recommended)
SELECT Top(2) St_Fname, St_Age, Dept_Id
from Student
order by St_Age desc

-- Get The 5th Younger Student
-- Using Ranking (Recommended)
Select *
from (Select St_Fname, St_Age, Dept_Id, ROW_NUMBER() over ( order by ST_Age) as RN
from Student WHERE St_Age is not null) as NewTable
where RN = 4

-- using top
SELECT Top(1) St_Fname, St_Age, Dept_Id
from (Select top(4) St_Fname, St_Age, Dept_Id from Student WHERE St_Age is not null ORDER BY St_Age ) as NewTable
order by St_Age  desc

-- Get The Younger Student At Each Department
-- Using Ranking Only
Select *
from (Select St_Fname, St_Age, Dept_Id, ROW_NUMBER() over ( partition by Dept_Id order by ST_Age) as RN
from Student WHERE St_Age is not null) as NewTable
where RN = 1

-- 4. NTi1e
-----------------
-- We Have 15 Instructors, and We Need to Get The 5 Instructors Who Takes the lowest salary

-- Using Ranking

SELECT *
from (Select *, NTILE(3) over (order by Salary) as NTile
from Instructor
WHERE Salary is not null) as NewTable
where NTile = 1

-- Using Top (Recommended)
SELECT Top(5) *
from Instructor
WHERE Salary is not null
order by Salary

--=============================================================--
----------------------- 3. Excution Order -----------------------
--=============================================================--
/*

1. From
2. Join/on
3. Where
4. Group by 
5. Having
6. Select
7. Distinct
8. Order by
9. Top

*/
Select CONCAT(S.St_Fname , ' ', S.St_Lname)	as FullName
from Student S
where FullName = 'Ahmed Hassan' -- it give error because FullName is not defined yet as he read the where before the select

SELECT CONCAT(S.St_Fname , ' ', S.St_Lname)	as FullName
from Student S
where CONCAT(S.St_Fname , ' ', S.St_Lname) = 'Ahmed Hassan' -- it will work

SELECT *
from (Select CONCAT(S.St_Fname , ' ', S.St_Lname) as FullName from Student S) as NewTable
where FullName = 'Ahmed Hassan'


Select CONCAT(S.St_Fname , ' ', S.St_Lname)	as FullName
from Student S
order by FullName -- it works because the order by is after the select

--=============================================================--
--------------------------- 4. Schema ---------------------------
--=============================================================--
-- server > database > schema > objects (tables, views, ... etc)
-- Schema is a container for objects
-- benefits of schema
-- 1. Security
-- 2. Organization
-- 3. Ownership
-- 4. Isolation

SELECT @@SERVERNAME as ServerName

SELECT *
FROM [ZiadMysara\SQLEXPRESS].[Assi_ITI].[dbo].[Student]
--      [ServerName].        [DBName].[SchemaName].[TableName]

-- DBO [Default Schema]	=> Database Owner
-- Create New Schema
CREATE SCHEMA Sales

-- Transfer Table to Sales Schema
ALTER SCHEMA Sales TRANSFER Student

-- Check The Table
SELECT *
FROM Student -- it will give error because the table is not in the dbo schema

SELECT *
FROM Sales.Student -- it will work because the table is in the Sales schema

-- Transfer Table to DBO Schema
ALTER SCHEMA dbo TRANSFER Sales.Student 

-- Create new table in sales Schema
Create Table Department
(id int Primary key)  -- Wong as object name is already exist in dbo schema

CREATE TABLE Sales.Department
(id int Primary key) -- it will work as the object name is not exist in the Sales schema

-- Delete Schemal
-- Schema Must Contain no tables to dropped

DROP SCHEMA Sales -- it will give error because the table is not empty

-- Delete Table
DROP TABLE Sales.Department

-- Delete Schema
DROP SCHEMA Sales -- it will work now




