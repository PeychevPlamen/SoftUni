CREATE DATABASE School
USE School

--	Section 1. DDL (30 pts)

CREATE TABLE Students
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT NOT NULL CHECK(Age BETWEEN 5 AND 100),
[Address] NVARCHAR(50),
Phone NCHAR(10)
)

CREATE TABLE Subjects
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT NOT NULL CHECK(Lessons > 0)
)

CREATE TABLE StudentsSubjects
(
Id INT PRIMARY KEY IDENTITY,
StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
Grade DECIMAL(3, 2) NOT NULL CHECK(Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams
(
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME,
SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams
(
StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
ExamId INT NOT NULL FOREIGN KEY REFERENCES Exams(Id),
Grade DECIMAL(3, 2) NOT NULL CHECK(Grade BETWEEN 2 AND 6)
PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
[Address] NVARCHAR(20) NOT NULL,
Phone CHAR(10),
SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers
(
StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers(Id)
PRIMARY KEY(StudentId, TeacherId)
)

--	Section 2. DML (10 pts)

--	2. Insert

INSERT INTO Teachers (FirstName, LastName, [Address], Phone, SubjectId)
VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', 3105500146, 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', 3324874824, 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', 4373065154, 5),
('Bert', 'Ivie', '2 Gateway Circle', 4409584510, 4)

INSERT INTO Subjects ([Name], Lessons)
VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

--	3. Update

UPDATE StudentsSubjects SET Grade = 6.00
WHERE SubjectId IN (1, 2) AND Grade >= 5.50

--	4. Delete

DELETE FROM StudentsTeachers
WHERE TeacherId IN (
SELECT Id FROM Teachers
WHERE Phone LIKE '%72%'
)

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

--	Section 3. Querying (40 pts)

--	5. Teen Students

SELECT FirstName, LastName, Age 
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

--	6. Students Teachers

SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS TeachersCount 
FROM Students AS s
JOIN StudentsTeachers AS st ON s.Id = st.StudentId
GROUP BY s.FirstName, s.LastName

--	7. Students to Go

SELECT CONCAT(s.FirstName, ' ' , s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

--	8. Top Students

SELECT TOP (10) s.FirstName, s.LastName, FORMAT(AVG(se.Grade), 'N2') AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON s.Id = se.StudentId
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

--	9. Not So In The Studying

SELECT CONCAT_WS(' ', s.FirstName, s.MiddleName, s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]

--	10. Average Grade per Subject

SELECT s.[Name], AVG(ss.Grade) AS AverageGrade
FROM Subjects AS s
JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
GROUP BY s.[Name], ss.SubjectId
ORDER BY ss.SubjectId

--	Section 4. Programmability (20 pts)

--	11. Exam Grades

GO

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3, 2))
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @studentExist INT = 
	(
	SELECT Id FROM Students
	WHERE Id = @studentId
	)
		IF (@studentExist IS NULL) 
	RETURN 'The student with provided id does not exist in the school!'
		IF (@grade > 6.00)
	RETURN 'Grade cannot be above 6.00!'

	RETURN CONCAT('You have to update ',
	(
	 SELECT COUNT(se.StudentId) 
	   FROM Students AS s
	   JOIN StudentsExams AS se ON s.Id = se.StudentId
	  WHERE Grade BETWEEN @grade AND @grade + 0.5 AND s.Id = @studentId
   GROUP BY se.StudentId),
   ' grades for the student ', 
   (
    SELECT FirstName 
      FROM Students
	 WHERE Id = @studentId
	 ))
END

GO

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

--	12. Exclude from school

GO

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @studentToDelete INT = 
	(
	SELECT Id FROM Students
	WHERE Id = @StudentId
	)

	IF (@studentToDelete IS NULL)
	BEGIN
	RAISERROR('This school has no student with the provided id!',16, 1)
	RETURN
	END

DELETE FROM StudentsExams
WHERE StudentId = @studentToDelete

DELETE FROM StudentsSubjects
WHERE StudentId = @studentToDelete

DELETE FROM StudentsTeachers
WHERE StudentId = @studentToDelete

DELETE FROM Students
WHERE Id = @studentToDelete

END

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students
EXEC usp_ExcludeFromSchool 301