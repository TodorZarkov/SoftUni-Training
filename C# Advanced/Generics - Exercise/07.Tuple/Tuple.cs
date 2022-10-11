using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<TI1,TI2>
    {
        public Tuple(TI1 item1, TI2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public TI1 Item1 { get; set; }
        public TI2 Item2 { get; set; }

        public override string ToString()
        {

            return $"{string.Join(' ',Item1)} -> {string.Join(' ', Item2)}";
        }
    }
}
