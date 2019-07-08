using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using SharedResources;
using Game_Defination;

namespace SharedResources
{
    public abstract class Helper<T, U>
    {

        protected internal U[] elements;
        protected internal Point _startingPoint;
        protected internal int direction;
        protected internal Dictionary<int, int> duration;
        protected internal int numberOfTimes;
        protected internal List<bool> canShootList;
        protected internal int maximumDirection;
        protected const int minimumDirection = 1;
        protected internal bool circular;
        protected internal bool canShoot = true;


        public int MinimumDirection { get; }
        public int MaximumDirection { get; }

        public int MyDirection
        {

            get
            {
                return direction;
            }

            set
            {
                if (value >= minimumDirection && value <= maximumDirection)
                {
                    direction = value;
                    //Fill();
                }
            }
        }
        public List<bool> CanShootList
        {

            get { return canShootList; }
            set
            {
                if (value != null && value.Count == canShootList.Count)
                    canShootList = value;
            }
        }
        public int NumberOfTimes
        {
            get { return numberOfTimes; }
            set
            {
                if (value > 0)
                {
                    numberOfTimes = value;
                    //Fill();
                }
            }
        }
        public Dictionary<int, int> Duration
        {
            get { return duration; }
            set { if (value != null && value.Count == duration.Count) duration = value; }
        }
        public U[] Elements
        {
            get
            {
                return elements;
            }

            set
            {
                if (value != null)
                    elements = value;
            }
        }
        public bool Circular
        {
            get
            {
                return circular;
            }

            set
            {
                circular = value;
                //Fill();
            }
        }
        public Point StartingPoint { get; set; }
        public bool CanShoot { get; set; }
       

        protected internal Helper()
        {
            numberOfTimes = 2;
            duration = new Dictionary<int, int>();
            canShootList = new List<bool>();
            elements = new U[GetDefaultSize()];
            circular = true;
            
        }

        // Only direction subclass uses this constructor.
        // Other subclasses should also use it.
        // Shared direction is null.
        protected internal Helper(U[] elements)
        {
            Instantiate(elements);
            duration = new Dictionary<int, int>();
            canShootList = new List<bool>();
            this.elements = elements;
            numberOfTimes = 2;
            circular = true;
        }

        protected internal Helper(Point startingPoint, int direction,
        List<bool> canShootList,Dictionary<int, int> duration, 
        int numberOfTimes, bool circular)

        {
            
            if (!IsDurationValid(duration))
                throw new Exception("Make sure all duration values and keys are greater than zero.");
            this.duration = duration;

            if (direction < 1)
                throw new Exception("The passed direction is incorrect, it must be at least 1.");
            this.direction = direction;

            if (numberOfTimes < 1)
                throw new Exception("The passed number of repeatations/rotations is incorrect, it must be at least 1.");
            this.numberOfTimes = numberOfTimes;

            if (canShootList.Count != duration.Count)
                throw new Exception("The number of elements in the can shoot " +
                    "list must be equals to the number of elements in a duration " +
                    "dictionary.");
            this.canShootList = canShootList;
            _startingPoint = startingPoint;
            this.circular = circular;
        }

        protected abstract void Instantiate(U[] points);

        protected abstract int GetDefaultSize();

        // Get the last point on this direction.
        public U GetLast()
        {
            return elements[elements.Length - 1];
        }

        // Get the first point on this direction.
        public U GetFirst()
        {
            return elements[0];
        }

        // Checks whether the times given are valid.
        public bool IsDurationValid(Dictionary<int, int> duration)
        {
            foreach (KeyValuePair<int, int> pair in duration)
                if (pair.Key < 0 || pair.Value < 0)
                    return false;

            return true;
        }

        // Fill the duration of this direction.
        // All points making up this direction have the same period.
        public void FillDuration(int circularTotalTime)
        {
            for (int i = 0; i < elements.Length; i++)
                duration.Add(i, circularTotalTime / (elements.Length));
        }

        // Determines whether or not a direction is within the boundaries.
        public bool IsDirectionValid(int direction)
        {
            return direction >= minimumDirection && direction <= maximumDirection;
        }

        // String representation of this circular direction.
        public string ToString<V>(V baseClass, int numberOfRotations)
        {
            string output = baseClass.ToString() + "\n";

            string elementsString = "";

            for (int index = 0; index < elements.Length; index++)
                elementsString += (elements[index].ToString() + "\n");

            return output + elementsString + "\nNumber Of rotations/repeatations : " + numberOfRotations;
        }

        // Fill the can shoot list will false values only.
        public void FillCanShoot()
        {
            for (int i = 0; i < elements.Length; i++)
                canShootList.Add(false);
        }

       

    }
}
