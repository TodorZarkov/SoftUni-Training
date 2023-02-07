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

CREATE OR ALTER TRIGGER tr_AddToLogsOnAccountUpdate
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
SET Balance = 123.12
WHERE Id = 1
GO

--problem 02. Create Table Emails
CREATE TABLE NotificationEmails
(
      Id BIGINT PRIMARY KEY IDENTITY(1,1)
    , Recipient INT NOT NULL
        ,FOREIGN KEY(Recipient) REFERENCES Accounts(Id)
    , [Subject] VARCHAR(100) NOT NULL
    , Body VARCHAR(300) NOT NULL
)
GO

CREATE OR ALTER TRIGGER tr_Email_On_Log_Update
ON Logs FOR INSERT
AS
    INSERT INTO NotificationEmails (Recipient, [Subject], Body)
    SELECT 
        i.AccountId
        , CONCAT('Balance change for account: '
        , i.AccountId)
        , CONCAT('On ',CONVERT(varchar,GETDATE(),0),' your balance was changed from ',i.OldSum,' to ', i.NewSum,'.')
    FROM inserted AS i
GO

SELECT * FROM NotificationEmails
GO

--problem 03. Deposit Money
CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount MONEY)
AS
    IF @MoneyAmount > 0
    BEGIN
        UPDATE Accounts
        SET Balance += @MoneyAmount
    END
GO

--problem 04. Withdraw Money Procedure
