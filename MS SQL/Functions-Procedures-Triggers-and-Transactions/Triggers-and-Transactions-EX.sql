USE Bank

-- 1. Create Table Logs



SELECT * FROM Accounts
SELECT * FROM AccountHolders


CREATE TABLE Logs
(
    [LogId] INT PRIMARY KEY IDENTITY,
    [AccountId] INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
    [OldSum] DECIMAL NOT NULL,
    [NewSum] DECIMAL NOT NULL
)
GO

CREATE TRIGGER tg_OnAccountsLogChangeOfSum
ON Accounts FOR UPDATE
AS
INSERT Logs (AccountId, OldSum, NewSum)
SELECT i.Id, d.Balance, i.Balance
FROM inserted AS i
JOIN deleted AS d ON d.Id = i.Id
GO 


-- 2.	Create Table Emails


CREATE TABLE NotificationEmails
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Recipient] INT FOREIGN KEY REFERENCES Accounts(Id),
    [Subject] NVARCHAR(MAX),
    [Body] NVARCHAR(MAX)
)

GO

CREATE TRIGGER tg_EmailOnAccountChange
ON Accounts FOR UPDATE
AS
DECLARE @AccountId INT = (SELECT TOP(1) Id FROM inserted)
DECLARE @OldSum DECIMAL = (SELECT Balance FROM deleted) 
DECLARE @NewSum DECIMAL = (SELECT Balance FROM inserted) 
INSERT INTO NotificationEmails(Recipient, Subject, Body) VALUES
(
    @AccountId, 
    'Balance change for account: ' +  CAST(@AccountId AS NVARCHAR(20)) ,
    'On ' + CONVERT(NVARCHAR(30), GETDATE(), 103) + ' your balance was changed from ' + CAST(@OldSum AS NVARCHAR(20)) + ' to ' + CAST(@NewSum AS NVARCHAR(20)) + '.'  
)
GO

-- 3.	Deposit Money


SELECT * FROM AccountHolders
SELECT * FROM Accounts

GO

CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS 

BEGIN TRANSACTION

IF NOT EXISTS (SELECT Id FROM Accounts WHERE Id = @AccountId)
    BEGIN
        ROLLBACK
        RAISERROR('Account is not existing', 16,1)
    END

IF   @MoneyAmount < 0
BEGIN
        ROLLBACK
        RAISERROR('Negative amount', 16,1)
END

UPDATE Accounts SET Balance += @MoneyAmount WHERE Id = @AccountId

COMMIT
GO

