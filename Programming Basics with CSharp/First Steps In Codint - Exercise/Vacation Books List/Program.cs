using System;

namespace Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //От конзолата се четат 3 реда:
            //1.Брой страници в текущата книга – цяло число в интервала[1…1000]
            //2.Страници, които прочита за 1 час – цяло число в интервала[1…1000]
            //3.Броят на дните, за които трябва да прочете книгата – цяло число в интервала[1…1000]

            //Да се отпечата на конзолата броят часове, които Жоро трябва да отделя за четене всеки ден.

            int pagesCurrBook = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysForBook = int.Parse(Console.ReadLine());

            int daysForRead = pagesCurrBook / pagesPerHour / daysForBook;

           //Console.WriteLine();
            Console.WriteLine(daysForRead);
        }
    }
}
