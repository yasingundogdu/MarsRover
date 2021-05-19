using MarsRover.Domain;
using MarsRover.Services;
using System;
using Xunit;

namespace MarsRover.Tests
{
    public class CalculateFinalPositionTest
    {
        [Fact]
        public void RoverFinalPosition_ShouldReturnExpectedValue_WhenInstructionsAreSet()
        {
            // Arrange
            PlateauModel plateau = new PlateauModel(5, 5);
            RoverModel rover = new RoverModel(1, 2, "N");
            var roverActionService = new RoverActionService();
            string order = "LMLMLMLMM";
            // Act
            var actual = roverActionService.Run(plateau, rover, order);
            // Assert
            Assert.Equal("1 3 N", actual.XCoord + " " + actual.YCoord + " " + actual.Direction);
        }
    }
}
