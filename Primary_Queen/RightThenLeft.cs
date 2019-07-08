using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class RightThenLeft<U> : Move<U>
    {

        public RightThenLeft()
        : base(new SecondMove())
        {

        }

        public RightThenLeft(R1Point _startingPoint, bool _circular, int _numberOfTimes,
        int _toRightFrequency, int _toLeftFrequency, bool circular)
        : base(new SecondMove(_startingPoint, circular, _numberOfTimes, _toRightFrequency, _toLeftFrequency, true))
        {

        }

        public RightThenLeft(R1Point startingPoint,
        float lengthOfDirections, float divisorOfDirections,
        int numberOfTimes, int _toRightFrequency, int _toLeftFrequency,
        bool circular)
        : base(new SecondMove(startingPoint, lengthOfDirections, divisorOfDirections,
        numberOfTimes, circular, _toRightFrequency, _toLeftFrequency, true))
        {

        }
    }
}
