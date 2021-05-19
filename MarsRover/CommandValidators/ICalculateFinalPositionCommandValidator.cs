using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.CommandValidators
{
    public interface ICalculateFinalPositionCommandValidator
    {
        ValidatorResponse PlateauCoordinatesValidator(string entry);
        ValidatorResponse RoverPositionValidator(string entry);
    }
}
