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

