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
    public class Letter<IPartOf> : Helper<IPartOf>
    {

        private Plane onPlane;
        private bool smaller;
        private char letter;

        private List<List<bool>> pointsCanSwitchList;
        private List<List<float>> pointsSpeedList;

        private List<ISharedDirection> sharedDirections;
        private List<float> componentDirectionLengths;

        public List<ISharedDirection> SharedDirections { get; set; }
        public List<float> ComponentDirectionLengths { get; }
        public List<List<bool>> PointsCanSwitchList { get; }
        public List<List<float>> PointsSpeedList { get; }


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

        public Letter()
        :base()
        {
            smaller = true;
            letter = 'C';
            // Need to be filled.
            pointsCanSwitchList = new List<List<bool>>();
            // Need to be filled.
            pointsSpeedList = new List<List<float>>();
            // Need to be filled.
            sharedDirections = new List<ISharedDirection>();
        }     

        public Letter(Plane onPlane, Point startingPoint, bool smaller,
        char letter, int direction, List<ISharedDirection> sharedDirections,
        List<float> speedList, float speed, List<List<bool>> pointsCanSwitchList,
        List<List<float>> pointsSpeedList)
        : base(startingPoint, direction, speedList, speed)
        {            
            SetSomeLetterAttributes(onPlane, smaller,
            letter, sharedDirections, pointsCanSwitchList, pointsSpeedList);          
        }

        public Letter(Plane onPlane, Point startingPoint,
        List<int> directions, List<ISharedDirection> sharedDirections,
        List<float> speedList, float speed, List<List<bool>> pointsCanSwitchList,
        List<List<float>> pointsSpeedList)
        : base(startingPoint, directions[directions.Count-1], speedList, speed)
        {
            if (!IsLetter(directions, sharedDirections))
                throw new Exception("Either the directions list or the shared directions list is not a letter.");

            if (IsC(directions, sharedDirections))letter = 'C';
            else if (IsI(directions, sharedDirections)) letter = 'I';
            else if (IsL(directions, sharedDirections)) letter = 'L';
            else if (IsM(directions, sharedDirections)) letter = 'M';
            else if (IsN(directions, sharedDirections)) letter = 'N';
            else if (IsO(directions, sharedDirections)) letter = 'O';
            else if (IsR(directions, sharedDirections)) letter = 'R';
            else if (IsS(directions, sharedDirections)) letter = 'S';
            else letter = 'W';

            SetSomeLetterAttributes(onPlane, DetermineSmaller(onPlane, directions),
            letter, sharedDirections, pointsCanSwitchList, pointsSpeedList);
        }

        private bool IsValidCanSwitchList(List<List<bool>> pointsCanSwitchList)
        {
            if (pointsCanSwitchList.Count != sharedDirections.Count)
            {
                Console.WriteLine("The number of direction lengths making up " +
                    "the letter is not equals to the number of lists containing " +
                    "the can switch points");
                return false;
            }

            for (int index = 0; index < pointsCanSwitchList.Count; index++)
                if (pointsCanSwitchList[index].Count != sharedDirections[index].GetNumberOfElements())
                {
                    Console.WriteLine("One of the direction lengths making up " +
                    "the letter has a length not equals to the corresponding number of  " +
                    "can switch points");
                    return false;
                }

            return true ;
        }

        private bool IsValidPointsSpeed(List<List<float>> pointsSpeedList)
        {
            for (int index = 0; index < pointsSpeedList.Count; index++)
                if (pointsCanSwitchList[index].Count != pointsSpeedList[index].Count + 1)
                {
                    Console.WriteLine("Make sure the points can switch list element has a " +
                        "size 1 greater than the corresponding points speed list element " +
                        "for all corresponding pairs.");
                    return false;
                }
            return true;
        }

        private bool DetermineSmaller(Plane onPlane, List<int> directions)
        {
            bool smaller;

            if (IsC(directions) || IsS(directions) || IsM(directions) || IsN(directions))
            {
                smaller = (directions[1] < onPlane.GetOppositeDirection(directions[1])) ? true : false;
            }

            else if (IsI(directions))
            {
                smaller = false;
            }

            else
            {
                smaller = (directions[0] < onPlane.GetOppositeDirection(directions[0])) ? true : false;
            }

            return smaller;
        }

        private void SetSomeLetterAttributes(Plane onPlane, bool smaller,
        char letter, List<ISharedDirection> sharedDirections, 
        List<List<bool>> pointsCanSwitchList, List<List<float>> pointsSpeedList)
        {

            if(!IsLetter(sharedDirections) && AreDivisorsEqual(sharedDirections))
                throw new Exception("Make sure you enter valid letter lengths and all divisors are equal.");
            this.sharedDirections = sharedDirections;

            if (!IsValidCanSwitchList(pointsCanSwitchList))
                throw new Exception("Make sure the can switch list for points is valid.");
            this.pointsCanSwitchList = pointsCanSwitchList;

            if (!IsValidPointsSpeed(pointsSpeedList))
                throw new Exception("Make sure the speed list for points is valid.");
            this.pointsSpeedList = pointsSpeedList;

            if (!(letter == 'C' || letter == 'I' || letter == 'L' || letter == 'M' || letter == 'N' || letter == 'O' ||
            letter == 'R' || letter == 'S' || letter == 'S'))
                throw new Exception("Make sure you enter a valid letter.");
            this.letter = letter;

            this.onPlane = onPlane;
            this.smaller = smaller;

            
        }

        private bool AreDivisorsEqual(List<ISharedDirection> sharedDirections)
        {
            float divisor = sharedDirections[0].Divisor;

            for (int i = 1; i < sharedDirections.Count; i++)
                if (sharedDirections[i].Divisor != divisor)
                    return false;
            return true;
        }

        public void DisplayLetterInfo()
        {
            Console.WriteLine(ToString());
        }


        // Checks whether the combination of directions and shared directions are a letter C.
        public bool IsC(List<int> directions, List<ISharedDirection> lengths)
        {

            return IsC(directions) && IsC(lengths);
        }
        // Checks whether the shared directions are a letter C.
        private bool IsC(List<ISharedDirection> lengths)
        {


            return 

                lengths.Count == 3 &&
                lengths[0].Length.Count > 1 &&
                lengths[0].Length.Count == lengths[1].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[1].GetDirectionLength() &&
                lengths[0].Length.Count == lengths[2].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[2].GetDirectionLength();
        }
        // Checks whether the directions are a letter C.
        private bool IsC(List<int> directions)
        {
            return

                directions.Count == 3 && onPlane.AreDirectionsPerpendicular
                (directions[0], directions[1]) && directions[0] == directions[2];
        }


        // Checks whether the combination of directions and shared directions are a letter I.
        public bool IsI(List<int> directions, List<ISharedDirection> lengths)
        {
            return IsI(directions) && IsI(lengths);
        }
        // Checks whether the shared directions are a letter I.
        private bool IsI(List<ISharedDirection> lengths)
        {
            return lengths.Count == 1 && lengths[0].Length.Count > 1;
        }
        // Checks whether the directions are a letter I.
        private bool IsI(List<int> directions)
        {
            return

                directions.Count == 1 && directions[0] > 0 && directions[0] <= 26;
        }


        // Checks whether the combination of directions and shared directions are a letter S.
        public bool IsL(List<int> directions, List<ISharedDirection> lengths)
        {
            return IsL(directions) && IsL(lengths);
        }
        // Checks whether the shared directions are a letter S.
        private bool IsL(List<ISharedDirection> lengths)
        {
            return (
                    lengths.Count == 2 &&
                    lengths[0].Length.Count > 1 &&
                    lengths[0].Length.Count == lengths[1].Length.Count &&
                    lengths[0].GetDirectionLength() == lengths[1].GetDirectionLength()
                   );
        }
        // Checks whether the directions are a letter S.
        private bool IsL(List<int> directions)
        {
            return directions.Count == 2 && 
            onPlane.AreDirectionsPerpendicular
            (directions[0], directions[1]);
        }


        // Checks whether the combination of directions and shared directions are a letter M.
        public bool IsM(List<int> directions, List<ISharedDirection> lengths)
        {
            return IsM(directions) && IsM(lengths);
        }
        // Checks whether the shared directions are a letter M.
        private bool IsM(List<ISharedDirection> lengths)
        {


            return 
                lengths.Count == 4 &&
                lengths[0].Length.Count > 1 &&
                lengths[0].Length.Count == lengths[3].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[3].GetDirectionLength() &&
                lengths[1].Length.Count > 1 &&
                lengths[1].Length.Count == lengths[2].Length.Count &&
                lengths[1].GetDirectionLength() == lengths[2].GetDirectionLength() &&
                IsNOrMHelper(lengths[0], lengths[1], out int firstPieceNumber) &&
                IsNOrMHelper(lengths[2], lengths[3], out int secondPieceNumber) &&
                firstPieceNumber == secondPieceNumber;
        }
        // Checks whether the directions are a letter M.
        private bool IsM(List<int> directions)
        {
            return directions.Count == 4 &&
                onPlane.AreDirectionsOpposite(directions[0], directions[3]) &&
                onPlane.AreDirectionsPerpendicular(directions[1], directions[2]) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[2], 1) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[1], 3) &&
                onPlane.AreDirectionsNFarApart(directions[1], directions[3], 1);
        }



        private bool IsNOrMHelper(ISharedDirection firstDirection, 
        ISharedDirection secondDirection, out int numberOfEqualDirectionComponents)
        {
            int countEqualDirectionComponent = 0;
            for (int index = 0; index < firstDirection.Length.Count; index++)
                if (firstDirection.Length[index] == secondDirection.Length[index] && firstDirection.Length[index] != 0)
                    countEqualDirectionComponent++;
            numberOfEqualDirectionComponents = countEqualDirectionComponent;
            return countEqualDirectionComponent >0  && countEqualDirectionComponent < firstDirection.Length.Count;

        }

        // Checks whether the combination of directions and shared directions are a letter N.
        public bool IsN(List<int> directions, List<ISharedDirection> lengths)
        {
            return IsN(directions) && IsN(lengths);
        }
        // Checks whether the shared directions are a letter N.
        private bool IsN(List<ISharedDirection> lengths)
        {
            return 
                lengths.Count == 3 &&
                lengths[0].Length.Count > 1 &&
                lengths[0].Length.Count == lengths[2].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[2].GetDirectionLength() &&
                lengths[1].Length.Count > 1 &&
                lengths[1].Length.Count == lengths[0].Length.Count &&
                IsNOrMHelper(lengths[0], lengths[1], out int firstPieceNumber) &&
                IsNOrMHelper(lengths[1], lengths[2], out int secondPieceNumber) &&
                firstPieceNumber == secondPieceNumber;
        }
        // Checks whether the directions are a letter N.
        private bool IsN(List<int> directions)
        {
            return directions.Count == 3 &&
                onPlane.AreDirectionsOpposite(directions[0], directions[2]) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[1], 3) &&
                onPlane.AreDirectionsNFarApart(directions[2], directions[3], 1);
        }


        // Checks whether the combination of directions and shared directions are a letter O.
        public bool IsO(List<int> directions, List<ISharedDirection> lengths)
        {
            return IsO(directions) && IsO(lengths);
        }
        // Checks whether the shared directions are a letter O.
        private bool IsO(List<ISharedDirection> lengths)
        {
            return 
                lengths.Count == 4 &&
                lengths[0].Length.Count > 1 &&
                lengths[0].Length.Count == lengths[1].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[1].GetDirectionLength() &&
                lengths[0].Length.Count == lengths[2].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[2].GetDirectionLength() &&
                lengths[0].Length.Count == lengths[3].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[3].GetDirectionLength();
        }
        // Checks whether the directions are a letter O.
        private bool IsO(List<int> directions)
        {
            return directions.Count == 4 &&
                onPlane.AreDirectionsOpposite(directions[0], directions[2]) &&
                onPlane.AreDirectionsOpposite(directions[1], directions[3]) &&

                onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) &&
                onPlane.AreDirectionsPerpendicular(directions[0], directions[3]) &&

                onPlane.AreDirectionsPerpendicular(directions[1], directions[2]);
        }


        // Checks whether the combination of directions and shared directions are a letter R.
        public bool IsR(List<int> directions, List<ISharedDirection> lengths)
        {
            return IsR(directions) && IsR(lengths);
        }
        // Checks whether the shared directions are a letter R.
        private bool IsR(List<ISharedDirection> lengths)
        {
            return 
                lengths.Count == 5 &&
                lengths[0].Length.Count > 1 &&
                lengths[0].Length.Count == lengths[1].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[1].GetDirectionLength() &&

                lengths[0].Length.Count == lengths[2].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[2].GetDirectionLength() &&
                lengths[3].GetDirectionLength() == lengths[4].GetDirectionLength() &&
                lengths[0].Length.Count == lengths[3].Length.Count &&
                (2 / Math.Sqrt(3)) * lengths[2].GetDirectionLength()
                 == lengths[3].GetDirectionLength();
        }
        // Checks whether the directions are a letter R.
        private bool IsR(List<int> directions)
        {
            return directions.Count == 5 &&
                directions[0] == directions[1] &&
                onPlane.AreDirectionsPerpendicular(directions[1], directions[2]) &&
                onPlane.AreDirectionsNFarApart(directions[1], directions[3], 5) &&
                onPlane.AreDirectionsNFarApart(directions[1], directions[4], 3) &&

                onPlane.AreDirectionsNFarApart(directions[2], directions[3], 3) &&
                onPlane.AreDirectionsNFarApart(directions[2], directions[4], 1) &&

                onPlane.AreDirectionsPerpendicular(directions[3], directions[4]);
        }


        // Checks whether the combination of directions and shared directions are a letter S.
        public bool IsS(List<int> directions, List<ISharedDirection> lengths)
        {
            return IsS(directions) && IsS(lengths);
        }
        // Checks whether the shared directions are a letter S.
        private bool IsS( List<ISharedDirection> lengths)
        {
            return 
                 lengths.Count == 5 &&
                 lengths[0].Length.Count > 1 &&
                 lengths[0].Length.Count == lengths[1].Length.Count &&
                 lengths[0].GetDirectionLength() == lengths[1].GetDirectionLength() &&
                 lengths[0].Length.Count == lengths[2].Length.Count &&
                 lengths[0].GetDirectionLength() == lengths[2].GetDirectionLength() &&
                 lengths[0].Length.Count == lengths[3].Length.Count &&
                 lengths[0].GetDirectionLength() == lengths[3].GetDirectionLength() &&
                 lengths[0].Length.Count == lengths[4].Length.Count &&
                 lengths[0].GetDirectionLength() == lengths[4].GetDirectionLength();
        }
        // Checks whether the directions are a letter S.
        private bool IsS(List<int> directions)
        {
            return directions.Count == 5 &&
                onPlane.AreDirectionsOpposite(directions[0], directions[2]) &&
                directions[0] == directions[4] &&
                onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) &&
                onPlane.AreDirectionsPerpendicular(directions[0], directions[3]) &&


                directions[1] == directions[3] &&
                onPlane.AreDirectionsPerpendicular(directions[1], directions[2]) &&
                onPlane.AreDirectionsPerpendicular(directions[1], directions[4]) &&


                onPlane.AreDirectionsPerpendicular(directions[2], directions[3]) &&
                onPlane.AreDirectionsOpposite(directions[2], directions[4]) &&

                 onPlane.AreDirectionsPerpendicular(directions[3], directions[4]);
        }


        // Checks whether the combination of directions and shared directions are a letter W.
        public bool IsW(List<int> directions, List<ISharedDirection> lengths)
        {
            return IsW(directions) && IsW(lengths);
        }
        // Checks whether the shared directions are a letter W.
        private bool IsW(List<ISharedDirection> lengths)
        {
            return 
                lengths.Count == 4 &&
                lengths[0].Length.Count > 1 &&
                lengths[0].Length.Count == lengths[1].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[1].GetDirectionLength() &&
                lengths[0].Length.Count == lengths[2].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[2].GetDirectionLength() &&
                lengths[0].Length.Count == lengths[3].Length.Count &&
                lengths[0].GetDirectionLength() == lengths[3].GetDirectionLength();
        }
        // Checks whether the directions are a letter W.
        public bool IsW(List<int> directions)
        {
            return directions.Count == 4 &&

                onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) &&
                directions[0] == directions[2] &&
                onPlane.AreDirectionsPerpendicular(directions[0], directions[1]) &&
                onPlane.AreDirectionsNFarApart(directions[0], directions[3], 2) &&

                onPlane.AreDirectionsPerpendicular(directions[1], directions[2]);
        }


        // Checks whether the combination of directions and shared directions is a valid letter.
        public bool IsLetter(List<int> directions, List<ISharedDirection> lengths)
        {
            return IsLetter(directions) && IsLetter(lengths);
        }
        // Checks whether the directions are a valid letter.
        public bool IsLetter(List<int> directions)
        {
            return IsC(directions) || IsI(directions) || IsL(directions)
            || IsM(directions) || IsN(directions)
            || IsO(directions) || IsR(directions) || IsS(directions)
            || IsW(directions);
        }
        // Checks whether the shared directions are a valid letter.
        private bool IsLetter(List<ISharedDirection> lengths)
        {
            return IsC(lengths) || IsI(lengths) || IsL(lengths)
            || IsM(lengths) || IsN(lengths)
            || IsO(lengths) || IsR(lengths) || IsS(lengths)
            || IsW(lengths);
        }


        //protected abstract void FillSharedDirections();

        // Set the can shoot property for a specific point.
        public void SetPointsCanSwitchList(int indexOfList, int indexOfCanSwitch, bool canSwitch)
        {
            pointsCanSwitchList[indexOfList][indexOfCanSwitch] = canSwitch;
        }

        // Set the can shoot list property for a specific direction.
        public void SetPointsCanSwitchList(int indexOfList, List<bool> canSwitchList)
        {
            if (pointsCanSwitchList[indexOfList].Count == canSwitchList.Count)
                for (int index = 0; index < canSwitchList.Count; index++)
                    pointsCanSwitchList[indexOfList][index] = canSwitchList[index];
            else
                throw new ArgumentException("Make sure the passed list has the same number of element as the list to be modified.");
        }

        // Get the can shoot property for a specific point.
        public bool GetPointsCanSwitch(int indexOfList, int indexOfCanSwitch)
        {
            return pointsCanSwitchList[indexOfList][indexOfCanSwitch];
        }

        // Get the can shoot list property for a specific direction.
        public List<bool> GetPointsCanSwitchList(int indexOfList)
        {
            return pointsCanSwitchList[indexOfList];
        }

        // Set the speed property for a specific point.
        public void SetPointsSpeedList(int indexOfList, int indexOfSpeed, float speed)
        {
            pointsSpeedList[indexOfList][indexOfSpeed] = speed;
        }

        // Set the speed list property for a specific direction.
        public void SetPointsSpeedList(int indexOfList, List<float> speedList)
        {
            if (pointsSpeedList[indexOfList].Count == speedList.Count)
                for (int index = 0; index < speedList.Count; index++)
                    pointsSpeedList[indexOfList][index] = speedList[index];
            else
                throw new ArgumentException("Make sure the passed list has the same number of element as the list to be modified.");
        }

        // Get the speed property for a specific point.
        public float GetPointsSpeed(int indexOfList, int indexOfSpeed)
        {
            return pointsSpeedList[indexOfList][indexOfSpeed];
        }

        // Get the speed list property for a specific direction.
        public List<float> GetPointsSpeedList(int indexOfList)
        {
            return pointsSpeedList[indexOfList];
        }

    }
}
