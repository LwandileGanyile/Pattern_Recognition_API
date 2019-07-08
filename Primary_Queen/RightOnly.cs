using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class RightOnly<U> : Move<U>
    {

        public RightOnly()
         : base(new FirstMove(new R1Point(), true, 1, true, 10))
        {
            ((FirstMove)movingStrategy).ToRight = false;
        }

        public RightOnly(int _frequency, bool _circular, int _numberOfTimes)
        : base(new FirstMove(new R1Point(), _circular, _numberOfTimes, true, _frequency))
        {

        }

        public RightOnly(R1Point startingPoint, int _frequency,
        float lengthOfDirections, float divisorOfDirections,
        int numberOfTimes, bool circular)
        : base(new FirstMove(startingPoint, lengthOfDirections, divisorOfDirections,
        numberOfTimes, true, circular, _frequency))
        {

        }

    }
}
