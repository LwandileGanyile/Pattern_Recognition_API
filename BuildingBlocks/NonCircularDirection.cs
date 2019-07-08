using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using Pieces;
using SharedResources;
using NonCircularIteration;

namespace BuildingBlocks
{
    public abstract class NonCircularDirection<T, U> : NonCircular<T, U>, IPointIterator<U>, IDirection<T>
    {
        protected Direction<T, U> directionHelper;
        protected bool canShoot;

        public Direction<T, U> DirectionHelper
        {
            get; set;
        }
        public bool CombinedCanShoot { get; set; }

        protected NonCircularDirection()
        :base()
        {

           
        }


        // Construct without specifying the number of canshoot property.
        protected NonCircularDirection(Point startingPoint, int direction, float directionLength,
        float directionDivisor, int duration, int numberOfRepeatations)
        : base(startingPoint, direction, Direction<T, U>.CreateDuration(
        new SharedDirection(directionLength, directionDivisor), duration), numberOfRepeatations)
        {
            

        }

        // Construct without specifying the can shoot property.
        protected NonCircularDirection(Point startingPoint, int direction, float directionLength,
        float directionDivisor, int duration, int numberOfRotations, bool canShoot)
        : base(startingPoint, direction, Direction<T, U>.CreateDuration(
        new SharedDirection(directionLength, directionDivisor), duration), numberOfRotations)
        {
            this.canShoot = canShoot;
        }

        // Construct by specifying the number of rotations.
        protected NonCircularDirection(Point startingPoint, int direction, float directionLength,
        float directionDivisor, List<bool> canShootList, int duration,
        int numberOfRepeatations)
        : base(startingPoint, direction, canShootList, Direction<T, U>.CreateDuration(
        new SharedDirection(directionLength, directionDivisor), duration), numberOfRepeatations)
        {

        }

        // Determines whether or not a direction is within the boundaries.
        public bool IsDirectionValid(int direction){return directionHelper.IsDirectionValid(direction);}

        // Displays direciton.
        public void Display(){directionHelper.Display();}

        // Retrieve last point on points making up this direction.
        public U GetLast(){return directionHelper.GetLast();}

        // Retrieve first point on points making up this direction.
        public U GetFirst(){return directionHelper.GetFirst();}

        // The string presentation of this non circular direction.
        public override string ToString()
        {
            return base.ToString() + "\n" + directionHelper.SharedDirection.ToString();
        }

        // Return an itertator for points.
        /* Can't be put into the proxy(Hepler class or Direction class) 
         because it results on ambiguity between non circular iteration 
         and circular iteration namespaces.*/
        /* The iterator is used to traverse points in case a player
        decided to keep track of them.*/
        public PointIterator<U> RetrievePointIterator()
        {
            return new PointIterator<U>(0, (DoubleLinkedList<U>)linkedList);
        }

        // Use direction helper to initialize attributes of the parent super class.
        protected void InitializeAttributes()
        {

            direction = directionHelper.MyDirection;
            duration = directionHelper.Duration;
            canShootList = directionHelper.CanShootList;

            U[] elements = directionHelper.Elements;

            for (int i = 0; i < elements.Length; i++)
                linkedList.Add(elements[i]);
        }

        // The method checks whether the passed parameter is ready for use by the initialize attribute method.
        // If it not ready, it get altered for use.
        protected void CreateNCDirection(Direction<T, U> directionHelper)
        {
            if (directionHelper.Elements.Length == 0)
                directionHelper.Fill();
            if (directionHelper.Duration.Count == 0)
                directionHelper.FillDuration(1000);
            if (directionHelper.CanShootList.Count == 0)
                directionHelper.FillCanShoot();

            this.directionHelper = directionHelper;

            InitializeAttributes();
        }

        // Add points making up this direction.
        // Directio 1 --> Right +x.
        // Any direction value correspond to Direction 2 --> Left -x.       
        public override void Fill()
        {
            directionHelper.Fill();
            U[] elements = directionHelper.Elements;

            if (linkedList.Size != 0)
                linkedList.Clear();

            for (int i = 0; i < elements.Length; i++)
                linkedList.Add(elements[i]);
        }

        // Move direction. 
        // Change the starting position on a direction.
        public T Translate(int coordinateSystemDirection, float amount){return directionHelper.Translate(coordinateSystemDirection, amount);}

        // The starting point of the resultent direction is the same as the one for initial direction.        
        public T ReflectAboutAxis(int axisIndex){return ((IDirection<T>)directionHelper).ReflectAboutAxis(axisIndex);}

        // The starting point for the direction following this one when making a letter.
        public Point RetrieveNextStartingPoint(int direction) { return directionHelper.RetrieveNextStartingPoint(direction); }

        // Remove the last point of this direction.
        public void RemoveLastPoint() { directionHelper.RemoveLastPoint(); }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public bool IsParallellTo(int axis){return directionHelper.IsParallellTo(axis);}

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public bool IsPerpendicularTo(int axis){return IsPerpendicularTo(axis);}

        public T RotateAroundAxis(int indexOfAxis, int numberOfTimes) { return ((IDirection<T>)directionHelper).RotateAroundAxis(indexOfAxis, numberOfTimes); }
        public T ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes) { return ((IDirection<T>)directionHelper).ReflectAboutEqualAxis(axisIndeces, numberOfTimes); }
        public int CompareTo(T comparableInstance) { return ((IDirection<T>)directionHelper).CompareTo(comparableInstance); }
        public T RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes){return ((IDirection<T>)directionHelper).RotateAroundEqualAxis(axisIndeces, numberOfTimes);}
    }
}
