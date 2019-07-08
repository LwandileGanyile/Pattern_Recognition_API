using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class LeftThenRight<U> : Move<U>
    {

        public LeftThenRight()
        : base(new SecondMove(new R1Point(), true, 1, 15, 25, false))
        {

        }

        public LeftThenRight(R1Point _startingPoint, bool _circular, int _numberOfTimes,
        int _toRightFrequency, int _toLeftFrequency, bool circular)
        : base(new SecondMove(_startingPoint, circular, _numberOfTimes, _toRightFrequency, _toLeftFrequency, false))
        {

        }

        public LeftThenRight(R1Point startingPoint,
        float lengthOfDirections, float divisorOfDirections,
        int numberOfTimes, int _toRightFrequency, int _toLeftFrequency,
        bool circular)
        : base(new SecondMove(startingPoint, lengthOfDirections, divisorOfDirections,
        numberOfTimes, circular, _toRightFrequency, _toLeftFrequency, true))
        {

        }
    }
}
