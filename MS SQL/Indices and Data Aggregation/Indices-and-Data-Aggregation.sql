USE Gringotts

	--	1. Records’ Count

	SELECT COUNT(*) AS [Count]
	  FROM WizzardDeposits

	--	2. Longest Magic Wand

	SELECT MAX(MagicWandSize) AS LongestMagicWand
	  FROM WizzardDeposits

	  --	3. Longest Magic Wand Per Deposit Groups

	  SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	    FROM WizzardDeposits
	GROUP BY DepositGroup

	--	4. * Smallest Deposit Group Per Magic Wand Size

	  SELECT TOP (2) DepositGroup
	    FROM WizzardDeposits
	GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize)

	--	5. Deposits Sum

	SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	  FROM WizzardDeposits
  GROUP BY DepositGroup

	--	6. Deposits Sum for Ollivander Family

	SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	  FROM WizzardDeposits
	 WHERE MagicWandCreator IN ('Ollivander family')
  GROUP BY DepositGroup

	--	7. Deposits Filter

	--SELECT * 
	--  FROM
	--		(
	--		SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	--		FROM WizzardDeposits
	--		WHERE MagicWandCreator IN ('Ollivander family')
	--		GROUP BY DepositGroup
	--		) AS FilteredTable
	-- WHERE TotalSum < 150000
 -- ORDER BY TotalSum DESC

	      SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
			FROM WizzardDeposits
		   WHERE MagicWandCreator IN ('Ollivander family')
		GROUP BY DepositGroup
		  HAVING SUM(DepositAmount) < 150000
		ORDER BY TotalSum DESC

		--	8.  Deposit Charge

	SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
	  FROM WizzardDeposits
  GROUP BY DepositGroup, MagicWandCreator
  ORDER BY MagicWandCreator, DepositGroup

	--	9. Age Groups

	SELECT AgeGroup, COUNT(AgeGroup) AS WizardCount
	  FROM (
			SELECT *,
				CASE
					WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
					WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
					WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
					WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
					WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
					WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
					ELSE '[61+]'
				END AS AgeGroup
			  FROM WizzardDeposits
			) AS AgeGroupsTable
	GROUP BY AgeGroup

	--	10. First Letter

	SELECT *
	  FROM (
			SELECT SUBSTRING(FirstName, 1, 1) AS FirstLetter
			  FROM WizzardDeposits
		     WHERE DepositGroup IN ('Troll Chest')
			) AS FirstLetterTable
    GROUP BY FirstLetter
	ORDER BY FirstLetter

	--	11. Average Interest 

	SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
	  FROM WizzardDeposits
	  WHERE DepositStartDate > '01/01/1985'
  GROUP BY DepositGroup, IsDepositExpired
  ORDER BY DepositGroup DESC, IsDepositExpired ASC
  
	--	12. * Rich Wizard, Poor Wizard

	SELECT SUM([Difference]) AS SumDifference
	  FROM
	(
	SELECT FirstName AS [Host Wizard]
	     , DepositAmount AS [Host Wizard Deposit]
		 , LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard]
		 , LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit]
		 , DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS [Difference]
	  FROM WizzardDeposits
	  ) AS DifferenceTable

	  --	13. Departments Total Salaries

	  USE SoftUni

	  SELECT DepartmentID, SUM(Salary) AS TotalSalary
	    FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

	--	14. Employees Minimum Salaries

	SELECT DepartmentID, MIN(Salary) AS MinimumSalary
	  FROM Employees
	 WHERE DepartmentID IN (2, 5, 7) AND HireDate > '01/01/2000'
  GROUP BY DepartmentID
  
	--	15. Employees Average Salaries

	SELECT *
	  INTO EmployeeOver30000
	  FROM Employees
	 WHERE Salary > 30000

	 DELETE FROM EmployeeOver30000
	 WHERE ManagerID = 42

	 UPDATE EmployeeOver30000
	    SET Salary += 5000
	  WHERE DepartmentID = 1

	  SELECT DepartmentID, AVG(Salary) AS AverageSalary
	    FROM EmployeeOver30000
    GROUP BY DepartmentID

	--	16. Employees Maximum Salaries

	SELECT DepartmentID, MAX(Salary) AS MaxSalary
	  FROM Employees
  GROUP BY DepartmentID 
	HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

	--	17. Employees Count Salaries

	SELECT COUNT(*) AS [Count]
	  FROM Employees 
	  WHERE ManagerID IS NULL

	  --	18. *3rd Highest Salary

	  SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary
	  FROM
			(
			SELECT *,
				DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS DenseRankRow
			  FROM Employees
			) AS ThirdMaxSalary
	   WHERE DenseRankRow IN (3)
	   
	--	19. **Salary Challenge	

	SELECT TOP (10) e.FirstName, e.LastName, e.DepartmentID
	  FROM Employees AS e
	  WHERE Salary > (
					  SELECT AVG (Salary) AS AvgDeprtmentSalary
					  FROM Employees
					  WHERE DepartmentID = e.DepartmentID
					  GROUP BY DepartmentID
					  )
	ORDER BY e.DepartmentID
	
	 