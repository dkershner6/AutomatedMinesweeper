using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedMinesweeper.API.Models
{
    public class MineModel
    {
        public MineModel(int x, int y, int r)
        {
            X = x;
            Y = y;
            R = r;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int R { get; set; }
    }
}
