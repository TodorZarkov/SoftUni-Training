namespace P01_StudentSystem;

using P01_StudentSystem.Data;

public class StartUp
{
    private static void Main(string[] args)
    {
        StudentSystemContext context = new StudentSystemContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}