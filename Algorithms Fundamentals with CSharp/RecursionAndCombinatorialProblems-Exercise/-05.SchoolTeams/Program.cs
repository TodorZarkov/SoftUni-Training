namespace _05.SchoolTeams
{
    using System;
    using System.Linq;

    public class Program
    {
        private static string[] combGirls;
        private static string[] combBoys;
        private static string[] girls;
        private static string[] boys;
        static void Main(string[] args)
        {
            int girlsInTeam = 3;
            int boysInTeam = 2;
            combGirls = new string[girlsInTeam];
            combBoys = new string[boysInTeam];

            girls = Console.ReadLine().Split(", ");
            boys = Console.ReadLine().Split(", ");

            CombineGirls(0, 0);
        }

        private static void CombineGirls(int index, int elementStartIdx)
        {
            if (index >= combGirls.Length)
            {
                CombineBoys(0, 0);
                return;
            }

            for (int i = elementStartIdx; i < girls.Length; i++)
            {
                combGirls[index] = girls[i];
                CombineGirls(index + 1, i + 1);
            }

        }

        private static void CombineBoys(int index, int elementStartIdx)
        {
            if (index >= combBoys.Length)
            {
                string[] result = new string[combGirls.Length + combBoys.Length];
                combGirls.CopyTo(result, 0);
                combBoys.CopyTo(result, combGirls.Length);
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = elementStartIdx; i < boys.Length; i++)
            {
                combBoys[index] = boys[i];
                CombineBoys(index + 1, i + 1);
            }
        }
    }
}
