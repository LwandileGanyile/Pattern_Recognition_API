using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Pieces;
using NonCircularIteration;
using SharedResources;

namespace Primary_Queen
{
    public class R1NCDirection : NonCircularDirection<R1NCDirection, R1Point>, ICloneable, IPrimaryDirection
    {

        public R1NCDirection()
        : base()
        {
            directionHelper = new R1Direction<R1NCDirection>();
            _startingPoint = directionHelper.GetFirst().Position;

            directionHelper.Fill();
            directionHelper.FillCanShoot();
            directionHelper.FillDuration(1000);

            InitializeAttributes();

        }

        public R1NCDirection(R1Direction<R1NCDirection> directionHelper)
        : base(directionHelper.GetFirst().Position, directionHelper.MyDirection,
        directionHelper.SharedDirection.XLength, directionHelper.SharedDirection.Divisor,
        directionHelper.CanShootList, Direction<R1NCDirection,R1Point>.CreateDuration(directionHelper.Duration), 
        directionHelper.NumberOfTimes)
        {

            _startingPoint = directionHelper.GetFirst().Position;
            CreateNCDirection(directionHelper);

        }

        public R1NCDirection(R1Point startingPoint, int direction, float directionLength,
        float directionDivisor, int duration)
        : this(startingPoint, direction, directionLength, directionDivisor, duration, 2)
        {

        }

        public R1NCDirection(R1Point startingPoint, int direction, float directionLength,
        float directionDivisor, int duration, int numberOfRotations)
        : base(startingPoint.Position, direction, directionLength,
        directionDivisor, duration, numberOfRotations)
        {
            R1Direction<R1NCDirection> directionHelper = new R1Direction<R1NCDirection>(startingPoint, direction,
            directionLength, directionDivisor, duration, numberOfRotations, false);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateNCDirection(directionHelper);
        }

       public R1NCDirection(R1Point startingPoint, int direction, float directionLength,
       float directionDivisor, bool canShoot, int duration, int numberOfRotations)
       : base(startingPoint.Position, direction, directionLength,
       directionDivisor, duration, numberOfRotations)
        {
            R1Direction<R1NCDirection> directionHelper = new R1Direction<R1NCDirection>(startingPoint, direction,
            directionLength, directionDivisor, duration, numberOfRotations, false);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateNCDirection(directionHelper);
        }

        public R1NCDirection(R1Point startingPoint, int direction, float directionLength,
        float divisor, List<bool> canShoot, int duration, int numberOfRotations)
        : base(startingPoint.Position, direction, directionLength, divisor, canShoot, duration,
        numberOfRotations)
        {
            R1Direction<R1NCDirection> directionHelper = new R1Direction<R1NCDirection>(
            startingPoint, direction, directionLength, divisor,
            canShootList, duration, numberOfRepeatations, false);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateNCDirection(directionHelper);


        }

        public R1NCDirection(R1Point startingPoint, int direction, float directionLength,
        float divisor, List<bool> canShoot, int duration)
        : this(startingPoint, direction, directionLength, divisor, canShoot, duration, 2)
        {

        }

        // String representation of this double direction.
        public override string ToString()
        {
            string output = base.ToString() + "\n";

            return output + linkedList.ToString() + "\nNumber Of repeatations : " + numberOfRepeatations;
        }

        // Retrive the opposite direction of this direction.
        // That resultant direction starts from the last point of the calling direction.
        public R1NCDirection GetOppositeDirection()
        {
            return new R1NCDirection((R1Direction<R1NCDirection>)directionHelper.GetOppositeDirection());
        }

        // Make a copy of this direction.
        public object Clone()
        {
            return new R1NCDirection(new R1Point(_startingPoint), direction,
            directionHelper.SharedDirection.XLength, directionHelper.SharedDirection.Divisor, 
            Direction<R1NCDirection, R1Point>.CreateDuration(duration), numberOfRepeatations);
        }
    }
}
