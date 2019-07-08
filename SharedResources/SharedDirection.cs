using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    
    public class SharedDirection
    {
        protected float _xLength;
        protected float _divisor;

        public float Divisor
        {
            get
            {
                return _divisor;
            }

            set
            {
                if (value > 0 && value % _divisor == 0)
                    _divisor = value;
            }
        }

        public float XLength
        {
            get
            {
                return _xLength;
            }

            set
            {

                if (value > 0 && value % _divisor == 0)
                    _xLength = value;

            }
        }

        public SharedDirection()
        {
            _divisor = 1;
            _xLength = 12;
        }

        public SharedDirection(float _divisor)
        {
            if (_divisor < 1 || _divisor > 12)
                throw new Exception("Make sure the divisor is between 1 and 12.");

            if (12 % _divisor != 0)
                throw new Exception("Make sure the divisor is a divisor of 12.");

            this._divisor = _divisor;
            _xLength = 12;
            
        }

        public SharedDirection(float _xLength, float _divisor)
        {
            if (_divisor < 1)
                throw new Exception("Make sure the divisor is at least 1.");
            this._divisor = _divisor;

            if (!(_xLength % _divisor == 0))
                throw new Exception("Make sure the direction length is a number divisible by the divisor.");
            this._xLength = _xLength;
        }

        public float GetDirectionLength()
        {
            return XLength;
        }

        public override string ToString()
        {
            return "xLength : " + _xLength + "\tDirection Divisor : " + _divisor+"\n";
        }

        
    }
}