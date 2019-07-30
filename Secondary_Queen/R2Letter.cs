using SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secondary_Queen
{
    public class R2Letter<R2Direction,V> : IPartOf<R2Letter<R2Direction,V>>, ILetter<R2Letter<R2Direction, V>>
    {
        private Letter<R2Direction> letter;
        private List<R2Direction<V>> directions = new List<R2Direction<V>>();

        public Letter<R2Direction> Letter { get; }
        internal List<R2Direction<V>> Directions { get; set; }

        public R2Letter()
        {
            letter = new Letter<R2Direction>();
            letter.OnPlane = R2Plane.GetR2Plane();
            letter.StartingPoint = new R2Point().Position;
        }

        public R2Letter(R2Plane onPlane, R2Point startingPoint, bool smaller,
        char letter, int direction, List<ISharedDirection> sharedDirections,
        List<float> speedList, float speed, List<List<bool>> pointsCanSwitchList,
        List<List<float>> pointsSpeedList)             
       {
            this.letter = new Letter<R2Direction>(
            R2Plane.GetR2Plane(), startingPoint.Position, smaller, letter,
            direction, sharedDirections, speedList, speed, pointsCanSwitchList,
            pointsSpeedList);
        }

        public R2Letter(R2Plane onPlane, R2Point startingPoint,
        List<int> directions, List<ISharedDirection> sharedDirections,
        List<float> speedList, float speed, List<List<bool>> pointsCanSwitchList,
        List<List<float>> pointsSpeedList)     
        {
            letter = new Letter<R2Direction>(
            R2Plane.GetR2Plane(), startingPoint.Position, directions, 
            sharedDirections,speedList, speed, pointsCanSwitchList,
            pointsSpeedList);
        }

        

        private R2Letter(List<R2Direction<V>> directions)
        {
            
        }

        // Make a copy of this letter.
        public object Clone()
        {
            return new R2Letter<R2Direction, V>(R2Plane.GetR2Plane(), new R2Point (letter.StartingPoint), 
            letter.Smaller, letter.MyLetter, letter.MyDirection, letter.SharedDirections,
            letter.SpeedList, letter.Speed, letter.PointsCanSwitchList,letter.PointsSpeedList);
        }

        // Compare two letters.
        public int CompareTo(R2Letter<R2Direction,V> other)
        {
            int returnValue = 0;

            if (letter.MyLetter < other.letter.MyLetter)
            {
                returnValue = -1;
            }

            else if (letter.MyLetter < other.letter.MyLetter)
            {
                returnValue = 1;
            }

            else
            {

                if (letter.MyDirection < other.letter.MyDirection)
                    returnValue = -1;
                else if (letter.MyDirection > other.letter.MyDirection)
                    returnValue = 1;
                else
                {
                    if (letter.Smaller && !other.letter.Smaller)
                        returnValue = -1;
                    else if (!letter.Smaller && other.letter.Smaller)
                        returnValue = 1;
                }

            }

            return returnValue;
        }

        // Print this letter.
        public void Display()
        {
            Console.WriteLine("------------------R2Letter--------------");
            Console.WriteLine(letter.ToString());            
        }

        // Reflect this letter about any valid axis.
        public R2Letter<R2Direction,V> ReflectAboutAxis(int axisIndex)
        {
            List<R2Direction<V>> translatedList = new List<R2Direction<V>>();

            foreach (R2Direction<V> direction in directions)
                translatedList.Add(direction.ReflectAboutAxis(axisIndex));

            return new R2Letter<R2Direction, V>(translatedList);
        }

        // Reflect a letter about a direction that has both axis coordinate changing.
        public R2Letter<R2Direction,V> ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return ReflectAboutEqualAxis(new List<int>(axisIndeces), numberOfTimes);
        }

        // Reflect this letter about any valid equals axiss, e.g y=z, z = -x etc.
        public R2Letter<R2Direction,V> ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            List<R2Direction<V>> translatedList = new List<R2Direction<V>>();

            foreach (R2Direction<V> direction in directions)
                translatedList.Add(direction.ReflectAboutEqualAxis(axisIndeces, numberOfTimes));

            return new R2Letter<R2Direction, V>(translatedList);
        }

        // Rotate this letter about the given axis.
        public R2Letter<R2Direction,V> RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            List<R2Direction<V>> translatedList = new List<R2Direction<V>>();

            foreach (R2Direction<V> direction in directions)
                translatedList.Add(direction.RotateAroundAxis(indexOfAxis, numberOfTimes));

            return new R2Letter<R2Direction, V>(translatedList);
        }

        public R2Letter<R2Direction,V> RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            List<R2Direction<V>> translatedList = new List<R2Direction<V>>();

            foreach (R2Direction<V> direction in directions)
                translatedList.Add(direction.RotateAroundEqualAxis(axisIndeces, numberOfTimes));

            return new R2Letter<R2Direction, V>(translatedList);
        }

        // Move this letter  from one point to another.
        public R2Letter<R2Direction,V> Translate(int coordinateSystemDirection, float amaunt)
        {
            List<R2Direction<V>> translatedList = new List<R2Direction<V>>();

            foreach (R2Direction<V> direction in directions)
                translatedList.Add(direction.Translate(coordinateSystemDirection,amaunt));

            return new R2Letter<R2Direction, V>(translatedList);
        }

        /*protected void Instantiate(R2Direction<IDirection<V>>[] directions)
        {
            List<int> letterDirections = new List<int>();
            List<ISharedDirection> letterLengths = new List<ISharedDirection>();

            for (int index = 0; index < directions.Length; index++)
            {
                letterDirections.Add(directions[index].Direction.MyDirection);
                letterLengths.Add(directions[index].Direction.SharedDirection);
            }

            if (!letter.IsLetter(letterDirections, letterLengths))
                throw new Exception("Make sure the combination of directions make up a letter and it is a single letter.");

            letter.OnPlane = R2Plane.GetR2Plane();

            if (letter.IsC(letterDirections, letterLengths)) letter.MyLetter = 'C'; 
            else if (letter.IsI(letterDirections, letterLengths)) letter.MyLetter = 'I'; 
            else if (letter.IsL(letterDirections, letterLengths)) letter.MyLetter = 'L'; 
            else if (letter.IsM(letterDirections, letterLengths)) letter.MyLetter = 'M';  
            else if (letter.IsN(letterDirections, letterLengths)) letter.MyLetter = 'N';  
            else if (letter.IsO(letterDirections, letterLengths)) letter.MyLetter = 'O';  
            else if (letter.IsR(letterDirections, letterLengths)) letter.MyLetter = 'R';  
            else if (letter.IsS(letterDirections, letterLengths)) letter.MyLetter = 'S';
            else letter.MyLetter = 'W';

            float directionDivisor = directions[0].Direction.SharedDirection.Divisor;

            for (int index = 1; index < directions.Length; index++)
                if (directions[index].Direction.SharedDirection.Divisor != directionDivisor)
                    throw new Exception("Make sure the divisor of all directions is the same.");

            letter.SharedDirections = new List<ISharedDirection>();

            for (int index = 0; index < directions.Length;index++)
                letter.SharedDirections[index] = 
                new SharedDirection(directions[index].
                    Direction.SharedDirection.Length[0], 
                    directions[index].Direction.SharedDirection.
                    Length[1], directionDivisor);

            letter.MaximumDirection = 8;

            if (letter.MyLetter == 'C' || letter.MyLetter == 'M' || letter.MyLetter == 'N' || letter.MyLetter == 'O' || 
                letter.MyLetter == 'S' || letter.MyLetter == 'W')
                letter.Smaller = (letterDirections[1] < letter.OnPlane.GetOppositeDirection(letterDirections[1]) ? true : false);
            else if (letter.MyLetter == 'L' || letter.MyLetter == 'R')
                letter.Smaller = (letterDirections[0] < letter.OnPlane.GetOppositeDirection(letterDirections[0]) ? true : false);
            else
                letter.Smaller = false;

            letter.MyDirection = letterDirections[letterDirections.Count-1];
            letter.StartingPoint = directions[0].Direction.GetFirst().Position;
            

        }*/

        protected void FillSharedDirections()
        {
            letter.SharedDirections = new List<ISharedDirection>();

            switch (letter.MyLetter)
            {
                case 'W':
                    if (letter.MyDirection == 4 || letter.MyDirection == 5 || letter.MyDirection == 6 || letter.MyDirection == 7)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                    }
                    else if (letter.MyDirection == 2 || letter.MyDirection == 3)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[3] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(2, 0, 1);
                    }
                    break;
                case 'I':
                    if(letter.MyDirection == 1 || letter.MyDirection == 8)
                        letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                    else if (letter.MyDirection == 2 || letter.MyDirection == 3)
                        letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                    else
                        letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                    break;
                case 'L':
                    if (letter.MyDirection == 1 || letter.MyDirection == 8)
                    {
                        letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                    }
                    else if (letter.MyDirection == 2 || letter.MyDirection == 3)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                    }
                    break;
                case 'M':
                    if (letter.MyDirection == 2 || letter.MyDirection == 3)
                    {
                        letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(0, 2, 1);
                    }
                    else if (letter.MyDirection == 1 || letter.MyDirection == 8)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(2, 0, 1);
                    }
                    else if (letter.MyDirection == 4)
                    {
                        if (letter.Smaller)
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else if (letter.MyDirection == 5)
                    {
                        if (letter.Smaller)
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else if (letter.MyDirection == 6)
                    {
                        if (letter.Smaller)
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else
                    {
                        if (letter.Smaller)
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                    }
                    break;
                case 'N':
                    if (letter.MyDirection == 2 || letter.MyDirection == 3)
                    {
                        letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                    }
                    else if (letter.MyDirection == 1 || letter.MyDirection == 8)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                    }
                    else if (letter.MyDirection == 4 || letter.MyDirection == 5)
                    {
                        if (letter.Smaller)
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else if (letter.MyDirection == 6)
                    {
                        if (letter.Smaller)
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else
                    {
                        if (letter.Smaller)
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                    }
                    break;
                case 'O':
                    if (letter.MyDirection == 1 || letter.MyDirection == 8)
                    {
                        letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(2, 0, 1);
                    }
                    else if (letter.MyDirection == 2 || letter.MyDirection == 3)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[3] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                    }
                    break;
                case 'R':
                    if (letter.MyDirection == 1 || letter.MyDirection == 8)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(0, 3, 1);
                        letter.SharedDirections[4] = new SharedDirection(3, 0, 1);
                    }
                    else if (letter.MyDirection == 2 || letter.MyDirection == 3)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(3, 0, 1);
                        letter.SharedDirections[4] = new SharedDirection(0, 3, 1);
                    }
                    else if (letter.MyDirection == 4 || letter.MyDirection == 7)
                    {
                        if (letter.Smaller)
                        {
                            letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[4] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[4] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else
                    {
                        if (!letter.Smaller)
                        {
                            letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[4] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                            letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                            letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                            letter.SharedDirections[4] = new SharedDirection(2, 2, 1);
                        }
                    }
                    break;
                case 'S':
                    if (letter.MyDirection == 1 || letter.MyDirection == 8)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[3] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[4] = new SharedDirection(2, 0, 1);
                    }
                    else if (letter.MyDirection == 2 || letter.MyDirection == 3)
                    {
                        letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[4] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[3] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[4] = new SharedDirection(2, 2, 1);
                    }
                    break;
                default:
                    if (letter.MyDirection == 1 || letter.MyDirection == 8)
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[1] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 0, 1);
                    }
                    else if (letter.MyDirection == 2 || letter.MyDirection == 3)
                    {
                        letter.SharedDirections[0] = new SharedDirection(0, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 0, 1);
                        letter.SharedDirections[2] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        letter.SharedDirections[0] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[1] = new SharedDirection(2, 2, 1);
                        letter.SharedDirections[2] = new SharedDirection(2, 2, 1);
                    }
                    break;

            }
        }

        public bool IsDirectionValid(int direction)
        {
            return letter.IsDirectionValid(direction);
        }

        public void DisplayLetterInfo()
        {
            letter.DisplayLetterInfo();
        }

        public bool IsC(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsC(directions, lengths);
        }

        public bool IsI(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsI(directions, lengths);
        }

        public bool IsL(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsL(directions, lengths);
        }

        public bool IsM(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsM(directions, lengths);
        }

        public bool IsN(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsN(directions, lengths);
        }

        public bool IsO(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsO(directions, lengths);
        }

        public bool IsR(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsR(directions, lengths);
        }

        public bool IsS(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsS(directions, lengths);
        }

        public bool IsW(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsW(directions, lengths);
        }

        public bool IsLetter(List<int> directions, List<ISharedDirection> lengths)
        {
            return letter.IsLetter(directions,lengths);
        }
    }
}
