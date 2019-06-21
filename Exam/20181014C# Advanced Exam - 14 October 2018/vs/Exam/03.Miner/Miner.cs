using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Miner
{
    class Miner
    {
        public Miner(bool isAlive, int row, int col)
        {
            IsAlive = isAlive;
            Row = row;
            Col = col;
        }

        public bool IsAlive { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
