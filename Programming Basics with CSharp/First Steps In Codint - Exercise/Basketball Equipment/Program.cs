using System;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {

            // такса вход
            // кецове –     цената им е 40 % по - малка от таксата за една година
            // екип –       цената му е 20 % по - евтина от тази на кецовете

            // топка –      цената ѝ е 1 / 4 от цената на баскетболния екип
            // аксесоари –  цената им е 1 / 5 от цената на баскетболната топка

            double tax = double.Parse(Console.ReadLine());

            double shoes = tax - tax * 40 / 100;
            double outfit = shoes - shoes * 20 / 100;
            double ball = outfit / 4;
            double accesories = ball / 5;

            tax = tax + shoes + ball + accesories + outfit;


            Console.WriteLine(tax);


        }
    }
}
