using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Queen
{
    public class ThirdMove : MovingStrategy
    {
        private int _firstFrequency;
        private int _secondFrequency;
        private int _thirdFrequency;
        private bool _rightFirst;

        public int FirstFrequency { get { return _firstFrequency; } set { if (value > 0) _firstFrequency = value; FillMove(); } }
        public int SecondFrequency { get { return _secondFrequency; } set { if (value > 0) _secondFrequency = value; FillMove(); } }
        public int ThirdFrequency { get { return _thirdFrequency; } set { if (value > 0) _thirdFrequency = value; FillMove(); } }
        public bool RightFirst { get { return _rightFirst; } set { _rightFirst = value; FillMove(); } }

        public ThirdMove()
        : base()
        {
            _firstFrequency = 15;
            _secondFrequency = 20;
            _thirdFrequency = 35;
            _rightFirst = true;
            FillMove();
        }

        public ThirdMove(R1Point _startingPoint, bool _circular, int _numberOfTimes,
        int _firstFrequency, int _secondFrequency, int _thirdFrequency,
        bool _rightFirst)
        : base(_startingPoint, _circular, _numberOfTimes)
        {
            this._firstFrequency = _firstFrequency;
            this._secondFrequency = _secondFrequency;
            this._thirdFrequency = _thirdFrequency;
            this._rightFirst = _rightFirst;
            FillMove();
        }

        public ThirdMove(R1Point _startingPoint,
        float _lengthOfDirections, float _divisorOfDirections,
        int _numberOfTimes, bool _circular, int _firstFrequency,
        int _secondFrequency, int _thirdFrequency,
        bool _rightFirst)
        : base(_startingPoint,
        _lengthOfDirections, _divisorOfDirections,
        _numberOfTimes, _circular)
        {
            this._firstFrequency = _firstFrequency;
            this._secondFrequency = _secondFrequency;
            this._thirdFrequency = _thirdFrequency;
            this._rightFirst = _rightFirst;
            FillMove();
        }

        public override void FillMove()
        {

        }
    }
}
