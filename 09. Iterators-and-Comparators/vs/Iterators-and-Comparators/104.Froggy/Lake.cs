using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _104.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;
        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i += 2)
            {

                yield return this.stones[i];
            }
            if ((this.stones.Length - 1) % 2 == 1)
            {
                for (int i = this.stones.Length - 1; i >= 0; i -= 2)
                {
                    yield return this.stones[i];
                }
            }
            else
            {
                for (int i = this.stones.Length - 2; i >= 0; i -= 2)
                {
                    yield return this.stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
