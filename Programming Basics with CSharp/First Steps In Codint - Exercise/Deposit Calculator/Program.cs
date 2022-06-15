using System;

namespace Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Депозирана сума – реално число в интервала[100.00 … 10000.00]
            //2.Срок на депозита(в месеци) – цяло число в интервала[1…12]
            //3.Годишен лихвен процент – реално число в интервала[0.00 …100.00]
            //Да се отпечата на конзолата сумата в края на срока.
            //сума = депозирана сума + срок на депозита * ((депозирана сума * годишен лихвен процент ) / 12)

            double dep = double.Parse(Console.ReadLine());
            int period = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double sum = dep + period * ((dep * percent/100.0) / 12.0);

            Console.WriteLine(sum);

        }
    }
}
