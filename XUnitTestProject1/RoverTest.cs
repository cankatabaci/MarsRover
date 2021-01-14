using MarsRover.BusinessLayer;
using MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class RoverTest
    {
        #region Static Test Member Data
        public static IEnumerable<object[]> RoverAtTheTopNorthData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Compass.North, 3, 3, false },
            new object[] { new List<int> { 4, 4 }, Compass.North, 4, 4, false },
            new object[] { new List<int> { 5, 5 }, Compass.North, 5, 5, false },
            new object[] { new List<int> { 5, 5 }, Compass.North, 4, 3, true },
            new object[] { new List<int> { 5, 5 }, Compass.North, 1, 2, true }};

        public static IEnumerable<object[]> RoverAtTheBottomSouthData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Compass.South, 0, 0, false },
            new object[] { new List<int> { 4, 4 }, Compass.South, 1, 0, false },
            new object[] { new List<int> { 5, 5 }, Compass.South, 5, 0, false },
            new object[] { new List<int> { 5, 5 }, Compass.South, 4, 1, true },
            new object[] { new List<int> { 5, 5 }, Compass.South, 5, 2, true }};


        public static IEnumerable<object[]> RoverAtTheEndEastData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Compass.East, 3, 3, false },
            new object[] { new List<int> { 4, 4 }, Compass.East, 4, 4, false },
            new object[] { new List<int> { 5, 5 }, Compass.East, 5, 2, false },
            new object[] { new List<int> { 5, 5 }, Compass.East, 4, 1, true },
            new object[] { new List<int> { 5, 5 }, Compass.East, 3, 3, true }};

        public static IEnumerable<object[]> RoverAtTheEndWestData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Compass.West, 0, 3, false },
            new object[] { new List<int> { 4, 4 }, Compass.West, 0, 4, false },
            new object[] { new List<int> { 5, 5 }, Compass.West, 0, 2, false },
            new object[] { new List<int> { 5, 5 }, Compass.West, 1, 1, true },
            new object[] { new List<int> { 5, 5 }, Compass.West, 3, 3, true }};

        public static IEnumerable<object[]> TurnLeftData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Compass.West, 1, 3, Compass.South },
            new object[] { new List<int> { 4, 4 }, Compass.South, 3, 4, Compass.East },
            new object[] { new List<int> { 5, 5 }, Compass.East, 2, 2, Compass.North },
            new object[] { new List<int> { 6, 6 }, Compass.North, 1, 1, Compass.West},
            new object[] { new List<int> { 7, 7 }, Compass.West, 3, 3, Compass.South}};

        public static IEnumerable<object[]> TurnRightData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Compass.West, 1, 3, Compass.North },
            new object[] { new List<int> { 4, 4 }, Compass.South, 3, 4, Compass.West },
            new object[] { new List<int> { 5, 5 }, Compass.East, 2, 2, Compass.South },
            new object[] { new List<int> { 6, 6 }, Compass.North, 1, 1, Compass.East},
            new object[] { new List<int> { 7, 7 }, Compass.West, 3, 3, Compass.North}};

        public static IEnumerable<object[]> MoveData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Compass.West, 1, 3,  new List<int> { 0, 3 } },
            new object[] { new List<int> { 4, 4 }, Compass.South, 3, 4,  new List<int> { 3, 3 } },
            new object[] { new List<int> { 5, 5 }, Compass.East, 2, 2,  new List<int> { 3, 2 } },
            new object[] { new List<int> { 6, 6 }, Compass.North, 1, 1,  new List<int> { 1, 2 }},
            new object[] { new List<int> { 7, 7 }, Compass.West, 3, 3,  new List<int> { 2, 3 }}};

        public static IEnumerable<object[]> StartEngineData => new List<object[]>{
        new object[] { new List<int> { 5, 5 }, Compass.North, 1, 2,"LMLMLMLMM",  "13North"},
            new object[] { new List<int> { 5, 5 }, Compass.East, 3, 3, "MMRMMRMRRM", "51East" }};



        #endregion

        [Theory]
        [MemberData(nameof(RoverAtTheTopNorthData))]
        public void DoesIsMoveable_ShouldNotMove_RoverAtTheTopNorth(List<int> maxRange, Compass targetLocation, int xCoordinate, int yCoordinate, bool expected)
        {
            Plateau plateau = new Plateau(maxRange);

            //for testing private methods
            var result = typeof(Rover).GetMethod("IsMoveable", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new Rover(plateau, targetLocation, xCoordinate, yCoordinate), null);

            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(RoverAtTheBottomSouthData))]
        public void DoesIsMoveable_ShouldNotMove_RoverAtTheBottomSouth(List<int> maxRange, Compass targetLocation, int xCoordinate, int yCoordinate, bool expected)
        {
            Plateau plateau = new Plateau(maxRange);

            //for testing private methods
            var result = typeof(Rover).GetMethod("IsMoveable", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new Rover(plateau, targetLocation, xCoordinate, yCoordinate), null);

            Assert.Equal(result, expected);
        }


        [Theory]
        [MemberData(nameof(RoverAtTheEndEastData))]
        public void DoesIsMoveable_ShouldNotMove_RoverAtTheEndEast(List<int> maxRange, Compass targetLocation, int xCoordinate, int yCoordinate, bool expected)
        {
            Plateau plateau = new Plateau(maxRange);

            //for testing private methods
            var result = typeof(Rover).GetMethod("IsMoveable", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new Rover(plateau, targetLocation, xCoordinate, yCoordinate), null);

            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(RoverAtTheEndWestData))]
        public void DoesIsMoveable_ShouldNotMove_RoverAtTheEndWest(List<int> maxRange, Compass targetLocation, int xCoordinate, int yCoordinate, bool expected)
        {
            Plateau plateau = new Plateau(maxRange);

            //for testing private methods
            var result = typeof(Rover).GetMethod("IsMoveable", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new Rover(plateau, targetLocation, xCoordinate, yCoordinate), null);

            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(TurnLeftData))]
        public void DoesTurnLeft_ShouldTurnLeft_Direction(List<int> maxRange, Compass targetLocation, int xCoordinate, int yCoordinate, Compass expected)
        {
            Plateau plateau = new Plateau(maxRange);


            Rover rover = new Rover(plateau, targetLocation, xCoordinate, yCoordinate);
            //for testing private methods
            typeof(Rover).GetMethod("TurnLeft", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(rover, null);
            var result = rover.TargetDirection;
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(TurnRightData))]
        public void DoesTurnRight_ShouldTurnRight_Direction(List<int> maxRange, Compass targetLocation, int xCoordinate, int yCoordinate, Compass expected)
        {
            Plateau plateau = new Plateau(maxRange);


            Rover rover = new Rover(plateau, targetLocation, xCoordinate, yCoordinate);
            //for testing private methods
            typeof(Rover).GetMethod("TurnRight", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(rover, null);
            var result = rover.TargetDirection;
            Assert.Equal(result, expected);
        }


        [Theory]
        [MemberData(nameof(MoveData))]
        public void DoesMove_ShouldMove_PlateauLocationCoordinatesData(List<int> maxRange, Compass targetLocation, int xCoordinate, int yCoordinate, List<int> expected)
        {
            Plateau plateau = new Plateau(maxRange);


            Rover rover = new Rover(plateau, targetLocation, xCoordinate, yCoordinate);
            //for testing private methods
            typeof(Rover).GetMethod("Move", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(rover, null);
            var result = new List<int> { rover.X, rover.Y };
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(StartEngineData))]
        public void DoesStartEngine_ShouldMoveRightPositionAndDirection_PlateauLocationCoordinatesData(List<int> maxRange, Compass targetLocation, int xCoordinate, int yCoordinate, string moves, string expected)
        {
            Plateau plateau = new Plateau(maxRange);


            Rover rover = new Rover(plateau, targetLocation, xCoordinate, yCoordinate);
            rover.StartTheEngine(moves);
            var result = $"{rover.X}{rover.Y}{rover.TargetDirection}";
            Assert.Equal(result, expected);
        }
    }
}
