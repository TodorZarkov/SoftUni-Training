﻿using System;

namespace _04._Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            double h = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());

            if (gender == 'f')
            {
                if (h < 16)
                {
                    Console.WriteLine("Miss");
                }
                else
                {
                    Console.WriteLine("Ms.");
                }
            }
            else if (gender == 'm')
            {
                if (h < 16)
                {
                    Console.WriteLine("Master");
                }
                else
                {
                    Console.WriteLine("Mr.");
                }
            }
        }
    }
}
