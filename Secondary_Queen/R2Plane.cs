using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Pieces;
namespace Secondary_Queen
{
    public class R2Plane : Plane
    {
        private static R2Plane plane = null;

        private R2Plane()
        {
            planeNumber = 1;
            planeDimension = 2;
            planeCentre = new R2Point().Position;
            isR2Plane = false;
            FillDirections();

        }


        public static R2Plane GetR2Plane()
        {


            if (plane == null)
            {
                plane = new R2Plane();
                return plane;
            }
            else
                return plane;
        }

        public override void FillDirections()
        {

            directions.Add(6);
            directions.Add(2);
            directions.Add(4);
            directions.Add(1);
            directions.Add(7);
            directions.Add(3);
            directions.Add(5);
            directions.Add(8);
        }

        // I'm not sure what is better than the other, between returning plane and returning this.
        public override Plane ReflectAboutAxis(int axisIndex)
        {
            return GetR2Plane();
        }

        // I'm not sure what is better than the other, between returning plane and returning this.
        public override Plane RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            return GetR2Plane();
        }

        // I'm not sure what is better than the other, between returning plane and returning this.
        public override Plane ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            return plane;
        }

        // Determines whether or not two directions are the opposite of each other.
        public override bool AreDirectionsOpposite(int direction1, int direction2)
        {
            bool returnValue = false;

            if ((direction1 == 1 && direction2 == 8) || (direction1 == 8 && direction2 == 1))
                returnValue = true;
            else if ((direction1 == 2 && direction2 == 3) || (direction1 == 3 && direction2 == 2))
                returnValue = true;
            else if ((direction1 == 6 && direction2 == 7) || (direction1 == 7 && direction2 == 6))
                returnValue = true;
            else if ((direction1 == 4 && direction2 == 5) || (direction1 == 5 && direction2 == 4))
                returnValue = true;

            return returnValue;
        }

        // The method returns the same passed direction parameter if that direction is invalid.
        public override int GetOppositeDirection(int direction)
        {
            int oppositeDirection;

            switch (direction)
            {
                case 1:
                    oppositeDirection = 8;
                    break;
                case 2:
                    oppositeDirection = 3;
                    break;
                case 3:
                    oppositeDirection = 2;
                    break;
                case 4:
                    oppositeDirection = 5;
                    break;
                case 5:
                    oppositeDirection = 4;
                    break;
                case 6:
                    oppositeDirection = 7;
                    break;
                case 7:
                    oppositeDirection = 6;
                    break;
                case 8:
                    oppositeDirection = 1;
                    break;
                default:
                    oppositeDirection = direction;
                    break;
            }

            return oppositeDirection;
        }
    }
}
