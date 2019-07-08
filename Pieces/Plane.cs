using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;

namespace Pieces
{
    public abstract class Plane : IReflect<Plane>, IRotate<Plane>, IReflectable<Plane>, IFillPlane
    {
        protected int planeDimension;
        protected int planeNumber;
        protected Point planeCentre;
        protected static List<int> directions;

        protected bool isR2Plane;

        protected Plane()
        {

            directions = new List<int>();
        }

        protected Plane(Point planeCentre, int planeDimension, int planeNumber)
        {
            this.planeCentre = planeCentre;
            this.planeDimension = planeDimension;
            this.planeNumber = planeNumber;
            directions = new List<int>();
            FillDirections();
        }

        public Point PlaneCentre
        {
            get
            {
                return planeCentre;
            }

            set
            {
                if (!isR2Plane)
                {

                }
            }
        }


        public int PlaneNumber
        {
            get
            {
                return planeNumber;
            }

            set
            {
                if (!isR2Plane)
                {

                }
            }
        }

        public int PlaneDimension { get; }

        public List<int> PlaneDirections { get; }

        public bool AreDirectionsOnPlane(List<int> directions)
        {

            for (int i = 0; i < directions.Count; i++)
                if (!Plane.directions.Contains(directions[i]))
                    return false;
            return true;

        }

        public bool AreDirectionsNFarApart(int direction1, int direction2, int howFar)
        {
            int indexOfDirection1 = -1;
            int indexOfDirection2 = -1;

            if (direction1 > 0 && direction1 < 9 && direction2 > 0 && direction2 < 9)
            {
                for (int i = 0; i < directions.Count; i++)
                {
                    if (direction1 == directions[i])
                        indexOfDirection1 = i;

                    if (direction2 == directions[i])
                        indexOfDirection2 = i;
                }

                return Math.Abs((indexOfDirection2 - indexOfDirection1)) == howFar;
            }

            return false;
        }

        public int[] RetrieveNeighborDirections(int direction)
        {
            int[] neighbors = new int[2];


            int indexOfDirection = -1;

            for (int i = 0; i < directions.Count; i++)
            {
                if (direction == directions[i])
                    indexOfDirection = i;
            }

            if (indexOfDirection == 0)
            {
                neighbors[0] = (directions[directions.Count - 1]);
                neighbors[1] = (directions[1]);
            }

            else if (indexOfDirection == directions.Count - 1)
            {
                neighbors[0] = (directions[directions.Count - 2]);
                neighbors[1] = (directions[0]);
            }

            else if (indexOfDirection < (directions.Count - 1) && indexOfDirection > 0)
            {
                neighbors[0] = (directions[indexOfDirection - 1]);
                neighbors[1] = (directions[indexOfDirection + 1]);
            }



            return neighbors;
        }

        public int[] RetrievePerpendicularDirections(int direction)
        {
            int[] perpendicularDirections = new int[2];


            int indexOfDirection = -1;

            for (int i = 0; i < directions.Count; i++)
            {
                if (direction == directions[i])
                    indexOfDirection = i;
            }

            if (indexOfDirection == 0)
            {
                perpendicularDirections[0] = (directions[directions.Count - 2]);
                perpendicularDirections[1] = (directions[2]);
            }

            else if (indexOfDirection == directions.Count - 1)
            {
                perpendicularDirections[0] = (directions[directions.Count - 3]);
                perpendicularDirections[1] = (directions[1]);
            }

            else if (indexOfDirection < (directions.Count - 2) && indexOfDirection > 1)
            {
                perpendicularDirections[0] = (directions[indexOfDirection - 2]);
                perpendicularDirections[1] = (directions[indexOfDirection + 2]);
            }



            return perpendicularDirections;
        }

        public bool AreDirectionsNeighbors(int direction1, int direction2)
        {
            return AreDirectionsNFarApart(direction1, direction2, 1);
        }

        public bool AreDirectionsPerpendicular(int direction1, int direction2)
        {
            return AreDirectionsNFarApart(direction1, direction2, 2);
        }

        public void RetrieveDistancedDirections(int direction, int howFar, int[] distancedDirections)
        {
            if (howFar == 0)
            {

            }

            else if (howFar == 1)
            {

            }

            else if (howFar == 2)
            {

            }

            else if (howFar == 3)
            {

            }

            else if (howFar == 4)
            {

            }


        }

        public abstract void FillDirections();

        public abstract Plane ReflectAboutAxis(int axisIndex);

        public abstract bool AreDirectionsOpposite(int direction1, int direction2);
        public abstract int GetOppositeDirection(int direction);


        public abstract Plane RotateAroundAxis(int indexOfAxis, int numberOfTimes);
        public abstract Plane ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes);
    }
}
