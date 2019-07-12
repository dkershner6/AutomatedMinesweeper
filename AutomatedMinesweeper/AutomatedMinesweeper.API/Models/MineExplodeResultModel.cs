using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedMinesweeper.API.Models
{
    public class MineExplodeResultModel
    {
        public MineExplodeResultModel(MineModel mine, int exploded, List<MineModel> minesThatExploded)
        {
            Mine = mine;
            Exploded = exploded;
            MinesThatExploded = minesThatExploded;
        }

        public MineModel Mine { get; set; }
        public int Exploded { get; set; }

        public List<MineModel> MinesThatExploded { get; set; }
    }
}
