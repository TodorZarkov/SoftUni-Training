USE Diablo
GO

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
WHERE u.Username = @user AND g.Name = @game

DECLARE @currToPay MONEY = 0
SELECT @currToPay = SUM(i.Price) FROM Items AS i
WHERE i.MinLevel IN(11, 12, 19, 20, 21)

UPDATE UsersGames
   SET Cash -= @currToPay
   WHERE Id = @userGameId
   BEGIN TRY
       INSERT INTO UserGameItems(ItemId, UserGameId)
       SELECT i.Id, @userGameId
       FROM Items AS i
       WHERE i.MinLevel IN(11, 12, 19, 20, 21)
       COMMIT
   END TRY
   BEGIN CATCH
       ROLLBACK
       RETURN
   END CATCH

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