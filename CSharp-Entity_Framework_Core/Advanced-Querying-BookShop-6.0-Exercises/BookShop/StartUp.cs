﻿namespace BookShop;

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

        //Console.WriteLine(GetBooksByAgeRestriction(db, "teEN"));
        //Console.WriteLine(GetGoldenBooks(db));
        Console.WriteLine(GetBooksByPrice(db));
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

}


