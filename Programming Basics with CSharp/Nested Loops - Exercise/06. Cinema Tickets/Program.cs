using System;

namespace _06._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int overallTickets = 0;
            int studentType = 0;
            int standartType = 0;
            int kidType = 0;
            while (movie != "Finish")
            {
                int places = int.Parse(Console.ReadLine());
                int totalTickets = 0;
                for (int i = 1; i <= places; i++)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }

                    switch (ticketType)
                    {
                        case "student":
                            studentType++;
                            break;
                        case "standard":
                            standartType++;
                            break;
                        case "kid":
                            kidType++;
                            break;
                    }
                    totalTickets++;
                }
                overallTickets += totalTickets;
                Console.WriteLine($"{movie} - {100.0*totalTickets/places:f2}% full.");

                movie = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {overallTickets}");
            Console.WriteLine($"{100.0*studentType/overallTickets:f2}% student tickets.");
            Console.WriteLine($"{100.0*standartType/overallTickets:f2}% standard tickets.");
            Console.WriteLine($"{100.0*kidType/overallTickets:f2}% kids tickets.");
        }
    }
}
