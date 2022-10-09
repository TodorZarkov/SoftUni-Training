using System;

namespace _05._Date_Modifier
{
    public class Program
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
