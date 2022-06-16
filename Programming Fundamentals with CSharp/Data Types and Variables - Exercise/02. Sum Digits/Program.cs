using System;

namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strNumber = Console.ReadLine();
            int sum = 0;    
            foreach (char item in strNumber)
            {
                sbyte digit = sbyte.Parse(item.ToString());
                sum += digit;
            }
            Console.WriteLine(sum); 
        }
    }
}
