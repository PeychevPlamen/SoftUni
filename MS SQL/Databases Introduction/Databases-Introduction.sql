--Problem 1.	Create Database
CREATE DATABASE Minions

--Problem 2.	Create Tables
CREATE TABLE Minions
(
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
Age TINYINT
)

CREATE TABLE Towns
(
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

USE Minions

--Problem 3.	Alter Minions Table
ALTER TABLE Minions
ADD TownId INT NOT NULL

ALTER TABLE Minions
ADD FOREIGN KEY (Id) REFERENCES Towns(Id)

--Problem 4.	Insert Records in Both Tables
INSERT INTO Towns (Id, [Name])
VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

SELECT * FROM Towns

INSERT INTO Minions (Id, [Name], Age, TownId)
VALUES (1, 'Kevin', 22, 1)

SELECT * FROM Minions

INSERT INTO Minions (Id, [Name], Age, TownId)
VALUES 
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--Problem 5.	Truncate Table Minions
TRUNCATE TABLE Minions

--Problem 6.	Drop All Tables
DROP TABLE Minions;
DROP TABLE Towns;

--Problem 7.	Create Table People
CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture NVARCHAR(MAX),
Height DECIMAL(10, 2),
[Weight] DECIMAL(10, 2),
Gender CHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Pesho', 'pesho.jpg', 170, 55, 'm', '2000-07-15', 'nishto osobeno'),
('Gosho', 'gosho.jpg', 177, 60, 'm', '2000-06-25', 'nishto osobeno2'),
('Pesho2', 'pesho2.jpg', 180, 55.5555, 'm', '2000-07-05', 'nishto osobeno3'),
('Pesho3', 'pesho3.jpg', 150, 55, 'm', '2000-09-15', 'nishto osobeno4'),
('Pesho4', 'pesho4.jpg', 170, 55, 'f', '2000-11-15', 'nishto osobeno5')

SELECT * FROM People

--Problem 8.	Create Table Users

CREATE TABLE Users 
(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARCHAR(MAX),
LastLoginTime DATETIME2,
IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('pe', '123456', 'picture.jpg', '2000-07-15', 1),
('pesho1', '1234567', 'picture1.jpg', '2001-07-15', 0),
('pesho2', '12345678', 'picture2.jpg', '2002-07-15', 0),
('pesho3', '12345679', 'picture3.jpg', '2003-07-15', 1),
('pesho4', '12345670', 'picture4.jpg', '2004-07-15', 1);

SELECT * FROM Users

--Problem 9.	Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07A1259879;

ALTER TABLE Users
ADD PRIMARY KEY (Id, Username)

--Problem 10.	Add Check Constraint
ALTER TABLE Users
ADD CHECK ([Password]>=5);

--Problem 11.	Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT df_LastLoginTime
DEFAULT CURRENT_TIMESTAMP FOR LastLoginTime;

--Problem 12.	Set Unique Field
ALTER TABLE Users
DROP PK__Users__77222459FD6A6282;

ALTER TABLE Users
ADD PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameIsAtLeast3SymbolLong 
CHECK(LEN(Username)>=3)


--Problem 13.	Movies Database

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes)
VALUES
('pesho', 'notes'),
('pesho1', 'notes1'),
('pesho2', 'notes2'),
('pesho3', 'notes3'),
('pesho4', 'notes4')

SELECT * FROM Directors

CREATE TABLE Genres
(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Genres(GenreName, Notes)
VALUES
('horror', 'notes'),
('horror1', 'notes1'),
('horror2', 'notes2'),
('horror3', 'notes3'),
('horror4', 'notes4')

SELECT * FROM Genres

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName, Notes)
VALUES
('horror', 'notes'),
('horror1', 'notes1'),
('horror2', 'notes2'),
('horror3', 'notes3'),
('horror4', 'notes4')

CREATE TABLE Movies
(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT,
CopyrightYear DATE,
[Length] TIME,
GenreId INT,
CategoryId INT,
Rating TINYINT,
Notes NVARCHAR(MAX)
)

INSERT INTO Movies(Title, DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes)
VALUES
('It', 1, '2000-11-12', '1:35:00', 1, 1, 10, 'notes'),
('It2', 3, '2001-5-6', '1:45:50', 2, 2, 10, 'notes'),
('It3', 2, '2020-10-7', '1:15:00', 3, 1, 9, 'notes'),
('It4', 5, '2007-11-11', '1:35:55', 5, 3, 3, 'notes'),
('It5', 4, '2009-12-12', '1:45:50', 4, 1, 10, 'notes')

--Problem 14.	Car Rental Database

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY,
CategoryName VARCHAR(50) NOT NULL,
DailyRate TINYINT NOT NULL,
WeeklyRate TINYINT NOT NULL,
MonthlyRate TINYINT NOT NULL,
WeekendRate TINYINT NOT NULL
)

INSERT INTO Categories 
(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES 
('COMEDY', 5, 9, 6, 6),
('HORROR', 2, 9, 8, 6),
('ACTION', 6, 5, 6, 10)


CREATE TABLE Cars
(
Id INT PRIMARY KEY IDENTITY,
PlateNumber VARCHAR(20) NOT NULL,
Manufacturer VARCHAR(40) NOT NULL,
Model VARCHAR(40),
CarYear TINYINT,
CategoryId INT,
Doors BIT,
Picture VARCHAR(MAX),
Condition VARCHAR(10),
Available VARCHAR(10)
)

ALTER TABLE Cars
ALTER COLUMN CarYear INT;

INSERT INTO Cars 
(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES 
('CA1111CA', 'BMW', '330', 2012, 1, 4, 'BMW.jpg', 'NEW', 'YES'),
('CA2222CA', 'VW', 'Golf', 2020, 2, 5, 'BMW.jpg', 'NEW', 'YES'),
('CA3333CA', 'BMW', '320', 2012, 3, 4, 'BMW2.jpg', 'NEW', 'NO')


CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30),
LastName VARCHAR(30),
Title VARCHAR(30),
Notes VARCHAR(MAX)
)

INSERT INTO Employees (FirstName,LastName,Title,Notes)
VALUES
('PESHO', 'IVANOV', 'CEO', 'notes notes'),
('PESHO1', 'IVANOV1', 'CEO1', 'notes notes1'),
('PESHO2', 'IVANOV2', 'CEO2', 'notes notes2')



CREATE TABLE Customers
(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber VARCHAR(30),
FullName VARCHAR(50) NOT NULL,
[Address] VARCHAR(90) NOT NULL,
City VARCHAR(30) NOT NULL,
ZIPCode INT NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES
('CA9999CB', 'Ivan Ivanov', 'Mladost 58', 'Sofia', 1000, 'some notes'),
('C7777CB', 'Pesho Ivanov', 'Mladost 16', 'Sofia', 1000, 'some notes'),
('CA7171CB', 'Joro Ivanov', 'Mladost 15', 'Plovdiv', 1000, 'some notes')


CREATE TABLE RentalOrders
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT,
CustomerId INT,
CarId INT,
TankLevel INT,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT NOT NULL,
StartDate DATE,
EndDate DATE,
TotalDays INT,
RateApplied INT,
TaxRate INT,
OrderStatus VARCHAR(10),
Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 12, 55, 1000, 1111, 12222, '2021-11-11', '2021-11-12', 1, 9, 6, 'DONE', 'some notes'),
(2, 3, 11, 55, 100, 1111, 12332, '2021-10-11', '2021-11-12', 30, 8, 6, 'DONE', 'some notes'),
(1, 1, 12, 55, 10, 111, 1222, '2021-10-25', '2021-11-12', 15, 9, 6, 'DONE', 'some notes')

--Problem 15.	Hotel Database

CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30),
LastName VARCHAR(30),
Title VARCHAR(30),
Notes VARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES
('JONI', 'KASH', 'SOME TITLE', 'SOME NOTES'),
('JONI2', 'KASH2', 'SOME TITLE1', 'SOME NOTES'),
('JONI3', 'KASH3', 'SOME TITLE2', 'SOME NOTES')

CREATE TABLE Customers
(
AccountNumber INT NOT NULL UNIQUE,
FirstName VARCHAR(30),
LastName VARCHAR(50),
PhoneNumber VARCHAR(90),
EmergencyName VARCHAR(30) NOT NULL,
EmergencyNumber VARCHAR(90) NOT NULL,
Notes VARCHAR(MAX)
)

ALTER TABLE Customers
ADD PRIMARY KEY (AccountNumber);

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
(13, 'pesho', 'ivanov', '+359666666', 'ivan', '+35955555555', 'some notes'),
(15, 'pesho2', 'ivanov2', '+359666666', 'pesh', '+35957755555', 'some notes'),
(14, 'pesho3', 'ivanov3', '+3596655666', 'ivanov', '+35955555555', 'some notes')

CREATE TABLE RoomStatus
(
RoomStatus VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)

ALTER TABLE RoomStatus
ADD PRIMARY KEY (RoomStatus);

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES
('FREE', 'SOME NOTES'),
('OCCUPAIND', 'SOME NOTES'),
('RESERVED', 'SOME NOTES')

CREATE TABLE RoomTypes 
(
RoomTypes VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)

ALTER TABLE RoomTypes
ADD PRIMARY KEY (RoomTypes);

INSERT INTO RoomTypes(RoomTypes, Notes)
VALUES
('single', 'some notes'),
('double', 'some notes'),
('apartment', 'some notes')


CREATE TABLE BedTypes 
(
BedTypes VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)

ALTER TABLE BedTypes
ADD PRIMARY KEY (BedTypes);

INSERT INTO BedTypes(BedTypes, Notes)
VALUES
('king size', 'some notes'),
('single bed', 'some notes'),
('double', 'some notes')

CREATE TABLE Rooms
(
RoomNumber INT PRIMARY KEY NOT NULL,
RoomType VARCHAR(30),
BedType VARCHAR(30),
Rate INT,
RoomStatus VARCHAR(30),
Notes VARCHAR(MAX)
)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
(131, 'apartment', 'king size', 10, 'free', 'some notes'),
(132, 'apartment', 'king size', 10, 'free', 'some notes'),
(133, 'apartment', 'king size', 10, 'free', 'some notes')

CREATE TABLE Payments
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL UNIQUE,
PaymentDate DATE,
AccountNumber INT NOT NULL,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays INT,
AmountCharged INT,
TaxRate INT,
TaxAmount INT,
PaymentTotal INT,
Notes VARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
(5, '2021-7-6', 13, '2021-7-4', '2021-7-9', 5, 55, 3, 15, 66, 'Some notes'),
(7, '2021-7-13', 15, '2021-5-4', '2021-7-9', 5, 57, 3, 15, 86, 'Some notes'),
(9, '2021-7-5', 13, '2021-7-4', '2021-11-9', 6, 55, 6, 25, 76, 'Some notes')

CREATE TABLE Occupancies
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL UNIQUE,
DateOccupied DATE,
AccountNumber INT NOT NULL,
RoomNumber INT,
RateApplied INT,
PhoneCharge INT,
Notes VARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
(100, '2001-11-25', 77, 15, 6, 13, 'some notes'),
(101, '2001-10-25', 57, 14, 6, 13, 'some notes'),
(150, '2001-9-26', 76, 15, 7, 19, 'some notes')



--		Problem 16.	  Create SoftUni Database


CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns 
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(90)
)

CREATE TABLE Addresses
(
Id INT PRIMARY KEY IDENTITY,
AddressText VARCHAR(100),
TownId INT
)

ALTER TABLE Addresses
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

CREATE TABLE Departments 
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(90)
)

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50),
MiddleName VARCHAR(50),
LastName VARCHAR(50),
JobTitle VARCHAR(50),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATE,
Salary DECIMAL(10, 2),
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)


--		Problem 18.		Basic Insert

INSERT INTO Towns
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments
VALUES
('Engineering'),('Sales'),('Marketing'),('Software Development'),('Quality Assurance')


INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88)


--		Problem 19.		Basic Select All Fields

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--		Problem 20.		Basic Select All Fields and Order Them

SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--		Problem 21.		Basic Select Some Fields

SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--		Problem 22.		Increase Employees Salary

UPDATE Employees
SET Salary += Salary * 0.1

SELECT Salary FROM Employees
