using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services
{
    public interface IRoverActionService
    {
        RoverModel TurnLeft(RoverModel rover);
        RoverModel TurnRight(RoverModel rover);
        RoverModel Move(PlateauModel plateau, RoverModel rover);
        RoverModel Execute(PlateauModel plateau, RoverModel rover, char command);
        string CalculatePosition(PlateauModel plateau, RoverModel rover, string order);
    }
}
