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
    public class R2Direction<IDirection> :  IPartOf<R2Direction<IDirection>>, IDirectionHelper<R2Point>
    {
        private Direction<R2Point> direction;

        public Direction<R2Point> Direction { get; }

        public R2Direction()
        {
            direction = new Direction< R2Point>();
            direction.StartingPoint = new R2Point().Position;
            direction.SharedDirection = new SharedDirection(2);
            direction.DirectionComponentLength = 2;
            direction.MyDirection = 6;
            direction.MaximumDirection = 8;
        }

        public R2Direction(R2Point startingPoint, int direction, float xLength,
        float yLength,  float divisor, List<float> speedList, float speed)
        {
            this.direction = new Direction<R2Point> (startingPoint.Position,
            direction, new SharedDirection(xLength, yLength, divisor), speedList,
            speed);

            this.direction.SharedDirection = new SharedDirection(xLength, yLength, divisor);

            this.direction.DirectionComponentLength = this.direction.SharedDirection.Length[
            this.direction.SharedDirection.Length.Count - 1] - this.direction.SharedDirection.Length[0];

            this.direction.MaximumDirection = 8;
        }

        // Reflect about the x-axis or y-axis.
        public R2Direction<IDirection> ReflectAboutAxis(int axisIndex)
        {
            int originalDirection = direction.MyDirection;
            float originalXCoordinate = direction.StartingPoint.GetAxisAt(0);
            float originalYCoordinate = direction.StartingPoint.GetAxisAt(1);

            int newDirection = originalDirection;
            float newYCoordinate = originalYCoordinate;
            float newXCoordinate = originalXCoordinate;


            if (axisIndex == 1)
            {
                newYCoordinate = -1 * originalYCoordinate;
                switch (direction.MyDirection)
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
                switch (direction.MyDirection)
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

            direction.StartingPoint = new R2Point(newXCoordinate, newYCoordinate).Position;
            direction.MyDirection = newDirection;

            direction.StartingPoint = new R2Point(originalXCoordinate, originalYCoordinate).Position;
            direction.MyDirection = originalDirection;


            return (R2Direction<IDirection>)Clone();
            ;
        }

        // Determines whether or not a direction is within the boundaries.
        public bool IsDirectionValid(int direction)
        {
            return direction >= 1 && direction <= 8;
        }

        // Move a direction along one of the eight possible directions.
        public R2Direction<IDirection> Translate(int coordinateSystemDirection, float amount)
        {

            float originalXCoordinate = direction.StartingPoint.GetAxisAt(0);
            float originalYCoordinate = direction.StartingPoint.GetAxisAt(1);

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

            direction.StartingPoint = new R2Point(newXCoordinate, newYCoordinate).Position;


            direction.StartingPoint = new R2Point(originalXCoordinate, originalYCoordinate).Position;
            return (R2Direction<IDirection>)Clone();
        }

        // Print this direction.
        // Belongs to hepler class.
        public void Display()
        {
            Console.WriteLine("---------------R2 Direction helper----------------");
            direction.ToString();

        }

        // Fill this direction with one of the eight possibilities.
        // Directio 1-7.
        // Any direction value correspond to Direction 8.
        public void Fill(MyLinkedList<R2Point> points)
        {
            points.Clear();

            R2Point point = new R2Point(direction.StartingPoint);
            points.Add(point);


            for (int i = 0; i < direction.SharedDirection.GetNumberOfElements(); i++)
                switch (direction.MyDirection)
                {
                    case 1:
                        points.Add(new R2Point(point.GetXCoordinate() - i * direction.SharedDirection.Divisor, point.GetYCoordinate()));
                        break;
                    case 2:
                        points.Add(new R2Point(point.GetXCoordinate(), point.GetYCoordinate() + i * direction.SharedDirection.Divisor));
                        break;
                    case 3:
                        points.Add(new R2Point(point.GetXCoordinate(), point.GetYCoordinate() - i * direction.SharedDirection.Divisor));
                        break;
                    case 4:
                        points.Add(new R2Point(point.GetXCoordinate() - i * direction.SharedDirection.Divisor,
                            point.GetYCoordinate() + i * direction.SharedDirection.Divisor));
                        break;
                    case 5:
                        points.Add(new R2Point(point.GetXCoordinate() + i * direction.SharedDirection.Divisor,
                            point.GetYCoordinate() - i * direction.SharedDirection.Divisor));
                        break;
                    case 6:
                        points.Add(new R2Point(point.GetXCoordinate() + i * direction.SharedDirection.Divisor,
                            point.GetYCoordinate() + i * direction.SharedDirection.Divisor));
                        break;
                    case 7:
                        points.Add(new R2Point(point.GetXCoordinate() - i * direction.SharedDirection.Divisor,
                            point.GetYCoordinate() - i * direction.SharedDirection.Divisor));
                        break;
                    default:
                        points.Add(new R2Point(point.GetXCoordinate() + i * direction.SharedDirection.Divisor, point.GetYCoordinate()));
                        break;
                }
        }

        // Reflect a point about a direction that has both axis coordinate changing.
        // Reflect about the  line y = x or y = -x a certain number of times, and return the result.
        // A negetive element means on the negetive side of the axis.
        // Reflect about y = x and y = -x. However y = x correspond to two axis indeces,
        // likewise for y = -x.
        public R2Direction<IDirection> ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            R2Direction<IDirection> r2Direction = (R2Direction < IDirection > )Clone();

            for (int i = 0; i < numberOfTimes; i++)
            {
                if ((axisIndeces[0] == 1 && axisIndeces[1] == 1) || (axisIndeces[0] == -1 && axisIndeces[1] == -1))
                {
                    switch (direction.MyDirection)
                    {
                        case 1:
                            direction.MyDirection = 3;
                            break;
                        case 2:
                            direction.MyDirection = 8;
                            break;
                        case 3:
                            direction.MyDirection = 1;
                            break;
                        case 4:
                            direction.MyDirection = 5;
                            break;
                        case 5:
                            direction.MyDirection = 4;
                            break;
                        case 6:
                            direction.MyDirection = 6;
                            break;
                        case 7:
                            direction.MyDirection = 7;
                            break;
                        case 8:
                            direction.MyDirection = 2;
                            break;
                    }
                }

                else if ((axisIndeces[0] == -1 && axisIndeces[1] == 1) || (axisIndeces[0] == 1 && axisIndeces[1] == -1))
                {
                    switch (direction.MyDirection)
                    {
                        case 1:
                            direction.MyDirection = 2;
                            break;
                        case 2:
                            direction.MyDirection = 1;
                            break;
                        case 3:
                            direction.MyDirection = 8;
                            break;
                        case 4:
                            direction.MyDirection = 4;
                            break;
                        case 5:
                            direction.MyDirection = 5;
                            break;
                        case 6:
                            direction.MyDirection = 7;
                            break;
                        case 7:
                            direction.MyDirection = 6;
                            break;
                        case 8:
                            direction.MyDirection = 3;
                            break;
                    }
                }

                SharedDirection shared = (SharedDirection)direction.SharedDirection;
                r2Direction = new R2Direction<IDirection>(new R2Point(direction.StartingPoint), 
                direction.MyDirection,shared.XLength, shared.YLength, shared.Divisor, 
                direction.SpeedList, direction.Speed);
            }
            return r2Direction;

        }

        public int CompareTo(R2Direction<IDirection> other)
        {
            int result = 0;
            SharedDirection shared = (SharedDirection)direction.SharedDirection;

            if (shared.XLength < ((SharedDirection)other.Direction.SharedDirection).XLength)
            {
                result = -1;
            }

            else if (shared.XLength > ((SharedDirection)other.Direction.SharedDirection).XLength)
            {
                result = 1;
            }

            else
            {
                if (shared.YLength < ((SharedDirection)other.Direction.SharedDirection).YLength)
                {
                    result = -1;
                }

                else if (shared.YLength > ((SharedDirection)other.Direction.SharedDirection).YLength)
                {
                    result = 1;
                }

                else
                {
                    if (shared.Divisor > ((SharedDirection)other.Direction.SharedDirection).Divisor)
                    {
                        result = -1;
                    }

                    else if (shared.Divisor < ((SharedDirection)other.Direction.SharedDirection).Divisor)
                    {
                        result = 1;
                    }

                    else
                    {
                        if (direction.MyDirection < other.Direction.MyDirection)
                        {
                            result = -1;
                        }

                        else if (direction.MyDirection > other.Direction.MyDirection)
                        {
                            result = 1;
                        }


                    }
                }

                
            }

            return result;
        }
        
        // Makes a copy of the current object.
        public object Clone()
        {
            SharedDirection shared = (SharedDirection)direction.SharedDirection;
            return new R2Direction<IDirection>(new R2Point(direction.StartingPoint), 
                direction.MyDirection,shared.XLength, shared.YLength, direction.
                SharedDirection.Divisor, direction.SpeedList, direction.Speed);
        }

        // Find the direction opposite to this direction.
        // The opposite direction starts on the last point of this direction.      
        public R2Direction<IDirection> GetOppositeDirection(R2Point lastPoint)
        {
            int newDirection;

            switch (direction.MyDirection)
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

            SharedDirection shared = (SharedDirection)direction.SharedDirection;
            return new R2Direction<IDirection>(lastPoint, newDirection,
            shared.XLength, shared.YLength, direction.SharedDirection.Divisor,
            direction.SpeedList, direction.Speed);
        }

        // The starting point for the direction following this one when making a letter.
        public Point RetrieveNextStartingPoint(int direction, R2Point lastPoint)
        {
            Point newStartingPoint = lastPoint.Position;

            switch (direction)
            {
                case 1:
                    newStartingPoint.SetAxisAt(0, lastPoint.Position.GetAxisAt(0) - this.direction.SharedDirection.Divisor);
                    break;
                case 2:
                    newStartingPoint.SetAxisAt(1, lastPoint.Position.GetAxisAt(1) + this.direction.SharedDirection.Divisor);
                    break;
                case 3:
                    newStartingPoint.SetAxisAt(1, lastPoint.Position.GetAxisAt(1) - this.direction.SharedDirection.Divisor);
                    break;
                case 4:
                    newStartingPoint.SetAxisAt(0, lastPoint.Position.GetAxisAt(0) - this.direction.SharedDirection.Divisor);
                    newStartingPoint.SetAxisAt(1, lastPoint.Position.GetAxisAt(1) + this.direction.SharedDirection.Divisor);
                    break;
                case 5:
                    newStartingPoint.SetAxisAt(0, lastPoint.Position.GetAxisAt(0) + this.direction.SharedDirection.Divisor);
                    newStartingPoint.SetAxisAt(1, lastPoint.Position.GetAxisAt(1) - this.direction.SharedDirection.Divisor);
                    break;
                case 6:
                    newStartingPoint.SetAxisAt(0, lastPoint.Position.GetAxisAt(0) + this.direction.SharedDirection.Divisor);
                    newStartingPoint.SetAxisAt(1, lastPoint.Position.GetAxisAt(1) + this.direction.SharedDirection.Divisor);
                    break;
                case 7:
                    newStartingPoint.SetAxisAt(0, lastPoint.Position.GetAxisAt(0) - this.direction.SharedDirection.Divisor);
                    newStartingPoint.SetAxisAt(1, lastPoint.Position.GetAxisAt(1) - this.direction.SharedDirection.Divisor);
                    break;
                case 8:
                    newStartingPoint.SetAxisAt(0, lastPoint.Position.GetAxisAt(0) + this.direction.SharedDirection.Divisor);
                    break;
            }

            return newStartingPoint;
        }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public bool IsParallellTo(int axis)
        {
            bool returnValue = false;

            if (axis == 1 && (direction.MyDirection == 1 || direction.MyDirection == 8))
            {
                returnValue = true;
            }

            else if (axis == 2 && (direction.MyDirection == 2 || direction.MyDirection == 3))
            {
                returnValue = true;
            }

            return returnValue;
        }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public bool IsPerpendicularTo(int axis)
        {
            bool returnValue = false;

            if (axis == 1 && (direction.MyDirection == 2 || direction.MyDirection == 3))
            {
                returnValue = true;
            }

            else if (axis == 2 && (direction.MyDirection == 1 || direction.MyDirection == 8))
            {
                returnValue = true;
            }

            return returnValue;
        }

        // Rotate about the  x-axis or y-axis a certatin number of times, and return the result.
        // Rotate around the x-axis or the y-axis.
        public R2Direction<IDirection> RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            return (R2Direction<IDirection>) Clone();
        }

        // Rotate about the  line y = x or y = -x a certain number of times, and return the result.
        // Rotate about y = x and y = -x.
        public R2Direction<IDirection> RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return (R2Direction<IDirection>)Clone();
        }

        // Reflect about y = x or y = -x.
        public R2Direction<IDirection> ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return ReflectAboutEqualAxis(new List<int>(axisIndeces),numberOfTimes);
        }

        
    }
}
