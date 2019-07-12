using AutomatedMinesweeper.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedMinesweeper.API.Helpers
{
    public static class Exploder
    {
        public static bool WillExplode(int x1, int y1, int r, int x2, int y2)
        {
            return r >= RangeNeeded(x1, y1, x2, y2);
        }

        private static double RangeNeeded(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
