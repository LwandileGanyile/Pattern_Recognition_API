
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using Pieces;

namespace SharedResources
{
    /* The class contains fields and methods that a common in 
     CircularDirection and NonCircularDirection.*/
    public abstract class Direction<T, U> : Helper<T, U>, IDirection<T>, IFill
    {
        protected SharedDirection sharedDirection;

        
        protected internal Direction()
        : base()
        {
            sharedDirection = new SharedDirection(12, 1);
        }

        protected internal Direction(U[] points)
        : base(points)
        {

        }

        

        protected internal Direction(Point startingPoint, int direction,
        SharedDirection sharedDirection, List<bool> canShootList, int duration,
        int numberOfTimes, bool circular)
        {
            this.sharedDirection = sharedDirection;

            this.duration = CreateDuration(sharedDirection, duration);

            if (direction < 1)
                throw new Exception("The passed direction is incorrect, it must be at least 1.");
            this.direction = direction;

            if (numberOfTimes < 1)
                throw new Exception("The passed number of repeatations/rotations is incorrect, it must be at least 1.");
            this.numberOfTimes = numberOfTimes;

            if (canShootList.Count != this.duration.Count)
                throw new Exception("The number of elements in the can shoot " +
                    "list must be equals to the number of elements in a duration " +
                    "dictionary.");
            this.canShootList = canShootList;
            _startingPoint = startingPoint;
            this.circular = circular;
           
        }

        public static Dictionary<int, int> CreateDuration(SharedDirection sharedDirection, int duration)
        {
            Dictionary<int, int> createdDictionary = new Dictionary<int, int>();

            int evenTime = (int)((duration) / (sharedDirection.Divisor));

            for (int i = 0; i < (int)sharedDirection.Divisor; i++)
                createdDictionary.Add(i, evenTime);

            return createdDictionary;
        }

        public static int CreateDuration(Dictionary<int, int> duration)
        {
            int convertedDuration = 0;

            foreach (KeyValuePair<int, int> pair in duration)
                convertedDuration += pair.Value;
            return convertedDuration;
        }

        // Print this direction.      
        public abstract void Display();
        // Populate this direction with points.
        public abstract void Fill();
        // Move this direction  from one point to another.
        public abstract T Translate(int coordinateSystemDirection, float amaunt);
        // Reflect this point about any valid axis.
        public abstract T ReflectAboutAxis(int axisIndex);
        // Reflect this point about any valid equals axiss, e.g y=z, z = -x etc.
        public abstract T ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes);
        // Compare two directions.
        public abstract int CompareTo(T other);
        // Make a copy of this direciton.
        public abstract object Clone();
        // Get the opposing direction starting at the same point as this direction.
        public abstract Direction<T, U> GetOppositeDirection();
        // Rotate this direction about the given axis.
        public abstract T RotateAroundAxis(int indexOfAxis, int numberOfTimes);

        // Reflect a point about a direction that has both axis coordinate changing.
        public T ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return ReflectAboutEqualAxis(new List<int>(axisIndeces), numberOfTimes);
        }

        // The default size for this direciton.
        protected override int GetDefaultSize() { return 10; }

        // Repeat this direction a certain number of times;
        protected void RepeatDirection()
        {

            int numberOfElements = elements.Length;


            if (circular)
            {
                for (int index = 2; index <= numberOfTimes; index++)
                    for (int x = 0; x < numberOfElements; x++)
                        elements[index] = elements[x];
            }
            else
            {
                for (int index = 2; index <= numberOfTimes; index++)
                    if (index % 2 == 0)
                        for (int x = numberOfElements - 2; x > -1; x--)
                            elements[index] = elements[x];
                    else
                    {
                        for (int x = 1; x < numberOfElements; x++)
                            elements[index] = elements[x];
                    }
            }
        }

        // The starting point for the direction following this one when making a letter.
        public abstract Point RetrieveNextStartingPoint(int direction);

        // Remove the last point on this direction.
        public void RemoveLastPoint()
        {
            U[] newElements = new U[elements.Length - 1];

            for (int i = 0; i < newElements.Length; i++)
                newElements[i] = elements[i];
            elements = newElements;
        }

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public abstract bool IsParallellTo(int axis);

        // Axis start from 1,2...with 1 corresponding to x-axis, 2 corresponding to y-axis and 3 corresponding to z-axis.
        public abstract bool IsPerpendicularTo(int axis);
        public abstract T RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes);
    }
}

