using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strLst = Console.ReadLine().Split('|').ToList();
            strLst.ForEach(x => x.Trim());
            List<int[]> intList = new List<int[]>();
            foreach (string item in strLst)
            {
                intList.Add(item.Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }   
            intList.Reverse();
            List<int> numbers = new List<int>();
            foreach (int[] arrInt in intList)
            {
                foreach (int number in arrInt)
                {
                    numbers.Add(number);
                }
            }
            Console.WriteLine(String.Join(' ',numbers));
            

        }
    }
}
