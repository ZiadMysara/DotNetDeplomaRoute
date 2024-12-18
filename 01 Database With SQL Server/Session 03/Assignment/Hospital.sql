CREATE DATABASE Hospital
use Hospital

Create Table Patient
(
    ID int Primary Key identity(1,1),
    Name varchar(15),
    DOB date,
    Ward_ID int,
    Con_ID int,
)

Create Table Ward
(
    ID int Primary Key identity(1,1),
    Name varchar(15),
    Nurse_Num int,
)

Create Table Nurse
(
    Number int Primary Key identity(1,1),
    Name varchar(15),
    Address varchar(100),
    Ward_ID int,
)

Create Table Consultant
(
    ID int Primary Key identity(1,1),
    Name varchar(15),
)

Create Table Patient_Consultant
(
    Con_ID int,
    Pat_ID int,
    primary key(Con_ID, Pat_ID),
)

Create Table Drugs
(
    Code int Primary Key identity(1,1),
    Dosage int,
)

Create Table Drug_Brand
(
    Drug_Code int ,
    Brand varchar(15),
    PRIMARY KEY(Drug_Code, Brand),
)

Create Table Nurse_Drug_Patient
(
    Nur_Num int,
    Drug_Code int,
    Pat_ID int,
    Date date,
    Time time,
    Dosage int,
    primary key(Pat_ID, Date, Time),
)

-- lets put foreign keys

Alter Table Patient
Add FOREIGN KEY (Ward_ID) References Ward(ID)

Alter Table Patient
Add FOREIGN KEY (Con_ID) References Consultant(ID)

Alter Table Ward
Add FOREIGN KEY (Nurse_Num) References Nurse(Number)

Alter Table Nurse
Add FOREIGN KEY (Ward_ID) References Ward(ID)

Alter Table Patient_Consultant
Add FOREIGN KEY (Con_ID) References Consultant(ID)

Alter Table Patient_Consultant
Add FOREIGN KEY (Pat_ID) References Patient(ID)

Alter Table Drug_Brand
Add FOREIGN KEY (Drug_Code) References Drugs(Code)

Alter Table Nurse_Drug_Patient
Add FOREIGN KEY (Nur_Num) References Nurse(Number)

Alter Table Nurse_Drug_Patient
Add FOREIGN KEY (Drug_Code) References Drugs(Code)

Alter Table Nurse_Drug_Patient
Add FOREIGN KEY (Pat_ID) References Patient(ID)

--=========================================================
