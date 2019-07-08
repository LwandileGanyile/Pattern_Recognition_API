using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using SharedResources;
using NonCircularIteration;
using Game_Defination;

namespace BuildingBlocks
{
    public abstract class NonCircularLetter<T, U> : NonCircular<T, U>, ILetter<T>,IDirectionIterator<U>
    {

        protected NonCircularLetter()
        {

        }

        public NonCircularLetter(Letter<T,U> letter)
        {

        }

        /*protected NonCircularLetter(Point startingPoint, char letter,
        int letterDirection, bool smaller, Dictionary<int, int> duration)
        {

        }*/

        /*protected NonCircularLetter(Point startingPoint, char letter,
        int letterDirection, bool smaller, Dictionary<int, int> duration,
        int numberOfRotations)
        {

        }*/

        protected NonCircularLetter(Point _startingPoint, char letter, Plane onPlane,
        bool smaller, int letterDirection, List<bool> canShootList, Dictionary<int, int> duration,
        int numberOfRotations)
        {

        }

        /*protected NonCircularLetter(Point startingPoint, char letter,
        int letterDirection, bool smaller, Dictionary<int, int> duration,
        int numberOfRotations, SharedDirection shareDirection)
        {

        }*/

        /*protected NonCircularLetter(Point startingPoint, char letter, int letterDirection,
        bool smaller, Dictionary<int, int> duration, SharedDirection shareDirection)
        {

        }*/


        /*protected NonCircularLetter(Point _startingPoint, char letter, Plane onPlane,
        bool smaller, int letterDirection, List<bool> canShootList, Dictionary<int, int> duration,
        int numberOfRotations, SharedDirection shareDirection)
        {

        }*/

        public abstract void DisplayLetterInfo();
        public abstract bool IsC(List<int> directions, List<float> lengths);
        public abstract bool IsI(List<int> directions, List<float> lengths);
        public abstract bool IsL(List<int> directions, List<float> lengths);
        public abstract bool IsM(List<int> directions, List<float> lengths);
        public abstract bool IsN(List<int> directions, List<float> lengths);
        public abstract bool IsO(List<int> directions, List<float> lengths);
        public abstract bool IsR(List<int> directions, List<float> lengths);
        public abstract bool IsS(List<int> directions, List<float> lengths);
        public abstract bool IsW(List<int> directions, List<float> lengths);


        public abstract DirectionIterator<U> RetrieveDirectionIterator();
        public abstract bool IsLetter(List<int> directions, List<float> lengths);
        public abstract T RotateAroundAxis(int indexOfAxis, int numberOfTimes);
        public abstract T ReflectAboutAxis(int axisIndex);
        public abstract T ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes);
        public abstract T Translate(int coordinateSystemDirection, float amaunt);
        public abstract void Display();
        public abstract int CompareTo(T comparableInstance);
        public abstract T RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes);
    }
}
