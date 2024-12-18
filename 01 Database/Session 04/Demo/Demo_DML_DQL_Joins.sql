-- database: /path/to/database.db
--=================================================--
---------- Data Manipulation Language(DML) ----------

-- 1. insert 
----------------
--1.1 Simple Insert(Add Just Only One Row)
use MyCompany
insert into Employee
Values( 'Mostafa' , 'Hany' , 'M' , ' 03-11-1998' , Null, Null,5000) -- as the order of columns in the table


insert into Employee(Fname, salary) 
values( 'Hadeer' , 2000) -- as the order of Fname and salary 

-- Note:
-- it must have at least one of the following constraints:

-- 1. Identity Constraint 
-- 2. Default Value
-- 3. Allow Null

-- with out theses constraints, the insert statement will give an error

-- 1.2 Row Constructor Insert (Add More Than One Row)

insert into Employee
Values
( 'Mostafa' , 'Hany' , 'M' , ' 03-11-1998' , Null, Null,5000),
( 'Hadeer' , 'Mohamed' , 'F' , ' 03-11-1998' , Null, Null,2000),
( 'Ahmed' , 'Ali' , 'M' , ' 03-11-1998' , Null, Null,3000)


-- 2. Update
----------------
-- 2.1 Update All Rows
update Employee
set salary += salary*10/100

-- 2.2 Update Specific Rows
update Employee
set salary = 10000
where Fname = 'Mostafa'

-- 3. Delete
----------------
-- 3.1 Delete All Rows
delete from Employee

-- 3.2 Delete Specific Rows
delete from Employee
where Fname = 'Mostafa'

-- note: if you delete identity, like identity id = 3, the next insert will start from 4 not 3

-- 4. Merge
----------------
-- 4.1 Merge Two Tables
-- Note: Merge is not supported in SQLite

-- 5. Truncate
----------------
-- 5.1 Truncate Table
-- Note: Truncate is not supported in SQLite

--=================================================--

---------- Data Query Language(DQL) ----------

-- Select => Just For Display
------------------------------


use Assi_ITI
-- Display all Data of Students
select * from Student

-- DispIay specific Columns of data of student
select St_Fname, St_Lname from Student

-- Display First name and Last name concatenation
select St_Fname + ' ' + St_Lname as FullName from Student

select St_Fname + ' ' + St_Lname [Full Name] from Student

select St_Fname + ' ' + St_Lname FullName from Student

select [Full Name] = St_Fname + ' ' + St_Lname from Student

-- Display Students With Age Less than 23
select * from Student
where St_Age < 23

-- Display Students With Age in Range 21 to 25

select * from Student where St_Age >= 21 and St_Age <= 25

select * from Student
where St_Age between 21 and 25

-- Display Students who live in alex, Mansoura, Cairo
SELECT * FROM Student
WHERE St_Address = 'Alex' OR St_Address = 'Mansoura' OR St_Address = 'Cairo'



select * from Student
where St_Address in ('Alex', 'Mansoura', 'Cairo')

-- Display Students who don't live in alex , Mansoura, Cairo
select * from Student
where St_Address not in ('Alex', 'Mansoura', 'Cairo')

-- Display Students who has no Supervisor
select * from Student
where St_super is null

-- Display Students who has Supervisor
select * from Student
where St_super is not null

-- student's Name With second char 'a'
select * from Student
where St_Fname like '_a%'

-- like With Some Patterns 
/*
Reserved Char
---------------

% => Zero or more characters

_ => Single character

[] =>  Any single character within the specified range ([a-z], [A-Z], [0-9]), 
or  set of characters [ahm], Ex: [a h m] =>  (a or h or m)

[^] =>  Any single character not within the specified range ([^a-z], [^A-Z], [^0-9]),
or not  set of characters [^ahm], Ex: [^a h m] => not  ( a or h or m)

*/
/*

Ex:

    'a%h'=> ahmed, amr hassan
    '%a_' => ah
    '[ahm]%' => amr hassan mohamed a hml
    '[^ahm]%' => omar Essam Tarek
    '[a-h]%' => ali bassem
    '[^a-h]%' => zeyad mohamed
    '[346]%' => 3mr 6x
    '%[%]' => ahmed%
    '%[_]%' => Ahmed_Ali_
    '[_]%[_]' => _Ahmed_

*/

-- Student's Name which end with %
select * from Student
where St_Fname like '%[%]'

-- student Name Without Duplication
select distinct St_Fname from Student

-- Order Student by Their Name
select * 
from Student
order by St_Fname

select * 
from Student
order by St_Fname desc

-- Order Student by Their Name and Age
select *
from Student
order by St_Fname, St_Age

select *
from Student
order by St_Fname desc, St_Age desc

SELECT St_Fname, St_Lname, St_Age
FROM Student
ORDER BY 1, 3   -- 1 => St_Fname, 3 => St_Age        -- 1 , 3 is the order of columns in the "select" statement not in the table

--=================================================--
----------------------- Joins -----------------------

-- 1. Cross join (Cartesian Product)
-------------------------------------
-- old way (ANSI)
select S.St_Fname , D.Dept_Name
from Student S, Department D

-- new way (Microsoft)
select S.St_Fname , D.Dept_Name
from Student S cross join Department D

--2.Inner Join
----------------
-- old way (ANSI)
select S.St_Fname , D.Dept_Name
from Student S, Department D
where S.Dept_ID = D.Dept_ID

-- new way (Microsoft)
select S.St_Fname , D.Dept_Name
from Student S inner join Department D
on S.Dept_ID = D.Dept_ID

--3. Outer Join
----------------
-- 3.1 Left Outer Join
------------------------
-- new way (Microsoft)
select S.St_Fname , D.Dept_Name
from Student S left outer join Department D
on S.Dept_ID = D.Dept_ID

-- 3.2 Right Outer Join
------------------------
-- new way (Microsoft)
select S.St_Fname , D.Dept_Name
from Student S right outer join Department D
on S.Dept_ID = D.Dept_ID

-- 3.3 Full Outer Join
------------------------
-- new way (Microsoft)
select S.St_Fname , D.Dept_Name
from Student S full outer join Department D
on S.Dept_ID = D.Dept_ID

-- 4. Self Join
----------------
-- old way (ANSI)
select S.*, Super.St_Fname as SuperName
from Student S, Student Super
where  S.St_super = Super.St_ID

-- new way (Microsoft)
select S.*, Super.St_Fname as SuperName
from Student S inner join Student Super
on S.St_super = Super.St_ID


-- Multi Table Join
---------------------
-- Inner Join Syntax (ANSI)
select S.St_Fname, C.Crs_Name
FROM Student S, Course C, Stud_Course SC
where S.St_ID = SC.St_ID and C.Crs_Id = SC.Crs_Id

-- Inner Join Syntax (Microsoft)
select S.St_Fname, C.Crs_Name
FROM Student S inner join Stud_Course SC
on S.St_ID = SC.St_ID
inner join Course C
on C.Crs_Id = SC.Crs_Id


-- in old way, we use "where" in condition, but in new way we use "on"

----------------------------------------------
----------------------------------------------
-- Join + DML

-- 1. Update
-- Updates Grades Of Student Who 're Living in Cairo
use Assi_ITI
update sc
set Grade += 10
from Student S, Stud_Course sc
where S.St_Id = SC.St_Id and S.St_Address = 'Cairo'



-- 2. Delete
-- Delete Students Who 're Living in Cairo
delete s
from Student S, Stud_Course sc
where S.St_Id = SC.St_Id and S.St_Address = 'Cairo' 

--=================================================--















