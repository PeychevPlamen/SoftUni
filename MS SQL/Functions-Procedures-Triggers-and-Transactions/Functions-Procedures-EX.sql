USE SoftUni

	--	1.	Employees with Salary Above 35000
  GO

	CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
	AS
	BEGIN
		SELECT FirstName AS [First Name], LastName AS [Last Name]
		  FROM Employees
		 WHERE Salary > 35000
	END

  GO

  EXECUTE dbo.usp_GetEmployeesSalaryAbove35000

  --	2.	Employees with Salary Above Number
  GO

  CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @inputNum DECIMAL(18, 4)
  AS
  BEGIN
		 SELECT FirstName AS [First Name], LastName AS [Last Name]
		   FROM Employees
		  WHERE Salary >= @inputNum
  END

  GO

	EXECUTE dbo.usp_GetEmployeesSalaryAboveNumber 48100

	--	3.	Town Names Starting With

	GO

	CREATE PROCEDURE usp_GetTownsStartingWith @inputString NVARCHAR(10)
	AS
	BEGIN
		DECLARE @lenOfStringInput INT = LEN(@inputString)
		SELECT [Name] AS Town
		  FROM Towns
		 WHERE SUBSTRING(LOWER([Name]), 1, @lenOfStringInput) = LOWER(@inputString)
	END

	GO

	EXECUTE dbo.usp_GetTownsStartingWith 'b'

	--	4.	Employees from Town

	GO

	CREATE PROCEDURE usp_GetEmployeesFromTown @TownsName NVARCHAR(50)
	AS
	BEGIN
		SELECT e.FirstName AS [First Name], e.LastName AS [Last Name]
		  FROM Employees AS e
		  JOIN Addresses AS a ON e.AddressID = a.AddressID
		  JOIN Towns AS t ON a.TownID = t.TownID
		  WHERE t.[Name] = @TownsName
	END

	GO

	EXECUTE dbo.usp_GetEmployeesFromTown 'Sofia'

	--	5.	Salary Level Function

	GO

	CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4)) 
	RETURNS VARCHAR(10)
	AS
	BEGIN
		DECLARE @result VARCHAR(10)
			IF(@salary < 30000)
				SET @result = 'Low'
			ELSE IF(@salary BETWEEN 30000 AND 50000)
				SET @result = 'Average'
			ELSE
				SET @result = 'High'
			RETURN @result
	END

	GO

	SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
	  FROM Employees

	  --	6.	Employees by Salary Level

	GO

	CREATE PROCEDURE usp_EmployeesBySalaryLevel @levelOfSalary VARCHAR(10)
	AS
	BEGIN
		SELECT FirstName AS [First Name], LastName AS [Last Name]
		  FROM Employees
		 WHERE dbo.ufn_GetSalaryLevel([Salary]) = @levelOfSalary	
	END

	GO

	EXECUTE dbo.usp_EmployeesBySalaryLevel 'High'

	--	7.	Define Function

	GO

	CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50)) 
	RETURNS BIT 
	BEGIN
	DECLARE @Count INT = 1
	   WHILE (@Count <= LEN(@word))
		BEGIN
			DECLARE @CurrentLetter CHAR(1) = SUBSTRING(@word, @Count, 1)
				IF CHARINDEX(@CurrentLetter, @setOfLetters) = 0
			RETURN 0
		SET @Count += 1
	    END 
	RETURN 1
	END

	GO 

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') AS Result

--	8.	* Delete Employees and Departments

GO

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
    ---First we need to delete all records from EmployeesProjects where EmployeeID is one of the lately deleted
    DELETE FROM [EmployeesProjects]
    WHERE [EmployeeID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
    
    ---We need to set ManagerID to NULL of all Employees which have their Manager lately deleted
    UPDATE [Employees]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
 
    ---We need to alter ManagerID column from Departments in order to be nullable because we need to set
    ---ManagerID to NULL of all Departments that have their Manager lately deleted
    ALTER TABLE [Departments]
    ALTER COLUMN [ManagerID] INT
 
    ---We need to set ManagerID to NULL (no Manager) to all departments that have their Manager lately deleted
    UPDATE [Departments]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
    
    ---We need to delete all employees from the lately deleted department
    DELETE FROM [Employees]
    WHERE [DepartmentID] = @departmentId
 
    ---Lastly we delete wanted department
    DELETE FROM [Departments]
    WHERE [DepartmentID] = @departmentId
 
    SELECT COUNT(*)
      FROM [Employees]
     WHERE [DepartmentID] = @departmentId
END

GO