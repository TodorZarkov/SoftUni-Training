namespace BookShop;

using BookShop.Models.Enums;
using Data;
using Initializer;
using System.Globalization;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        //DbInitializer.ResetDatabase(db);
        Console.WriteLine(GetBooksByAgeRestriction(db, "teEN"));
    }

    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        command = new CultureInfo("en-US").TextInfo.ToTitleCase(command);
        AgeRestriction commandEnum;
        if (!Enum.TryParse<AgeRestriction>(command, out commandEnum))
        {
            return string.Empty;
        }

        var filteredBooksByAge = context.Books
            .Where(b => b.AgeRestriction == commandEnum)
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToList();

        StringBuilder sb = new StringBuilder();
        filteredBooksByAge.ForEach(t => sb.AppendLine(t));

        return sb.ToString().TrimEnd();
    }
}


