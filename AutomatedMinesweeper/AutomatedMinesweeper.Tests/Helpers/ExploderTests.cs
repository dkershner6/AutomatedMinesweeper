using AutomatedMinesweeper.API.Helpers;
using Moq;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AutomatedMinesweeper.Tests.Helpers
{
    public class ExploderTests : IDisposable
    {
        private MockRepository mockRepository;
        private readonly ITestOutputHelper output;


        public ExploderTests(ITestOutputHelper testOutput)
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.output = testOutput;
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Explode_Nearby_ShouldBeTrue()
        {
            // Arrange
            int x1 = 5;
            int y1 = 5;
            int r = 1;
            int x2 = 5;
            int y2 = 6;

            // Act
            var result = Exploder.WillExplode(
                x1,
                y1,
                r,
                x2,
                y2);

            // Assert            
            Assert.True(result);
        }

        [Fact]
        public void Explode_FarAway_ShouldBeFalse()
        {
            // Arrange
            int x1 = 5;
            int y1 = 5;
            int r = 1;
            int x2 = 5;
            int y2 = 175;

            // Act
            var result = Exploder.WillExplode(
                x1,
                y1,
                r,
                x2,
                y2);

            // Assert            
            Assert.False(result);
        }

        [Fact]
        public void Explode_Zero_ShouldBeFalse()
        {
            // Arrange
            int x1 = 5;
            int y1 = 5;
            int r = 0;
            int x2 = 5;
            int y2 = 6;

            // Act
            var result = Exploder.WillExplode(
                x1,
                y1,
                r,
                x2,
                y2);

            // Assert            
            Assert.False(result);
        }
    }
}
