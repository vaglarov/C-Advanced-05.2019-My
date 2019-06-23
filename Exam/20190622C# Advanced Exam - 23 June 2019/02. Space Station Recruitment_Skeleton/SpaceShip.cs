using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceShip
    {
        public SpaceShip(int row, int col, int point, bool isIlive=true)
        {
            Row = row;
            Col = col;
            Point = point;
            IsIlive = isIlive;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Point { get; set; }
        public bool IsIlive { get; set; }
    }
}
