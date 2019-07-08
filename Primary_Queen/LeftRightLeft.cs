using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class LeftRightLeft<U> : Move<U>
    {
        public LeftRightLeft()
        : base(new ThirdMove())
        {

        }

        public LeftRightLeft(int _firstFrequency,
        int _secondFrequency, int _thirdFrequency,
        bool circular)
        : base(new ThirdMove(new R1Point(), true, 1, _firstFrequency,
        _secondFrequency, _thirdFrequency, false))
        {

        }

        public LeftRightLeft(R1Point startingPoint,
        float lengthOfDirections, float divisorOfDirections,
        int _numberOfTimes, int _firstFrequency,
        int _secondFrequency, int _thirdFrequency, bool circular)
        : base(new ThirdMove(startingPoint, lengthOfDirections,
        divisorOfDirections, _numberOfTimes, circular,
        _firstFrequency, _secondFrequency,
        _thirdFrequency, false))
        {

        }
    }
}
