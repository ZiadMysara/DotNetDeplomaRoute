CREATE DATABASE Musician
use Musician
Create Table Musicians
(
ID int Primary Key identity(1,1),
NAME varchar(15) ,
Ph_Number varchar(15),
City varchar(15),
Street varchar(15),
)
Create Table Instruments
(
    NAME varchar(15) Primary Key,
    Ins_Key VARCHAR(15),
)
CREATE TABLE Album
(
ID int Primary Key identity(1,1),
Tittle varchar(15),
Date date,
Mus_ID int,
)
CREATE TABLE Song
(
    Tittle varchar(15) Primary Key,
    Autor varchar(15),
)
Create Table Album_Song
(
    Album_ID int,
    Song_Tittle varchar(15) PRIMARY KEY,
)
Create Table Mus_Song
(
    Mus_ID int,
    Song_Tittle varchar(15),
    primary key(Mus_ID, Song_Tittle),
)
Create Table Mus_Instrument
(
    Mus_ID int,
    Instrument_Name varchar(15),
    primary key(Mus_ID, Instrument_Name),
)

-- lets put foreign keys
Alter Table Album
Add FOREIGN KEY (Mus_ID) References Musicians(ID)

Alter Table Album_Song
Add FOREIGN KEY (Album_ID) References Album(ID)

Alter Table Album_Song
Add FOREIGN KEY (Song_Tittle) References Song(Tittle)

Alter Table Mus_Song
Add FOREIGN KEY (Mus_ID) References Musicians(ID)

Alter Table Mus_Song
Add FOREIGN KEY (Song_Tittle) References Song(Tittle)

Alter Table Mus_Instrument
Add FOREIGN KEY (Mus_ID) References Musicians(ID)

Alter Table Mus_Instrument
Add FOREIGN KEY (Instrument_Name) References Instruments(NAME)

--=========================================================