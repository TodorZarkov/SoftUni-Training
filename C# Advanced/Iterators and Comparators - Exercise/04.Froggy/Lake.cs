using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    internal class Lake : IEnumerable<int>
    {
        private List<int> stones;
        public Lake(params int[] stones)
        {
            this.stones = new List<int>(stones);
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i+=2)
            {
                yield return stones[i];
            }
            int nextStart = stones.Count - 1;
            if (nextStart % 2 ==0)
            {
                nextStart--;
            }
            for (int i = nextStart; i > 0; i-=2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
