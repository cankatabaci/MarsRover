using MarsRover.Constants;
using MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Utils
{
    public class MarsRoverUtils
    {
        public static int GetXCoordinate(List<string> clearPosition)
        {
            return Convert.ToInt32(clearPosition[0]);
        }

        public static int GetYCoordinate(List<string> clearPosition)
        {
            return Convert.ToInt32(clearPosition[1]);
        }

        public static Compass GetDirection(List<string> clearPosition)
        {
            char direction = char.Parse(clearPosition[2]);
            switch (direction)
            {
                case 'N':
                    return Compass.North;
                case 'S':
                    return Compass.South;
                case 'W':
                    return Compass.West;
                case 'E':
                    return Compass.East;
                default:
                    throw new ArgumentException(UserMessages.InvalidDirection);
            }
        }
    }
}
