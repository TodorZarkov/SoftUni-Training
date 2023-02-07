--problem 01. Create Table Logs
USE Bank
GO
CREATE TABLE Logs (
      LogId BIGINT PRIMARY KEY IDENTITY(1,1)
    , AccountId INT NOT NULL
        ,FOREIGN KEY(AccountId) REFERENCES Accounts(Id)
    , OldSum MONEY 
    , NewSum MONEY
)
GO

CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON Accounts FOR UPDATE
AS
    INSERT INTO Logs(AccountId, OldSum, NewSum)
        SELECT i.Id, d.Balance, i.Balance
        FROM inserted AS i
        JOIN deleted AS d
        ON i.Id = d.Id
        WHERE i.Balance <> d.Balance
GO

SELECT * FROM Accounts

SELECT * FROM Logs

UPDATE Accounts
SET Balance = 200
WHERE Id = 1

--problem 02. Create Table Emails
