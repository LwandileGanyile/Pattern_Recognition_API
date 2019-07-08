using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using SharedResources;
using Pieces;

namespace SharedResources
{
    public abstract class Letter<T, Direction> : Helper<T, Direction>, ILetter<T>, IFill
    {

        protected Plane onPlane;
        protected bool smaller;
        protected char letter;

        protected List<SharedDirection> sharedDirections = new List<SharedDirection>();

        protected List<SharedDirection> SharedDirections { get; }

        public Plane OnPlane
        {
            get { return onPlane; }
            set { if (value != null) { onPlane = value; /*Fill()*/; } }
        }

        public bool Smaller
        {
            get { return smaller; }
            set { if (value != smaller) { smaller = value; /*Fill()*/; } }
        }

        public char MyLetter
        {
            get
            {
                return letter;
            }

            set
            {
                if (value == 'C' || value == 'I' || value == 'L' || value == 'N' ||
                value == 'M' || value == 'O' || value == 'R' || value == 'S' ||
                value == 'W')
                {
                    letter = value;
                    //Fill();
                }
            }
        }

        protected internal Letter()
        :base()
        {
            smaller = true;
            letter = 'C';
            sharedDirections = new List<SharedDirection>();
            sharedDirections[0] = new SharedDirection(12, 1);
            sharedDirections[1] = new SharedDirection(12, 1);
            sharedDirections[2] = new SharedDirection(12, 1);
        }

        private Letter(Plane onPlane, Point startingPoint, bool smaller,
        char letter, int direction,Dictionary<int, int> duration, int numberOfTimes, 
        bool circular)
        {

            SetSomeLetterAttributes(onPlane, startingPoint, smaller,
            letter, direction, duration, new List<bool>(),
            numberOfTimes, circular);
        }

        protected internal Letter(Plane onPlane, Point startingPoint, bool smaller,
        char letter, int direction, Dictionary<int, int> duration, List<bool> canShootList, 
        int numberOfTimes, bool circular)
        {
            
            SetSomeLetterAttributes(onPlane, startingPoint, smaller,
            letter, direction, duration, canShootList,
            numberOfTimes, circular);

            FillSharedDirections();
            FillCanShoot();

        }

        protected internal Letter(Plane onPlane, Point startingPoint, 
        bool smaller, char letter, int direction,List<SharedDirection> sharedDirections,
         Dictionary<int, int> duration,int numberOfTimes, bool circular)
        : this(onPlane, startingPoint, smaller,letter, direction, duration, 
        numberOfTimes,circular)
        {
            this.sharedDirections = sharedDirections;
        }

        protected internal Letter(Plane onPlane, Point startingPoint,
        bool smaller, char letter, int direction,List<SharedDirection> sharedDirections,
        Dictionary<int, int> duration,List<bool> canShootList,
        int numberOfTimes, bool circular)
       
        {
            SetSomeLetterAttributes(onPlane, startingPoint, smaller,
            letter, direction, duration, canShootList,
            numberOfTimes, circular);
            this.sharedDirections = sharedDirections;
        }

        public void SetSomeLetterAttributes(Plane onPlane, Point startingPoint, bool smaller,
        char letter, int direction, Dictionary<int, int> duration, List<bool> canShootList,
        int numberOfTimes, bool circular)
        {
            
            if (!(letter == 'C' || letter == 'I' || letter == 'L' || letter == 'M' || letter == 'N' || letter == 'O' ||
            letter == 'R' || letter == 'S' || letter == 'S'))
                throw new Exception("Make sure you enter a valid letter.");
            this.letter = letter;

            if (!IsDirectionValid(direction))
                throw new Exception("Make sure you enter a valid direction.");
            this.direction = direction;

            _startingPoint = startingPoint;
            this.duration = duration;
            this.canShootList = canShootList;
            this.circular = circular;
            this.onPlane = onPlane;
            this.smaller = smaller;
        }

        protected override int GetDefaultSize() { return 4; }

        public void DisplayLetterInfo()
        {
            Console.WriteLine(ToString());
        }

        public bool IsC(List<int> directions, List<float> lengths)
        {


            return (
                
                directions.Count == 3 && onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) && 
                directions[0] == directions[2] &&

                lengths.Count == 3 && lengths[0] == lengths[1] && lengths[0] == lengths[2]
                );
        }

        public bool IsI(List<int> directions, List<float> lengths)
        {
            return directions.Count == 1 && directions[0] > 0 && directions[0] <= 26
                   &&
                   lengths.Count == 1;
        }

        public bool IsL(List<int> directions, List<float> lengths)
        {
            return (directions.Count == 2 && onPlane.AreDirectionsPerpendicular(directions[0], directions[1])
                
                    &&

                    lengths.Count == 2 &&
                    lengths[0] == lengths[1] 
                );
        }

        public bool IsM(List<int> directions, List<float> lengths)
        {
            return (directions.Count == 4 &&
                onPlane.AreDirectionsOpposite(directions[0], directions[3]) &&
                onPlane.AreDirectionsPerpendicular(directions[1], directions[2]) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[2], 1) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[1], 3) &&
                onPlane.AreDirectionsNFarApart(directions[1], directions[3], 1)
                
                &&

                lengths.Count == 4 &&
                lengths[1] == lengths[2] && (lengths[1] == (Math.Pow(lengths[0], 2) +(Math.Pow((lengths[0] / 2), 2)))) 
                && lengths[0]  == lengths[3]

                );
        }

        public bool IsN(List<int> directions, List<float> lengths)
        {
            return (directions.Count == 3 &&
                onPlane.AreDirectionsOpposite(directions[0], directions[2]) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[1], 3) &&
                onPlane.AreDirectionsNFarApart(directions[2], directions[3], 1)

                &&

                lengths.Count == 3 &&
                lengths[0] == lengths[2] &&
                lengths[1] == Math.Pow(lengths[0], 2) + Math.Pow(lengths[0] / 2, 2)

                );
        }

        public bool IsO(List<int> directions, List<float> lengths)
        {
            return (directions.Count == 4 &&
                onPlane.AreDirectionsOpposite(directions[0], directions[2]) &&
                onPlane.AreDirectionsOpposite(directions[1], directions[3]) &&

                onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) &&
                onPlane.AreDirectionsPerpendicular(directions[0], directions[3]) &&

                onPlane.AreDirectionsPerpendicular(directions[1], directions[2])

                &&

                lengths.Count == 4 &&
                lengths[0] == lengths[1] && lengths[0] == lengths[2] && lengths[0] == lengths[3]

                );
        }

        public bool IsR(List<int> directions, List<float> lengths)
        {
            return (directions.Count == 4 &&
                onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[2], 5) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[3], 3) &&

                onPlane.AreDirectionsNFarApart(directions[1], directions[2], 3) &&
                onPlane.AreDirectionsNFarApart(directions[1], directions[3], 1) &&

                onPlane.AreDirectionsPerpendicular(directions[2], directions[3])

                &&

                lengths.Count == 4 &&
                lengths[0] == lengths[1] &&
                lengths[2] == Math.Pow(lengths[0], 2) + Math.Pow((lengths[0] / 2), 2) && 
                lengths[2] == lengths[3]

                );
        }

        public bool IsS(List<int> directions, List<float> lengths)
        {
            return (directions.Count == 5 &&
                onPlane.AreDirectionsOpposite(directions[0], directions[2]) &&
                directions[0] == directions[4] &&
                onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) &&
                onPlane.AreDirectionsPerpendicular(directions[0], directions[3]) &&


                directions[1] == directions[3] &&
                onPlane.AreDirectionsPerpendicular(directions[1], directions[2]) &&
                onPlane.AreDirectionsPerpendicular(directions[1], directions[4]) &&


                onPlane.AreDirectionsPerpendicular(directions[2], directions[3]) &&
                onPlane.AreDirectionsOpposite(directions[2], directions[4]) &&

                 onPlane.AreDirectionsPerpendicular(directions[3], directions[4]) &&

                 lengths.Count == 5 &&
                 lengths[0] == lengths[1] && lengths[0] == lengths[2] && lengths[0] == lengths[3] && lengths[0] == lengths[4]

                );
        }

        public bool IsW(List<int> directions, List<float> lengths)
        {
            return (directions.Count == 4 &&

                onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) &&
                directions[0] == directions[2] &&
                onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[3], 2) &&

                onPlane.AreDirectionsPerpendicular(directions[1], directions[2]) &&
                directions[1] == directions[3]

                &&

                lengths.Count == 4 &&
                lengths[0] == lengths[1] && lengths[0] == lengths[2] && lengths[0] == lengths[3]

                );
        }

        public bool IsLetter(List<int> directions, List<float> lengths)
        {
            return IsC(directions, lengths) || IsI(directions, lengths) || IsL(directions,lengths)
            || IsM(directions, lengths) || IsN(directions, lengths)
            || IsO(directions, lengths) || IsR(directions, lengths) || IsS(directions, lengths)
            || IsW(directions, lengths);
        }


        protected abstract void FillSharedDirections();

        // Print this letter.      
        public abstract void Display();
        
        // Populate this letter with points.
        public abstract void Fill();
        
        // Move this letter  from one point to another.
        public abstract T Translate(int coordinateSystemDirection, float amaunt);
        
        // Reflect this letter about any valid axis.
        public abstract T ReflectAboutAxis(int axisIndex);
        
        // Reflect this letter about any valid equals axiss, e.g y=z, z = -x etc.
        public abstract T ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes);
        
        // Compare two letters.
        public abstract int CompareTo(T other);
        
        // Make a copy of this letter.
        public abstract object Clone();
        
        // Rotate this letter about the given axis.
        public abstract T RotateAroundAxis(int indexOfAxis, int numberOfTimes);

        // Reflect a letter about a direction that has both axis coordinate changing.
        public T ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return ReflectAboutEqualAxis(new List<int>(axisIndeces), numberOfTimes);
        }

        public abstract T RotateAroundEqualAxis(int[] axisIndeces, int numberOfTimes);
    }
}
