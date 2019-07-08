using SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class FirstMove : MovingStrategy
    {
        private bool _toRight;
        private int _frequency;

        public bool ToRight
        {
            get { return _toRight; }
            set { _toRight = value; FillMove(); }
        }
        public int Frequency
        {
            get { return _frequency; }
            set { if (value >= 1) _frequency = value; }
        }

        public FirstMove()
        : base()
        {
            _frequency = 10;
            _toRight = true;
            FillMove();
        }

        public FirstMove(R1Point startingPoint, bool circular, int _numberOfTimes, bool _toRight, int _frequency)
        : base(startingPoint, circular, _numberOfTimes)
        {
            this._frequency = _frequency;
            this._toRight = _toRight;
            FillMove();
        }

        public FirstMove(R1Point startingPoint,
        float lengthOfDirections, float divisorOfDirections,
        int numberOfTimes, bool _toRight, bool circular, int _frequency)
        : base(startingPoint, lengthOfDirections, divisorOfDirections,
        numberOfTimes, circular)
        {
            this._frequency = _frequency;
            this._toRight = _toRight;
            FillMove();
        }

        public override void FillMove()
        {

        }
    }
}
