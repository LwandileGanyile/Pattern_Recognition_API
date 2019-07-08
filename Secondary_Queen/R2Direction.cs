using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using BuildingBlocks;
using SharedResources;

namespace Secondary_Queen
{

    // U is either R2CircularDirection or R2CircularDirection.
    public class R2Direction<IDirection> : Direction<IDirection, R2Point>, ILetterPart
    {


        public new Point StartingPoint
        {
            get
            {
                return _startingPoint;
            }
            set
            {
                if (value != null && value.GetDimension() == 2)
                {
                    _startingPoint = value;
                    Fill();
                }
            }
        }

        public SharedDirection SharedDirection
        {
            get { return (SharedDirection)sharedDirection; }
            set
            {
                if (value.Divisor != 0 &&
                value.XLength % value.Divisor == 0 && value.YLength % value.Divisor == 0
                && (value.Divisor < value.XLength || value.Divisor < value.YLength) )
                {
                    sharedDirection = value;
                    //Fill();
                }
            }
        }

        public R2Direction()
        {
            _startingPoint = new R2Point().Position;
            direction = 6;
            maximumDirection = 8;
        }

        public R2Direction(R2Point[] points)
        : base(points)
        {
            maximumDirection = 8;
        }

        public R2Direction(R2Point startingPoint, int direction, float xLength,
        float yLength,float divisor, int duration,
        int numberOfTimes, bool circular)
        : base(startingPoint.Position, direction, new SharedDirection(xLength, yLength, divisor),
        new List<bool>(), duration,numberOfTimes, circular)
        {
            elements = new R2Point[(int)(Math.Sqrt(xLength*xLength + yLength*yLength))];
            maximumDirection = 8;
        }

        public R2Direction(R2Point startingPoint, int direction, float xLength,
        float yLength, float divisor, List<bool> canShootList, int duration,
        int numberOfTimes, bool circular)
        : base(startingPoint.Position, direction, new SharedDirection(xLength, yLength,divisor), 
        canShootList,duration, numberOfTimes, circular)
        {
            elements = new R2Point[(int)(Math.Sqrt(xLength * xLength + yLength * yLength))];
            maximumDirection = 8;
        }

        // Used if we only know the points making up this direction.
        // All other attributes are to be generated.
        protected override void Instantiate(R2Point[] points)
        {
            if (points.Length >= 2)
            {
                float difference;
                if (Math.Abs(elements[0].GetXCoordinate() - elements[1].GetXCoordinate()) != 0)
                    difference = Math.Abs(elements[0].GetXCoordinate() - elements[1].GetXCoordinate());
                else if (Math.Abs(elements[0].GetYCoordinate() - elements[1].GetYCoordinate()) != 0)
                    difference = Math.Abs(elements[0].GetYCoordinate() - elements[1].GetYCoordinate());
                else
                    throw new Exception("Any two consecutive points must have a common x or y difference.");

                for (int i = 0; i < points.Length - 1; i++)
                    if ((Math.Abs(elements[i].GetXCoordinate() - points[i + 1].GetXCoordinate()) != difference)
                        || (Math.Abs(elements[i].GetYCoordinate() - points[i + 1].GetYCoordinate()) != difference))
                        throw new Exception("The difference between points making up a direction should be the same.");

                if (elements[0].GetXCoordinate() > elements[1].GetXCoordinate()
                    && elements[0].GetYCoordinate() > elements[1].GetYCoordinate())
                    direction = 6;
                else if (elements[0].GetXCoordinate() < elements[1].GetXCoordinate()
                    && elements[0].GetYCoordinate() < elements[1].GetYCoordinate())
                    direction = 7;
                else if (elements[0].GetXCoordinate() < elements[1].GetXCoordinate()
                    && elements[0].GetYCoordinate() > elements[1].GetYCoordinate())
                    direction = 5;
                else if (elements[0].GetXCoordinate() > elements[1].GetXCoordinate()
                    && elements[0].GetYCoordinate() < elements[1].GetYCoordinate())
                    direction = 4;
                else if (elements[0].GetXCoordinate() == elements[1].GetXCoordinate()
                   && elements[0].GetYCoordinate() < elements[1].GetYCoordinate())
                    direction = 2;
                else if (elements[0].GetXCoordinate() == elements[1].GetXCoordinate()
                   && elements[0].GetYCoordinate() > elements[1].GetYCoordinate())
                    direction = 3;
                else if (elements[0].GetXCoordinate() > elements[1].GetXCoordinate()
                   && elements[0].GetYCoordinate() == elements[1].GetYCoordinate())
                    direction = 8;
                else if (elements[0].GetXCoordinate() < elements[1].GetXCoordinate()
                   && elements[0].GetYCoordinate() == elements[1].GetYCoordinate())
                    direction = 1;
                else
                    throw new Exception("There should be no duplicates points making up a direction.");

                _startingPoint = points[0].Position;
                sharedDirection = new SharedDirection(
                                  Math.Abs(points[0].GetXCoordinate() - points[points.Length - 1].GetXCoordinate()),
                                  Math.Abs(points[0].GetYCoordinate() - points[points.Length - 1].GetYCoordinate()), 
                                  difference);
                maximumDirection = 8;
            }
        }

        // Reflect about the x-axis, y-axis or z-axis.
        public override IDirection ReflectAboutAxis(int axisIndex)
        {
            int originalDirection = direction;
            float originalXCoordinate = _startingPoint.GetAxisAt(0);
            float originalYCoordinate = _startingPoint.GetAxisAt(1);

            int newDirection = originalDirection;
            float newYCoordinate = originalYCoordinate;
            float newXCoordinate = originalXCoordinate;


            if (axisIndex == 1)
            {
                newYCoordinate = -1 * originalYCoordinate;
                switch (direction)
                {

                    case 2:
                        newDirection = 3;
                        break;
                    case 3:
                        newDirection = 2;
                        break;
                    case 4:
                        newDirection = 7;
                        break;
                    case 5:
                        newDirection = 6;
                        break;
                    case 6:
                        newDirection = 5;
                        break;
                    case 7:
                        newDirection = 4;
                        break;

                }
            }

            else if (axisIndex == 2)
            {
                newXCoordinate = -1 * originalXCoordinate;
                switch (direction)
                {
                    case 1:
                        newDirection = 8;
                        break;
                    case 4:
                        newDirection = 6;
                        break;
                    case 5:
                        newDirection = 7;
                        break;
                    case 6:
                        newDirection = 4;
                        break;
                    case 7:
                        newDirection = 5;
                        break;
                    case 8:
                        newDirection = 1;
                        break;
                }
            }

            StartingPoint = new R2Point(newXCoordinate, newYCoordinate).Position;
            MyDirection = newDirection;

            IDirection reflectedDirection = (IDirection)Clone();

            StartingPoint = new R2Point(originalXCoordinate, originalYCoordinate).Position;
            MyDirection = originalDirection;


            return reflectedDirection;
        }

        // Determines whether or not a direction is within the boundaries.
        public new bool IsDirectionValid(int direction)
        {
            return direction >= 1 && direction <= 8;
        }

        // Move a direction along one of the eight possible directions.
        public override IDirection Translate(int coordinateSystemDirection, float amount)
        {

            float originalXCoordinate = _startingPoint.GetAxisAt(0);
            float originalYCoordinate = _startingPoint.GetAxisAt(1);

            float newXCoordinate = originalXCoordinate;
            float newYCoordinate = originalYCoordinate;

            switch (coordinateSystemDirection)
            {
                case 1:
                    newXCoordinate -= Math.Abs(amount);
                    break;
                case 2:
                    newYCoordinate += Math.Abs(amount);
                    break;
                case 3:
                    newYCoordinate -= Math.Abs(amount);
                    break;
                case 4:
                    newXCoordinate -= Math.Abs(amount);
                    newYCoordinate += Math.Abs(amount);
                    break;
                case 5:
                    newXCoordinate += Math.Abs(amount);
                    newYCoordinate -= Math.Abs(amount);
                    break;
                case 6:
                    newXCoordinate += Math.Abs(amount);
                    newYCoordinate += Math.Abs(amount);
                    break;
                case 7:
                    newXCoordinate -= Math.Abs(amount);
                    newYCoordinate -= Math.Abs(amount);
                    break;
                case 8:
                    newXCoordinate += Math.Abs(amount);
                    break;

            }

            StartingPoint = new R2Point(newXCoordinate, newYCoordinate).Position;

            IDirection translatedDirection = (IDirection)Clone();

            StartingPoint = new R2Point(originalXCoordinate, originalYCoordinate).Position;
            return translatedDirection;
        }

        // Print this direction.      
        public override void Display()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i].Display();
                if (i != elements.Length - 1)
                    Console.Write(" , ");
            }

        }

        // Fill this direction with one of the eight possibilities.
        // Directio 1-7.
        // Any direction value correspond to Direction 8.
        public override void Fill()
        {
            for (int index = 0; index < elements.Length; index++)
                elements[index] = null;

            R2Point point = new R2Point(_startingPoint);
            elements[0] = point;


            for (int i = 0; i < elements.Length; i++)
                switch (direction)
                {
                    case 1:
                        elements[i] = new R2Point(point.GetXCoordinate() - i * sharedDirection.Divisor, point.GetYCoordinate());
                        break;
                    case 2:
                        elements[i] = new R2Point(point.GetXCoordinate(), point.GetYCoordinate() + i * sharedDirection.Divisor);
                        break;
                    case 3:
                        elements[i] = new R2Point(point.GetXCoordinate(), point.GetYCoordinate() - i * sharedDirection.Divisor);
                        break;
                    case 4:
                        elements[i] = new R2Point(point.GetXCoordinate() - i * sharedDirection.Divisor,
                            point.GetYCoordinate() + i * sharedDirection.Divisor);
                        break;
                    case 5:
                        elements[i] = new R2Point(point.GetXCoordinate() + i * sharedDirection.Divisor,
                            point.GetYCoordinate() - i * sharedDirection.Divisor);
                        break;
                    case 6:
                        elements[i] = new R2Point(point.GetXCoordinate() + i * sharedDirection.Divisor,
                            point.GetYCoordinate() + i * sharedDirection.Divisor);
                        break;
                    case 7:
                        elements[i] = new R2Point(point.GetXCoordinate() - i * sharedDirection.Divisor,
                            point.GetYCoordinate() - i * sharedDirection.Divisor);
                        break;
                    default:
                        elements[i] = new R2Point(point.GetXCoordinate() + i * sharedDirection.Divisor, point.GetYCoordinate());
                        break;
                }

            RepeatDirection();


        }

        // Reflect a point about a direction that has both axis coordinate changing.
        // Reflect about the  line y = x or y = -x a certain number of times, and return the result.
        // A negetive element means on the negetive side of the axis.
        // Reflect about y = x and y = -x. However y = x correspond to two axis indeces,
        // likewise for y = -x.
        public override IDirection ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            IDirection<IDirection> r2Direction = (IDirection<IDirection>)Clone();

            for (int i = 0; i < numberOfTimes; i++)
            {
                if ((axisIndeces[0] == 1 && axisIndeces[1] == 1) || (axisIndeces[0] == -1 && axisIndeces[1] == -1))
                {
                    switch (direction)
                    {
                        case 1:
                            direction = 3;
                            break;
                        case 2:
                            direction = 8;
                            break;
                        case 3:
                            direction = 1;
                            break;
                        case 4:
                            direction = 5;
                            break;
                        case 5:
                            direction = 4;
                            break;
                        case 6:
                            direction = 6;
                            break;
                        case 7:
                            direction = 7;
                            break;
                        case 8:
                            direction = 2;
                            break;
                    }
                }

                else if ((axisIndeces[0] == -1 && axisIndeces[1] == 1) || (axisIndeces[0] == 1 && axisIndeces[1] == -1))
                {
                    switch (direction)
                    {
                        case 1:
                            direction = 2;
                            break;
                        case 2:
                            direction = 1;
                            break;
                        case 3:
                            direction = 8;
                            break;
                        case 4:
                            direction = 4;
                            break;
                        case 5:
                            direction = 5;
                            break;
                        case 6:
                            direction = 7;
                            break;
                        case 7:
                            direction = 6;
                            break;
                        case 8:
                            direction = 3;
                            break;
                    }
                }

                r2Direction = (new R2Direction<IDirection>(new R2Point(StartingPoint), direction,
                SharedDirection.XLength, SharedDirection.YLength, SharedDirection.Divisor, canShootList,
                CreateDuration(duration), numberOfTimes, circular));
            }
            return (IDirection)r2Direction;

        }

        // Comparing two objects of this class.
        public override int CompareTo(IDirection other)
        {
            return CompareTo(other);
        }

        // Hepler method for comparing two objects of this class.
        private int CompareTo(R2Direction<IDirection> other)
        {
            int result = 0;

            if (sharedDirection.XLength < other.SharedDirection.XLength)
            {
                result = -1;
            }

            else if (sharedDirection.XLength > other.SharedDirection.XLength)
            {
                result = 1;
            }

            else
            {
                if (SharedDirection.YLength < other.SharedDirection.YLength)
                {
                    result = -1;
                }

                else if (SharedDirection.YLength > other.SharedDirection.YLength)
                {
                    result = 1;
                }

                else
                {
                    if (sharedDirection.Divisor > other.SharedDirection.Divisor)
                    {
                        result = -1;
                    }

                    else if (sharedDirection.Divisor < other.SharedDirection.Divisor)
                    {
                        result = 1;
                    }

                    else
                    {
                        if (MyDirection < other.MyDirection)
                        {
                            result = -1;
                        }

                        else if (MyDirection > other.MyDirection)
                        {
                            result = 1;
                        }


                    }
                }

                
            }

            return result;
        }

        // Makes a copy of the current object.
        public override object Clone()
        {
            return new R2Direction<IDirection>(new R2Point(_startingPoint), direction,
                SharedDirection.XLength, SharedDirection.YLength, sharedDirection.Divisor,
                canShootList, CreateDuration(duration), numberOfTimes, circular);
        }

        // Find the direction opposite to this direction.
        // The opposite direction starts on the last point of this direction.      
        public override Direction<IDirection, R2Point> GetOppositeDirection()
        {
            int newDirection;

            switch (direction)
            {
                case 1:
                    newDirection = 8;
                    break;
                case 2:
                    newDirection = 3;
                    break;
                case 3:
                    newDirection = 2;
                    break;
                case 4:
                    newDirection = 5;
                    break;
                case 5:
                    newDirection = 4;
                    break;
                case 6:
                    newDirection = 7;
                    break;
                case 7:
                    newDirection = 6;
                    break;
                default:
                    newDirection = 1;
                    break;


            }


            return new R2Direction<IDirection>(GetLast(), newDirection,
            SharedDirection.XLength, SharedDirection.YLength, sharedDirection.Divisor,
            canShootList, CreateDuration(duration), numberOfTimes, circular);
        }

        // The starting point for the direction following this one when making a letter.
        public override Point RetrieveNextStartingPoint(int direction)
        {
            Point newStartingPoint = GetLast().Position;

            switch (direction)
            {
                case 1:
                    newStartingPoint.SetAxisAt(0, GetLast().Position.GetAxisAt(0) - elements.Length);
                    break;
                case 2:
                    newStartingPoint.SetAxisAt(1, GetLast().Position.GetAxisAt(1) + elements.Length);
                    break;
                case 3:
                    newStartingPoint.SetAxisAt(1, GetLast().Position.GetAxisAt(1) - elements.Length);
                    break;
                case 4:
                    newStartingPoint.SetAxisAt(0, GetLast().Position.GetAxisAt(0) - elements.Length);
                    newStartingPoint.SetAxisAt(1, GetLast().Position.GetAxisAt(1) + elements.Length);
                    break;
                case 5:
                    newStartingPoint.SetAxisAt(0, GetLast().Position.GetAxisAt(0) + elements.Length);
                    newStartingPoint.SetAxisAt(1, GetLast().Position.GetAxisAt(1) - elements.Length);
                    break;
                case 6:
                    newStartingPoint.SetAxisAt(0, GetLast().Position.GetAxisAt(0) + elements.Length);
                    newStartingPoint.SetAxisAt(1, GetLast().Position.GetAxisAt(1) + elements.Length);
                    break;
                case 7:
                    newStartingPoint.SetAxisAt(0, GetLast().Position.GetAxisAt(0) - elements.Length);
                    newStartingPoint.SetAxisAt(1, GetLast().Position.GetAxisAt(1) - elements.Length);
                    break;
                case 8:
                    newStartingPoint.SetAxisAt(0, GetLast().Position.GetAxisAt(0) + elements.Length);
                    break;
            }

            return newStartingPoint;
        }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public override bool IsParallellTo(int axis)
        {
            bool returnValue = false;

            if (axis == 1 && (direction == 1 || direction == 8))
            {
                returnValue = true;
            }

            else if (axis == 2 && (direction == 2 || direction == 3))
            {
                returnValue = true;
            }

            return returnValue;
        }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public override bool IsPerpendicularTo(int axis)
        {
            bool returnValue = false;

            if (axis == 1 && (direction == 2 || direction == 3))
            {
                returnValue = true;
            }

            else if (axis == 2 && (direction == 1 || direction == 8))
            {
                returnValue = true;
            }

            return returnValue;
        }

        // Rotate about the  x-axis or y-axis a certatin number of times, and return the result.
        // Rotate around the x-axis or the y-axis.
        public override IDirection RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            return (IDirection)Clone();
        }

        // Rotate about the  line y = x or y = -x a certain number of times, and return the result.
        // Rotate about y = x and y = -x.
        public override IDirection RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return (IDirection)Clone();
        }
    }
}
