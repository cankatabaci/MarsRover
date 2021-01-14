using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Constants
{
    public static class UserMessages
    {
        public const string NotMoveable = "The rover cannot move because it is at the border.";
        public const string InvalidChar = "Invalid character to move.";
        public const string InvalidDirection = "Invalid direction to turn.";
        public const string MissionSuccess = "Mission Accomplished!";
        public const string InvalidInputMaxRange = "The maximum coordinates given for the plateau are incorrect";
        public const string InvalidInputStartPosition = "The inputs describing the rover's position are incorrect";

    }
}
