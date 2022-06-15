using System;

namespace _06._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double academyPoits = double.Parse(Console.ReadLine());
            int juryNumber = int.Parse(Console.ReadLine());
            string juryMember = "";
            double juryPoits = 0;

            //points = initial points + juryMembrLentghName*juryMemberPoints/2 >1250.5

            for (int i = 0; i < juryNumber; i++)
            {
                juryMember = Console.ReadLine();
                juryPoits = double.Parse(Console.ReadLine());
                academyPoits += juryMember.Length * juryPoits / 2;
                if (academyPoits > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {academyPoits:f1}!");
                    return;
                }
            }
            Console.WriteLine($"Sorry, {actorName} you need {1250.5-academyPoits:f1} more!");
        }
    }
}
