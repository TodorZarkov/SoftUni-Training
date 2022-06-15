using System;

namespace _07._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            // Група до 5 човека – изкачват Мусала
            // Група от 6 до 12 човека – изкачват Монблан
            // Група от 13 до 25 човека – изкачват Килиманджаро
            // Група от 26 до 40 човека – изкачват К2
            // Група от 41 или повече човека – изкачват Еверест
            int n = int.Parse(Console.ReadLine());
            int groupMembers = 0;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            int totalMembers = 0;
            for (int i = 0; i < n; i++)
            {
                groupMembers = int.Parse(Console.ReadLine());
                if (groupMembers <= 5)
                {
                    p1 += groupMembers;
                }
                else if (groupMembers >= 5 && groupMembers <= 12)
                {
                    p2 += groupMembers;
                }
                else if (groupMembers >= 13 && groupMembers <= 25)
                {
                    p3 += groupMembers;
                }
                else if (groupMembers >= 26 && groupMembers <= 40)
                {
                    p4 += groupMembers;
                }
                else if (groupMembers > 40)
                {
                    p5 += groupMembers;
                }

                totalMembers += groupMembers;
            }
            Console.WriteLine($"{100.0 * p1 / totalMembers:f2}%");
            Console.WriteLine($"{100.0 * p2 / totalMembers:f2}%");
            Console.WriteLine($"{100.0 * p3 / totalMembers:f2}%");
            Console.WriteLine($"{100.0 * p4 / totalMembers:f2}%");
            Console.WriteLine($"{100.0 * p5 / totalMembers:f2}%");
        }
    }
}
