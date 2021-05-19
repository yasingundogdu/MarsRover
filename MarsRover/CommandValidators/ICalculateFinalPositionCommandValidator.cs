using MarsRover.Models;

namespace MarsRover.CommandValidators
{
    public interface ICalculateFinalPositionCommandValidator
    {
        ValidatorResponse PlateauCoordinatesValidator(string entry);
        ValidatorResponse RoverPositionValidator(string entry);
    }
}
