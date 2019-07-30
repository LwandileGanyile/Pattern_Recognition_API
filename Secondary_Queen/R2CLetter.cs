using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Pieces;
using CircularIteration;
using SharedResources;

namespace Secondary_Queen
{
    public class R2CLetter : IPartOf<R2CLetter>,  IPointIterator<R2Point>, ILetter<R2CLetter>
    {
        private CircularLetter<R2CLetter, R2CDirection> circularLeter;
        private R2Letter<R2Direction<R2CDirection>, R2CDirection> letter;
        private List<R2CDirection> directions = new List<R2CDirection>();

        public R2Letter<R2CLetter, R2CDirection> MyLetter { get; set; }
        public CircularLetter<R2CLetter, R2CDirection> CircularLeter { get; set; }

        public R2CLetter()
        {
            circularLeter = new CircularLetter<R2CLetter, R2CDirection>();
            letter = new R2Letter<R2Direction<R2CDirection>, R2CDirection>();
            

            Fill();
        }


        protected R2CLetter(R2Point startingPoint, char letter, bool smaller, int letterDirection,
        List<ISharedDirection> sharedDirections, List<float> speedList, float speed, 
        List<List<bool>> pointsCanSwitchList, List<bool> directionsCanSwitchList, bool canSwitch,
        List<List<float>> pointsSpeedList, int numberOfRotations)
        {
            circularLeter = new CircularLetter<R2CLetter, R2CDirection>(
                           directionsCanSwitchList, canSwitch, numberOfRotations);

            this.letter = new R2Letter<R2Direction<R2CDirection>, R2CDirection>(R2Plane.GetR2Plane(), 
            startingPoint, smaller,letter, letterDirection, sharedDirections, speedList, speed, 
            pointsCanSwitchList, pointsSpeedList);

            Fill();
        }
        
        protected R2CLetter(R2Point startingPoint, List<List<bool>> pointsCanSwitchList, 
        List<bool> directionsCanSwitchList,int numberOfRotations, List<float> speedList, 
        float speed, List<int> directions, List<ISharedDirection> sharedDirections, 
        bool canSwitch, List<List<float>> pointsSpeedList)       
        {
            circularLeter = new CircularLetter<R2CLetter, R2CDirection>(
                           directionsCanSwitchList, canSwitch, numberOfRotations);

            letter = new R2Letter<R2Direction<R2CDirection>, R2CDirection>(R2Plane.GetR2Plane(), 
            startingPoint, directions, sharedDirections,speedList, speed, pointsCanSwitchList,
            pointsSpeedList);



            Fill();
        }

        public int CompareTo(R2CLetter comparableInstance)
        {
            return letter.CompareTo(comparableInstance.letter);
        }

        public void Display()
        {
            letter.Display();
        }

        public void DisplayLetterInfo()
        {
            letter.DisplayLetterInfo();
        }

        public R2CLetter ReflectAboutAxis(int axisIndex)
        {
            throw new NotImplementedException();
        }

        public R2CLetter ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public DirectionIterator<R2CDirection> RetrieveDirectionIterator()
        {
            return new DirectionIterator<R2CDirection>(0, (CircularLinkedList<R2CDirection>)circularLeter.LinkedList);
        }

        public PointIterator<R2Point> RetrievePointIterator()
        {
            CircularLinkedList<R2Point> linkedList = new CircularLinkedList<R2Point>();

            for (int index = 0; index < circularLeter.LinkedList.Size; index++)
            {
                R2CDirection circularDirection = circularLeter.LinkedList.GetAt(index);
                PointIterator<R2Point> iterator = circularDirection.RetrievePointIterator();

                while (iterator.HasNext())
                {
                    linkedList.Add(iterator.GetNext());
                }

            }

            return new PointIterator<R2Point>(0, linkedList);
        }


        public R2CLetter RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public R2CLetter RotateAroundEqualAxis(List<int> indecesOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public R2CLetter Translate(int coordinateSystemDirection, float amaunt)
        {
            throw new NotImplementedException();
        }


        public R2CLetter ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public R2CLetter RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }



        public void Fill()
        {
            R2CDirection firstDirection = null;
            R2CDirection secondDirection = null;
            R2CDirection thirdDirection = null;
            R2CDirection forthDirection = null;
            R2CDirection fifthDirection = null;

            int currentDirection; // Used to avoid duplication of code.

            if (letter.Letter.Smaller)
            {

                switch (letter.Letter.MyLetter)
                {
                    case 'W':
                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),

                        (letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0] <
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1] ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1]),

                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        firstDirection.DirectionHelper.Direction.MyDirection), firstDirection.DirectionHelper.Direction.MyDirection,
                        letter.Letter.SharedDirections[2].Length[0], letter.Letter.SharedDirections[2].Length[1], letter.Letter.
                        SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1,
                        circularLeter.CanSwitchList[2], letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[3].Length[0],
                        letter.Letter.SharedDirections[3].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[3], letter.Letter.PointsCanSwitchList[3], 1, circularLeter.CanSwitchList[3],
                        letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        break;
                    case 'I':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.MyDirection, letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[0], letter.Letter.SpeedList[0]);

                        break;
                    case 'L':


                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),

                        (letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0]
                        < letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1]) ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1],

                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();

                        break;
                    case 'M':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.OnPlane.GetOppositeDirection(letter.Letter.MyDirection),
                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = (letter.Letter.OnPlane.RetrieveNeighborDirections(letter.Letter.MyDirection)[0] <
                        letter.Letter.OnPlane.RetrieveNeighborDirections(letter.Letter.MyDirection)[1]) ? letter.Letter.OnPlane.
                        RetrieveNeighborDirections(letter.Letter.MyDirection)[0] : letter.Letter.OnPlane.RetrieveNeighborDirections(
                        letter.Letter.MyDirection)[1];

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();
                        currentDirection = (letter.Letter.OnPlane.AreDirectionsNeighbors(firstDirection.DirectionHelper.Direction.MyDirection, letter.Letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.DirectionHelper.Direction.MyDirection)[0])) ? letter.Letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.DirectionHelper.Direction.MyDirection)[1] : letter.Letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.DirectionHelper.Direction.MyDirection)[0];

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[2].Length[0], letter.Letter.SharedDirections[2].Length[1], letter.Letter.
                        SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1,
                        circularLeter.CanSwitchList[2], letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[3].Length[0],
                        letter.Letter.SharedDirections[3].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[3], letter.Letter.PointsCanSwitchList[3], 1, circularLeter.CanSwitchList[3],
                        letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        break;
                    case 'N':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.OnPlane.GetOppositeDirection(letter.Letter.MyDirection),
                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = (letter.Letter.OnPlane.RetrieveNeighborDirections(letter.Letter.MyDirection)[0] <
                        letter.Letter.OnPlane.RetrieveNeighborDirections(letter.Letter.MyDirection)[1]) ? letter.Letter.OnPlane.
                        RetrieveNeighborDirections(letter.Letter.MyDirection)[0] : letter.Letter.OnPlane.RetrieveNeighborDirections(
                        letter.Letter.MyDirection)[1];

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[2].Length[0], letter.Letter.SharedDirections[2].Length[1], letter.Letter.
                        SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1,
                        circularLeter.CanSwitchList[2], letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        break;
                    case 'O':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),

                        (letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0]
                        < letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1]) ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1],

                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = letter.Letter.OnPlane.GetOppositeDirection(letter.Letter.MyDirection);

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();
                        currentDirection = letter.Letter.OnPlane.GetOppositeDirection(firstDirection.DirectionHelper.Direction.MyDirection);

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[2].Length[0], letter.Letter.SharedDirections[2].Length[1], letter.Letter.
                        SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1,
                        circularLeter.CanSwitchList[2], letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();
                        currentDirection = letter.Letter.OnPlane.GetOppositeDirection(secondDirection.DirectionHelper.Direction.MyDirection);

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[3].Length[0],
                        letter.Letter.SharedDirections[3].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[3], letter.Letter.PointsCanSwitchList[3], 1, circularLeter.CanSwitchList[3],
                        letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        break;
                    case 'R':

                        int[] threeUnitsAwayDirections = new int[2];
                        int[] perpendicularDirections;

                        letter.Letter.OnPlane.RetrieveDistancedDirections(letter.Letter.MyDirection, 3, threeUnitsAwayDirections);

                        currentDirection = (threeUnitsAwayDirections[0] < threeUnitsAwayDirections[1]) ?
                        threeUnitsAwayDirections[0] : threeUnitsAwayDirections[1];

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        currentDirection, letter.Letter.SharedDirections[0].Length[0], letter.Letter.
                        SharedDirections[0].Length[1], letter.Letter.SharedDirections[0].Divisor,
                        letter.Letter.PointsSpeedList[0], letter.Letter.PointsCanSwitchList[0], 1,
                        circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();

                        perpendicularDirections = letter.Letter.OnPlane.RetrievePerpendicularDirections(secondDirection.DirectionHelper.Direction.MyDirection);

                        if (letter.Letter.OnPlane.AreDirectionsNFarApart(letter.Letter.MyDirection, perpendicularDirections[0], 1))
                            currentDirection = perpendicularDirections[1];
                        else
                            currentDirection = perpendicularDirections[0];

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[2].Length[0],
                        letter.Letter.SharedDirections[2].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1, circularLeter.CanSwitchList[2],
                        letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        perpendicularDirections = letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection);

                        if (letter.Letter.OnPlane.AreDirectionsNFarApart(
                        secondDirection.DirectionHelper.Direction.MyDirection,
                        perpendicularDirections[0], 5) &&
                        letter.Letter.OnPlane.AreDirectionsNFarApart(
                        thirdDirection.DirectionHelper.Direction.MyDirection,
                        perpendicularDirections[0], 3))
                            currentDirection = perpendicularDirections[1];
                        else
                            currentDirection = perpendicularDirections[0];

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[3].Length[0],
                        letter.Letter.SharedDirections[3].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[3], letter.Letter.PointsCanSwitchList[3], 1, circularLeter.CanSwitchList[3],
                        letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        fifthDirection = new R2CDirection(forthDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[4].Length[0],
                        letter.Letter.SharedDirections[4].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[4], letter.Letter.PointsCanSwitchList[4], 1, circularLeter.CanSwitchList[4],
                        letter.Letter.SpeedList[4]);

                        fifthDirection.RemoveLast();

                        break;
                    case 'S':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.MyDirection, letter.Letter.SharedDirections[0].Length[0], letter.Letter.
                        SharedDirections[0].Length[1], letter.Letter.SharedDirections[0].Divisor,
                        letter.Letter.PointsSpeedList[0], letter.Letter.PointsCanSwitchList[0], 1,
                        circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = (letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[0]
                        < letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[1]) ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[1];

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();
                        currentDirection = letter.Letter.OnPlane.GetOppositeDirection(firstDirection.DirectionHelper.Direction.MyDirection);

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[2].Length[0],
                        letter.Letter.SharedDirections[2].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1, circularLeter.CanSwitchList[2],
                        letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        secondDirection.DirectionHelper.Direction.MyDirection), secondDirection.DirectionHelper.Direction.
                        MyDirection, letter.Letter.SharedDirections[3].Length[0], letter.Letter.SharedDirections[3].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[3], letter.Letter.
                        PointsCanSwitchList[3], 1, circularLeter.CanSwitchList[3], letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        fifthDirection = new R2CDirection(forthDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[4].Length[0],
                        letter.Letter.SharedDirections[4].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[4], letter.Letter.PointsCanSwitchList[4], 1, circularLeter.CanSwitchList[4],
                        letter.Letter.SpeedList[4]);

                        fifthDirection.RemoveLast();

                        break;
                    default:

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.OnPlane.GetOppositeDirection(letter.Letter.MyDirection),
                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.
                        SharedDirections[0].Length[1], letter.Letter.SharedDirections[0].Divisor,
                        letter.Letter.PointsSpeedList[0], letter.Letter.PointsCanSwitchList[0], 1,
                        circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = (letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[0]
                        < letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[1]) ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[1];

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();


                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[2].Length[0],
                        letter.Letter.SharedDirections[2].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1, circularLeter.CanSwitchList[2],
                        letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        break;
                }

            }

            else
            {
                switch (letter.Letter.MyLetter)
                {
                    case 'W':
                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),

                        (letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0] >
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1] ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1]),

                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1], 
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0],letter.Letter.
                        PointsCanSwitchList[0],1, circularLeter.CanSwitchList[1],letter.Letter.SpeedList[0]);

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[1].Length[0], 
                        letter.Letter.SharedDirections[1].Length[1],letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1], 
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        firstDirection.DirectionHelper.Direction.MyDirection), firstDirection.DirectionHelper.Direction.MyDirection, 
                        letter.Letter.SharedDirections[2].Length[0],letter.Letter.SharedDirections[2].Length[1], letter.Letter.
                        SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1, 
                        circularLeter.CanSwitchList[2],letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[3].Length[0], 
                        letter.Letter.SharedDirections[3].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[3], letter.Letter.PointsCanSwitchList[3], 1,circularLeter.CanSwitchList[3], 
                        letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        break;
                    case 'I':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.MyDirection, letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[0], letter.Letter.SpeedList[0]);

                        break;
                    case 'L':


                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),

                        (letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0]
                        > letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1]) ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1],

                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();

                        break;
                    case 'M':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.OnPlane.GetOppositeDirection(letter.Letter.MyDirection),
                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = (letter.Letter.OnPlane.RetrieveNeighborDirections(letter.Letter.MyDirection)[0] >
                        letter.Letter.OnPlane.RetrieveNeighborDirections(letter.Letter.MyDirection)[1]) ? letter.Letter.OnPlane.
                        RetrieveNeighborDirections(letter.Letter.MyDirection)[0] : letter.Letter.OnPlane.RetrieveNeighborDirections(
                        letter.Letter.MyDirection)[1];

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();
                        currentDirection = (letter.Letter.OnPlane.AreDirectionsNeighbors(firstDirection.DirectionHelper.Direction.MyDirection, letter.Letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.DirectionHelper.Direction.MyDirection)[0])) ? letter.Letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.DirectionHelper.Direction.MyDirection)[0] : letter.Letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.DirectionHelper.Direction.MyDirection)[1];

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[2].Length[0], letter.Letter.SharedDirections[2].Length[1], letter.Letter.
                        SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1,
                        circularLeter.CanSwitchList[2], letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[3].Length[0],
                        letter.Letter.SharedDirections[3].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[3], letter.Letter.PointsCanSwitchList[3], 1, circularLeter.CanSwitchList[3],
                        letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        break;
                    case 'N':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.OnPlane.GetOppositeDirection(letter.Letter.MyDirection),
                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = (letter.Letter.OnPlane.RetrieveNeighborDirections(letter.Letter.MyDirection)[0] >
                        letter.Letter.OnPlane.RetrieveNeighborDirections(letter.Letter.MyDirection)[1]) ? letter.Letter.OnPlane.
                        RetrieveNeighborDirections(letter.Letter.MyDirection)[0] : letter.Letter.OnPlane.RetrieveNeighborDirections(
                        letter.Letter.MyDirection)[1];

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[2].Length[0], letter.Letter.SharedDirections[2].Length[1], letter.Letter.
                        SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1,
                        circularLeter.CanSwitchList[2], letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        break;
                    case 'O':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),

                        (letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0]
                        > letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1]) ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection)[1],

                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.SharedDirections[0].Length[1],
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[0], letter.Letter.
                        PointsCanSwitchList[0], 1, circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = letter.Letter.OnPlane.GetOppositeDirection(letter.Letter.MyDirection);

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();
                        currentDirection = letter.Letter.OnPlane.GetOppositeDirection(firstDirection.DirectionHelper.Direction.MyDirection);

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[2].Length[0], letter.Letter.SharedDirections[2].Length[1], letter.Letter.
                        SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1,
                        circularLeter.CanSwitchList[2], letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();
                        currentDirection = letter.Letter.OnPlane.GetOppositeDirection(secondDirection.DirectionHelper.Direction.MyDirection);

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[3].Length[0],
                        letter.Letter.SharedDirections[3].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[3], letter.Letter.PointsCanSwitchList[3], 1, circularLeter.CanSwitchList[3],
                        letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        break;
                    case 'R':

                        int[] threeUnitsAwayDirections = new int[2];
                        int[] perpendicularDirections;

                        letter.Letter.OnPlane.RetrieveDistancedDirections(letter.Letter.MyDirection, 3, threeUnitsAwayDirections);

                        currentDirection = (threeUnitsAwayDirections[0] > threeUnitsAwayDirections[1]) ?
                        threeUnitsAwayDirections[0] : threeUnitsAwayDirections[1];

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        currentDirection,letter.Letter.SharedDirections[0].Length[0], letter.Letter.
                        SharedDirections[0].Length[1],letter.Letter.SharedDirections[0].Divisor, 
                        letter.Letter.PointsSpeedList[0], letter.Letter.PointsCanSwitchList[0], 1, 
                        circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();

                        perpendicularDirections = letter.Letter.OnPlane.RetrievePerpendicularDirections(secondDirection.DirectionHelper.Direction.MyDirection);

                        if (letter.Letter.OnPlane.AreDirectionsNFarApart(letter.Letter.MyDirection, perpendicularDirections[0], 1))
                            currentDirection = perpendicularDirections[0];
                        else
                            currentDirection = perpendicularDirections[1];

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[2].Length[0],
                        letter.Letter.SharedDirections[2].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1, circularLeter.CanSwitchList[2],
                        letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        perpendicularDirections = letter.Letter.OnPlane.RetrievePerpendicularDirections(letter.Letter.MyDirection);

                        if (letter.Letter.OnPlane.AreDirectionsNFarApart(
                        secondDirection.DirectionHelper.Direction.MyDirection, 
                        perpendicularDirections[0], 5) &&
                        letter.Letter.OnPlane.AreDirectionsNFarApart(
                        thirdDirection.DirectionHelper.Direction.MyDirection, 
                        perpendicularDirections[0], 3))
                            currentDirection = perpendicularDirections[0];
                        else
                            currentDirection = perpendicularDirections[1];

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[3].Length[0],
                        letter.Letter.SharedDirections[3].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[3], letter.Letter.PointsCanSwitchList[3], 1, circularLeter.CanSwitchList[3],
                        letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        fifthDirection = new R2CDirection(forthDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[4].Length[0],
                        letter.Letter.SharedDirections[4].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[4], letter.Letter.PointsCanSwitchList[4], 1, circularLeter.CanSwitchList[4],
                        letter.Letter.SpeedList[4]);

                        fifthDirection.RemoveLast();

                        break;
                    case 'S':

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.MyDirection, letter.Letter.SharedDirections[0].Length[0], letter.Letter.
                        SharedDirections[0].Length[1], letter.Letter.SharedDirections[0].Divisor,
                        letter.Letter.PointsSpeedList[0], letter.Letter.PointsCanSwitchList[0], 1,
                        circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = (letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[0]
                        > letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[1]) ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[1];

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();
                        currentDirection = letter.Letter.OnPlane.GetOppositeDirection(firstDirection.DirectionHelper.Direction.MyDirection);

                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[2].Length[0],
                        letter.Letter.SharedDirections[2].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1, circularLeter.CanSwitchList[2],
                        letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        forthDirection = new R2CDirection(thirdDirection.RetrieveNextStartingPoint(
                        secondDirection.DirectionHelper.Direction.MyDirection), secondDirection.DirectionHelper.Direction.
                        MyDirection, letter.Letter.SharedDirections[3].Length[0],letter.Letter.SharedDirections[3].Length[1], 
                        letter.Letter.SharedDirections[0].Divisor, letter.Letter.PointsSpeedList[3], letter.Letter.
                        PointsCanSwitchList[3], 1, circularLeter.CanSwitchList[3], letter.Letter.SpeedList[3]);

                        forthDirection.RemoveLast();

                        fifthDirection = new R2CDirection(forthDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[4].Length[0],
                        letter.Letter.SharedDirections[4].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[4], letter.Letter.PointsCanSwitchList[4], 1, circularLeter.CanSwitchList[4],
                        letter.Letter.SpeedList[4]);

                        fifthDirection.RemoveLast();

                        break;
                    default:

                        firstDirection = new R2CDirection(new R2Point(letter.Letter.StartingPoint),
                        letter.Letter.OnPlane.GetOppositeDirection(letter.Letter.MyDirection), 
                        letter.Letter.SharedDirections[0].Length[0], letter.Letter.
                        SharedDirections[0].Length[1], letter.Letter.SharedDirections[0].Divisor,
                        letter.Letter.PointsSpeedList[0], letter.Letter.PointsCanSwitchList[0], 1,
                        circularLeter.CanSwitchList[1], letter.Letter.SpeedList[0]);

                        currentDirection = (letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[0]
                        > letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[1]) ?
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[0] :
                        letter.Letter.OnPlane.RetrievePerpendicularDirections(firstDirection.DirectionHelper.Direction.MyDirection)[1];

                        secondDirection = new R2CDirection(firstDirection.RetrieveNextStartingPoint(
                        currentDirection), currentDirection, letter.Letter.SharedDirections[1].Length[0],
                        letter.Letter.SharedDirections[1].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[1], letter.Letter.PointsCanSwitchList[1], 1, circularLeter.CanSwitchList[1],
                        letter.Letter.SpeedList[1]);

                        secondDirection.RemoveLast();


                        thirdDirection = new R2CDirection(secondDirection.RetrieveNextStartingPoint(
                        letter.Letter.MyDirection), letter.Letter.MyDirection, letter.Letter.SharedDirections[2].Length[0],
                        letter.Letter.SharedDirections[2].Length[1], letter.Letter.SharedDirections[0].Divisor, letter.
                        Letter.PointsSpeedList[2], letter.Letter.PointsCanSwitchList[2], 1, circularLeter.CanSwitchList[2],
                        letter.Letter.SpeedList[2]);

                        thirdDirection.RemoveLast();

                        break;
                }
            }

            circularLeter.LinkedList.Add(firstDirection);

            if (secondDirection != null)
                circularLeter.LinkedList.Add(secondDirection);
            if(thirdDirection != null)
                circularLeter.LinkedList.Add(thirdDirection);
            if (forthDirection != null)
                circularLeter.LinkedList.Add(forthDirection);
            if (fifthDirection != null)
                circularLeter.LinkedList.Add(fifthDirection);
        }


        public void RemoveLast()
        {

        }




        public bool IsC(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsC(directions, lengths);
        }

        public bool IsI(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsI(directions, lengths);
        }

        public bool IsL(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsL(directions, lengths);
        }

        public bool IsM(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsM(directions, lengths);
        }

        public bool IsN(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsN(directions, lengths);
        }

        public bool IsO(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsO(directions, lengths);
        }

        public bool IsR(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsR(directions, lengths);
        }

        public bool IsS(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsS(directions, lengths);
        }

        public bool IsW(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsW(directions, lengths);
        }

        public bool IsLetter(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsLetter(directions, lengths);
        }

        public bool IsDirectionValid(int direction)
        {
            return letter.IsDirectionValid(direction);
        }

        
    }

}
