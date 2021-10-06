USE SoftUni

  --		1.	Employee Address

    SELECT TOP (5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
      FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
  ORDER BY e.AddressID

  --		2.	Addresses with Towns
  
	 SELECT TOP (50) 
			 e.FirstName, 
			 e.LastName,
			 t.[Name], 
			 a.AddressText
       FROM Employees AS e
       JOIN Addresses AS a ON e.AddressID = a.AddressID
       JOIN Towns AS t ON a.TownID = t.TownID
   ORDER BY FirstName, LastName

   --		3.	Sales Employee

   SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
     FROM Employees AS e
	 JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
 ORDER BY e.EmployeeID

	--		4.	Employee Departments

 SELECT TOP (5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
   FROM Employees AS e
   JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
   WHERE e.Salary > 15000
ORDER BY e.DepartmentID

	--		5.	Employees Without Project

	SELECT TOP (3) e.EmployeeID, e.FirstName
	  FROM Employees AS e
	  LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
     WHERE ep.ProjectID IS NULL
  ORDER BY e.EmployeeID
	 
	 --		6.	Employees Hired After

	 SELECT e.FirstName, e. LastName, e.HireDate, d.[Name] AS DeptName
	   FROM Employees AS e
	   JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	  WHERE e.HireDate > '01/01/1999' 
	        --AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
		      AND d.[Name] IN ('Sales', 'Finance')
   ORDER BY e.HireDate

	--		7.	Employees with Project

	SELECT TOP (5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
	  FROM Employees AS e
	  JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	  JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	 WHERE p.StartDate > '08/13/2002' AND p.EndDate IS NULL
  ORDER BY e.EmployeeID

	--		8.	Employee 24

	SELECT *
	  FROM Employees AS e
	  JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	  JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	 WHERE e.EmployeeID = 24