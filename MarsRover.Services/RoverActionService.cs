using MarsRover.Domain;
using System;

namespace MarsRover.Services
{
    public class RoverActionService : IRoverActionService
    {
        public string CalculatePosition(PlateauModel plateau, RoverModel rover, string order)
        {
            for (int i = 0; i < order.Length; i++)
            {
                rover = Execute(plateau, rover, order[i]);
            }
            return $"{rover.XCoord} {rover.YCoord} {rover.Direction}";
        }

        public RoverModel Execute(PlateauModel plateau, RoverModel rover, char command)
        {
            if (command.Equals('L'))
                TurnLeft(rover);

            else if (command.Equals('R'))
                TurnRight(rover);

            else if (command.Equals('M'))
                Move(plateau, rover);
            
            else
                Console.WriteLine("Wrong");
            
            return rover;
        }

        private bool MoveCheck(PlateauModel plateau, RoverModel rover)
        {
            return (rover.XCoord >= 0) &&
                   (rover.XCoord <= plateau.Width) &&
                   (rover.YCoord >= 0) &&
                   (rover.YCoord <= plateau.Height);
        }

        public RoverModel Move(PlateauModel plateau, RoverModel rover)
        {
            RoverModel expected = new RoverModel(rover.XCoord,rover.YCoord,rover.Direction);
            switch (rover.Direction)
            {
                case "N":
                    expected.YCoord = rover.YCoord + 1;
                    if (MoveCheck(plateau, expected))
                        rover.YCoord = expected.YCoord;
                    break;
                case "W":
                    expected.XCoord = rover.XCoord - 1;
                    if (MoveCheck(plateau, expected))
                        rover.XCoord = expected.XCoord;
                    break;
                case "S":
                    expected.YCoord = rover.YCoord - 1;
                    if (MoveCheck(plateau, expected))
                        rover.YCoord = expected.YCoord;
                    break;
                case "E":
                    expected.XCoord = rover.XCoord + 1;
                    if (MoveCheck(plateau, expected))
                        rover.XCoord = expected.XCoord;
                    break;
            }
            return rover;
        }

        public RoverModel TurnLeft(RoverModel rover)
        {
            switch (rover.Direction)
            {
                case "N": rover.Direction = "W"; break;
                case "W": rover.Direction = "S"; break;
                case "S": rover.Direction = "E"; break;
                case "E": rover.Direction = "N"; break;
            }
            return rover;
        }

        public RoverModel TurnRight(RoverModel rover)
        {
            switch (rover.Direction)
            {
                case "N": rover.Direction = "E"; break;
                case "E": rover.Direction = "S"; break;
                case "S": rover.Direction = "W"; break;
                case "W": rover.Direction = "N"; break;
            }
            return rover;
        }
    }
}
