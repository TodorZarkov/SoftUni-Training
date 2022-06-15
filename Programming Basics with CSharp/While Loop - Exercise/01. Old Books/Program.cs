using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            string book = Console.ReadLine();
            int counter = 0;

            while (book != favoriteBook)
            {
                book = Console.ReadLine();
                counter++;
                if (book == "No More Books")
                {
                    Console.WriteLine($"The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    return;
                }
            }
            Console.WriteLine($"You checked {counter} books and found it.");
        }
    }
}
