using MarsRover.Domain;
using MarsRover.Services;
using Xunit;

namespace MarsRover.Tests
{
    public class CalculateFinalPositionTest
    {
        [Fact]
        public void RoverFinalPosition_ShouldReturnExpectedValue_WhenInstructionsAreSet()
        {
            PlateauModel plateau = new PlateauModel(5, 5);
            RoverModel rover = new RoverModel(1, 2, "N");
            string order = "LMLMLMLMM";
            var roverActionService = new RoverActionService();

            var actual = roverActionService.Run(plateau, rover, order);
            
            Assert.Equal("1 3 N", actual.XCoord + " " + actual.YCoord + " " + actual.Direction);
        }
    }
}
