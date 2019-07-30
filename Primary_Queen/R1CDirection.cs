using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Pieces;
using CircularIteration;
using SharedResources;

namespace Primary_Queen
{
    public class R1CDirection :  ICloneable, IPrimaryDirection
    {

        private CircularDirection<R1CDirection, R1Point> circularDirection;
        private R1Direction<R1CDirection> directionHelper;

        public CircularDirection<R1CDirection, R1Point> Direction { get; }
        public R1Direction<R1CDirection> DirectionHelper { get; }

        public R1CDirection()
        : base()
        {
            circularDirection = new CircularDirection<R1CDirection, R1Point>();
            directionHelper = new R1Direction<R1CDirection>();
            
            InitializeAttributes();

        }

        public R1CDirection(R1Direction<R1CDirection> directionHelper)
        {
            this.directionHelper = directionHelper;

            circularDirection = new CircularDirection<R1CDirection, R1Point>(
            CreateCanSwitchList(), true, 1);

            InitializeAttributes();

        }
       
        public R1CDirection(R1Point startingPoint, int direction, float directionLength,
        float directionDivisor, List<float> speedList, List<bool> canSwitchList, 
        int numberOfRepeatations, bool canSwitch, float speed)
        {
            circularDirection = new CircularDirection<R1CDirection, R1Point>(
            canSwitchList, canSwitch, numberOfRepeatations);

            directionHelper = new R1Direction<R1CDirection>(startingPoint, direction,
            directionLength, directionDivisor, speedList, speed);


            InitializeAttributes();
        }

        // Create a default can switch list.
        private List<bool> CreateCanSwitchList()
        {
            List<bool> canSwitchList = new List<bool>();
            for (int i = 0; i < circularDirection.LinkedList.Size; i++)
                canSwitchList.Add(true);
            return canSwitchList;
        }

        // Initialize all other attributes from a list of points.
        public void InitializeAttributes()
        {

            if (circularDirection.LinkedList.Size == 0)
                directionHelper.Fill(circularDirection.LinkedList);

            if (circularDirection.CanSwitchList.Count == 0)
                circularDirection.FillCanSwitchList(CreateCanSwitchList());

            if (directionHelper.Direction.SpeedList.Count == 0)
                directionHelper.Direction.FillSpeedList(10);
        }

        // String representation of this circular direction.
        public override string ToString()
        {
            string output = base.ToString() + "\n";

            return output + circularDirection.LinkedList.ToString() + "\nNumber Of repeatations : " + circularDirection.NumberOfTimes;
        }

        // Make a copy of this direction.
        public object Clone()
        {

            SharedDirection shared = (SharedDirection)directionHelper.Direction.SharedDirection;
            return new R1CDirection(new R1Point(directionHelper.Direction.StartingPoint),
                directionHelper.Direction.MyDirection, shared.XLength,
                directionHelper.Direction.SharedDirection.Divisor, directionHelper.Direction.SpeedList,
                circularDirection.CanSwitchList, circularDirection.NumberOfTimes, circularDirection.CanSwitch,
                directionHelper.Direction.Speed);
        }

        // Determines whether or not a direction is within the boundaries.
        public bool IsDirectionValid(int direction)
        {
            return directionHelper.IsDirectionValid(direction);
        }

        // The starting point for the direction following this one when making a letter.
        public R1Point RetrieveNextStartingPoint(int direction)
        {
            return new R1Point(circularDirection.RetrieveNextStartingPoint(direction));
        }

        // Rotate about the  x-axis or y-axis a certatin number of times, and return the result.
        // Rotate around the x-axis or the y-axis.
        public R1CDirection RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            return new R1CDirection(directionHelper.RotateAroundAxis(indexOfAxis, numberOfTimes));
        }

        // Rotate about the  line y = x or y = -x a certain number of times, and return the result.
        // Rotate about y = x and y = -x.
        public R1CDirection RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return new R1CDirection(directionHelper.RotateAroundEqualAxis(axisIndeces, numberOfTimes));
        }

        // Reflect about the x-axis or y-axis.
        public R1CDirection ReflectAboutAxis(int axisIndex)
        {
            return new R1CDirection(directionHelper.ReflectAboutAxis(axisIndex));
        }

        // Reflect about y = x or y = -x.
        public R1CDirection ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return new R1CDirection(directionHelper.ReflectAboutEqualAxis(axisIndeces, numberOfTimes));
        }

        // Move a direction along one of the eight possible directions.
        public R1CDirection Translate(int coordinateSystemDirection, float amaunt)
        {
            return new R1CDirection(directionHelper.Translate(coordinateSystemDirection, amaunt));
        }

        // Print this direction. 
        public void Display()
        {
            directionHelper.Display();
        }

        // Hepler method for comparing two objects of this class.
        public int CompareTo(R1CDirection other)
        {

            return directionHelper.CompareTo(other.DirectionHelper);
        }

        // Remove the last point on this direction.
        public void RemoveLast() { circularDirection.RemoveLast(); }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public bool IsParallellTo(int axis) { return directionHelper.IsParallellTo(axis); }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public bool IsPerpendicularTo(int axis) { return IsPerpendicularTo(axis); }

        // Return an itertator for points.
        // Used in case a player decided to keep track of points.
        public PointIterator<R1Point> RetrievePointIterator()
        {
            return circularDirection.RetrievePointIterator();
        }
    }
}
