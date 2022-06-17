using System;

namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());//N
            int initPower = pokePower;
            int distanceBetweenTargets = int.Parse(Console.ReadLine());//M
            int exhaustionFactor = int.Parse(Console.ReadLine());//Y
            int pokedTargets = 0;
            while (pokePower >= distanceBetweenTargets && pokePower != 0)
            {
                pokePower -= distanceBetweenTargets;
                pokedTargets++;
                if (pokePower !=0) //prevent div by zero
                {
                    if (initPower / pokePower == 2 && initPower % pokePower == 0 && exhaustionFactor != 0)
                    {
                        if (pokePower / exhaustionFactor != 0)
                        {
                            pokePower /= exhaustionFactor;
                        }
                    }

                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);


        }
    }
}
