using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte inputLength = byte.Parse(Console.ReadLine());
            double kegVolume = 0;
            string kegName = string.Empty;

            for (byte i = 0; i < inputLength; i++)
            {

                string curName = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double curVolume = Math.PI*Math.Pow(radius, 2)*height;
                if (curVolume>kegVolume)
                {
                    kegVolume = curVolume;
                    kegName = curName;
                }
            }
            Console.WriteLine(kegName);

        }
    }
}
