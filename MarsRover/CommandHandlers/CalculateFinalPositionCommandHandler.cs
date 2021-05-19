using MarsRover.Commands;
using MarsRover.Domain;
using MarsRover.Services;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.CommandHandlers
{
    public class CalculateFinalPositionCommandHandler : IRequestHandler<CalculateFinalPositionCommand, string>
    {

        private readonly IRoverActionService _roverActionService;
        public CalculateFinalPositionCommandHandler(IRoverActionService roverActionService)
        {
            _roverActionService = roverActionService;
        }
        public Task<string> Handle(CalculateFinalPositionCommand request, CancellationToken cancellationToken)
        {
            var plateauCoordinates = request.PlateauCoordinates.Split(" ").ToList();
            var roverPosition = request.RoverPosition.Split(" ").ToList();

            PlateauModel plateau = new PlateauModel(Convert.ToInt32(plateauCoordinates[0]), Convert.ToInt32(plateauCoordinates[1]));
            RoverModel rover = new RoverModel(Convert.ToInt32(roverPosition[0]), Convert.ToInt32(roverPosition[1]), roverPosition[2]);

            return Task.Run(() =>
            {
                return _roverActionService.CalculatePosition(plateau, rover, request.RoverOrder);
            });
        }
    }
}
