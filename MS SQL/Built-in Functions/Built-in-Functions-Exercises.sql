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


