namespace P02_FootballBetting;

using P02_FootballBetting.Data;

internal class StartUp
{
    private static void Main(string[] args)
    {
        FootballBettingContext ctx = new FootballBettingContext();
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
    }
}