using MediatR;

namespace MarsRover.Commands
{
    public class CalculateFinalPositionCommand : IRequest<string>
    {
        public string PlateauCoordinates { get; set; }
        public string RoverPosition { get; set; }
        public string RoverOrder { get; set; }
    }
}
