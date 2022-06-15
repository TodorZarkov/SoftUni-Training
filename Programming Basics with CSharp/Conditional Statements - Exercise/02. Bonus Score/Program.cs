using System;

namespace _02._Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());
            double bonus = 0;

            if (score <= 100)
            {
                bonus = 5;
            }
            else if (score > 100 && score <= 1000)
            {
                bonus = score * 20 / 100.0;
            }
            else if (score > 1000)
            {
                bonus = score * 10 / 100.0;
            }

            if (score % 2 == 0)
            {
                bonus++;
            }
            else if (score % 5 == 0)
            {
                bonus += 2;
            }
            double result = score + bonus;


            Console.WriteLine(bonus);
            Console.WriteLine(result);
        }
    }
}
