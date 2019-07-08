using SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secondary_Queen
{
    public class R2Letter<IDirection, R2Direction> : Letter<IDirection, R2Direction<IDirection>>
    {
        public R2Letter()
        {
            onPlane = R2Plane.GetR2Plane();

            
        }

       public R2Letter(R2Point startingPoint, bool smaller,
       char letter, int direction, Dictionary<int, int> duration, 
       List<bool> canShootList,int numberOfTimes, bool circular)      
       :base(R2Plane.GetR2Plane(), startingPoint.Position, smaller,
       letter, direction, duration, canShootList,
       numberOfTimes, circular)
        {

        }

        public R2Letter(R2Point startingPoint,
        bool smaller, char letter, int direction, List<SharedResources.SharedDirection> sharedDirections,
         Dictionary<int, int> duration, int numberOfTimes, bool circular)
        : base(R2Plane.GetR2Plane(), startingPoint.Position, smaller, letter, direction,
        sharedDirections, duration,numberOfTimes, circular)
        {
            
        }

        public R2Letter(R2Point startingPoint,
        bool smaller, char letter, int direction, List<SharedResources.SharedDirection> sharedDirections,
         Dictionary<int, int> duration, List<bool> canShootList,int numberOfTimes, bool circular)
        : base(R2Plane.GetR2Plane(), startingPoint.Position, smaller, letter, direction,
        sharedDirections, duration, canShootList,numberOfTimes, circular)
        {

        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override int CompareTo(IDirection other)
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Fill()
        {
            throw new NotImplementedException();
        }

        public override IDirection ReflectAboutAxis(int axisIndex)
        {
            throw new NotImplementedException();
        }

        public override IDirection ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override IDirection RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override IDirection RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override IDirection Translate(int coordinateSystemDirection, float amaunt)
        {
            throw new NotImplementedException();
        }

        protected override void Instantiate(R2Direction<IDirection>[] directions)
        {
            List<int> letterDirections = new List<int>();
            List<float> letterLengths = new List<float>();

            for (int index = 0; index < directions.Length; index++)
            {
                letterDirections.Add(directions[index].MyDirection);
                letterLengths.Add(directions[index].SharedDirection.GetDirectionLength());
            }

            if (!IsLetter(letterDirections, letterLengths))
                throw new Exception("Make sure the combination of directions make up a letter and it is a single letter.");

            onPlane = R2Plane.GetR2Plane();

            if (IsC(letterDirections, letterLengths)) letter = 'C'; 
            else if (IsI(letterDirections, letterLengths)) letter = 'I'; 
            else if (IsL(letterDirections, letterLengths)) letter = 'L'; 
            else if (IsM(letterDirections, letterLengths)) letter = 'M';  
            else if (IsN(letterDirections, letterLengths)) letter = 'N';  
            else if (IsO(letterDirections, letterLengths)) letter = 'O';  
            else if (IsR(letterDirections, letterLengths)) letter = 'R';  
            else if (IsS(letterDirections, letterLengths)) letter = 'S';
            else letter = 'W';

            float directionDivisor = directions[0].SharedDirection.Divisor;

            for (int index = 1; index < directions.Length; index++)
                if (directions[index].SharedDirection.Divisor != directionDivisor)
                    throw new Exception("Make sure the divisor of all directions is the same.");

            sharedDirections = new List<SharedResources.SharedDirection>();

            for (int index = 0; index < directions.Length;index++)
                sharedDirections[index] = new Secondary_Queen.SharedDirection(directions[index].SharedDirection.XLength, directions[index].SharedDirection.YLength, directionDivisor);

            maximumDirection = 8;

            if (letter == 'C' || letter == 'M' || letter == 'N' || letter == 'O' || letter == 'S' || letter == 'W')
                smaller = (letterDirections[1] < onPlane.GetOppositeDirection(letterDirections[1]) ? true : false);
            else if (letter == 'L' || letter == 'R')
                smaller = (letterDirections[0] < onPlane.GetOppositeDirection(letterDirections[0]) ? true : false);
            else
                smaller = false;

            direction = letterDirections[letterDirections.Count-1];
            _startingPoint = directions[0].GetFirst().Position;
            

        }

        protected override void FillSharedDirections()
        {
            sharedDirections = new List<SharedResources.SharedDirection>();

            switch (letter)
            {
                case 'W':
                    if (direction == 4 || direction == 5 || direction == 6 || direction == 7)
                    {
                        sharedDirections[0] = new SharedDirection(2, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 2, 1);
                        sharedDirections[3] = new SharedDirection(2, 2, 1);
                    }
                    else if (direction == 2 || direction == 3)
                    {
                        sharedDirections[0] = new SharedDirection(2, 0, 1);
                        sharedDirections[1] = new SharedDirection(0, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 0, 1);
                        sharedDirections[3] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        sharedDirections[0] = new SharedDirection(0, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 0, 1);
                        sharedDirections[2] = new SharedDirection(0, 2, 1);
                        sharedDirections[3] = new SharedDirection(2, 0, 1);
                    }
                    break;
                case 'I':
                    if(direction==1 || direction==8)
                        sharedDirections[0] = new SharedDirection(2, 0, 1);
                    else if (direction == 2 || direction == 3)
                        sharedDirections[0] = new SharedDirection(0, 2, 1);
                    else
                        sharedDirections[0] = new SharedDirection(2, 2, 1);
                    break;
                case 'L':
                    if (direction == 1 || direction == 8)
                    {
                        sharedDirections[0] = new SharedDirection(0, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 0, 1);
                    }
                    else if (direction == 2 || direction == 3)
                    {
                        sharedDirections[0] = new SharedDirection(2, 0, 1);
                        sharedDirections[1] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        sharedDirections[0] = new SharedDirection(2, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                    }
                    break;
                case 'M':
                    if (direction == 2 || direction == 3)
                    {
                        sharedDirections[0] = new SharedDirection(0, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 2, 1);
                        sharedDirections[3] = new SharedDirection(0, 2, 1);
                    }
                    else if (direction == 1 || direction == 8)
                    {
                        sharedDirections[0] = new SharedDirection(2, 0, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 2, 1);
                        sharedDirections[3] = new SharedDirection(2, 0, 1);
                    }
                    else if (direction == 4)
                    {
                        if (smaller)
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(2, 0, 1);
                            sharedDirections[2] = new SharedDirection(0, 2, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(0, 2, 1);
                            sharedDirections[2] = new SharedDirection(2, 0, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else if (direction == 5)
                    {
                        if (smaller)
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(0, 2, 1);
                            sharedDirections[2] = new SharedDirection(2, 0, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(2, 0, 1);
                            sharedDirections[2] = new SharedDirection(0, 2, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else if (direction == 6)
                    {
                        if (smaller)
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(0, 2, 1);
                            sharedDirections[2] = new SharedDirection(2, 0, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(2, 0, 1);
                            sharedDirections[2] = new SharedDirection(0, 2, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else
                    {
                        if (smaller)
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(2, 0, 1);
                            sharedDirections[2] = new SharedDirection(0, 2, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(0, 2, 1);
                            sharedDirections[2] = new SharedDirection(2, 0, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                        }
                    }
                    break;
                case 'N':
                    if (direction == 2 || direction == 3)
                    {
                        sharedDirections[0] = new SharedDirection(0, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(0, 2, 1);
                    }
                    else if (direction == 1 || direction == 8)
                    {
                        sharedDirections[0] = new SharedDirection(2, 0, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 0, 1);
                    }
                    else if (direction == 4 || direction == 5)
                    {
                        if (smaller)
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(0, 2, 1);
                            sharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(2, 0, 1);
                            sharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else if (direction == 6)
                    {
                        if (smaller)
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(2, 0, 1);
                            sharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(0, 2, 1);
                            sharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else
                    {
                        if (smaller)
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(0, 2, 1);
                            sharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            sharedDirections[0] = new SharedDirection(2, 2, 1);
                            sharedDirections[1] = new SharedDirection(2, 0, 1);
                            sharedDirections[2] = new SharedDirection(2, 2, 1);
                        }
                    }
                    break;
                case 'O':
                    if (direction == 1 || direction == 8)
                    {
                        sharedDirections[0] = new SharedDirection(0, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 0, 1);
                        sharedDirections[2] = new SharedDirection(0, 2, 1);
                        sharedDirections[3] = new SharedDirection(2, 0, 1);
                    }
                    else if (direction == 2 || direction == 3)
                    {
                        sharedDirections[0] = new SharedDirection(2, 0, 1);
                        sharedDirections[1] = new SharedDirection(0, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 0, 1);
                        sharedDirections[3] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        sharedDirections[0] = new SharedDirection(2, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 2, 1);
                        sharedDirections[3] = new SharedDirection(2, 2, 1);
                    }
                    break;
                case 'R':
                    if (direction == 1 || direction == 8)
                    {
                        sharedDirections[0] = new SharedDirection(2, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 2, 1);
                        sharedDirections[3] = new SharedDirection(0, 3, 1);
                        sharedDirections[4] = new SharedDirection(3, 0, 1);
                    }
                    else if (direction == 2 || direction == 3)
                    {
                        sharedDirections[0] = new SharedDirection(2, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 2, 1);
                        sharedDirections[3] = new SharedDirection(3, 0, 1);
                        sharedDirections[4] = new SharedDirection(0, 3, 1);
                    }
                    else if (direction==4 || direction == 7)
                    {
                        if (smaller)
                        {
                            sharedDirections[0] = new SharedDirection(0, 2, 1);
                            sharedDirections[1] = new SharedDirection(0, 2, 1);
                            sharedDirections[2] = new SharedDirection(2, 0, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                            sharedDirections[4] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            sharedDirections[0] = new SharedDirection(2, 0, 1);
                            sharedDirections[1] = new SharedDirection(2, 0, 1);
                            sharedDirections[2] = new SharedDirection(0, 2, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                            sharedDirections[4] = new SharedDirection(2, 2, 1);
                        }
                    }
                    else
                    {
                        if (!smaller)
                        {
                            sharedDirections[0] = new SharedDirection(0, 2, 1);
                            sharedDirections[1] = new SharedDirection(0, 2, 1);
                            sharedDirections[2] = new SharedDirection(2, 0, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                            sharedDirections[4] = new SharedDirection(2, 2, 1);
                        }
                        else
                        {
                            sharedDirections[0] = new SharedDirection(2, 0, 1);
                            sharedDirections[1] = new SharedDirection(2, 0, 1);
                            sharedDirections[2] = new SharedDirection(0, 2, 1);
                            sharedDirections[3] = new SharedDirection(2, 2, 1);
                            sharedDirections[4] = new SharedDirection(2, 2, 1);
                        }
                    }
                    break;
                case 'S':
                    if (direction == 1 || direction == 8)
                    {
                        sharedDirections[0] = new SharedDirection(2, 0, 1);
                        sharedDirections[1] = new SharedDirection(0, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 0, 1);
                        sharedDirections[3] = new SharedDirection(0, 2, 1);
                        sharedDirections[4] = new SharedDirection(2, 0, 1);
                    }
                    else if (direction == 2 || direction == 3)
                    {
                        sharedDirections[0] = new SharedDirection(0, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 0, 1);
                        sharedDirections[2] = new SharedDirection(0, 2, 1);
                        sharedDirections[3] = new SharedDirection(2, 0, 1);
                        sharedDirections[4] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        sharedDirections[0] = new SharedDirection(2, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 2, 1);
                        sharedDirections[3] = new SharedDirection(2, 2, 1);
                        sharedDirections[4] = new SharedDirection(2, 2, 1);
                    }
                    break;
                default:
                    if (direction == 1 || direction == 8)
                    {
                        sharedDirections[0] = new SharedDirection(2, 0, 1);
                        sharedDirections[1] = new SharedDirection(0, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 0, 1);
                    }
                    else if (direction == 2 || direction == 3)
                    {
                        sharedDirections[0] = new SharedDirection(0, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 0, 1);
                        sharedDirections[2] = new SharedDirection(0, 2, 1);
                    }
                    else
                    {
                        sharedDirections[0] = new SharedDirection(2, 2, 1);
                        sharedDirections[1] = new SharedDirection(2, 2, 1);
                        sharedDirections[2] = new SharedDirection(2, 2, 1);
                    }
                    break;

            }
        }
        
    }
}
