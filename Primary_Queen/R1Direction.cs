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
    public class R1Direction<IDirection> : Direction<IDirection, R1Point>
    {
        public new Point StartingPoint
        {
            get
            {
                return _startingPoint;
            }
            set
            {
                if (value != null && value.GetDimension() == 1)
                {
                    _startingPoint = value;
                    Fill();
                }
            }
        }

        public SharedDirection SharedDirection
        {
            get { return sharedDirection; }
            set
            {
                if (value.Divisor != 0 &&
                value.XLength % value.Divisor == 0 
                && value.Divisor < value.XLength)
                {
                    sharedDirection = value;
                    //Fill();
                }
            }
        }

        public R1Direction()
        {
            _startingPoint = new R1Point().Position;
            direction = 1;
            maximumDirection = 2;
        }

        public R1Direction(R1Point[] points)
        : base(points)
        {
            maximumDirection = 2;
        }

        public R1Direction(R1Point startingPoint, int direction, float directionLength,
        float divisor, int duration, int numberOfTimes, bool circular)
        : base(startingPoint.Position, direction, new SharedDirection(directionLength, divisor), 
        new List<bool>(), duration,numberOfTimes, circular)
        {
            elements = new R1Point[(int)(directionLength/divisor)];
            maximumDirection = 2;

        }

        public R1Direction(R1Point startingPoint, int direction, float directionLength,
        float divisor, List<bool> canShootList, int duration,
        int numberOfTimes, bool circular)
        : base(startingPoint.Position, direction, new SharedDirection(directionLength,divisor), canShootList,
        duration, numberOfTimes, circular)
        {
            elements = new R1Point[(int)(directionLength / divisor)];
            maximumDirection = 2;

        }

       

        // Used if we only know the points making up this direction.
        // All other attributes are to be generated.
        protected override void Instantiate(R1Point[] points)
        {
            if (points.Length >= 2)
            {
                float difference = Math.Abs(points[0].GetXCoordinate() - points[1].GetXCoordinate());

                for (int i = 0; i < points.Length - 1; i++)
                    if (Math.Abs(points[i].GetXCoordinate() - points[i + 1].GetXCoordinate()) != difference)
                        throw new Exception("The difference between points making up a direction should be the same.");

                if (points[0].GetXCoordinate() > points[1].GetXCoordinate())
                    direction = 2;
                else if (points[0].GetXCoordinate() < points[1].GetXCoordinate())
                    direction = 1;
                else
                    throw new Exception("There should be no duplicates points making up a direction.");

                _startingPoint = points[0].Position;
                sharedDirection = new SharedDirection(points.Length, difference);
                maximumDirection = 2;

            }
        }

        // Only reflect about the origin. That is axisIndex 1.     
        public override IDirection ReflectAboutAxis(int axisIndex)
        {

            int originalDirection = direction;
            Point originalPoint = _startingPoint;

            _startingPoint = new R1Point(-1 * _startingPoint.GetAxisAt(0)).Position;


            if (axisIndex == 1)
            {
                if (direction == 1)
                    MyDirection = 2;
                else if (direction == 2)
                    MyDirection = 1;
            }

            IDirection reflectedDirection = (IDirection)Clone();

            MyDirection = originalDirection;
            StartingPoint = originalPoint;

            return reflectedDirection;
        }

        // Determines whether or not a direction is within the boundaries.
        public new bool IsDirectionValid(int direction)
        {
            return direction == 1 || direction == 2;
        }

        // The set the values for the Translate method.
        public override IDirection Translate(int coordinateSystemDirection, float amount)
        {

            float finalX = _startingPoint.GetAxisAt(0);
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

            Point point = new R1Point(_startingPoint).Position;

            point.SetAxisAt(0, finalX);
            StartingPoint = point;

            IDirection translatedDirection = (IDirection)Clone();

            point.SetAxisAt(0, originalXCoordinate);
            StartingPoint = point;

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

        // Add points making up this direction.
        // Directio 1 --> Right +x.
        // Any direction value correspond to Direction 2 --> Left -x.
        public override void Fill()
        {
            for (int index = 0; index < elements.Length; index++)
                elements[index] = null;



            R1Point point = new R1Point(_startingPoint);
            elements[0] = point;

            for (int i = 1; i <= SharedDirection.XLength / SharedDirection.Divisor; i++)
                // Going left.
                if (MyDirection == 1)
                    elements[i] = new R1Point(point.GetXCoordinate() - i * SharedDirection.Divisor);
                // Going right.
                else
                    elements[i] = new R1Point(point.GetXCoordinate() + i * SharedDirection.Divisor);
            RepeatDirection();
        }

        // Helper method for comparing two objects of this class.
        private int CompareTo(R1Direction<IDirection> other)
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
                if (sharedDirection.Divisor < other.SharedDirection.Divisor)
                {
                    result = -1;
                }

                else if (sharedDirection.Divisor > other.SharedDirection.Divisor)
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

            return result;
        }

        // Makes a copy of the current object.
        public override object Clone()
        {
            return new R1Direction<IDirection>(new R1Point(_startingPoint), direction,
                sharedDirection.XLength, sharedDirection.Divisor,
                CreateDuration(duration), numberOfTimes, circular);
        }

        // Find the direction opposite to this direction.
        // The opposite direction starts on the last point of this direction.
        public override Direction<IDirection, R1Point> GetOppositeDirection()
        {
            return new R1Direction<IDirection>(GetLast(), (direction == 1) ? 2 : 1,
            sharedDirection.XLength, sharedDirection.Divisor,
            canShootList, CreateDuration(duration), numberOfTimes, circular);
        }

        // Reflect a point about a direction that has both axis coordinate changing.
        // The method is unsupported for a one dimensional direction. 
        // However the method will return a non reflection of this current object.
        public override IDirection ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            return (IDirection)Clone();
        }

        /* The method is unsupported for a one dimensional direction. 
           However the method will return a non reflection of the current object.
           For the rotate method this R1doubleDirection instance will be returned because in R1 rotation isn't applicable.*/
        public override IDirection RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            return (IDirection)Clone();
        }

        // Comparing two objects of this class.
        public override int CompareTo(IDirection other)
        {
            return CompareTo(other);
        }

        // The starting point for the direction following this one when making a letter.
        public override Point RetrieveNextStartingPoint(int direction)
        {
            Point newStartingPoint = GetLast().Position;

            if (direction == 1)
                newStartingPoint.SetAxisAt(0, GetLast().Position.GetAxisAt(0) + sharedDirection.XLength / sharedDirection.Divisor);
            else if(direction == 2)
                newStartingPoint.SetAxisAt(0, GetLast().Position.GetAxisAt(0) - sharedDirection.XLength / sharedDirection.Divisor);

            return newStartingPoint;
        }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public override bool IsParallellTo(int axis)
        {
            bool returnValue = false;

            if (axis == 1)
            {
                returnValue = true;
            }

            return returnValue;
        }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public override bool IsPerpendicularTo(int axis)
        {
            return false;
        }

        // The method is unsupported for a one dimensional direction. 
        // However the method will return a non reflection of this current object.
        public override IDirection RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return (IDirection)Clone();
        }
    }
}
