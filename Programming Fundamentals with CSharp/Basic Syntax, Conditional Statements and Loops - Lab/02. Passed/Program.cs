﻿using System;

namespace _02._Passed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float grade = float.Parse(Console.ReadLine());
            if (grade >= 3)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
