using MarsRover.BusinessLayer;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Test Input:
             * 5 5
             * 1 2 N
             * LMLMLMLMM
             * 3 3 E
             * MMRMMRMRRM
             */

            List<int> maxRange = new List<int> { 5, 5 };
            Plateau plateau = new Plateau(maxRange);


            Rover firstRover = new Rover(plateau, Enums.Compass.North, 1, 2);
            string firstRoverMoves = "LMLMLMLMM";
            firstRover.StartTheEngine(firstRoverMoves);

            Rover secondRover = new Rover(plateau, Enums.Compass.East, 3, 3);
            string secondRoverMoves = "MMRMMRMRRM";
            secondRover.StartTheEngine(secondRoverMoves);
        }
    }
}
