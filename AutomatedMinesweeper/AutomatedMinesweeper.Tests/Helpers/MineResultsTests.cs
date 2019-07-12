using AutomatedMinesweeper.API.Helpers;
using AutomatedMinesweeper.API.Models;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AutomatedMinesweeper.Tests.Helpers
{
    public class MineResultsTests : IDisposable
    {
        private MockRepository mockRepository;

        private readonly ITestOutputHelper output;

        public MineResultsTests(ITestOutputHelper testOutput)
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.output = testOutput;
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public void Get_SmallStartingMine_SomeExplode()
        {
            // Arrange
            List<MineModel> mines = new List<MineModel>{
                new MineModel(1, 1, 1),
                new MineModel(2, 1, 0),
                new MineModel(28, 32, 105)
            };
            MineModel startingMine = new MineModel(1, 1, 1);

            // Act
            var result = MineResults.GetForOneMine(
                mines,
                startingMine);

            output.WriteLine(JsonConvert.SerializeObject(result.MinesThatExploded, Formatting.Indented));

            // Assert
            Assert.Equal(2, result.Exploded);
        }

        [Fact]
        public void Get_BigStartingMine_AllExplode()
        {
            // Arrange
            List<MineModel> mines = new List<MineModel>{
                new MineModel(1, 1, 1),
                new MineModel(2, 1, 0),
                new MineModel(28, 32, 105)
            };
            MineModel startingMine = new MineModel(28, 32, 105);

            // Act
            var result = MineResults.GetForOneMine(
                mines,
                startingMine);

            //output.WriteLine(JsonConvert.SerializeObject(result.MinesThatExploded, Formatting.Indented));

            // Assert
            Assert.Equal(3, result.Exploded);
        }

        [Fact]
        public void Get_IneffectualMine_ItExplodes()
        {
            // Arrange
            List<MineModel> mines = new List<MineModel>{
                new MineModel(1, 1, 1),
                new MineModel(2, 1, 0),
                new MineModel(28, 32, 105)
            };
            MineModel startingMine = new MineModel(2, 2, 0);

            // Act
            var result = MineResults.GetForOneMine(
                mines,
                startingMine);

            //output.WriteLine(JsonConvert.SerializeObject(result.MinesThatExploded, Formatting.Indented));

            // Assert
            Assert.Equal(1, result.Exploded);
        }

        [Fact]
        public void Get_TwoHugeMines_BothIncluded()
        {
            // Arrange
            List<MineModel> mines = new List<MineModel>{
                new MineModel(1, 1, 1),
                new MineModel(2, 1, 0),
                new MineModel(28, 32, 105),
                new MineModel(28,33,105)
            };

            // Act
            var results = MineResults.GetForAllMines(
                mines);

            //output.WriteLine(JsonConvert.SerializeObject(result.MinesThatExploded, Formatting.Indented));

            // Assert
            Assert.Equal(2, results.PossibleStartingMines.Count());
        }

        [Fact]
        public void Get_BigStartingMine_PassedThroughToResults()
        {
            // Arrange
            List<MineModel> mines = new List<MineModel>{
                new MineModel(1, 1, 1),
                new MineModel(2, 1, 0),
                new MineModel(28, 32, 105)
            };

            // Act
            var results = MineResults.GetForAllMines(
                mines);

            //output.WriteLine(JsonConvert.SerializeObject(result.MinesThatExploded, Formatting.Indented));

            // Assert
            Assert.True(results.PossibleStartingMines.Any(m => m.X == 28 && m.Y == 32) && results.MinesExploded == 3);
        }
    }
}
