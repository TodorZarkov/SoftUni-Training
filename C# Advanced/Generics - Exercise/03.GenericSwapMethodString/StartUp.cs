using System;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                box.Items.Add(line);
            }
            int[] swapData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(swapData[0], swapData[1]);
            Console.WriteLine(box);

        }
    }
}
