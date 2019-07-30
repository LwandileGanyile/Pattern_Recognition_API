using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Pieces;
using NonCircularIteration;
using SharedResources;

namespace Primary_Queen
{
    public class R1NCDirection :  ICloneable, IPrimaryDirection
    {
        private NonCircularDirection<R1NCDirection, R1Point> nonCircularDirection;
        private R1Direction<R1NCDirection> directionHelper;

        public NonCircularDirection<R1NCDirection, R1Point> Direction { get; }
        public R1Direction<R1NCDirection> DirectionHelper { get; }

        public R1NCDirection()
        : base()
        {
            nonCircularDirection = new NonCircularDirection<R1NCDirection, R1Point>();
            directionHelper = new R1Direction<R1NCDirection>();

            InitializeAttributes();

        }

        public R1NCDirection(R1Direction<R1NCDirection> directionHelper)
        {
            this.directionHelper = directionHelper;

            nonCircularDirection = new NonCircularDirection<R1NCDirection, R1Point>(
            CreateCanSwitchList(), true, 1);

            InitializeAttributes();

        }

        public R1NCDirection(R1Point startingPoint, int direction, float directionLength,
        float directionDivisor, List<float> speedList, List<bool> canSwitchList,
        int numberOfRepeatations, bool canSwitch, float speed)
        {
            nonCircularDirection = new NonCircularDirection<R1NCDirection, R1Point>(
            canSwitchList, canSwitch, numberOfRepeatations);

            directionHelper = new R1Direction<R1NCDirection>(startingPoint, direction,
            directionLength, directionDivisor, speedList, speed);


            InitializeAttributes();
        }

        private List<bool> CreateCanSwitchList()
        {
            List<bool> canSwitchList = new List<bool>();
            for (int i = 0; i < nonCircularDirection.LinkedList.Size; i++)
                canSwitchList.Add(true);
            return canSwitchList;
        }

        // Initialize all other attributes from a list of points.
        public void InitializeAttributes()
        {          
            if (nonCircularDirection.LinkedList.Size == 0)
                directionHelper.Fill(nonCircularDirection.LinkedList);

            if (nonCircularDirection.CanSwitchList.Count == 0)
                nonCircularDirection.FillCanSwitchList(CreateCanSwitchList());

            if (directionHelper.Direction.SpeedList.Count == 0)
                directionHelper.Direction.FillSpeedList(10);
        }

        // String representation of this circular direction.
        public override string ToString()
        {
            string output = base.ToString() + "\n";

            return output + nonCircularDirection.LinkedList.ToString() + "\nNumber Of repeatations : " + nonCircularDirection.NumberOfTimes;
        }

        // Make a copy of this direction.
        public object Clone()
        {

            SharedDirection shared = (SharedDirection)directionHelper.Direction.SharedDirection;
            return new R1NCDirection(new R1Point(directionHelper.Direction.StartingPoint),
                directionHelper.Direction.MyDirection, shared.XLength,
                directionHelper.Direction.SharedDirection.Divisor, directionHelper.Direction.SpeedList,
                nonCircularDirection.CanSwitchList,nonCircularDirection.NumberOfTimes, 
                nonCircularDirection.CanSwitch, directionHelper.Direction.Speed);
        }

        // Determines whether or not a direction is within the boundaries.
        public bool IsDirectionValid(int direction)
        {
            return directionHelper.IsDirectionValid(direction);
        }

        // The starting point for the direction following this one when making a letter.
        public R1Point RetrieveNextStartingPoint(int direction)
        {
            return new R1Point(nonCircularDirection.RetrieveNextStartingPoint(direction));
        }

        // Rotate about the  x-axis or y-axis a certatin number of times, and return the result.
        // Rotate around the x-axis or the y-axis.
        public R1NCDirection RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            return new R1NCDirection(directionHelper.RotateAroundAxis(indexOfAxis, numberOfTimes));
        }

        // Rotate about the  line y = x or y = -x a certain number of times, and return the result.
        // Rotate about y = x and y = -x.
        public R1NCDirection RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return new R1NCDirection(directionHelper.RotateAroundEqualAxis(axisIndeces, numberOfTimes));
        }

        // Reflect about the x-axis or y-axis.
        public R1NCDirection ReflectAboutAxis(int axisIndex)
        {
            return new R1NCDirection(directionHelper.ReflectAboutAxis(axisIndex));
        }

        // Reflect about y = x or y = -x.
        public R1NCDirection ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return new R1NCDirection(directionHelper.ReflectAboutEqualAxis(axisIndeces, numberOfTimes));
        }

        // Move a direction along one of the eight possible directions.
        public R1NCDirection Translate(int coordinateSystemDirection, float amaunt)
        {
            return new R1NCDirection(directionHelper.Translate(coordinateSystemDirection, amaunt));
        }

        // Print this direction. 
        public void Display()
        {
            directionHelper.Display();
        }

        // Hepler method for comparing two objects of this class.
        public int CompareTo(R1NCDirection other)
        {

            return directionHelper.CompareTo(other.DirectionHelper);
        }

        // Remove the last point on this direction.
        public void RemoveLast() { nonCircularDirection.RemoveLast(); }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public bool IsParallellTo(int axis) { return directionHelper.IsParallellTo(axis); }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public bool IsPerpendicularTo(int axis) { return IsPerpendicularTo(axis); }

        // Return an itertator for points.
        // Used in case a player decided to keep track of points.
        public PointIterator<R1Point> RetrievePointIterator()
        {
            return nonCircularDirection.RetrievePointIterator();
        }
    }
}
