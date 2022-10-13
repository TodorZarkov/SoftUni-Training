using System;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            StringBuilder sb = new StringBuilder();
            foreach (var stone in lake)
            {
                sb.Append(stone);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 1);
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
