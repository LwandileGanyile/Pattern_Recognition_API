using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class LeftOnly<U> : Move<U>
    {
        public LeftOnly()
        : base(new FirstMove(new R1Point(), true, 1, false, 10))
        {
            ((FirstMove)movingStrategy).ToRight = false;
        }

        public LeftOnly(int _frequency, bool _circular, int _numberOfTimes)
        : base(new FirstMove(new R1Point(), _circular, _numberOfTimes, false, _frequency))
        {

        }

        public LeftOnly(R1Point startingPoint, int _frequency,
        float lengthOfDirections, float divisorOfDirections,
        int numberOfTimes, bool circular)
        : base(new FirstMove(startingPoint, lengthOfDirections, divisorOfDirections,
        numberOfTimes, false, circular, _frequency))
        {

        }
    }
}
