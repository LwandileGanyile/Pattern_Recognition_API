using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class SecondMove : MovingStrategy
    {
        private int _toLeftFrequency;
        private int _toRightFrequency;
        private bool _rightFirst;

        public int ToLeftFrequency { get { return _toLeftFrequency; } set { if (value > 0) _toLeftFrequency = value; FillMove(); } }
        public int ToRightFrequency { get { return _toRightFrequency; } set { if (value > 0) _toRightFrequency = value; FillMove(); } }
        public bool RightFirst { get { return _rightFirst; } set { _rightFirst = value; FillMove(); } }


        public SecondMove()
        : base()
        {
            _toRightFrequency = 25;
            _toLeftFrequency = 15;
            _rightFirst = true;
            FillMove();
        }

        public SecondMove(R1Point _startingPoint, bool _circular, int _numberOfTimes,
        int _toRightFrequency, int _toLeftFrequency, bool _rightFirst)
        : base(_startingPoint, _circular, _numberOfTimes)
        {
            this._toLeftFrequency = _toLeftFrequency;
            this._toRightFrequency = _toRightFrequency;
            this._rightFirst = _rightFirst;
            FillMove();
        }

        public SecondMove(R1Point _startingPoint,
        float _lengthOfDirections, float _divisorOfDirections,
        int _numberOfTimes, bool _circular, int _toRightFrequency,
        int _toLeftFrequency, bool _rightFirst)
        : base(_startingPoint, _lengthOfDirections, _divisorOfDirections,
        _numberOfTimes, _circular)
        {
            this._toLeftFrequency = _toLeftFrequency;
            this._toRightFrequency = _toRightFrequency;
            this._rightFirst = _rightFirst;
            FillMove();
        }

        public override void FillMove()
        {

        }
    }
}
