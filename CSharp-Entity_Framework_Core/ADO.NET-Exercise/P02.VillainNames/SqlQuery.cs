namespace ProblemsOnADO.NET
{
    public static class SqlQuery
    {
        public const string VillainsNamesAndTheirMinions =
                @"  SELECT 
                    CONCAT_WS(' - ',v.Name, COUNT(*)) AS [Output]
                    FROM Villains AS v
                    JOIN MinionsVillains AS mv
                    ON mv.VillainId = v.Id
                    JOIN Minions AS m
                    ON m.Id = mv.MinionId
                    GROUP BY v.Id, v.Name
                    HAVING COUNT(*) > @minMinions
                    ORDER BY COUNT(*) DESC
                ";

        public const string MinionNamesForVillian =
                @"
                    SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                             m.Name, 
                                                             m.Age
                                                        FROM MinionsVillains AS mv
                                                        JOIN Minions As m ON mv.MinionId = m.Id
                                                       WHERE mv.VillainId = @Id
                                                    ORDER BY m.Name
                ";

        public const string GetVillianById =
                @"
                    SELECT Name FROM Villains WHERE Id = @Id
                ";

        public const string GetVillainIdByName =
                @"
                    SELECT Id FROM Villains WHERE Name = @Name
                ";

        public const string GetMinionIdByName =
                @"
                    SELECT Id FROM Minions WHERE Name = @Name
                ";

        public const string GetTownIdByName =
                @"
                    SELECT Id FROM Towns WHERE Name = @townName
                ";

        public const string AddMinion =

                @"
                    INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)
                ";

        public const string AddTown =
                @"
                    INSERT INTO Towns (Name) VALUES (@townName)
                ";

        public const string AddVillain =
                @"
                    INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)
                ";

        public const string AddMinionsVillainsIdKey =
                @"
                    INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)
                ";

        public const string TownsToUpper =
                @"
                    UPDATE Towns
                    SET Name = UPPER(Name)
                    WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)
                ";

        public const string GetAffectedTowns =
                @"
                    SELECT t.Name 
                        FROM Towns as t
                        JOIN Countries AS c ON c.Id = t.CountryCode
                    WHERE c.Name = @countryName
                ";

        public const string GetVillianNameById =
                @"
                    SELECT Name FROM Villains WHERE Id = @villainId
                ";

        public const string DeleteMinionVillainsKey =
                @"
                    DELETE FROM MinionsVillains 
                          WHERE VillainId = @villainId
                ";

        public const string DeleteVillain =
                @"
                    DELETE FROM Villains
                          WHERE Id = @villainId
                ";

        public const string GetAllMinionsNames =
                @"
                    SELECT Name FROM Minions
                ";

        public const string ChangeYearsAndNamesOfMinionsById =
                @"
                    UPDATE Minions
                       SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                     WHERE Id = @Id
                ";

        public const string GetNameAndAgeFromMinions =
                @"
                    SELECT Name, Age FROM Minions
                ";
    }
}
