using MarsRover.Constants;
using MarsRover.Enums;
using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer
{
    public class Rover : IRover
    {
        public Compass TargetDirection { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        Plateau Plateau { get; set; }


        public Rover(Plateau plateau, Compass targetLocation, int x, int y)
        {
            Plateau = plateau;
            TargetDirection = targetLocation;
            X = x;
            Y = y;
        }

        public void StartTheEngine(string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case (char)Moves.Left:
                        TurnLeft();
                        break;
                    case (char)Moves.Right:
                        TurnRight();
                        break;
                    case (char)Moves.Move:
                        Move();
                        break;
                    default:
                        Console.WriteLine(UserMessages.InvalidChar);
                        break;
                }
            }

            Console.WriteLine(UserMessages.MissionSuccess);
            Console.WriteLine($"{X} {Y} {TargetDirection}");
        }

        private void Move()
        {
            if (IsMoveable())
            {
                switch (TargetDirection)
                {
                    case Compass.North:
                        Y += 1;
                        break;
                    case Compass.South:
                        Y -= 1;
                        break;
                    case Compass.East:
                        X += 1;
                        break;
                    case Compass.West:
                        X -= 1;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine(UserMessages.NotMoveable);
            }
        }

        private void TurnLeft()
        {
            switch (TargetDirection)
            {
                case Compass.North:
                    TargetDirection = Compass.West;
                    break;
                case Compass.South:
                    TargetDirection = Compass.East;
                    break;
                case Compass.East:
                    TargetDirection = Compass.North;
                    break;
                case Compass.West:
                    TargetDirection = Compass.South;
                    break;
                default:
                    Console.WriteLine(UserMessages.InvalidDirection);
                    break;
            }
        }

        private void TurnRight()
        {
            switch (TargetDirection)
            {
                case Compass.North:
                    TargetDirection = Compass.East;
                    break;
                case Compass.South:
                    TargetDirection = Compass.West;
                    break;
                case Compass.East:
                    TargetDirection = Compass.South;
                    break;
                case Compass.West:
                    TargetDirection = Compass.North;
                    break;
                default:
                    Console.WriteLine(UserMessages.InvalidDirection);
                    break;
            }
        }

        private bool IsMoveable()
        {
            bool isMoveable;

            if (TargetDirection == Compass.North && Y == Plateau.MaxHeight) //Rover at the top north of the map
                isMoveable = false;
            else if (TargetDirection == Compass.South && Y == Plateau.MinHeight) // Rover at the bottom south of the map
                isMoveable = false;
            else if (TargetDirection == Compass.East && X == Plateau.MaxWidth) //Rover at the East end point of the map
                isMoveable = false;
            else if (TargetDirection == Compass.West && X == Plateau.MinWidth) //Rover at the West end point of the map
                isMoveable = false;
            else
                isMoveable = true;

            return isMoveable;
        }
    }
}
