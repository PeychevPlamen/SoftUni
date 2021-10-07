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

	SELECT e.EmployeeID, e.FirstName,
			CASE
				WHEN p.StartDate >= '2005' THEN NULL
				ELSE p.[Name]
			END
				AS ProjectName
	  FROM Employees AS e
	  JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	  JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	 WHERE e.EmployeeID = 24

	 --		9.	Employee Manager

	 SELECT A.EmployeeID, A.FirstName, A.ManagerID, B.FirstName AS ManagerName
	   FROM Employees A, Employees B
	  WHERE A.ManagerID IN (3, 7) AND A.ManagerID = B.EmployeeID
   ORDER BY A.EmployeeID

	 --		10. Employee Summary

	 SELECT TOP (50)
	        e.EmployeeID
		   ,CONCAT(e.FirstName,' ', e.LastName) AS EmployeeName
		   ,CONCAT(emp.FirstName, ' ', emp.LastName) AS ManagerName
		   ,d.[Name] AS DepartmentName
	   FROM Employees AS e
	    JOIN Employees AS emp ON e.ManagerID = emp.EmployeeID
	    JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
   ORDER BY e.EmployeeID
	   
	   --	11. Min Average Salary

	   SELECT TOP(1) AVG(Salary) AS MinAverageSalary
         FROM Employees
     GROUP BY DepartmentID
     ORDER BY MinAverageSalary

	 --		12. Highest Peaks in Bulgaria

	 USE [Geography]

	 SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	   FROM Peaks AS p
	   JOIN Mountains AS m ON p.MountainId = m.Id
	   JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
	   JOIN Countries AS c ON mc.CountryCode = c.CountryCode
	  WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
   ORDER BY p.Elevation DESC

   --		13. Count Mountain Ranges

   SELECT mc.CountryCode, COUNT(*) AS MountainRanges
     FROM MountainsCountries AS mc
	 JOIN Mountains AS m ON mc.MountainId = m.Id
	WHERE mc.CountryCode IN ('BG', 'RU', 'US')
 GROUP BY mc.CountryCode

	--		14. Countries with Rivers

	SELECT TOP (5) c.CountryName, r.RiverName
	  FROM Countries AS c
	  LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	  LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	  WHERE c.ContinentCode = 'AF'
   ORDER BY c.CountryName

	 --		15. *Continents and Currencies

	 SELECT ContinentCode, CurrencyCode, CurrCodeCount AS CurrencyUsage
	 FROM
		(
		SELECT  *,
			DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrCodeCount DESC) AS CurrencyCount
		  FROM (
		     SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrCodeCount
			 FROM Countries
			 GROUP BY ContinentCode, CurrencyCode
			 ) AS CurrCodeSubQuery
		WHERE CurrCodeCount > 1
		) AS CurrRankingSubQuery
    WHERE CurrencyCount = 1
 ORDER BY ContinentCode

	--		16.	Countries Without Any Mountains
	
	SELECT COUNT(*) AS [Count]
	  FROM Countries AS c
	  LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	 WHERE mc.MountainId IS NULL
	  
	 --		17. Highest Peak and Longest River by Country

	 SELECT top (5) 
	 c.CountryName
	 , MAX(p.Elevation) AS HighestPeakElevation
	 , MAX(r.[Length]) AS LongestRiverLength
	   FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON m.Id = p.MountainId
		LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
   GROUP BY c.CountryName
   ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName
