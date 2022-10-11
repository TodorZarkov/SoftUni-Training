using System;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                box.Items.Add(int.Parse(line));
            }
            int[] swapData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(swapData[0], swapData[1]);
            Console.WriteLine(box);
        }
    }
}
