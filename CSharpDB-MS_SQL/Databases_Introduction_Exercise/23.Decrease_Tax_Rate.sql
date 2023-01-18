USE Hotel
GO

UPDATE Payments
SET TaxRate /= 1.03
SELECT TaxRate FROM Payments