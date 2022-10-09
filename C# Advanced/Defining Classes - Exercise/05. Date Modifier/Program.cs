using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            Console.WriteLine(DateModifier.getDifference(startDate, endDate));
        }
    }
}
