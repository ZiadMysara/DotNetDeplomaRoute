-- Part 01(Functions)
-------------------------------------------
USE Assi_ITI

/*
 1. Create a multi-statements table-valued function that takes 2
    integers and returns the values between them.
*/
GO
Create or ALTER Function ValuesBetweenTwoNum(@x int, @y int)
Returns @VALUESS table (
    arr int
)
As
Begin
IF @x > @y
    Declare @i int = @x
    While @i >= @y
    Begin
        Insert into @VALUESS
        Values(@i)
        Set @i = @i - 1
    End
IF @x < @y
    set @i = @x
    While @i <= @y
    Begin
        Insert into @VALUESS
        Values(@i)
        Set @i = @i + 1
    End
    return
End
GO
-- Call Function
select * from dbo.ValuesBetweenTwoNum(1, 9)

/*
2. Create a table-valued function that takes Student No and 
   returns Department Name with Student full name.
*/
GO
CREATE or ALTER FUNCTION GetDepartmentNameWithStudentFullName(@stdNum int)
Returns VARCHAR(30)
BEGIN
    declare @Result VARCHAR(30)
    SELECT @Result = CONCAT(D.Dept_Name, '    ' , S.St_Fname, ' ', S.St_Lname)
    from Student S, Department D
    WHERE S.St_Id = @stdNum and D.Dept_Id = S.Dept_Id 
    return @Result
END
GO
-- Call Function
SELECT dbo.GetDepartmentNameWithStudentFullName(1)

/*
3. Create a function that takes an integer which represents
   the format of the Manager hiring date and displays
   department name, Manager Name and hiring date with
   this format.
*/
GO
Create or Alter Function DepName_MangName_HirDate(@Formate int)
Returns table 
AS
return
(
    SELECT D.Dept_Name, I.Ins_Name, convert (Varchar (50), D.Manager_hiredate, @Formate) as Manager_HireDate
    from Department D, Instructor I
    WHERE D.Dept_Manager = I.Ins_Id
)
GO
-- Call Function
SELECT * from dbo.DepName_MangName_HirDate(101)

/*
4. Create multi-statement table-valued function that takes a
   string
   a. If string='first name' returns student first name
   b. If string='last name' returns student last name
   c. If string='full name' returns Full Name from student
   table
   Note: Use "ISNULL" function
*/
GO
CREATE function ReturnName (@format varchar(20))
returns @Results Table (
    StdName VARCHAR(20)
)
as 
BEGIN
    IF @format = 'first name'
        INSERT INTO @Results
        SELECT ISNULL( St_Fname, 'noFirstName')
        from Student
    ELSE IF @format = 'last name'
        INSERT INTO @Results
        SELECT ISNULL( St_Lname, 'noLastName')
        FROM Student
    ELSE IF @format = 'full name'
        INSERT INTO @Results
        SELECT concat (St_Fname ,' ', St_Lname) As FullName
        from Student
    return
END
GO
-- Call Function
SELECT * from dbo.ReturnName('last name')

/*
5. Create function that takes project number and display all
   employees in this project (Use MyCompany DB)
*/
use MyCompany
GO
CREATE function EmployeesInProjectNum(@projNum int)
returns TABLE 
as 
RETURN(
    SELECT E.Fname 
    from Employee E, Works_for W
    where E.SSN = W.ESSn and W.Pno = @projNum
)
GO
-- Call Function
SELECT * from dbo.EmployeesInProjectNum(300)

/*
6. Create a scalar function that takes a date and returns the
   Month name of that date.
*/
GO 
CREATE FUNCTION GetMonthName(@Date Date)
Returns VARCHAR(20)
BEGIN
    DECLARE @MonthName VARCHAR(20) = datename(month, @Date)
    RETURN @MonthName
END
GO
-- Call Function
SELECT dbo.GetMonthName('2021-11-10')

/*
7. Create a scalar function that takes Student ID and returns
a message to user
    d. If first name and Last name are null then display 'First
       name & last name are null'
    e. If First name is null then display 'first name is null'
    f. If Last name is null then display 'last name is null'
    g. Else display 'First name & last name are not null'
*/
use Assi_ITI
GO
CREATE FUNCTION GetStatusOFNameOfStudent(@ID int)
Returns VARCHAR(30)
BEGIN
    DECLARE @Name VARCHAR(30)
    DECLARE @FName VARCHAR(30)
    DECLARE @LName VARCHAR(30)
    SELECT @Name = concat(St_Fname , ' ' ,St_Lname),  @FName = ISNULL(St_Fname, 'null'),  @LName = ISNULL(St_Lname, 'null')
    FROM Student
    WHERE St_Id = @ID
    IF @Name = ' '
        SET @name =  'First name & last name are null'
    ELSE IF(@FName = 'null')
        SET @name =  'first name is null'
    ELSE IF (@LName = 'null')
        SET @name =  'last name is null'
    ELSE 
        SET @name =  'First name & last name are not null'
    RETURN @name
END
GO
-- Call Function
SELECT dbo.GetStatusOFNameOfStudent(1)

-- Part 02(Views)
-------------------------------------------
-- Assi_ITI DB
---------------
USE Assi_ITI

/*
1. Create a view that displays the student's full name, course
   name if the student has a grade more than 50.
*/
GO
Create VIEW studentFullName_CourseName(FullName, CourseName)
AS
    SELECT concat(St_Fname , ' ' ,St_Lname), Crs_Name
    from Student S, Stud_Course SC, Course C
    WHERE S.St_Id = SC.St_Id and SC.Crs_Id = C.Crs_Id
GO
-- Call View
SELECT * from dbo.studentFullName_CourseName

/*
2. Create an Encrypted view that displays manager names 
   and the topics they teach.
*/
GO
CREATE VIEW  managerNames_Topics(ManagerNames, Topics)
WITH ENCRYPTion
AS
    SELECT DISTINCT I.Ins_Name, Top_Name
    FROM Department D, Instructor I, Ins_Course IC, Course C, Topic T
    WHERE D.Dept_Manager = I.Ins_Id and I.Ins_Id = IC.Ins_Id and
    IC.Crs_Id = C.Crs_Id and C.Top_Id = T.Top_Id 
GO
-- Call View
SELECT * from dbo.managerNames_Topics

/*
3. Create a view that will display Instructor Name, Department
   Name for the 'SD' or 'Java' Department "use Schema
   binding" and describe what is the meaning of Schema Binding
*/
GO 
create view InstructorNameForDepartmenSDorJava(InstructorName, DepartmentName)
AS
    SELECT Ins_Name, Dept_Name
    FROM Instructor I, Department D
    WHERE D.Dept_Name = 'SD' or D.Dept_Name = 'Java' and I.Dept_Id = D.Dept_Id
GO
-- Call View
SELECT * from dbo.InstructorNameForDepartmenSDorJava

/*
4. Create a view "VI" that displays student data for students
   who live in Alex or Cairo.
   Note: Prevent the users to run the following query
   Update VI set st_address='tanta'
   Where st address='alex';
*/
GO
CREATE VIEW studentDataForStdThatLiveInAlexOrCairo
WITH ENCRYPTion
As 
    SELECT *
    FROM Student
    WHERE St_Address = 'Alex' or St_Address = 'Cairo'
    WITH CHECK OPTION;
GO
-- Call View
SELECT * from dbo.studentDataForStdThatLiveInAlexOrCairo

/*
5. Create a view that will display the project name and the
   number of employees working on it. (Use Company DB)
*/
use MyCompany
GO
CREATE view projectNameAndNumofemployees( projectname, [the number of employees])
AS
    SELECT P.Pname, COUNT(E.SSN)
    FROM Project P, Works_for W, Employee E
    WHERE E.SSN = w.ESSn and W.Pno = P.Pnumber
    GROUP by P.Pname
GO
-- Call View
SELECT * from dbo.projectNameAndNumofemployees

-- CompanySD32 DB
-----------------
USE [SD32-Company]

/*
1. Create a view named "v_clerk" that will display employee
   Number ,project Number, the date of hiring of all the jobs
   of the type 'Clerk'.
*/
GO
CREATE or ALTER VIEW v_clerk( NoOfEmployees,NoOfProjects,Enter_Date)
AS
    SELECT E.EmpNo, W.ProjectNo, W.Enter_Date
    FROM Hr.Employee E, Dbo.Works_on W
    WHERE W.Job = 'Clerk' and E.EmpNo = W.EmpNo
GO
-- Call View
SELECT * from dbo.v_clerk

/*
2. Create view named "v without budget" that will display all
   the projects data without budget
*/
GO
CREATE or ALTER VIEW v_without_budget
AS
    SELECT P.ProjectNo, P.ProjectName 
    FROM HR.Project P
GO
-- Call View
SELECT * from dbo.v_without_budget

/*
3. Create view named "v_count " that will display the project
   name and the Number of jobs in it
*/
GO
CREATE or Alter VIEW v_count
AS
    SELECT P.ProjectName, COUNT(J.Job) AS 'Number of Jobs'
    from HR.Project P, dbo.works_on J
    WHERE P.ProjectNo = J.ProjectNo
    GROUP BY P.ProjectName
GO
-- Call View
select * from v_count

/*
4. Create view named " v_project_p2" that will display the
   emp# s for the project# 'p2' . (use the previously created
   view "v_clerk")
*/
GO
Create or Alter VIEW v_project_p2
AS
    select V.NoOfEmployees
    from dbo.v_clerk V, HR.Project P, DBO.Works_on W
    where  P.ProjectNo = W.ProjectNo and W.EmpNo = V.NoOfEmployees
GO
-- Call View
SELECT * from dbo.v_project_p2

/*
5. modify the view named "v_without_budget" to display all
   DATA in project pl and p2.
*/
GO
ALTER VIEW v_without_budget
AS
    SELECT *
    FROM HR.Project P
    WHERE P.ProjectNo = '1' OR P.ProjectNo = '2'
GO
-- Call View
SELECT * from dbo.v_without_budget

/*
6. Delete the views "v_clerk" and "v_count" 6.
*/
GO
DROP VIEW v_clerk
DROP VIEW v_count

/*
7. Create view that will display the emp# and emp last name
   who works on deptNumber is 'd2'
*/
GO
create view NumOfEmp_LName_ThatWorkInD2(NumOfEmp, LName)
As
    SELECT E.EmpNo, E.EmpLname
    from HR.Employee E, Department D
    where D.DeptNo = 2
GO
-- Call View
SELECT * from dbo.NumOfEmp_LName_ThatWorkInD2

/*
8. Display the employee lastname that contains letter "J"
   (Use the previous view created in Q#7)
*/
GO
Create or Alter VIEW v_EmpLName_ThatContainsJ
As
    select E.LName
    from Dbo.NumOfEmp_LName_ThatWorkInD2 E
    where E.LName like '%J%'
GO
-- Call View
SELECT * from dbo.v_EmpLName_ThatContainsJ

/*
9. Create view named "v_dept" that will display the
   department# and department name
*/
GO
Create or Alter View v_dept(NumOfDep, DepName)
AS
    select DeptNo, DeptName
    from Department
GO
-- Call View
SELECT * from dbo.v_dept

/*
10. using the previous view try enter new department data
    where dept# is 'd4' and dept name is 'Development'
*/
GO
insert into Dbo.v_dept
values (4,'Development')
GO

/*
11. Create view name "v_2006_check" that will display
    employee Number, the project Number where he works
    and the date of joining the project which must be from the
    first of January and the last of December 2006.this view
    will be used to insert data so make sure that the coming
    new data must match the condition.
*/
GO
Create or ALTER VIEW  v_2006_check
AS
    select E.EmpNo, P.ProjectNo, W.Enter_Date
    from HR.Employee E, Works_on W, HR.Project P
    where E.EmpNo = W.EmpNo and W.ProjectNo = P.ProjectNo
          and W.Enter_Date between '2006-01-01' and eomonth('2006-12-01')
    WITH CHECK OPTION;
GO
-- Call View
SELECT * from dbo.v_2006_check

