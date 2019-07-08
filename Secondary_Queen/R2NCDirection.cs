using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Pieces;
using NonCircularIteration;
using SharedResources;

namespace Secondary_Queen
{
    public class R2NCDirection : NonCircularDirection<R2NCDirection, R2Point>, ICloneable
    {

        public R2NCDirection()
        : base()
        {

            directionHelper = new R2Direction<R2NCDirection>();
            _startingPoint = directionHelper.GetFirst().Position;

            directionHelper.Fill();
            directionHelper.FillCanShoot();
            directionHelper.FillDuration(1000);

            InitializeAttributes();

        }

        public R2NCDirection(R2Direction<R2NCDirection> directionHelper)
        : base(directionHelper.GetFirst().Position, directionHelper.MyDirection,
        directionHelper.SharedDirection.DirectionLength, directionHelper.SharedDirection.Divisor,
        directionHelper.CanShootList, Direction<R2CDirection, R2Point>.CreateDuration(
        directionHelper.Duration), directionHelper.NumberOfTimes)
        {

        }

        public R2NCDirection(R2Point startingPoint, int direction,
        float directionLength, float directionDivisor, List<bool> canShootList,
        int duration)
        : this(startingPoint, direction, directionLength, directionDivisor,
        canShootList, duration, 2)
        {

        }

        public R2NCDirection(R2Point startingPoint, int direction,
        float directionLength, float divisor, List<bool> canShootList,
        int duration, int numberOfRepeatations)
        : base(startingPoint.Position, direction, directionLength, divisor,
        canShootList, duration, numberOfRepeatations)
        {
            R2Direction<R2NCDirection> directionHelper = new R2Direction<R2NCDirection>(startingPoint, direction,
             directionLength, divisor, canShootList, duration, numberOfRepeatations, false);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateNCDirection(directionHelper);
        }

        public R2NCDirection(R2Point startingPoint, int direction,
        float directionLength, float directionDivisor,
        int duration)
        : this(startingPoint, direction,
        directionLength, directionDivisor, duration, 2)
        {

        }

        public R2NCDirection(R2Point startingPoint, int direction,
        float directionLength, float divisor,
        int duration, int numberOfRepeatations)
        : base(startingPoint.Position, direction, directionLength, divisor,
        duration, numberOfRepeatations)
        {
            R2Direction<R2NCDirection> directionHelper = new R2Direction<R2NCDirection>(startingPoint, direction,
            directionLength, divisor, duration, numberOfRepeatations, false);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateNCDirection(directionHelper);
        }

        public R2NCDirection(R2Point startingPoint, int direction,
        float directionLength, float divisor, bool canShoot,
        int duration, int numberOfRotations)
        : base(startingPoint.Position, direction, directionLength, divisor,
        duration, numberOfRotations, canShoot)
        {
            R2Direction<R2NCDirection> directionHelper = new R2Direction<R2NCDirection>(startingPoint, direction,
            directionLength, divisor, duration, numberOfRotations, true);

            _startingPoint = directionHelper.GetFirst().Position;
            CreateNCDirection(directionHelper);
        }

        
        // String representation of this circular direction.
        public override string ToString()
        {
            string output = base.ToString() + "\n";

            return output + linkedList.ToString() + "\nNumber Of repeatations : " + numberOfRepeatations;
        }
    
        // Retrive the opposite direction of this direction.
        // That resultant direction starts from the last point of the calling direction.
        public R2NCDirection GetOppositeDirection()
        {
            return new R2NCDirection((R2Direction<R2NCDirection>)directionHelper.GetOppositeDirection());
        }

        // Make a copy of this direction.
        public object Clone()
        {
            return new R2NCDirection(new R2Point(_startingPoint), direction,
            directionHelper.SharedDirection.DirectionLength, directionHelper.
            SharedDirection.Divisor, canShootList,Direction<R2CDirection, R2Point>.
            CreateDuration(duration), numberOfRepeatations);
        }
    }
}

