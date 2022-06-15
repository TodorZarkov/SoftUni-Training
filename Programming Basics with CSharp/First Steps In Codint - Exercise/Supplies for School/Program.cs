using System;

namespace Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            double penPrice = 5.80;
            double markerPrice = 7.20;
            double conditionerPrice = 1.2;

            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int conditioners = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double pensPrice = penPrice * pens;
            double markersPrice = markerPrice * markers;
            double conditionersPrice = conditionerPrice * conditioners;

            double bill = pensPrice + markersPrice + conditionersPrice;
            double billDisc = bill - bill * discount / 100.0;

            Console.WriteLine(billDisc);

        }
    }
}
