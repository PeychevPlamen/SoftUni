--Section 1. DDL (30 pts)

CREATE DATABASE CigarShop
USE CigarShop

CREATE TABLE Sizes
(
Id INT PRIMARY KEY IDENTITY,
[Length] INT NOT NULL CHECK([Length] BETWEEN 10 AND 25),
RingRange DECIMAL(16, 2) NOT NULL CHECK(RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes
(
Id INT PRIMARY KEY IDENTITY,
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
Id INT PRIMARY KEY IDENTITY,
BrandName VARCHAR(30) NOT NULL UNIQUE,
BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
Id INT PRIMARY KEY IDENTITY,
CigarName VARCHAR(80) NOT NULL,
BrandId INT NOT NULL FOREIGN KEY REFERENCES Brands(Id),
TastId INT NOT NULL FOREIGN KEY REFERENCES Tastes(Id),
SizeId INT NOT NULL FOREIGN KEY REFERENCES Sizes(Id),
PriceForSingleCigar DECIMAL(18, 2) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
Id INT PRIMARY KEY IDENTITY,
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(50) NOT NULL,
AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars
(
ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id),
CigarId INT NOT NULL FOREIGN KEY REFERENCES Cigars(Id),
PRIMARY KEY(ClientId, CigarId)
)

--	Section 2. DML (10 pts)

--	2.	Insert

INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00,'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000),
('Athens', 'Greece', '4342 McDonald Avenue', 10435),
('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)

--	3.	Update

UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar * 1.20
WHERE TastId IN (SELECT Id FROM Tastes WHERE TasteType = 'Spicy')

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--	4.	Delete

DELETE FROM Clients
WHERE AddressId IN (SELECT Id FROM Addresses
WHERE Country LIKE 'C%')

DELETE FROM Addresses
WHERE Country LIKE 'C%'

--	Section 3. Querying (40 pts)

--	5.	Cigars by Price

SELECT CigarName, PriceForSingleCigar, ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC

--	6.	Cigars by Taste

SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength
FROM Cigars AS c
JOIN Tastes AS t ON t.Id = c.TastId
WHERE t.TasteType IN ('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC

--	7.	Clients without Cigars

SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS ClientName, c.Email
FROM ClientsCigars AS cc
RIGHT JOIN Clients AS c ON c.Id = cc.ClientId
WHERE cc.CigarId IS NULL
ORDER BY ClientName

--	8.	First 5 Cigars

SELECT TOP (5) c.CigarName, c.PriceForSingleCigar, c.ImageURL
FROM Cigars AS c
JOIN Sizes AS s ON s.Id = c.SizeId
WHERE s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

--	9.	Clients with ZIP Codes

SELECT 
CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
a.Country,
a.ZIP,
CONCAT('$', MAX(cig.PriceForSingleCigar)) AS CigarPrice 
FROM Clients AS c
JOIN Addresses AS a ON a.Id = c.AddressId
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS cig ON cig.Id = cc.CigarId
WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP
ORDER BY FullName
 

 --	10.	Cigars by Size

 SELECT 
 c.LastName , 
 AVG(s.[Length]) AS CiagrLength,
 CEILING(AVG(s.RingRange)) AS CiagrRingRange
 FROM Clients AS c
JOIN ClientsCigars AS cc ON c.Id= cc.ClientId
JOIN Cigars AS cig ON cig.Id = cc.CigarId
JOIN Sizes AS s ON s.Id = cig.SizeId
GROUP BY c.LastName
ORDER BY CiagrLength DESC

--Section 4. Programmability (20 pts)

--	11.	Client with Cigars

GO

CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(50)) 
RETURNS INT
AS
BEGIN
	DECLARE @output INT = 
	(SELECT COUNT(*)
	FROM CLIENTS AS c
	JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
	JOIN Cigars AS cig ON cig.Id = cc.CigarId
	WHERE c.FirstName = @name)

	RETURN @output
END

GO

--SELECT dbo.udf_ClientWithCigars('Betty')

--	12.	Search for Cigar with Specific Taste

GO

CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT
	cig.CigarName,
	CONCAT('$', cig.PriceForSingleCigar) AS Price,
	t.TasteType,
	b.BrandName,
	CONCAT(s.[Length], ' cm') AS CigarLength,
	CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM Cigars AS cig
	JOIN Brands AS b ON b.Id = cig.BrandId
	JOIN Tastes AS t ON t.Id = cig.TastId
	JOIN Sizes AS s ON s.Id =cig.SizeId
	WHERE t.TasteType IN (@taste)
	ORDER BY CigarLength, CigarRingRange DESC
END

GO

--EXEC usp_SearchByTaste 'Woody'