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
CREATE OR ALTER PROC usp_DepositMoney(@AccountId INT, @MoneyAmount MONEY)
AS
    IF @MoneyAmount > 0
    BEGIN
        UPDATE Accounts
        SET Balance += @MoneyAmount
        WHERE Id = @AccountId
    END
GO

--problem 04. Withdraw Money Procedure
CREATE OR ALTER PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount MONEY)
AS
    IF @MoneyAmount > 0
    BEGIN
        UPDATE Accounts
        SET Balance -= @MoneyAmount
        WHERE Id = @AccountId
    END
GO

--problem 05. Money Transfer
CREATE OR ALTER PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
    BEGIN TRANSACTION

    DECLARE @beforeAmmount MONEY
    SELECT @beforeAmmount = a.Balance
    FROM Accounts AS a
    WHERE a.Id = @SenderId

    EXEC dbo.usp_WithdrawMoney @SenderId, @Amount

    DECLARE @afterAmmount MONEY
    SELECT @afterAmmount = a.Balance
    FROM Accounts AS a
    WHERE a.Id = @SenderId

    IF ROUND(@afterAmmount,4) <> ROUND((@beforeAmmount - @Amount),4)
        BEGIN
            ROLLBACK
            RETURN
        END
    ELSE
        BEGIN
            SELECT @beforeAmmount = a.Balance
            FROM Accounts AS a
            WHERE a.Id = @ReceiverId

            EXEC dbo.usp_DepositMoney @ReceiverId, @Amount

            SELECT @afterAmmount = a.Balance
            FROM Accounts AS a
            WHERE a.Id = @ReceiverId

            IF ROUND(@afterAmmount,4) <> ROUND((@beforeAmmount + @Amount),4)
                BEGIN
                    ROLLBACK
                    RETURN
                END
            ELSE
                BEGIN
                    COMMIT
                END
        END
GO

EXEC dbo.usp_TransferMoney 5, 1, 5000

SELECT * FROM Accounts
WHERE Id IN(1,5)

--problem 06. *Massive Shopping
USE Diablo
GO

BEGIN TRANSACTION
DECLARE @startItemLevel INT = 11
DECLARE @endItemLevel INT = 12
DECLARE @user NVARCHAR(200) = 'Stamat'
DECLARE @game NVARCHAR(300) = 'Safflower'
DECLARE @userGameId INT
DECLARE @moneyLeft MONEY

SELECT 
     @userGameId = ug.Id
    ,@moneyLeft = ug.Cash
FROM Users AS u
JOIN UsersGames AS ug
ON ug.UserId = u.Id
JOIN UserGameItems ugi
ON ugi.UserGameId = ug.Id
JOIN Games AS g
ON g.Id = ug.GameId
JOIN Items AS i
ON i.Id = ugi.ItemId
WHERE u.Username = @user AND g.Name = @game

DECLARE @currToPay MONEY = 0
SELECT @currToPay = SUM(i.Price) FROM Items AS i
WHERE i.MinLevel BETWEEN @startItemLevel AND @endItemLevel

IF @currToPay > @moneyLeft
BEGIN
    ROLLBACK
    RETURN
END
ELSE
BEGIN
    UPDATE UsersGames
    SET Cash -= @currToPay
    WHERE Id = @userGameId
    BEGIN TRY
        INSERT INTO UserGameItems(ItemId, UserGameId)
        SELECT i.Id, @userGameId
        FROM Items AS i
        WHERE i.MinLevel BETWEEN @startItemLevel AND @endItemLevel
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
        RETURN
    END CATCH
END
--------------------------------------------------

BEGIN TRANSACTION
SET @startItemLevel = 19
SET @endItemLevel = 21

SELECT 
     @userGameId = ug.Id
    ,@moneyLeft = ug.Cash
FROM Users AS u
JOIN UsersGames AS ug
ON ug.UserId = u.Id
JOIN UserGameItems ugi
ON ugi.UserGameId = ug.Id
JOIN Games AS g
ON g.Id = ug.GameId
JOIN Items AS i
ON i.Id = ugi.ItemId
WHERE u.Username = @user AND g.Name = @game

SET @currToPay = 0
SELECT @currToPay = SUM(i.Price) FROM Items AS i
WHERE i.MinLevel BETWEEN @startItemLevel AND @endItemLevel

IF @currToPay > @moneyLeft
BEGIN
    ROLLBACK
    RETURN
END
ELSE
BEGIN
    UPDATE UsersGames
    SET Cash -= @currToPay
    WHERE Id = @userGameId
    BEGIN TRY
        INSERT INTO UserGameItems(ItemId, UserGameId)
        SELECT i.Id, @userGameId
        FROM Items AS i
        WHERE i.MinLevel BETWEEN @startItemLevel AND @endItemLevel
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
        RETURN
    END CATCH
END

SELECT 
    i.Name as [Item Name]
FROM Users AS u
JOIN UsersGames AS ug
ON ug.UserId = u.Id
JOIN UserGameItems ugi
ON ugi.UserGameId = ug.Id
JOIN Games AS g
ON g.Id = ug.GameId
JOIN Items AS i
ON i.Id = ugi.ItemId
WHERE u.Username = @user AND g.Name = @game
ORDER BY i.Name

--problem 07.Employees with Three Projects.
USE SoftUni
GO
CREATE OR ALTER PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
    BEGIN TRANSACTION
    INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
    VALUES (@emloyeeId, @projectID)
    
    DECLARE @numberOfProjects INT
    SELECT 
        @numberOfProjects = COUNT(*)
    FROM EmployeesProjects AS ep
    WHERE ep.EmployeeID = @emloyeeId

    IF @numberOfProjects > 3
    BEGIN
        ROLLBACK;
        THROW 50003, 'The employee has too many projects!', 1
    END
    ELSE
    BEGIN
    COMMIT
    END
GO

SELECT * FROM EmployeesProjects WHERE EmployeeID = 27
EXEC dbo.usp_AssignProject 27, 114

--problem 09.Delete Employees
