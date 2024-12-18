

-- Part 01
-------------------------------------------
USE Assi_ITI

-- 1. Select max two salaries in the instructor table.
SELECT TOP 2 Salary
FROM Instructor
ORDER BY Salary DESC

/*
 2. Write a query to select the highest two salaries
    in Each Department for instructors who have salaries.
    “using one of Ranking Functions”
*/
SELECT Dept_Id, Salary
FROM (
    SELECT Dept_Id, Salary, DENSE_RANK() OVER (PARTITION BY Dept_Id ORDER BY Salary DESC) AS Rank
    FROM Instructor
) AS T
WHERE Rank <= 2

/*
 3. Write a query to select a random  student from each department.
    “using one of Ranking Functions”
*/
SELECT *
from (
SELECT * , ROW_NUMBER() OVER (PARTITION by Dept_Id ORDER by NEWID() ) as RN
from Student S WHERE Dept_Id is not NULL) as newTable
WHERE RN = 1

--================================================================================================--

-- Part 02
-------------------------------------------
USE AdventureWorks2012

/*
 1. Display the SalesOrderID, ShipDate of the SalesOrderHearder table 
    (Sales schema) to designate SalesOrders that occurred within
    the period ‘7/28/2002’ and ‘7/29/2014’
*/
SELECT  COUNT(ShipDate)
from Sales.SalesOrderHeader
WHERE ShipDate BETWEEN '2002-07-28 00:00:00.000' and '2014-07-29 00:00:00.000'

/*
 2. Display only Products(Production schema) with a StandardCost below $110.00 
    (show ProductID, Name only)
*/
SELECT ProductID, Name
FROM Production.Product
WHERE StandardCost < 110.00

/*
 3. Display ProductID, Name if its weight is unknown
*/
SELECT ProductID, Name
FROM Production.Product
WHERE Weight IS NULL

/*
 4. Display all Products with a Silver, Black, or Red Color
*/
SELECT Name, Color
From Production.Product
WHERE Color in ('Silver', 'Black', 'Red')

/*
 5. Display any Product with a Name starting with the letter B
*/
SELECT Name
From Production.Product
WHERE Name like 'B%'

/*
 6. Run the following Query
*/
    UPDATE Production.ProductDescription
    SET Description = 'Chromoly steel_High of defects'
    WHERE ProductDescriptionID = 3

/*
    Then write a query that displays any Product description 
    with underscore value in its description.
*/
SELECT Description
From Production.ProductDescription
WHERE Description like '%[_]%'

/*
 7. Display the Employees HireDate (note no repeated values are allowed)
*/
SELECT DISTINCT HireDate
From HumanResources.Employee

/*
 8. Display the Product Name and its ListPrice within the values of 100 and 120
    the list should have the following format "The [product name] is only! [List price]"
    (the list will be sorted according to its ListPrice value)
*/
SELECT CONCAT('The ',[name],' is only! ',[Listprice])
From Production.Product
WHERE ListPrice BETWEEN 100 and 120 
ORDER by ListPrice