using AutomatedMinesweeper.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedMinesweeper.API.Helpers
{
    public static class MineResults
    {
        public static MineResultResponse GetForAllMines(List<MineModel> mines)
        {
            var results = new List<MineExplodeResultModel>();

            foreach (var mine in mines)
            {
                results.Add(GetForOneMine(mines, mine));
            }

            int maxMinesExploded = results.Max(r => r.Exploded);

            return new MineResultResponse(maxMinesExploded, results.Where(r => r.Exploded == maxMinesExploded).Select(r => r.Mine));
        }

        public static MineExplodeResultModel GetForOneMine(IEnumerable<MineModel> originalMineList, MineModel startingMine)
        {
            var mines = originalMineList.ToList(); // Create identical list that can be modified
            Queue<MineModel> minesToExplode = new Queue<MineModel>();
            minesToExplode.Enqueue(startingMine);
            List<MineModel> minesThatHaveExploded = new List<MineModel>();

            while (minesToExplode.Count > 0)
            {
                var mineToExplode = minesToExplode.Dequeue();
                if (!minesThatHaveExploded.Contains(mineToExplode))
                {
                    mines.RemoveAll(m => m.X == mineToExplode.X && m.Y == mineToExplode.Y);

                    foreach (var mine in mines)
                    {
                        if (Exploder.WillExplode(mineToExplode.X, mineToExplode.Y, mineToExplode.R, mine.X, mine.Y))
                        {
                            minesToExplode.Enqueue(mine);
                        }
                    }

                    minesThatHaveExploded.Add(mineToExplode);
                }
            }

            return new MineExplodeResultModel(startingMine, minesThatHaveExploded.Count, minesThatHaveExploded);
        }
    }
}
