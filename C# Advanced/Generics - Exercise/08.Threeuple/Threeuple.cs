using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<TI1,TI2,TI3>
    {
        public Threeuple(TI1 item1, TI2 item2, TI3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public TI1 Item1 { get; set; }
        public TI2 Item2 { get; set; }
        public TI3 Item3 { get; set; }

        public override string ToString()
        {

            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
