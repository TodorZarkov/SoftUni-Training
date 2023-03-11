namespace BookShop;

using BookShop.Models;
using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;
using Z.EntityFramework.Plus;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

        //Console.WriteLine(GetBooksByAgeRestriction(db, "teEN"));
        //Console.WriteLine(GetGoldenBooks(db));
        //Console.WriteLine(GetBooksByPrice(db));
        //Console.WriteLine(GetBooksNotReleasedIn(db, 1998));
        //Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));
        //Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));
        //Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));
        //Console.WriteLine(GetBookTitlesContaining(db, "WOR"));
        //Console.WriteLine(GetBooksByAuthor(db,  "po"));
        //Console.WriteLine(CountBooks(db, 40));
        //Console.WriteLine(CountCopiesByAuthor(db));
        //Console.WriteLine(GetTotalProfitByCategory(db));
        //Console.WriteLine(GetMostRecentBooks(db));
        //IncreasePrices(db);
        //Console.WriteLine(RemoveBooks(db));
    }

    //p.02. Age Restriction 
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

    //p.03. Golden Books
    public static string GetGoldenBooks(BookShopContext context)
    {
        var goldenBooks = context.Books
            .Where(b => b.EditionType == EditionType.Gold &&
                        b.Copies < 5000)
            .Select(b => b.Title)
            .ToList();

        StringBuilder sb = new StringBuilder();
        goldenBooks.ForEach(t => sb.AppendLine(t));

        return sb.ToString().TrimEnd();
    }

    //p.04. Books by Price 
    public static string GetBooksByPrice(BookShopContext context)
    {
        var booksByPrice = context.Books
            .Where(b => b.Price > 40m)
            .OrderByDescending(b => b.Price)
            .Select(b => $"{b.Title} - ${b.Price:f2}")
            .ToList();

        StringBuilder sb = new StringBuilder();
        booksByPrice.ForEach(tp => sb.AppendLine(tp));

        return sb.ToString().TrimEnd();
    }

    //p.05. Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var bookTitlesFiltered = context.Books
            .Where(b => b.ReleaseDate.HasValue &&
                        b.ReleaseDate.Value.Year != year)
            .Select(b => b.Title)
            .ToList();

        StringBuilder sb = new StringBuilder();
        bookTitlesFiltered.ForEach(t => sb.AppendLine(t));
        return sb.ToString().TrimEnd();
    }

    //p.06. Book Titles by Category
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        HashSet<string> inputCategories = input
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLower())
            .ToHashSet();

        var titlesByCategory = context.Books
            .Join(
                context.BooksCategories,
                b => b.BookId,
                bc => bc.BookId,
                (b, bc) => new { b, bc })
            .Join(
                context.Categories,
                bbc => bbc.bc.CategoryId,
                c => c.CategoryId,
                (bbc, c) => new { bbc, c })
            .Where(bbcc => inputCategories.Contains(bbcc.c.Name.ToLower()))
            .Select(bbcc => bbcc.bbc.b.Title)
            .OrderBy(t => t)
            .ToList();
        //.ToQueryString();

        StringBuilder sb = new StringBuilder();
        titlesByCategory.ForEach(t => sb.AppendLine(t));

        return sb.ToString().TrimEnd();
    }

    //p.07. Released Before Date
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        DateTime dateFormated;
        if (!DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture ,DateTimeStyles.None, out dateFormated))
        {
            return string.Empty;
        }

        var booksInfo = context
            .Books
            .Where(b => b.ReleaseDate < dateFormated)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                Title = b.Title,
                EditionType = b.EditionType.ToString(),
                Price = b.Price.ToString("f2")
            })
            //.ToQueryString();
            .ToList();

        StringBuilder sb = new StringBuilder();
        booksInfo.ForEach(bi => sb.AppendLine($"{bi.Title} - {bi.EditionType} - ${bi.Price}"));

        return sb.ToString().TrimEnd();
    }

    //p.08. Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authorsInfo = context
            .Authors
            .Where(a => a.FirstName.EndsWith(input))
            .OrderBy(a => a.FirstName + " " + a.LastName)
            .Select(a => new { a.FirstName, a.LastName })
            //.ToQueryString;
            .ToList();

        StringBuilder sb = new StringBuilder();
        authorsInfo.ForEach(ai => sb.AppendLine($"{ai.FirstName} {ai.LastName}"));

        return sb.ToString().TrimEnd();
    }

    //p.09. Book Search
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var titlesInfo = context
            .Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            //.ToQueryString;
            .ToList();

        StringBuilder sb = new StringBuilder();
        titlesInfo.ForEach(ti => sb.AppendLine(ti));

        return sb.ToString().TrimEnd();
    }

    //p.10. Book Search by Author
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var titles = context
            .Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .Select(b => new
            {
                b.Title,
                Author = string.Concat(b.Author.FirstName," ", b.Author.LastName)
            })
            .ToList();

        StringBuilder sb = new StringBuilder();
        titles.ForEach(t => sb.AppendLine($"{t.Title} ({t.Author})"));

        return sb.ToString().TrimEnd();
    }

    //p.11. Count Books
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        int bookCount = context
            .Books
            .Where(b => b.Title.Length > lengthCheck)
            .Count();

        return bookCount;
    }

    //p.12. Total Book Copies
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var authorInfo = context
            .Authors
            .Select(a => new
            {
                Name = string.Concat(a.FirstName, " ", a.LastName),
                BooksCount = a.Books.Sum(b => b.Copies)
            })
            .OrderByDescending(a => a.BooksCount)
            .ToList();

        StringBuilder sb = new StringBuilder();
        authorInfo.ForEach(a => sb.AppendLine($"{a.Name} - {a.BooksCount}"));

        return sb.ToString().TrimEnd();
    }

    //p.13. Profit by Category
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        var categoriesInfo = context
            .Categories
            .Select(c => new
            {
                c.Name,

                TotalProfit = c.CategoryBooks
                .Sum(b => (b.Book.Copies * b.Book.Price)),

                TotalProfitFormated = c.CategoryBooks
                .Sum(b => (b.Book.Copies * b.Book.Price))
                .ToString("f2")
            })
            .OrderBy(c => c.Name)
            .OrderByDescending(c => c.TotalProfit)
            .ToList();

        StringBuilder sb = new StringBuilder();
        categoriesInfo.ForEach(c => sb.AppendLine($"{c.Name} ${c.TotalProfitFormated}"));

        return sb.ToString().TrimEnd();
    }

    //p.14. Most Recent Books 
    public static string GetMostRecentBooks(BookShopContext context)
    {
        var categoriesInfo = context
            .Categories
            .Select(c => new
            {
                CategoryName = c.Name,
                BookTitleAndDate = c.CategoryBooks.Select(cb => new
                {
                    BookTitle = cb.Book.Title,
                    BookReleaseDate = cb.Book.ReleaseDate,
                    BookReleasedYear = cb.Book.ReleaseDate.Value.Year
                })
                .OrderByDescending(b => b.BookReleaseDate)
                .Take(3)
                .ToList()
            })
            .OrderBy(c => c.CategoryName)
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var ci in categoriesInfo)
        {
            sb.AppendLine($"--{ci.CategoryName}");
            foreach (var btd in ci.BookTitleAndDate)
            {
                sb.AppendLine($"{btd.BookTitle} ({btd.BookReleasedYear})");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //p.15. Increase Prices 
    public static void IncreasePrices(BookShopContext context)
    {
        DateTime dateToFilterBy = new DateTime(2010, 1, 1);
        var booksFilteredByDate = context
            .Books
            .Where(b => b.ReleaseDate < dateToFilterBy)
            .Update(b => new Book() { Price = b.Price + 5 });
    }

    //p.16. Remove Books 
    public static int RemoveBooks(BookShopContext context)
    {
        int copiesToFilterby = 4200;
        var booksWithNumberOfCopiesFilter = context
            .Books
            .Where(b => b.Copies < copiesToFilterby)
            .Delete();

        return booksWithNumberOfCopiesFilter;
    }
}


