using AutomatedMinesweeper.API.Controllers;
using AutomatedMinesweeper.API.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AutomatedMinesweeper.Tests.Controllers
{
    public class MinesControllerTests : IDisposable
    {
        private MockRepository mockRepository;



        public MinesControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private MinesController CreateMinesController()
        {
            return new MinesController();
        }

        [Fact]
        public void Post_TwoBigMines_BothReturned()
        {
            // Arrange
            var unitUnderTest = this.CreateMinesController();
            List<MineModel> mines = new List<MineModel>{
                new MineModel(1, 1, 1),
                new MineModel(2, 1, 0),
                new MineModel(28, 32, 105),
                new MineModel(28,33,105)
            };

            // Act
            var result = MinesController.Post(
                mines);

            // Assert
            Assert.True(result.Value.PossibleStartingMines.Count() == 2);
        }

        [Fact]
        public void Post_TwoBigMines_AllExplode()
        {
            // Arrange
            var unitUnderTest = this.CreateMinesController();
            List<MineModel> mines = new List<MineModel>{
                new MineModel(1, 1, 1),
                new MineModel(2, 1, 0),
                new MineModel(28, 32, 105),
                new MineModel(28,33,105)
            };

            // Act
            var result = MinesController.Post(
                mines);

            // Assert
            Assert.True(result.Value.MinesExploded == 4);
        }
    }
}
