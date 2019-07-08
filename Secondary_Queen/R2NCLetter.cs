using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Pieces;
using NonCircularIteration;
using SharedResources;

namespace Secondary_Queen
{
    public class R2NCLetter : NonCircularLetter<R2NCLetter, R2NCDirection>, IPointIterator<R2Point>
    {
        private R2Letter<R2NCLetter, R2NCDirection> letter;

        public R2Letter<R2NCLetter, R2NCDirection> MyLetter { get; set; }

        public R2NCLetter()
        {
            letter = new R2Letter<R2NCLetter, R2NCDirection>();
            letter.OnPlane = R2Plane.GetR2Plane();
            _startingPoint = new R2Point().Position;

            Fill();
        }


        protected R2NCLetter(Point _startingPoint, char letter, bool smaller, int letterDirection,
        List<bool> canShootList, Dictionary<int, int> duration, int numberOfRotations)
        : this(_startingPoint, letter, smaller, letterDirection,
        canShootList, duration, numberOfRotations, new SharedDirection(10, 1))
        {

        }

        protected R2NCLetter(Point _startingPoint, char letter, bool smaller, int letterDirection,
        List<bool> canShootList, Dictionary<int, int> duration, int numberOfRotations,
        SharedDirection shareDirection)
        : base(_startingPoint, letter, R2Plane.GetR2Plane(), smaller, letterDirection,
        canShootList, duration, numberOfRotations)
        {
            Fill();
        }


        public override int CompareTo(R2NCLetter comparableInstance)
        {
            int returnValue = 0;

            if (letter.MyLetter < comparableInstance.MyLetter.MyLetter)
            {
                returnValue = -1;
            }

            else if (letter.MyLetter < comparableInstance.MyLetter.MyLetter)
            {
                returnValue = 1;
            }

            else
            {

                if (letter.MyDirection < comparableInstance.MyLetter.MyDirection)
                    returnValue = -1;
                else if (letter.MyDirection > comparableInstance.MyLetter.MyDirection)
                    returnValue = 1;
                else
                {
                    if (letter.Smaller && !comparableInstance.MyLetter.Smaller)
                        returnValue = -1;
                    else if (!letter.Smaller && comparableInstance.MyLetter.Smaller)
                        returnValue = 1;
                }

            }

            return returnValue;
        }

        public override void Display()
        {
            Console.Write("(-----");

            for (int i = 0; i < linkedList.Size - 1; i++)
                Console.WriteLine(linkedList.GetAt(i) + ",");
            Console.WriteLine(linkedList.GetAt(linkedList.Size - 1) + "----)");
        }

        public override void DisplayLetterInfo()
        {
            int time = 0;

            Console.WriteLine("Letter : " + letter.MyLetter);
            Console.WriteLine("Letter Direction : " + direction);
            Console.WriteLine("Smaller : " + letter.Smaller);

            foreach (KeyValuePair<int, int> pair in duration)
            {
                time += pair.Key;
            }


            Console.WriteLine("Letter Duration : " + time + " milliseconds.");
        }


        public override R2NCLetter ReflectAboutAxis(int axisIndex)
        {
            throw new NotImplementedException();
        }

        public override R2NCLetter ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override DirectionIterator<R2NCDirection> RetrieveDirectionIterator()
        {
            return new DirectionIterator<R2NCDirection>(0, (DoubleLinkedList<R2NCDirection>)linkedList);
        }

        public PointIterator<R2Point> RetrievePointIterator()
        {
            DoubleLinkedList<R2Point> linkedList = new DoubleLinkedList<R2Point>();

            for (int index = 0; index < this.linkedList.Size; index++)
            {
                R2NCDirection nonCircularDirection = this.linkedList.GetAt(index);
                PointIterator<R2Point> iterator = nonCircularDirection.RetrievePointIterator();

                while (iterator.HasNext())
                {
                    linkedList.Add(iterator.GetNext());
                }

            }

            return new PointIterator<R2Point>(0,linkedList);
        }








        public override R2NCLetter RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override R2NCLetter RotateAroundEqualAxis(List<int> indecesOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override R2NCLetter Translate(int coordinateSystemDirection, float amaunt)
        {
            throw new NotImplementedException();
        }


        public override R2NCLetter ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override void Fill()
        {
            R2NCDirection firstDirection = null;
            R2NCDirection secondDirection = null;
            R2NCDirection thirdDirection = null;
            R2NCDirection forthDirection = null;
            R2NCDirection fifthDirection = null;

            int currentDirection; // Used to avoid duplication of code.

            if (letter.Smaller)
            {

                switch (letter.MyLetter)
                {
                    case 'W':
                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),

                        (letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0] <
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1] ?
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1]),

                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();


                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        firstDirection.Direction)), firstDirection.Direction,
                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor, letter.CanShootList[2],
                        letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        break;
                    case 'I':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.MyDirection, letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        break;
                    case 'L':


                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),

                        (letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0]
                        < letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1]) ?
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1],

                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();

                        break;
                    case 'M':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.OnPlane.GetOppositeDirection(letter.MyDirection),
                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = (letter.OnPlane.RetrieveNeighborDirections(letter.MyDirection)[0] <
                        letter.OnPlane.RetrieveNeighborDirections(letter.MyDirection)[1]) ? letter.OnPlane.
                        RetrieveNeighborDirections(letter.MyDirection)[0] : letter.OnPlane.RetrieveNeighborDirections(
                        letter.MyDirection)[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();
                        currentDirection = (letter.OnPlane.AreDirectionsNeighbors(firstDirection.Direction, letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.Direction)[0])) ? letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.Direction)[0] : letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.Direction)[1];

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        break;
                    case 'N':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.OnPlane.GetOppositeDirection(letter.MyDirection),
                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = (letter.OnPlane.RetrieveNeighborDirections(letter.MyDirection)[0] <
                        letter.OnPlane.RetrieveNeighborDirections(letter.MyDirection)[1]) ? letter.OnPlane.
                        RetrieveNeighborDirections(letter.MyDirection)[0] : letter.OnPlane.RetrieveNeighborDirections(
                        letter.MyDirection)[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        break;
                    case 'O':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),

                        (letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0]
                        < letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1]) ?
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1],

                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = letter.OnPlane.GetOppositeDirection(letter.MyDirection);

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();
                        currentDirection = letter.OnPlane.GetOppositeDirection(firstDirection.Direction);

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();
                        currentDirection = letter.OnPlane.GetOppositeDirection(secondDirection.Direction);

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        break;
                    case 'R':

                        int[] threeUnitsAwayDirections = new int[2];
                        int[] perpendicularDirections;

                        letter.OnPlane.RetrieveDistancedDirections(letter.MyDirection, 3, threeUnitsAwayDirections);

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        (threeUnitsAwayDirections[0] < threeUnitsAwayDirections[1]) ?
                        threeUnitsAwayDirections[0] : threeUnitsAwayDirections[1],
                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        perpendicularDirections = letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction);

                        if (letter.OnPlane.AreDirectionsNFarApart(letter.MyDirection, perpendicularDirections[0], 1))
                            currentDirection = perpendicularDirections[0];
                        else
                            currentDirection = perpendicularDirections[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();

                        perpendicularDirections = letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection);

                        if (letter.OnPlane.AreDirectionsNFarApart(firstDirection.Direction, perpendicularDirections[0], 5) &&
                            letter.OnPlane.AreDirectionsNFarApart(secondDirection.Direction, perpendicularDirections[0], 3))
                            currentDirection = perpendicularDirections[0];
                        else
                            currentDirection = perpendicularDirections[1];

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        break;
                    case 'S':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.MyDirection, letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = (letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[0]
                        < letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[1]) ?
                        letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();
                        currentDirection = letter.OnPlane.GetOppositeDirection(firstDirection.Direction);

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        secondDirection.Direction)), secondDirection.Direction, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        fifthDirection = new R2NCDirection(new R2Point(forthDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[4], letter.Duration[4], 1);

                        fifthDirection.RemoveLastPoint();

                        break;
                    default:

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.OnPlane.GetOppositeDirection(letter.MyDirection), letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = (letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[0]
                        < letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[1]) ?
                        letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();


                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        break;
                }

            }

            else
            {
                switch (letter.MyLetter)
                {
                    case 'W':
                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),

                        (letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0] >
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1] ?
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1]),

                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();


                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        firstDirection.Direction)), firstDirection.Direction,
                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor, letter.CanShootList[2],
                        letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        break;
                    case 'I':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.MyDirection, letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        break;
                    case 'L':


                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),

                        (letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0]
                        > letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1]) ?
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1],

                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();

                        break;
                    case 'M':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.OnPlane.GetOppositeDirection(letter.MyDirection),
                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = (letter.OnPlane.RetrieveNeighborDirections(letter.MyDirection)[0] >
                        letter.OnPlane.RetrieveNeighborDirections(letter.MyDirection)[1]) ? letter.OnPlane.
                        RetrieveNeighborDirections(letter.MyDirection)[0] : letter.OnPlane.RetrieveNeighborDirections(
                        letter.MyDirection)[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();
                        currentDirection = (letter.OnPlane.AreDirectionsNeighbors(firstDirection.Direction, letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.Direction)[0])) ? letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.Direction)[0] : letter.OnPlane.
                        RetrievePerpendicularDirections(secondDirection.Direction)[1];

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        break;
                    case 'N':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.OnPlane.GetOppositeDirection(letter.MyDirection),
                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = (letter.OnPlane.RetrieveNeighborDirections(letter.MyDirection)[0] >
                        letter.OnPlane.RetrieveNeighborDirections(letter.MyDirection)[1]) ? letter.OnPlane.
                        RetrieveNeighborDirections(letter.MyDirection)[0] : letter.OnPlane.RetrieveNeighborDirections(
                        letter.MyDirection)[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        break;
                    case 'O':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),

                        (letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0]
                        > letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1]) ?
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection)[1],

                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = letter.OnPlane.GetOppositeDirection(letter.MyDirection);

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();
                        currentDirection = letter.OnPlane.GetOppositeDirection(firstDirection.Direction);

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();
                        currentDirection = letter.OnPlane.GetOppositeDirection(secondDirection.Direction);

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        break;
                    case 'R':

                        int[] threeUnitsAwayDirections = new int[2];
                        int[] perpendicularDirections;

                        letter.OnPlane.RetrieveDistancedDirections(letter.MyDirection, 3, threeUnitsAwayDirections);

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        (threeUnitsAwayDirections[0] > threeUnitsAwayDirections[1]) ?
                        threeUnitsAwayDirections[0] : threeUnitsAwayDirections[1],
                        letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        perpendicularDirections = letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction);

                        if (letter.OnPlane.AreDirectionsNFarApart(letter.MyDirection, perpendicularDirections[0], 1))
                            currentDirection = perpendicularDirections[0];
                        else
                            currentDirection = perpendicularDirections[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();

                        perpendicularDirections = letter.OnPlane.RetrievePerpendicularDirections(letter.MyDirection);

                        if (letter.OnPlane.AreDirectionsNFarApart(firstDirection.Direction, perpendicularDirections[0], 5) &&
                            letter.OnPlane.AreDirectionsNFarApart(secondDirection.Direction, perpendicularDirections[0], 3))
                            currentDirection = perpendicularDirections[0];
                        else
                            currentDirection = perpendicularDirections[1];

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        break;
                    case 'S':

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.MyDirection, letter.SharedDirection.DirectionLength, letter.SharedDirection.Divisor,
                        letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = (letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[0]
                        > letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[1]) ?
                        letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();
                        currentDirection = letter.OnPlane.GetOppositeDirection(firstDirection.Direction);

                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        forthDirection = new R2NCDirection(new R2Point(thirdDirection.RetrieveNextStartingPoint(
                        secondDirection.Direction)), secondDirection.Direction, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[3], letter.Duration[3], 1);

                        forthDirection.RemoveLastPoint();

                        fifthDirection = new R2NCDirection(new R2Point(forthDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[4], letter.Duration[4], 1);

                        fifthDirection.RemoveLastPoint();

                        break;
                    default:

                        firstDirection = new R2NCDirection(new R2Point(letter.StartingPoint),
                        letter.OnPlane.GetOppositeDirection(letter.MyDirection), letter.SharedDirection.DirectionLength,
                        letter.SharedDirection.Divisor, letter.CanShootList[0], letter.Duration[0], 1);

                        currentDirection = (letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[0]
                        > letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[1]) ?
                        letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[0] :
                        letter.OnPlane.RetrievePerpendicularDirections(firstDirection.Direction)[1];

                        secondDirection = new R2NCDirection(new R2Point(firstDirection.RetrieveNextStartingPoint(
                        currentDirection)), currentDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[1], letter.Duration[1], 1);

                        secondDirection.RemoveLastPoint();


                        thirdDirection = new R2NCDirection(new R2Point(secondDirection.RetrieveNextStartingPoint(
                        letter.MyDirection)), letter.MyDirection, letter.SharedDirection.DirectionLength, letter.
                        SharedDirection.Divisor, letter.CanShootList[2], letter.Duration[2], 1);

                        thirdDirection.RemoveLastPoint();

                        break;
                }
            }

            linkedList.Add(firstDirection);

            if (secondDirection != null)
                linkedList.Add(secondDirection);
            if (thirdDirection != null)
                linkedList.Add(thirdDirection);
            if (forthDirection != null)
                linkedList.Add(forthDirection);
            if (fifthDirection != null)
                linkedList.Add(fifthDirection);
        }

        public override bool IsLetterDimensionCorrect()
        {
            throw new NotImplementedException();
        }





        public override bool IsC(List<int> directions)
        {
            return letter.IsC(directions);
        }

        public override bool IsI(List<int> directions)
        {
            return letter.IsI(directions);
        }

        public override bool IsL(List<int> directions)
        {
            return letter.IsL(directions);
        }

        public override bool IsM(List<int> directions)
        {
            return letter.IsM(directions);
        }

        public override bool IsN(List<int> directions)
        {
            return letter.IsN(directions);
        }

        public override bool IsO(List<int> directions)
        {
            return letter.IsO(directions);
        }

        public override bool IsR(List<int> directions)
        {
            return letter.IsR(directions);
        }

        public override bool IsS(List<int> directions)
        {
            return letter.IsS(directions);
        }

        public override bool IsW(List<int> directions)
        {
            return letter.IsW(directions);
        }

        public override bool IsLetter(List<int> directions)
        {
            throw new NotImplementedException();
        }
    }
}
