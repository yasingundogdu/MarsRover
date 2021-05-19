using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Domain
{
    public class RoverModel
    {
        public RoverModel(int x, int y, string direction)
        {
            XCoord = x;
            YCoord = y;
            Direction = direction;
        }

        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string Direction { get; set; }
    }
}
