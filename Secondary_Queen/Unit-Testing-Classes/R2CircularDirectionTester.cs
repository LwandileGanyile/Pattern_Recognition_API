using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secondary_Queen.Unit_Testing_Classes
{
    public class R2CircularDirectionTester
    {
        protected internal R2CDirection r1Direction;
        protected internal R2CDirection r2Direction;
        protected internal R2CDirection r3Direction;
        protected internal R2CDirection r4Direction;

        public R2CircularDirectionTester()
        {
            r1Direction = new R2CDirection();
            List<bool> canShoot = new List<bool>();



            float directionLength = 5;
            float directionDivisor = 0.5f;
            int direction = 1;

            int numberOfElements = (int)(directionLength / directionDivisor);



            for (int i = 0; i < numberOfElements; i++)
                if (i % 2 == 0)
                    canShoot.Add(true);
                else
                    canShoot.Add(false);



            Dictionary<int, int> duration = new Dictionary<int, int>();


            for (int i = 0; i < numberOfElements; i++)
            {
                duration.Add(i, 1000 / numberOfElements);
            }

            r2Direction = new R2CDirection(new R2Point(0, 5), direction, directionLength, directionDivisor, duration);


            r3Direction = new R2CDirection(new R2Point(-1, 2), direction, directionLength, directionDivisor, duration);

            r4Direction = new R2CDirection(new R2Point(-1, 10), direction, directionLength, directionDivisor, duration, 3);

            /*CheckIsDirectionValid(-1);
            CheckIsDirectionValid(0);
            CheckIsDirectionValid(1);
            CheckIsDirectionValid(2);
            CheckIsDirectionValid(3);

            CheckIsDimensionCorrect();
            CheckIsPointCorrect();
            CheckReflectAboutX();
            CheckRotateAroundX();
            CheckReflectEqualX();
            CheckRotateAroundEqualX();
            CheckTranslate();*/
            CheckCompareTo();
        }

        public R2CircularDirectionTester(R2CDirection r1Direction, R2CDirection r2Direction, R2CDirection r3Direction, R2CDirection r4Direction)
        {
            this.r1Direction = r1Direction;
            this.r2Direction = r2Direction;
            this.r3Direction = r3Direction;
            this.r4Direction = r4Direction;
        }

        // Checks whether or not the direction is valid.
        public void CheckIsDirectionValid(int direction)
        {
            Console.WriteLine("\n*********************Checking direction " + direction + " *******************************");
            Console.WriteLine("Is the direction of list1 valid? : " + r1Direction.IsDirectionValid(direction));
            Console.WriteLine("Is the direction of list2 valid? : " + r2Direction.IsDirectionValid(direction));
            Console.WriteLine("Is the direction of list3 valid? : " + r3Direction.IsDirectionValid(direction));
            Console.WriteLine("Is the direction of list4 valid? : " + r4Direction.IsDirectionValid(direction));
            Console.WriteLine();
        }


        // Checks whether or not the one can reflect about axis.
        public void CheckReflectAboutX()
        {

            Console.WriteLine("\n***************Checking the ReflectAboutAxis(-1) method *****************");

            Console.WriteLine("\nBefore calling ReflectAboutAxis(-1) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(-1) on : \n" +
            r1Direction.ReflectAboutAxis(-1).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(-1) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(-1) on : \n" +
            r2Direction.ReflectAboutAxis(-1).ToString());

            Console.WriteLine("\nBefore calling ReflectAboutAxis(-1) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(-1) on : \n" +
            r3Direction.ReflectAboutAxis(-1).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(-1) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(-1) on : \n" +
            r4Direction.ReflectAboutAxis(-1).ToString());

            Console.WriteLine("\n***************Checking the ReflectAboutAxis(0) method *****************");

            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("After calling ReflectAboutAxis(0) on : \n" +
            r1Direction.ReflectAboutAxis(0).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(0) on : \n" +
            r2Direction.ReflectAboutAxis(0).ToString());

            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(0) on : \n" +
            r3Direction.ReflectAboutAxis(0).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(0) on : \n" +
            r4Direction.ReflectAboutAxis(0).ToString());

            Console.WriteLine();

            Console.WriteLine("\n***************Checking the ReflectAboutAxis(1) method *****************");

            Console.WriteLine("\nBefore calling ReflectAboutAxis(1) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(1) on : \n" +
            r1Direction.ReflectAboutAxis(1).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(1) on : \n" +
            r2Direction.ToString());
            Console.WriteLine("\nAfter calling ReflectAboutAxis(1) on : \n" +
            r2Direction.ReflectAboutAxis(1).ToString());

            Console.WriteLine("\nBefore calling ReflectAboutAxis(1) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(1) on : \n" +
            r3Direction.ReflectAboutAxis(1).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(1) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(1) on : \n" +
            r4Direction.ReflectAboutAxis(1).ToString());


            Console.WriteLine();
        }

        // Checks whether or not the one can rotate about axis.
        public void CheckRotateAroundEqualX()
        {

            Console.WriteLine("\n***************Checking the RotateAboutAxis((new List<int> { +-1,+-2}, index) method *****************");

            Console.WriteLine("\nBefore calling RotateAboutAxis((new List<int> { 1,2}, 2) on: \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling RotateAboutAxis((new List<int> { 1,2}, 2) on : \n" +
            r1Direction.RotateAroundEqualAxis(new List<int> { 1, 2 }, 2).ToString());


            Console.WriteLine("\nBefore calling RotateAboutAxis((new List<int> { 1,2}, 3) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling RotateAboutAxis((new List<int> { -1,2}, 3) on : \n" +
            r2Direction.RotateAroundEqualAxis(new List<int> { -1, 2 }, 3).ToString());

            Console.WriteLine("\nBefore calling RotateAboutAxis((new List<int> { 1,2}, 4) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling RotateAboutAxis((new List<int> { 1,-2}, 4) on : \n" +
            r3Direction.RotateAroundEqualAxis(new List<int> { 1, -2 }, 4).ToString());


            Console.WriteLine("\nBefore calling RotateAboutAxis((new List<int> { 1,2}, 5) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling RotateAboutAxis((new List<int> { -1,-2}, 5) on : \n" +
            r4Direction.RotateAroundEqualAxis(new List<int> { -1, -2 }, 5).ToString());


        }


        // Checks whether or not the one can reflect about axis.
        public void CheckReflectEqualX()
        {

            Console.WriteLine("\n***************Checking the ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes) method *****************");

            Console.WriteLine("\nBefore calling ReflectAboutAxis(new List<int> { 1,-2}, 2) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(new List<int> { 1,-2}, 2) on : \n" +
            r1Direction.ReflectAboutEqualAxis(new List<int> { 1, -2 }, 2).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(new List<int> { 1, 2 }, 2) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(new List<int> { 1, 2 }, 2) on : \n" +
            r2Direction.ReflectAboutEqualAxis(new List<int> { 1, 2 }, 2).ToString());

            Console.WriteLine("\nBefore calling ReflectAboutAxis(new List<int> { -1, -2 }, 3) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(new List<int> { -1, -2 }, 3) on : \n" +
            r3Direction.ReflectAboutEqualAxis(new List<int> { -1, -2 }, 3).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(new List<int> { -1, 2 }, 3) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(new List<int> { -1, 2 }, 3) on : \n" +
            r4Direction.ReflectAboutEqualAxis(new List<int> { -1, 2 }, 2).ToString());

            Console.WriteLine();
            Console.WriteLine("\n***************Checking the ReflectAboutAxis(0) method *****************");

            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("After calling ReflectAboutAxis(0) on : \n" +
            r1Direction.ReflectAboutAxis(0).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(0) on : \n" +
            r2Direction.ReflectAboutAxis(0).ToString());

            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(0) on : \n" +
            r3Direction.ReflectAboutAxis(0).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(0) on : \n" +
            r4Direction.ReflectAboutAxis(0).ToString());

            Console.WriteLine();

            Console.WriteLine("\n***************Checking the ReflectAboutAxis(-1) method *****************");

            Console.WriteLine("\nBefore calling ReflectAboutAxis(-1) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(-1) on : \n" +
            r1Direction.ReflectAboutAxis(-1).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(-1) on : \n" +
            r2Direction.ToString());
            Console.WriteLine("\nAfter calling ReflectAboutAxis(-1) on : \n" +
            r2Direction.ReflectAboutAxis(-1).ToString());

            Console.WriteLine("\nBefore calling ReflectAboutAxis(-1) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(-1) on : \n" +
            r3Direction.ReflectAboutAxis(-1).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(-1) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(-1) on : \n" +
            r4Direction.ReflectAboutAxis(-1).ToString());


            Console.WriteLine();

            Console.WriteLine("\n***************Checking the ReflectAboutAxis(0) method *****************");

            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("After calling ReflectAboutAxis(0) on : \n" +
            r1Direction.ReflectAboutAxis(0).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(0) on : \n" +
            r2Direction.ReflectAboutAxis(0).ToString());

            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(0) on : \n" +
            r3Direction.ReflectAboutAxis(0).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(0) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(0) on : \n" +
            r4Direction.ReflectAboutAxis(0).ToString());

            Console.WriteLine();

            Console.WriteLine("\n***************Checking the ReflectAboutAxis(1) method *****************");

            Console.WriteLine("\nBefore calling ReflectAboutAxis(1) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(1) on : \n" +
            r1Direction.ReflectAboutAxis(1).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(1) on : \n" +
            r2Direction.ToString());
            Console.WriteLine("\nAfter calling ReflectAboutAxis(1) on : \n" +
            r2Direction.ReflectAboutAxis(1).ToString());

            Console.WriteLine("\nBefore calling ReflectAboutAxis(1) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(1) on : \n" +
            r3Direction.ReflectAboutAxis(1).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(1) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(1) on : \n" +
            r4Direction.ReflectAboutAxis(1).ToString());


            Console.WriteLine();
        }

        // Checks whether or not the one can rotate about axis.
        public void CheckRotateAroundX()
        {

            Console.WriteLine("\nBefore calling ReflectAboutAxis(-1) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(-1) on : \n" +
            r3Direction.RotateAroundAxis(-1, 4).ToString());


            Console.WriteLine("\nBefore calling ReflectAboutAxis(2) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling ReflectAboutAxis(2) on : \n" +
            r4Direction.RotateAroundAxis(2, 3).ToString());


            Console.WriteLine();

            Console.WriteLine("\n***************Checking the RotateAroundAxis(axis,times) method *****************");

            Console.WriteLine("\nBefore calling RotateAroundAxis(1,1) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("After calling ReflectAboutAxis(1,1) on : \n" +
            r1Direction.RotateAroundAxis(1, 1).ToString());


            Console.WriteLine("\nBefore calling RotateAroundAxis(1,2) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling RotateAroundAxis(1,2) on : \n" +
            r2Direction.RotateAroundAxis(1, 2).ToString());

            Console.WriteLine("\nBefore calling RotateAroundAxis(2,1) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling RotateAroundAxis(2,1) on : \n" +
            r3Direction.RotateAroundAxis(2, 1).ToString());


            Console.WriteLine("\nBefore calling RotateAroundAxis(2,2) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling RotateAroundAxis(2,2) on : \n" +
            r4Direction.RotateAroundAxis(2, 2).ToString());

            Console.WriteLine();

        }

        // Checks the Translate method.
        public void CheckTranslate()
        {


            Console.WriteLine("\n***************Checking the Translate(direction,10) method *****************");

            //////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nBefore calling Translate(-1,10) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(-1,10) on : \n" +
            r1Direction.Translate(-1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(0,10) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(0,10) on : \n" +
            r1Direction.Translate(0, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(1,10) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(1,10) on : \n" +
            r1Direction.Translate(1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(2,10) on : \n" +
             r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(2,10) on : \n" +
            r1Direction.Translate(2, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(3,10) on : \n" +
             r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(3,10) on : \n" +
            r1Direction.Translate(3, 10).ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nBefore calling Translate(-1,10) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(-1,10) on : \n" +
            r2Direction.Translate(-1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(0,10) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(0,10) on : \n" +
            r2Direction.Translate(0, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(1,10) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(1,10) on : \n" +
            r2Direction.Translate(1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(2,10) on : \n" +
             r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(2,10) on : \n" +
            r1Direction.Translate(2, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(3,10) on : \n" +
             r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(3,10) on : \n" +
            r2Direction.Translate(3, 10).ToString());

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nBefore calling Translate(-1,10) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(-1,10) on : \n" +
            r3Direction.Translate(-1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(0,10) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(0,10) on : \n" +
            r3Direction.Translate(0, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(1,10) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(1,10) on : \n" +
            r3Direction.Translate(1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(2,10) on : \n" +
             r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(2,10) on : \n" +
            r3Direction.Translate(2, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(3,10) on : \n" +
             r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(3,10) on : \n" +
            r3Direction.Translate(3, 10).ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nBefore calling Translate(-1,10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(-1,10) on : \n" +
            r4Direction.Translate(-1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(0,10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(0,10) on : \n" +
            r4Direction.Translate(0, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(1,10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(1,10) on : \n" +
            r4Direction.Translate(1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(2,10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(2,10) on : \n" +
            r4Direction.Translate(2, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(3,10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(3,10) on : \n" +
            r4Direction.Translate(3, 10).ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////



            Console.WriteLine("\n***************Checking the Translate(direction,-10) method *****************");

            //////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\nBefore calling Translate(-1,-10) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(-1,-10) on : \n" +
            r1Direction.Translate(-1, -10).ToString());


            Console.WriteLine("\nBefore calling Translate(0,-10) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(0,-10) on : \n" +
            r1Direction.Translate(0, -10).ToString());

            Console.WriteLine("\nBefore calling Translate(1,-10) on : \n" +
            r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(1,-10) on : \n" +
            r1Direction.Translate(1, -10).ToString());


            Console.WriteLine("\nBefore calling Translate(2,-10) on : \n" +
             r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(2,-10) on : \n" +
            r1Direction.Translate(2, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(3,-10) on : \n" +
             r1Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(3,-10) on : \n" +
            r1Direction.Translate(3, -10).ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nBefore calling Translate(-1,-10) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(-1,-10) on : \n" +
            r2Direction.Translate(-1, -10).ToString());


            Console.WriteLine("\nBefore calling Translate(0,-10) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(0,-10) on : \n" +
            r2Direction.Translate(0, -10).ToString());

            Console.WriteLine("\nBefore calling Translate(1,-10) on : \n" +
            r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(1,-10) on : \n" +
            r2Direction.Translate(1, -10).ToString());


            Console.WriteLine("\nBefore calling Translate(2,-10) on : \n" +
             r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(2,-10) on : \n" +
            r1Direction.Translate(2, -10).ToString());

            Console.WriteLine("\nBefore calling Translate(3,-10) on : \n" +
             r2Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(3,-10) on : \n" +
            r2Direction.Translate(3, -10).ToString());

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nBefore calling Translate(-1,-10) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(-1,-10) on : \n" +
            r3Direction.Translate(-1, -10).ToString());


            Console.WriteLine("\nBefore calling Translate(0,-10) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(0,-10) on : \n" +
            r3Direction.Translate(0, -10).ToString());

            Console.WriteLine("\nBefore calling Translate(1,-10) on : \n" +
            r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(1,-10) on : \n" +
            r3Direction.Translate(1, -10).ToString());


            Console.WriteLine("\nBefore calling Translate(2,-10) on : \n" +
             r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(2,-10) on : \n" +
            r3Direction.Translate(2, -10).ToString());

            Console.WriteLine("\nBefore calling Translate(3,-10) on : \n" +
             r3Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(3,-10) on : \n" +
            r3Direction.Translate(3, -10).ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nBefore calling Translate(-1,-10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(-1,-10) on : \n" +
            r4Direction.Translate(-1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(0,-10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(0,-10) on : \n" +
            r4Direction.Translate(0, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(1,-10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(1,-10) on : \n" +
            r4Direction.Translate(1, 10).ToString());


            Console.WriteLine("\nBefore calling Translate(2,-10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(2,-10) on : \n" +
            r4Direction.Translate(2, 10).ToString());

            Console.WriteLine("\nBefore calling Translate(3,-10) on : \n" +
            r4Direction.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAfter calling Translate(3,-10) on : \n" +
            r4Direction.Translate(3, -10).ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////


            Console.WriteLine();
        }

        public void CheckCompareTo()
        {
            Dictionary<int, int> duration = new Dictionary<int, int>();

            duration.Add(0, 1500);
            duration.Add(1, 3000);
            duration.Add(2, 4500);
            duration.Add(3, 6000);
            duration.Add(4, 1500);
            duration.Add(5, 3000);
            duration.Add(6, 4500);
            duration.Add(7, 6000);
            duration.Add(8, 1500);
            duration.Add(9, 3000);
            duration.Add(10, 4500);
            duration.Add(11, 6000);

            R2CDirection direction1 = new R2CDirection(new R2Point(10, 10), 1, 25, 5, duration);
            R2CDirection direction2 = new R2CDirection(new R2Point(-50, 50), 2, 45, 5, duration);
            R2CDirection direction3 = new R2CDirection(new R2Point(10, 20), 3, 10, 2.5f, duration);
            R2CDirection direction4 = new R2CDirection(new R2Point(-10, -10), 4, 30, 3, duration);

            R2CDirection direction5 = new R2CDirection(new R2Point(5, 15), 5, 100, 20, duration, 1);
            R2CDirection direction6 = new R2CDirection(new R2Point(-5, 15), 6, 200, 20, duration, 2);
            R2CDirection direction7 = new R2CDirection(new R2Point(25, 10), 7, 300, 15, duration, 1);
            R2CDirection direction8 = new R2CDirection(new R2Point(-10, 40), 8, 500, 15, duration, 2);

            R2CDirection direction11 = new R2CDirection(new R2Point(15, 10), 1, 10, 2, new List<bool> { true, false, true, false, true }, duration);
            R2CDirection direction22 = new R2CDirection(new R2Point(-15, 50), 2, 100, 20, new List<bool> { false, false, false, false, true }, duration);
            R2CDirection direction33 = new R2CDirection(new R2Point(100, 30), 3, 15, 2.5f, new List<bool> { false, false, false, false, true }, duration);
            R2CDirection direction44 = new R2CDirection(new R2Point(-10, 50), 4, 28, 3.5f, new List<bool> { true, true, true, false, true }, duration);

            R2CDirection direction55 = new R2CDirection(new R2Point(15, 10), 5, 10, 8.5f, new List<bool> { true, false, true, false, true }, duration);
            R2CDirection direction66 = new R2CDirection(new R2Point(-15, 50), 6, 20, 25, new List<bool> { false, false, false, false, true }, duration);
            R2CDirection direction77 = new R2CDirection(new R2Point(100, 30), 7, 2.5f, 12, new List<bool> { false, false, false, false, true }, duration);
            R2CDirection direction88 = new R2CDirection(new R2Point(-10, 50), 8, 3.5f, 5.3f, new List<bool> { true, true, true, false, true }, duration);

            R2CDirection direction111 = new R2CDirection(new R2Point(15, 10), 1, 10, 2, new List<bool> { true, false, true, false, true }, duration, 1);
            R2CDirection direction222 = new R2CDirection(new R2Point(-15, 50), 2, 100, 20, new List<bool> { false, false, false, false, true }, duration, 2);
            R2CDirection direction333 = new R2CDirection(new R2Point(100, 30), 3, 15, 2.5f, new List<bool> { false, false, false, false, true }, duration, 1);
            R2CDirection direction444 = new R2CDirection(new R2Point(-10, 50), 4, 28, 3.5f, new List<bool> { true, true, true, false, true }, duration, 2);


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + r1Direction.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction1.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (r1Direction.CompareTo(direction1) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction1.ToString());
            else if (r1Direction.CompareTo(direction1) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction1.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction1.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + r1Direction.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + r2Direction.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (r1Direction.CompareTo(r2Direction) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is less than ---direction : \n\n" + r2Direction.ToString());
            else if (r1Direction.CompareTo(r2Direction) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is greater ---than direction : \n\n" + r2Direction.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + r2Direction.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + r1Direction.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + r3Direction.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (r1Direction.CompareTo(r3Direction) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is less than ---direction : \n\n" + r3Direction.ToString());
            else if (r1Direction.CompareTo(r3Direction) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is greater ---than direction : \n\n" + r3Direction.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + r3Direction.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + r1Direction.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + r4Direction.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (r1Direction.CompareTo(r4Direction) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is less than ---direction : \n\n" + r4Direction.ToString());
            else if (r1Direction.CompareTo(r4Direction) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is greater ---than direction : \n\n" + r4Direction.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + r1Direction.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + r4Direction.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + r2Direction.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + r3Direction.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (r2Direction.CompareTo(r3Direction) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r2Direction.ToString() + " \n\t\t---is less than ---direction : \n\n" + r3Direction.ToString());
            else if (r2Direction.CompareTo(r3Direction) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r2Direction.ToString() + " \n\t\t---is greater ---than direction : \n\n" + r3Direction.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + r2Direction.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + r3Direction.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + r2Direction.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + r4Direction.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (r2Direction.CompareTo(r4Direction) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r2Direction.ToString() + " \n\t\t---is less than ---direction : \n\n" + r4Direction.ToString());
            else if (r2Direction.CompareTo(r4Direction) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r2Direction.ToString() + " \n\t\t---is greater ---than direction : \n\n" + r4Direction.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + r2Direction.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + r4Direction.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + r3Direction.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + r4Direction.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (r3Direction.CompareTo(r4Direction) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r3Direction.ToString() + " \n\t\t---is less than ---direction : \n\n" + r4Direction.ToString());
            else if (r3Direction.CompareTo(r4Direction) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + r3Direction.ToString() + " \n\t\t---is greater ---than direction : \n\n" + r4Direction.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + r3Direction.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + r4Direction.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /*************************************************************************************************************/

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction11.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction22.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction11.CompareTo(direction22) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction22.ToString());
            else if (direction11.CompareTo(direction1) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction22.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction22.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction11.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction33.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction11.CompareTo(direction33) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction33.ToString());
            else if (direction11.CompareTo(direction1) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction33.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction33.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction11.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction44.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction11.CompareTo(direction44) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction44.ToString());
            else if (direction11.CompareTo(direction44) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction44.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction44.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction11.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction55.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction11.CompareTo(direction55) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction55.ToString());
            else if (direction11.CompareTo(direction55) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction55.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction55.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction11.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction66.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction11.CompareTo(direction66) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction66.ToString());
            else if (direction11.CompareTo(direction66) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction66.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction66.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction11.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction77.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction11.CompareTo(direction77) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction77.ToString());
            else if (direction11.CompareTo(direction77) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction77.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction77.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction11.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction88.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction11.CompareTo(direction88) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction88.ToString());
            else if (direction11.CompareTo(direction88) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction88.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction11.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction88.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction22.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction33.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction22.CompareTo(direction33) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction33.ToString());
            else if (direction22.CompareTo(direction33) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction33.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction33.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction22.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction44.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction22.CompareTo(direction44) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction44.ToString());
            else if (direction22.CompareTo(direction44) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction44.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction44.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction11.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction55.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction22.CompareTo(direction55) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction55.ToString());
            else if (direction22.CompareTo(direction55) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction55.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction55.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction22.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction66.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction22.CompareTo(direction66) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction66.ToString());
            else if (direction22.CompareTo(direction66) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction66.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction66.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction22.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction77.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction22.CompareTo(direction77) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction77.ToString());
            else if (direction22.CompareTo(direction77) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction77.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction77.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction22.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction88.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction22.CompareTo(direction88) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction88.ToString());
            else if (direction22.CompareTo(direction88) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction88.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction22.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction88.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction33.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction44.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction33.CompareTo(direction44) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction44.ToString());
            else if (direction33.CompareTo(direction44) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction44.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction44.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction33.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction55.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction33.CompareTo(direction55) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction55.ToString());
            else if (direction33.CompareTo(direction55) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction55.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction55.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction22.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction66.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction33.CompareTo(direction66) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction66.ToString());
            else if (direction33.CompareTo(direction66) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction66.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction66.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction33.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction77.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction33.CompareTo(direction77) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction77.ToString());
            else if (direction33.CompareTo(direction77) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction77.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction77.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction33.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction88.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction33.CompareTo(direction88) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction88.ToString());
            else if (direction33.CompareTo(direction88) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction88.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction88.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction33.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction55.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction33.CompareTo(direction55) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction55.ToString());
            else if (direction33.CompareTo(direction55) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction55.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction55.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction22.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction66.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction33.CompareTo(direction66) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction66.ToString());
            else if (direction33.CompareTo(direction66) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction66.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction66.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction33.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction77.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction33.CompareTo(direction77) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction77.ToString());
            else if (direction33.CompareTo(direction77) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction77.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction33.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction77.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction111.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction222.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction111.CompareTo(direction222) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction111.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction222.ToString());
            else if (direction111.CompareTo(direction222) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction111.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction222.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction111.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction222.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction111.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction333.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction111.CompareTo(direction333) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction111.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction333.ToString());
            else if (direction111.CompareTo(direction333) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction111.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction333.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction111.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction333.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction111.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction444.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction111.CompareTo(direction444) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction111.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction444.ToString());
            else if (direction111.CompareTo(direction44) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction111.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction444.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction111.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction444.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction222.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction333.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction222.CompareTo(direction333) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction222.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction333.ToString());
            else if (direction222.CompareTo(direction333) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction222.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction333.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction222.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction333.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction222.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction444.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction222.CompareTo(direction444) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction222.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction444.ToString());
            else if (direction222.CompareTo(direction44) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction222.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction444.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction222.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction444.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\t\tComparing direction : \n\n" + direction333.ToString());
            Console.WriteLine("\n\n\n\t\twith direction : \n\n" + direction444.ToString());

            Console.WriteLine("\n************************************************************************************\n");

            if (direction333.CompareTo(direction444) < 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction333.ToString() + " \n\t\t---is less than ---direction : \n\n" + direction444.ToString());
            else if (direction333.CompareTo(direction44) > 0)
                Console.WriteLine("\nWe find that Direction : \n\n" + direction333.ToString() + " \n\t\t---is greater ---than direction : \n\n" + direction444.ToString());
            else
                Console.WriteLine("\nWe find that Direction : \n\n" + direction333.ToString() + " \n\t\t---is equals tot-- direction : \n\n" + direction444.ToString());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
