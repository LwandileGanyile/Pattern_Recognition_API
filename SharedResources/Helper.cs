using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using SharedResources;
using Game_Defination;
using System.Collections;

namespace SharedResources
{
    public abstract class Helper<U> 
    {

        // The starting point present the initial points of the elements.
        protected internal Point _startingPoint;

        // This is the direction the elements are pointing at.
        protected internal int direction;

        // The maximum boundary of directions for a given dimension.
        protected internal int maximumDirection;
        // The minimum boundary of directions for a given dimension.
        protected const int minimumDirection = 1;

        // The speeds for moving from element at i to element at i+1 where i>=0 and i < number of elements - 1.
        protected internal List<float> speedList;

        // The speed of this object.
        protected internal float speed;


        public int MinimumDirection { get; }
        public int MaximumDirection { get; set; }

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
                }
            }
        }
        public Point StartingPoint { get; set; }      
        
        public List<float> SpeedList
        {
            get
            {
                return speedList;
            }

            set
            {

                if (value != null && value.Count == speedList.Count)
                    speedList = value;

            }
        }
        public float Speed { get; set; }


        protected internal Helper()
        {          
            speed = 10;
            speedList = new List<float>();
        }

        protected internal Helper(Point startingPoint, int direction,  
        List<float> speedList, float speed)
        {

            if (!IsDirectionValid(direction))
                throw new Exception("Make sure you enter a valid direction.");
            this.direction = direction;

            if (speed < 0)
                throw new Exception("Make sure the speed is a positive number.");
            this.speed = speed;

            if(speedList.Count == 0)
                throw new Exception("Make sure the speed list is non empty.");
            this.speedList = speedList;

            _startingPoint = startingPoint;
        }

        // Checks whether the times given are valid.
        // No Longer useful.
        public bool IsDurationValid(Dictionary<int, int> duration)
        {
            foreach (KeyValuePair<int, int> pair in duration)
                if (pair.Key < 0 || pair.Value < 0)
                    return false;

            return true;
        }

        // Determines whether or not a direction is within the boundaries.
        public bool IsDirectionValid(int direction)
        {
            return direction >= minimumDirection && direction <= maximumDirection;
        }


        // Get the string presentation of the speed list.
        public string GetSpeedPresentation()
        {
            string output = "[ ";
            int i;
            for (i = 0; i < speedList.Count - 1; i++)
                output += speedList[i] + ", ";
            return output + speedList[i+1]+ "]\n";
        }

        // Fill this  speed list using a common speed.
        public void FillSpeedList(float commonSpeed)
        {
            if (speedList.Count == 0)
                for (int i = 0; i < speedList.Count; i++)
                    speedList.Add(commonSpeed);
        }

        // Display the speed list.
        public void DisplaySpeedList()
        {
            int count = 0;

            for (int i = 0; i < speedList.Count; i++)
            {
                if (count % 10 == 0 && count != 0)
                    Console.WriteLine(speedList[i] + " ");
                else
                    Console.Write(speedList[i] + " ");
                count++;
            }

            Console.WriteLine();
        }

        // Find the value of each axis direction component on this direction.
        protected float DetermineDirectionComponentLength(ISharedDirection sharedDirection)
        {
            float firstComponent = sharedDirection.Length[0];

            foreach (float componentLength in sharedDirection.Length)
                if (componentLength != 0 && componentLength != firstComponent)
                    throw new Exception("Make sure all the components of a direction length have equal length.");
            return firstComponent;
        }
    }
}
