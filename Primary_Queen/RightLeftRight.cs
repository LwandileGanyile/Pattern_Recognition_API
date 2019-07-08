using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class RightLeftRight<U> : Move<U>
    {

        public RightLeftRight()
        : base(new ThirdMove())
        {

        }

        public RightLeftRight(int _firstFrequency,
        int _secondFrequency, int _thirdFrequency,
        bool circular)
        : base(new ThirdMove(new R1Point(), true, 1, _firstFrequency,
        _secondFrequency, _thirdFrequency, true))
        {

        }

        public RightLeftRight(R1Point startingPoint,
        float lengthOfDirections, float divisorOfDirections,
        int _numberOfTimes, int _firstFrequency,
        int _secondFrequency, int _thirdFrequency, bool circular)
        : base(new ThirdMove(startingPoint, lengthOfDirections,
        divisorOfDirections, _numberOfTimes, circular,
        _firstFrequency, _secondFrequency,
        _thirdFrequency, true))
        {

        }
    }
}
