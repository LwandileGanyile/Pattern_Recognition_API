using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Pieces;
using CircularIteration;
using SharedResources;

namespace Secondary_Queen
{
    public class R2CDirection : CircularDirection<R2CDirection, R2Point>, ICloneable
    {
        public R2CDirection()
        : base()
        {

            directionHelper = new R2Direction<R2CDirection>();
            _startingPoint = directionHelper.GetFirst().Position;

            directionHelper.Fill();
            directionHelper.FillCanShoot();
            directionHelper.FillDuration(1000);

            InitializeAttributes();
        }

        public R2CDirection(R2Direction<R2CDirection> directionHelper)
        : base(directionHelper.GetFirst().Position, directionHelper.MyDirection,
        directionHelper.SharedDirection.XLength, directionHelper.SharedDirection.XLength directionHelper.
        SharedDirection.Divisor,directionHelper.CanShootList, 
        Direction< R2CDirection, R2Point >.CreateDuration(directionHelper.Duration), 
        directionHelper.NumberOfTimes)
        {
            _startingPoint = directionHelper.GetFirst().Position;
            CreateCDirection(directionHelper);
        }

        public R2CDirection(R2Point startingPoint, int direction, float directionLength,
        float divisor, List<bool> canShoot, int duration, int numberOfRotations)
        : base(startingPoint.Position, direction, directionLength, divisor, canShoot, 
        duration, numberOfRotations)
        {
            R2Direction<R2CDirection> directionHelper = new R2Direction<R2CDirection>(startingPoint, direction,
            directionLength, divisor, canShootList,duration, numberOfRotations, true);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateCDirection(directionHelper);

        }

        public R2CDirection(R2Point startingPoint, int direction, float directionLength,
        float divisor, List<bool> canShoot, int duration)
        : this(startingPoint, direction, directionLength, divisor, canShoot, duration, 2)
        {

        }

        public R2CDirection(R2Point startingPoint, int direction,
        float directionLength, float directionDivisor,
        int duration)
        : this(startingPoint, direction,
        directionLength, directionDivisor, duration, 2)
        {

        }

        public R2CDirection(R2Point startingPoint, int direction,
        float directionLength, float divisor,
        int duration, int numberOfRotations)
        : base(startingPoint.Position, direction, directionLength, divisor,
        duration, numberOfRotations)
        {
            R2Direction<R2CDirection> directionHelper = new R2Direction<R2CDirection>(startingPoint, direction,
            directionLength, divisor, duration, numberOfRotations, true);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateCDirection(directionHelper);
        }

        public R2CDirection(R2Point startingPoint, int direction,
        float directionLength, float divisor, bool canShoot,
        int duration, int numberOfRotations)
        : base(startingPoint.Position, direction, directionLength, divisor,
        duration, numberOfRotations, canShoot)
        {
            R2Direction<R2CDirection> directionHelper = new R2Direction<R2CDirection>(startingPoint, direction,
            directionLength, divisor, duration, numberOfRotations, true);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateCDirection(directionHelper);
        }

        // String representation of this circular direction.
        public override string ToString()
        {
            string output = base.ToString() + "\n";

            return output + linkedList.ToString() + "\nNumber Of rotations : " + numberOfRotations;
        }

        // Retrive the opposite direction of this direction.
        // That resultant direction starts from the last point of the calling direction.
        public R2CDirection GetOppositeDirection()
        {

            return new R2CDirection((R2Direction<R2CDirection>)directionHelper.GetOppositeDirection());
        }

        // Make a copy of this direction.
        public object Clone()
        {
            return new R2CDirection(new R2Point(_startingPoint), direction,
           directionHelper.SharedDirection.DirectionLength, directionHelper.
           SharedDirection.Divisor, canShootList, Direction<R2CDirection, 
           R2Point>.CreateDuration(duration), numberOfRotations);
        }
    }

}
