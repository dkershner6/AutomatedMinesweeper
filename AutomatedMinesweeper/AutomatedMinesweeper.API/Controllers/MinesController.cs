using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutomatedMinesweeper.API.Helpers;
using AutomatedMinesweeper.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomatedMinesweeper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinesController : ControllerBase
    {
        [HttpPost]
        public static ActionResult<MineResultResponse> Post([Required, FromBody] List<MineModel> mines)
        {
            foreach (var mine in mines)
            {
                if (mines.Count(m => m.X == mine.X && m.Y == mine.Y) > 1)
                {
                    return new BadRequestObjectResult("You put two mines on the same square, that's a No-No.");
                }
            }

            return MineResults.GetForAllMines(mines);
        }
    }
}