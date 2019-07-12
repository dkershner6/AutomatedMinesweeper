using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedMinesweeper.API.Models
{
    public class MineResultResponse
    {
        public MineResultResponse(int minesExploded, IEnumerable<MineModel> startingMines)
        {
            MinesExploded = minesExploded;
            PossibleStartingMines = startingMines;
        }

        public int MinesExploded { get; set; }
        public IEnumerable<MineModel> PossibleStartingMines { get; set; }
    }
}
