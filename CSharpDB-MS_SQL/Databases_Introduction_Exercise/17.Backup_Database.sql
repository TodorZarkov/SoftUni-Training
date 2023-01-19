BACKUP DATABASE SoftUni
TO DISK = '/var/opt/mssql/data/softuni-backup-last.bak'

USE master
GO

ALTER DATABASE SoftUni SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

DROP DATABASE SoftUni
GO

RESTORE DATABASE SoftUni
    FROM DISK = '/var/opt/mssql/data/softuni-backup-last.bak'

