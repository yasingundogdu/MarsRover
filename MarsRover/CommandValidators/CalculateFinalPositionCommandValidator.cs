using MarsRover.Models;
using System;

namespace MarsRover.CommandValidators
{
    public class CalculateFinalPositionCommandValidator : ICalculateFinalPositionCommandValidator
    {
        public ValidatorResponse PlateauCoordinatesValidator(string entry)
        {
            if (String.IsNullOrEmpty(entry) || entry.Split(" ").Length != 2)
                return new ValidatorResponse { IsValid = false, Message = "Invalid Coordinates!" };
            return new ValidatorResponse { IsValid = true, Message = String.Empty };
        }
        public ValidatorResponse RoverPositionValidator(string entry)
        {
            if (String.IsNullOrEmpty(entry) || entry.Split(" ").Length != 3)
                return new ValidatorResponse { IsValid = false, Message = "Invalid Position!" };
            return new ValidatorResponse { IsValid = true, Message = String.Empty };
        }
    }
}
