using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Предпазен найлон -1.50 лв.за кв. метър
            // Боя - 14.50 лв.за литър
            // Разредител за боя - 5.00 лв.за литър
            //            Румен иска да добави още 10 % от количеството боя и 2 кв.м.
            // найлон, разбира се и 0.40 лв.за торбички. Сумата, която се заплаща на майсторите за 1 час работа, е равна
            //на 30 % от сбора на всички разходи за материали.

            //            Входът се чете от конзолата и съдържа точно 4 реда:
            //            1.Необходимо количество найлон(в кв.м.) -цяло число в интервала[1... 100]
            //2.Необходимо количество боя(в литри) -цяло число в интервала[1…100]
            //3.Количество разредител(в литри) - цяло число в интервала[1…30]
            //4.Часовете, за които майсторите ще свършат работата -цяло число в интервала[1…9]

            double nylonPrice = 1.5;
            double paintPrice = 14.5;
            double dissolverPrice = 5;

            int addPaint = 10;
            int addNylon = 2;
            double bagPrice = .4;

            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int dissolver = int.Parse(Console.ReadLine());
            int workingHours = int.Parse(Console.ReadLine());

            double totalMaterialsPrice = (nylon + addNylon) * nylonPrice + (paint + paint * addPaint / 100.0)*paintPrice + dissolver * dissolverPrice + bagPrice;
            double workersPricePerHour = totalMaterialsPrice * 30 / 100;
            double totalWorkersPrice = workersPricePerHour * workingHours;

            double totalRepaintingPrice = totalMaterialsPrice + totalWorkersPrice;

            Console.WriteLine(totalRepaintingPrice);



        }
    }
}
