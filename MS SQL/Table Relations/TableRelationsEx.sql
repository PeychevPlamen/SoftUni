CREATE DATABASE [TableRelations]

USE [TableRelations]

--		Problem 1.	One-To-One Relationship

CREATE TABLE [Passports] 
	( 
	[PassportID] INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[PassportNumber] VARCHAR(12)
	)

CREATE TABLE [Persons]
	(
	[PersonID] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[Salary] DECIMAL(9, 2),
	[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE
	)

INSERT INTO [Passports] ([PassportNumber])
	 VALUES
			('N34FG21B')
			,('K65LO4R7')
			,('ZE657QP2')

INSERT INTO [Persons] ([FirstName], [Salary], [PassportID])
	 VALUES
			('Roberto', 43300.00, 102)
			,('Tom', 56100.00, 103)
			,('Yana', 60200.00, 101)

--		Problem 2.	One-To-Many Relationship

CREATE TABLE [Manufacturers]
	(
	[ManufacturerID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[EstablishedOn] DATE NOT NULL
	)

CREATE TABLE [Models]
	(
	[ModelID] INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
	)

INSERT INTO [Manufacturers] ([Name], [EstablishedOn])
	 VALUES
			('BMW', '07/03/1916')
			,('Tesla', '01/01/2003')
			,('Lada', '01/05/1966')

INSERT INTO [Models] ([Name], [ManufacturerID])
	 VALUES
			('X1', 1)
			,('i6', 1)
			,('Model S', 2)
			,('Model X', 2)
			,('Model 3', 2)
			,('Nova', 3)


--		Problem 3.	Many-To-Many Relationship

CREATE TABLE [Students]
	(
	[StudentID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
	)

CREATE TABLE [Exams]
	(
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL
	)

CREATE TABLE [StudentsExams]
	(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]) NOT NULL,
	PRIMARY KEY ([StudentID], [ExamID])
	)

--		Problem 4.	Self-Referencing 

CREATE TABLE [Teachers]
	(
	[TeacherID] INT PRIMARY KEY IDENTITY (101, 1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
	)

INSERT INTO [Teachers] ([Name], [ManagerID])
	 VALUES
		('John', NULL)
		,('Maya', 106)
		,('Silvia', 106)
		,('Ted', 105)
		,('Mark', 101)
		,('Greta', 101)


--		Problem 5.	Online Store Database

CREATE DATABASE [OnlineStore]

USE [OnlineStore]

CREATE TABLE [Cities] 
	(
	[CityID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
	)

CREATE TABLE [Customers]
	(
	[CustomerID] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,[Birthday] DATE
	,[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
	)

CREATE TABLE [ItemTypes]
	(
	[ItemTypeID] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50)
	)

CREATE TABLE [Items]
	(
	[ItemID] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50)
	,[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
	)

CREATE TABLE [Orders]
	(
	[OrderID] INT PRIMARY KEY IDENTITY NOT NULL
	,[CustomerID] INT NOT NULL
	)

ALTER TABLE [Orders]
ADD CONSTRAINT FK_CustomersOrders
FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID])

CREATE TABLE [OrderItems]
	(
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]) NOT NULL
	,[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]) NOT NULL
	, PRIMARY KEY ([OrderID], [ItemID])
	)
	 
--		Problem 6.	University Database

CREATE DATABASE [University]

USE [University]

CREATE TABLE [Subjects]
	(
	[SubjectID] INT PRIMARY KEY IDENTITY NOT NULL
	,[SubjectName] VARCHAR(50) NOT NULL
	)

CREATE TABLE [Majors]
	(
	[MajorID] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	)

CREATE TABLE [Students]
	(
	[StudentID] INT PRIMARY KEY IDENTITY NOT NULL
	,[StudentNumber] INT NOT NULL
	,[StudentName] VARCHAR(50)
	,[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
	)

CREATE TABLE [Payments]
	(
	[PaymentID] INT PRIMARY KEY IDENTITY NOT NULL
	,[PaymentDate] DATE
	,[PaymentAmount] DECIMAL(9, 2)
	,[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
	)

CREATE TABLE [Agenda]
	(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
	,[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]) NOT NULL
	, PRIMARY KEY ([StudentID], [SubjectID])
	)

--		Problem 9.	*Peaks in Rila

USE [Geography]

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM [Mountains] AS m
JOIN PEAKS AS p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC