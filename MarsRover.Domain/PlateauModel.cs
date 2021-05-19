﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Domain
{
    public class PlateauModel
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public PlateauModel(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
