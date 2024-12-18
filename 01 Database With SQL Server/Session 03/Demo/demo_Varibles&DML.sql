--=========================================================
---------------------- 01 Comment ----------------------
--------------------------------------------------------

-- Single Line Comment
/*
MultiLine
Comment
*/
-- Ctrl+K , ctrl+C => Comment
-- Ctrl+K , Ctrl+U => Uncomment

--=========================================================
---------------------- 02 Data Types ----------------------
-----------------------------------------------------------


---------------------- 1.Numeric Data Types ----------------------
bit			-- Boolean Value 0[false]: 1[true]
tinyint		-- 1 Byte => -128: 127		| 0: 255 [Unsigned]
smallint	-- 2 Byte => -32768:32767	| 0: 65555 [Unsigned]
int			-- 4 Byte
bigint		-- 8 Byte

---------------------- 2. Fractions Data Types ----------------------
smallmoney		4B.0000				-- 4 Numbers After Point
money			8B.0000				-- 4 Numbers After Point
real			8B.0000000			-- 7 Numbers After Point
float			8B.000000000000000	-- 15 Numbers After Point
dec				-- Datatype and Make Valiadtion at The Same Time => Recommended
dec(5,2)		-- the total number is 5 digits, and there was 2 digts after "." 
				-- EX: dec(5,2):	124.22✓		18.1✖	12.2212✖	2.1234✖

---------------------- 3. String Data Types ----------------------
char(10)		-- [Fixed Length Character]				Ahmed 10	Ali 10
varchar(10)		-- [Variable Length Character]			Ahmed 5		Ali 3 
nchar(l0)		-- [like char(), But With UniCode]		احمد 10	   	 علي 10 //can use Arbic
nvarchar(10)	-- [like varchar(), But With UniCode]	احمد 5		 علي 3  //can use Arbic
nvarchar(max)	-- [Up to 2GB]
varchar(max)	-- [Up to 2GB]

---------------------- 4. DateTime Data Types ----------------------
Date			MM/dd/yyyy		-- 05/12/2025
Time			hh:mm:ss.123	-- Defult =>Time(3)
Time(5)			hh:mm:ss.12345
smalldatetime	MM/dd/yyyy hh:mm:00
datetime		MM/dd/yyyy hh:mm:ss.123
datetime2(4)	MM/dd/yyyy hh:mm:ss.1234
datetimeoffset	11/23/2020 10:30 +2:00 Timezone

---------------------- 5. Binary Data Types ----------------------
binary		[Fixed width binary string] 01110011 11110000
image 
varbinary	[Variable width binary string]

---------------------- 6.Misce11aneous Data Types ----------------------
Xml
sql_variant		-- Like Var In Javascript

--=========================================================
---------------------- 03 Variables ----------------------
-- 1. Global Variables [Built in]

select @@VERSION	--select is for select column

Print @@SeRvErNaMe	--Print is for print Variable, etc.

Print @@Language

-- 2. Local Variables (User-Defind)

declare @Name char(10) =  'Ahmed' -- 10

Select @Name
--=========================================================
---------------------- Data Definition Language (DDL) ----------------------
-- 1. Create
-------------

-- To Create Database:

create database Group02

-- Select Database:
Use Group02

-- To Create Table:
Drop Table Employee
Create Table Employees
(
SSN int Primary Key identity(1,1),
FName varchar(15) Not Null,
LName varchar(15),
Gender char(1),
BirthDate Date,
DNum int,
Super_SSN int References Employees(SSN),
Salary Money
)
Create Table Departments
(
DNum int Primary Key Identity(10, 10),
DName varchar(15)Not Null,
Manager_SSN int References Employees (SSN),
Hiring_Date Date,
)
-- 2. Alter (Update)
---------------------
-- Add New Column

Alter Table Employees
Add Test int


-- Alter an existing Column

Alter Table Employees
Alter Column Test BigInt

-- Drop column

Alter Table Employees
Drop Column Test

-- Add Reference to Column

Alter Table Employees
Add FOREIGN KEY (DNum) References Departments(DNum)

-- 3. Drop (Delete)
---------------------
-- Drop Table

Drop Table Employees

-- Drop Database

Drop Database Group02

--=========================================================
