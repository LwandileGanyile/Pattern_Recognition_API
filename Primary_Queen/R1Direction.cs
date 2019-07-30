using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using BuildingBlocks;
using SharedResources;


namespace Primary_Queen
{
    // U is either R1CircularDirection or R1CircularDirection.
    public class R1Direction<IDirection> :  IDirection<R1Direction<IDirection>>
    {

        private Direction<R1Point> direction;

        public Point StartingPoint
        {
            get
            {
                return direction.StartingPoint;
            }
            set
            {
                if (value != null && value.GetDimension() == 1)
                {
                    direction.StartingPoint = value;
                }
            }
        }

        public Direction<R1Point> Direction { get; }

        public R1Direction()
        {
            direction = new Direction<R1Point>();
            direction.StartingPoint = new R1Point().Position;
            direction.SharedDirection = new SharedDirection(2);
            direction.DirectionComponentLength = 2;
            direction.MyDirection = 1;
            direction.MaximumDirection = 2;
            
        }

        public R1Direction(R1Point startingPoint, int direction, float directionLength,
        float divisor, List<float> speedList, float speed)
        {
            this.direction = new Direction<R1Point>(startingPoint.Position, direction, 
            new SharedDirection(directionLength, divisor), speedList, speed);

            this.direction.SharedDirection = new SharedDirection(directionLength, divisor);

            this.direction.DirectionComponentLength = this.direction.SharedDirection.Length[
            this.direction.SharedDirection.Length.Count - 1] - this.direction.SharedDirection.Length[0];

            this.direction.MaximumDirection = 2;

        }

        // Only reflect about the origin. That is axisIndex 1.     
        public R1Direction<IDirection> ReflectAboutAxis(int axisIndex)
        {

            int originalDirection = direction.MyDirection;
            Point originalPoint = StartingPoint;

            StartingPoint = new R1Point(-1 * StartingPoint.GetAxisAt(0)).Position;


            if (axisIndex == 1)
            {
                if (direction.MyDirection == 1)
                    direction.MyDirection = 2;
                else if (direction.MyDirection == 2)
                    direction.MyDirection = 1;
            }

            R1Direction<IDirection> reflectedDirection = (R1Direction < IDirection > )Clone();

            direction.MyDirection = originalDirection;
            StartingPoint = originalPoint;

            return reflectedDirection;
        }

        // Determines whether or not a direction is within the boundaries.
        public bool IsDirectionValid(int direction)
        {
            return direction == 1 || direction == 2;
        }

        // The set the values for the Translate method.
        public R1Direction<IDirection> Translate(int coordinateSystemDirection, float amount)
        {

            float finalX = StartingPoint.GetAxisAt(0);
            float originalXCoordinate = finalX;


            switch (coordinateSystemDirection)
            {
                case 1:
                    finalX -= Math.Abs(amount);

                    break;
                default:
                    finalX += Math.Abs(amount);
                    break;

            }

            Point point = new R1Point(StartingPoint).Position;

            point.SetAxisAt(0, finalX);
            StartingPoint = point;

            R1Direction<IDirection> translatedDirection = (R1Direction < IDirection > )Clone();

            point.SetAxisAt(0, originalXCoordinate);
            StartingPoint = point;

            return translatedDirection;

        }

        // Print this direction.      
        public  void Display()
        {
            Console.WriteLine("---------------R1 Direction helper----------------");
            direction.ToString();

        }

        // Add points making up this direction.
        // Directio 1 --> Right +x.
        // Any direction value correspond to Direction 2 --> Left -x.
        public  void Fill(MyLinkedList<R1Point> points)
        {
            points.Clear();

            R1Point point = new R1Point(StartingPoint);
            ;

            for (int i = 1; i <= direction.SharedDirection.GetNumberOfElements(); i++)
                // Going left.
                if (direction.MyDirection == 1)
                    points.Add(new R1Point(point.GetXCoordinate() - i * direction.SharedDirection.Divisor));
                // Going right.
                else
                    points.Add(new R1Point(point.GetXCoordinate() + i * direction.SharedDirection.Divisor));

        }

        // Helper method for comparing two objects of this class.
        public int CompareTo(R1Direction<IDirection> other)
        {
            int result = 0;

            if (direction.SharedDirection.GetDirectionLength() < other.Direction.SharedDirection.GetDirectionLength())
            {
                result = -1;
            }

            else if (direction.SharedDirection.GetDirectionLength() > other.Direction.SharedDirection.GetDirectionLength())
            {
                result = 1;
            }

            else
            {
                if (direction.SharedDirection.Divisor < other.Direction.SharedDirection.Divisor)
                {
                    result = -1;
                }

                else if (direction.SharedDirection.Divisor > other.Direction.SharedDirection.Divisor)
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

            return result;
        }

        // Makes a copy of the current object.
        public  object Clone()
        {
            return new R1Direction<IDirection>(new R1Point(StartingPoint), direction.MyDirection,
                direction.SharedDirection.GetDirectionLength(), direction.SharedDirection.Divisor,
                direction.SpeedList, direction.Speed);
        }

        // Find the direction opposite to this direction.
        // The opposite direction starts on the last point of this direction.
        public  R1Direction<IDirection> GetOppositeDirection(R1Point lastPoint)
        {
            return new R1Direction<IDirection>(lastPoint, 
            (direction.MyDirection == 1) ? 2 : 1, direction.
            SharedDirection.GetDirectionLength(), direction.
            SharedDirection.Divisor, direction.SpeedList, direction.Speed);
        }

        // Reflect a point about a direction that has both axis coordinate changing.
        // The method is unsupported for a one dimensional direction. 
        // However the method will return a non reflection of this current object.
        public R1Direction<IDirection> ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            return (R1Direction<IDirection>)Clone();
        }

        /* The method is unsupported for a one dimensional direction. 
           However the method will return a non reflection of the current object.
           For the rotate method this R1doubleDirection instance will be returned because in R1 rotation isn't applicable.*/
        public R1Direction<IDirection> RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            return (R1Direction<IDirection>)Clone();
        }

        // The starting point for the direction following this one.
        public  Point RetrieveNextStartingPoint(int direction, R1Point lastPoint)
        {
            Point newStartingPoint = lastPoint.Position;

            if (direction == 1)
                newStartingPoint.SetAxisAt(0, lastPoint.Position.GetAxisAt(0) + this.direction.SharedDirection.Divisor);
            else if(direction == 2)
                newStartingPoint.SetAxisAt(0, lastPoint.Position.GetAxisAt(0) - this.direction.SharedDirection.Divisor);

            return newStartingPoint;
        }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public  bool IsParallellTo(int axis)
        {
            bool returnValue = false;

            if (axis == 1)
            {
                returnValue = true;
            }

            return returnValue;
        }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public  bool IsPerpendicularTo(int axis)
        {
            return false;
        }

        // The method is unsupported for a one dimensional direction. 
        // However the method will return a non reflection of this current object.
        public R1Direction<IDirection> RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return (R1Direction<IDirection>)Clone();
        }

        // The method is unsupported for a one dimensional direction.
        public R1Direction<IDirection> ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return (R1Direction<IDirection>)Clone();
        }
    }
}
