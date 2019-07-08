using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Pieces;
using CircularIteration;
using SharedResources;

namespace Primary_Queen
{
    public class R1CDirection : CircularDirection<R1CDirection, R1Point>, ICloneable, IPrimaryDirection
    {

        public R1CDirection()
        : base()
        {

            directionHelper = new R1Direction<R1CDirection>();
            _startingPoint = directionHelper.GetFirst().Position;

            directionHelper.Fill();
            directionHelper.FillCanShoot();
            directionHelper.FillDuration(1000);

            InitializeAttributes();
        }

        public R1CDirection(R1Direction<R1CDirection> directionHelper)
        : base(directionHelper.GetFirst().Position, directionHelper.MyDirection,
        directionHelper.SharedDirection.XLength, directionHelper.
        SharedDirection.Divisor,directionHelper.CanShootList, 
        Direction<R1CDirection, R1Point>.CreateDuration(directionHelper.Duration), 
        directionHelper.NumberOfTimes)
        {

            _startingPoint = directionHelper.GetFirst().Position;
            CreateCDirection(directionHelper);
        }

        public R1CDirection(R1Point startingPoint, int direction, float directionLength,
        float directionDivisor, int duration)
        : this(startingPoint, direction, directionLength, directionDivisor, duration, 2)
        {

        }

        public R1CDirection(R1Point startingPoint, int direction, float directionLength,
        float directionDivisor, int duration, int numberOfRotations)
        : base(startingPoint.Position, direction, directionLength,
        directionDivisor, duration, numberOfRotations)
        {
            R1Direction<R1CDirection> directionHelper = new R1Direction<R1CDirection>(startingPoint, direction,
            directionLength, directionDivisor, duration, numberOfRotations, true);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateCDirection(directionHelper);
        }

        public R1CDirection(R1Point startingPoint, int direction, float directionLength,
        float directionDivisor, bool canShoot, int duration, int numberOfRotations)
      : base(startingPoint.Position, direction, directionLength,
      directionDivisor, duration, numberOfRotations)
        {
            R1Direction<R1CDirection> directionHelper = new R1Direction<R1CDirection>(startingPoint, direction,
            directionLength, directionDivisor, duration, numberOfRotations, false);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateCDirection(directionHelper);
        }

        public R1CDirection(R1Point startingPoint, int direction, float directionLength,
        float divisor, List<bool> canShoot, int duration, int numberOfRotations)
        : base(startingPoint.Position, direction, directionLength, divisor, canShoot, duration,
        numberOfRotations)
        {
            R1Direction<R1CDirection> directionHelper = new R1Direction<R1CDirection>(
           startingPoint, direction, directionLength, divisor,
           canShootList, duration, numberOfRotations, true);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateCDirection(directionHelper);
        }

        public R1CDirection(R1Point startingPoint, int direction, float directionLength,
        float divisor, List<bool> canShoot, int duration)
        : this(startingPoint, direction, directionLength, divisor, canShoot, duration, 2)
        {

        }

        // String representation of this circular direction.
        public override string ToString()
        {
            string output = base.ToString() + "\n";

            return output + linkedList.ToString() + "\nNumber Of rotations : " + numberOfRotations;
        }

        // Retrive the opposite direction of this direction.
        // That resultant direction starts from the last point of the calling direction.
        public R1CDirection GetOppositeDirection()
        {

            return new R1CDirection((R1Direction<R1CDirection>)directionHelper.GetOppositeDirection());
        }

        // Make a copy of this direction.
        public object Clone()
        {
            return new R1CDirection(new R1Point(StartingPoint), Direction,
            directionHelper.SharedDirection.XLength, directionHelper.
            SharedDirection.Divisor, Direction<R1NCDirection, R1Point>.
            CreateDuration(duration),numberOfRotations);
        }
    }
}
