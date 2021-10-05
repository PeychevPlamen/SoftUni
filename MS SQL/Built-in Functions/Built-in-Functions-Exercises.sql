USE SoftUni

--		Problem 1.	Find Names of All Employees by First Name

SELECT [FirstName], [LastName] 
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'

 --		Problem 2.	  Find Names of All employees by Last Name 

 SELECT [FirstName], [LastName] 
   FROM [Employees]
  WHERE [LastName] LIKE '%ei%'

  --	Problem 3.	Find First Names of All Employees

  SELECT FirstName
    FROM Employees
   WHERE DepartmentID IN (3, 10) AND YEAR(HireDate) BETWEEN '1995' AND '2005'

   --	Problem 4.	Find All Employees Except Engineers

   SELECT FirstName, LastName
     FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

	--	Problem 5.	Find Towns with Name Length

	SELECT [Name] 
	  FROM Towns
     WHERE LEN([Name]) IN (5, 6)
  ORDER BY [Name]

  --	Problem 6.	 Find Towns Starting With M, K, B, or E.

  SELECT * 
    FROM Towns
   WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

   --	Problem 7.	 Find Towns Not Starting With

  SELECT * 
    FROM Towns
   WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

	--	Problem 7.	 BUILT IN FUNCTIONS SOLUTION METHOD

  SELECT * 
    FROM Towns
   WHERE NOT LEFT([Name], 1) IN ('R', 'B', 'D')
ORDER BY [Name]

	--	Problem 8.	Create View Employees Hired After 2000 Year

CREATE VIEW [V_EmployeesHiredAfter2000] AS
     SELECT FirstName, LastName 
       FROM Employees
      WHERE YEAR(HireDate) > 2000

	--	Problem 9.	Length of Last Name

	SELECT FirstName, LastName 
	  FROM Employees
	 WHERE DATALENGTH(LastName) IN (5)

	     -- OR --

	 SELECT FirstName, LastName 
	  FROM Employees
	 WHERE LEN(LastName) = 5

	 --	Problem 10.		Rank Employees by Salary

	  SELECT EmployeeID, FirstName, LastName, Salary,
	         DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	    FROM Employees
	   WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC
      
	--	Problem 11.		Find All Employees with Rank 2 *

	SELECT * 
	  FROM
			(SELECT EmployeeID, FirstName, LastName, Salary,
					DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
				FROM Employees
			   WHERE Salary BETWEEN 10000 AND 50000
			) AS RankingTable
	WHERE [Rank] = 2
 ORDER BY Salary DESC

	--	Problem 12.		Countries Holding ‘A’ 3 or More Times

	USE [Geography]

	SELECT CountryName AS [Country Name], 
	       IsoCode AS [ISO Code] 
	  FROM Countries
	 WHERE CountryName LIKE ('%A%A%A%')
  ORDER BY IsoCode

  --	Problem 13.		Mix of Peak and River Names

  SELECT p.PeakName, r.RiverName,
		 LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS Mix
    FROM Peaks AS p, 
	     Rivers AS r
   WHERE LOWER(RIGHT(PeakName, 1)) = LOWER(LEFT(RiverName, 1))
ORDER BY Mix

	--	Problem 14.	Games from 2011 and 2012 year

	USE Diablo

	SELECT TOP 50 [Name],  FORMAT([Start], 'yyyy-MM-dd') AS [Start]
	  FROM Games
	 WHERE YEAR([Start]) BETWEEN 2011 AND 2012
  ORDER BY [Start], [Name] 

	--	Problem 15.	 User Email Providers

	SELECT Username, 
	       SUBSTRING(Email,CHARINDEX('@',Email,1)+1,LEN(Email)-CHARINDEX('@',Email,1)+1) 
		   AS [Email Provider]
	  FROM Users
  ORDER BY [Email Provider], Username

  --	Problem 16.	 Get Users with IPAdress Like Pattern

  SELECT Username, IpAddress 
    FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

	--	Problem 17.	 Show All Games with Duration and Part of the Day
	
	SELECT [Name] AS Game,
		   CASE
		      WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
			  WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
			  WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
			END
			      AS [Part of the Day],
		    CASE
			  WHEN Duration <= 3 THEN 'Extra Short'
			  WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
			  WHEN Duration > 6 THEN 'Long'
			  ELSE 'Extra Long'
		    END
		          AS Duration
	  FROM Games
  ORDER BY Game, Duration
	 
	 --		Problem 18.	 Orders Table

	 USE Orders

	 SELECT ProductName,OrderDate,
	       DATEADD(DAY,3,OrderDate) AS [Pay Due],
	       DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
       FROM Orders
	 
	 --		Problem 19.	 People Table

	CREATE TABLE People
	(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50),
	Birthdate DATETIME2
	)

	INSERT INTO People 
	VALUES
     ('Victor', '1998-07-02')
    ,('Steven', '1991-10-10')
    ,('Stephen', '1996-06-20')
    ,('John', '2001-01-16')

	SELECT [Name],
			DATEDIFF(YEAR,[Birthdate], GETDATE()) AS [Age in Years],
			DATEDIFF(MONTH,[Birthdate], GETDATE()) AS [Age in Months],
			DATEDIFF(DAY,[Birthdate], GETDATE()) AS [Age in Days],
			DATEDIFF(MINUTE,[Birthdate], GETDATE()) AS [Age in Minutes]
      FROM People