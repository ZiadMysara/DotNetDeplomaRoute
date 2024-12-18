USE [master]
GO
/****** Object:  Database [MyCompany]    Script Date: 05/11/2024 12:54:35 ص ******/
CREATE DATABASE [MyCompany]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Company_SD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyCompany.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Company_SD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyCompany_log.ldf' , SIZE = 3840KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MyCompany] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyCompany].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyCompany] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyCompany] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyCompany] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyCompany] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyCompany] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyCompany] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyCompany] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyCompany] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyCompany] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyCompany] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyCompany] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyCompany] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyCompany] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyCompany] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyCompany] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyCompany] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyCompany] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyCompany] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyCompany] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyCompany] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyCompany] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyCompany] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyCompany] SET RECOVERY FULL 
GO
ALTER DATABASE [MyCompany] SET  MULTI_USER 
GO
ALTER DATABASE [MyCompany] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyCompany] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyCompany] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyCompany] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MyCompany] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyCompany] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyCompany', N'ON'
GO
ALTER DATABASE [MyCompany] SET QUERY_STORE = OFF
GO
USE [MyCompany]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 05/11/2024 12:54:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Dname] [nvarchar](50) NULL,
	[Dnum] [int] NOT NULL,
	[MGRSSN] [int] NULL,
	[MGRStart Date] [datetime] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Dnum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dependent]    Script Date: 05/11/2024 12:54:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dependent](
	[ESSN] [int] NOT NULL,
	[Dependent_name] [nvarchar](255) NOT NULL,
	[Sex] [nvarchar](255) NULL,
	[Bdate] [datetime] NULL,
 CONSTRAINT [PK_Dependent] PRIMARY KEY CLUSTERED 
(
	[ESSN] ASC,
	[Dependent_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 05/11/2024 12:54:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Fname] [nvarchar](50) NULL,
	[Lname] [nvarchar](50) NULL,
	[SSN] [int] NOT NULL,
	[Bdate] [datetime] NULL,
	[Address] [nvarchar](50) NULL,
	[Sex] [nvarchar](50) NULL,
	[Salary] [int] NULL,
	[Superssn] [int] NULL,
	[Dno] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[SSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 05/11/2024 12:54:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Pname] [nvarchar](50) NULL,
	[Pnumber] [int] NOT NULL,
	[Plocation] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Dnum] [int] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Pnumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works_for]    Script Date: 05/11/2024 12:54:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works_for](
	[ESSn] [int] NOT NULL,
	[Pno] [int] NOT NULL,
	[Hours] [int] NULL,
 CONSTRAINT [PK_Works_for] PRIMARY KEY CLUSTERED 
(
	[ESSn] ASC,
	[Pno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Departments] ([Dname], [Dnum], [MGRSSN], [MGRStart Date]) VALUES (N'DP1', 10, 223344, NULL)
INSERT [dbo].[Departments] ([Dname], [Dnum], [MGRSSN], [MGRStart Date]) VALUES (N'DP2', 20, 968574, CAST(N'2006-01-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Departments] ([Dname], [Dnum], [MGRSSN], [MGRStart Date]) VALUES (N'DP3', 30, 512463, CAST(N'2006-01-06T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Dependent] ([ESSN], [Dependent_name], [Sex], [Bdate]) VALUES (112233, N'Hala Saied Ali', N'F', CAST(N'1970-10-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Dependent] ([ESSN], [Dependent_name], [Sex], [Bdate]) VALUES (223344, N'Ahmed Kamel Shawki', N'M', CAST(N'1998-03-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Dependent] ([ESSN], [Dependent_name], [Sex], [Bdate]) VALUES (223344, N'Mona Adel Mohamed', N'F', CAST(N'1975-04-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Dependent] ([ESSN], [Dependent_name], [Sex], [Bdate]) VALUES (321654, N'Omar Amr Omran', N'M', CAST(N'1993-03-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Dependent] ([ESSN], [Dependent_name], [Sex], [Bdate]) VALUES (321654, N'Ramy Amr Omran', N'M', CAST(N'1990-01-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Dependent] ([ESSN], [Dependent_name], [Sex], [Bdate]) VALUES (321654, N'Sanaa Gawish', N'F', CAST(N'1973-05-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Dependent] ([ESSN], [Dependent_name], [Sex], [Bdate]) VALUES (512463, N'Nora Ghaly', N'F', CAST(N'1976-06-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Dependent] ([ESSN], [Dependent_name], [Sex], [Bdate]) VALUES (512463, N'Sara Edward', N'F', CAST(N'2001-09-15T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Employee] ([Fname], [Lname], [SSN], [Bdate], [Address], [Sex], [Salary], [Superssn], [Dno]) VALUES (N'Ahmed', N'Ali', 112233, CAST(N'1965-01-01T00:00:00.000' AS DateTime), N'15 Ali fahmy St.Giza', N'M', 1300, 223344, NULL)
INSERT [dbo].[Employee] ([Fname], [Lname], [SSN], [Bdate], [Address], [Sex], [Salary], [Superssn], [Dno]) VALUES (N'Hanaa', N'Sobhy', 123456, CAST(N'1973-03-18T00:00:00.000' AS DateTime), N'38 Abdel Khalik Tharwat St. Downtown.Cairo', N'F', 800, 223344, NULL)
INSERT [dbo].[Employee] ([Fname], [Lname], [SSN], [Bdate], [Address], [Sex], [Salary], [Superssn], [Dno]) VALUES (N'Kamel', N'Mohamed', 223344, CAST(N'1970-10-15T00:00:00.000' AS DateTime), N'38 Mohy el dien abo el Ezz  St.Cairo', N'M', 1800, 321654, 10)
INSERT [dbo].[Employee] ([Fname], [Lname], [SSN], [Bdate], [Address], [Sex], [Salary], [Superssn], [Dno]) VALUES (N'Amr', N'Omran', 321654, CAST(N'1963-09-14T00:00:00.000' AS DateTime), N'44 Hilopolis.Cairo', N'M', 2500, NULL, NULL)
INSERT [dbo].[Employee] ([Fname], [Lname], [SSN], [Bdate], [Address], [Sex], [Salary], [Superssn], [Dno]) VALUES (N'Edward', N'Hanna', 512463, CAST(N'1972-08-19T00:00:00.000' AS DateTime), N'18 Abaas El 3akaad St. Nasr City.Cairo', N'M', 1500, 321654, 30)
INSERT [dbo].[Employee] ([Fname], [Lname], [SSN], [Bdate], [Address], [Sex], [Salary], [Superssn], [Dno]) VALUES (N'Maged', N'Raoof', 521634, CAST(N'1980-06-04T00:00:00.000' AS DateTime), N'18 Kholosi st.Shobra.Cairo', N'M', 1000, 968574, 30)
INSERT [dbo].[Employee] ([Fname], [Lname], [SSN], [Bdate], [Address], [Sex], [Salary], [Superssn], [Dno]) VALUES (N'Mariam', N'Adel', 669955, CAST(N'1982-12-06T00:00:00.000' AS DateTime), N'269 El-Haram st. Giza', N'F', 750, 512463, 20)
INSERT [dbo].[Employee] ([Fname], [Lname], [SSN], [Bdate], [Address], [Sex], [Salary], [Superssn], [Dno]) VALUES (N'Noha', N'Mohamed', 968574, CAST(N'1975-01-02T00:00:00.000' AS DateTime), N'55 Orabi St. El Mohandiseen .Cairo', N'F', 1600, 321654, 20)
GO
INSERT [dbo].[Project] ([Pname], [Pnumber], [Plocation], [City], [Dnum]) VALUES (N'AL Solimaniah', 100, N'Cairo_Alex Road', N'Alex', 10)
INSERT [dbo].[Project] ([Pname], [Pnumber], [Plocation], [City], [Dnum]) VALUES (N'Al Rabwah', 200, N'6th of October City', N'Giza', 10)
INSERT [dbo].[Project] ([Pname], [Pnumber], [Plocation], [City], [Dnum]) VALUES (N'Al Rawdah', 300, N'Zaied City', N'Giza', 10)
INSERT [dbo].[Project] ([Pname], [Pnumber], [Plocation], [City], [Dnum]) VALUES (N'Al Rowad', 400, N'Cairo_Faiyom Road', N'Giza', 20)
INSERT [dbo].[Project] ([Pname], [Pnumber], [Plocation], [City], [Dnum]) VALUES (N'Al Rehab', 500, N'Nasr City', N'Cairo', 30)
INSERT [dbo].[Project] ([Pname], [Pnumber], [Plocation], [City], [Dnum]) VALUES (N'Pitcho american', 600, N'Maady', N'Cairo', 30)
INSERT [dbo].[Project] ([Pname], [Pnumber], [Plocation], [City], [Dnum]) VALUES (N'Ebad El Rahman', 700, N'Ring Road', N'Cairo', 20)
GO
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (112233, 100, 40)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (223344, 100, 10)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (223344, 200, 10)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (223344, 300, 10)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (223344, 500, 10)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (512463, 500, 10)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (512463, 600, 25)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (521634, 300, 6)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (521634, 400, 4)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (521634, 500, 10)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (521634, 600, 20)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (669955, 300, 10)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (669955, 400, 20)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (669955, 700, 7)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (968574, 300, 10)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (968574, 400, 15)
INSERT [dbo].[Works_for] ([ESSn], [Pno], [Hours]) VALUES (968574, 700, 15)
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Employee] FOREIGN KEY([MGRSSN])
REFERENCES [dbo].[Employee] ([SSN])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Employee]
GO
ALTER TABLE [dbo].[Dependent]  WITH CHECK ADD  CONSTRAINT [FK_Dependent_Employee] FOREIGN KEY([ESSN])
REFERENCES [dbo].[Employee] ([SSN])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dependent] CHECK CONSTRAINT [FK_Dependent_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Departments] FOREIGN KEY([Dno])
REFERENCES [dbo].[Departments] ([Dnum])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Departments]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([Superssn])
REFERENCES [dbo].[Employee] ([SSN])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Departments] FOREIGN KEY([Dnum])
REFERENCES [dbo].[Departments] ([Dnum])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Departments]
GO
ALTER TABLE [dbo].[Works_for]  WITH CHECK ADD  CONSTRAINT [FK_Works_for_Employee] FOREIGN KEY([ESSn])
REFERENCES [dbo].[Employee] ([SSN])
GO
ALTER TABLE [dbo].[Works_for] CHECK CONSTRAINT [FK_Works_for_Employee]
GO
ALTER TABLE [dbo].[Works_for]  WITH CHECK ADD  CONSTRAINT [FK_Works_for_Project] FOREIGN KEY([Pno])
REFERENCES [dbo].[Project] ([Pnumber])
GO
ALTER TABLE [dbo].[Works_for] CHECK CONSTRAINT [FK_Works_for_Project]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Manager Relation' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Departments', @level2type=N'CONSTRAINT',@level2name=N'FK_Departments_Employee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Work Relation' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'CONSTRAINT',@level2name=N'FK_Employee_Departments'
GO
USE [master]
GO
ALTER DATABASE [MyCompany] SET  READ_WRITE 
GO
