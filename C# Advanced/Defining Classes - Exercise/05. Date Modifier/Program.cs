using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = "";
            string endDate = "";

            startDate = Console.ReadLine();
            endDate = Console.ReadLine();

            DateModifier dm = new DateModifier();
            Console.WriteLine(dm.getDifference(startDate, endDate));
        }
    }
}
