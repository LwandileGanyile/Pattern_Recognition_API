using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secondary_Queen
{
    public class SharedDirection : SharedResources.SharedDirection
    {
        protected float _yLength;

        public float YLength
        {
            get
            {
                return _yLength;
            }

            set
            {

                if (value > 0 && value % _divisor == 0)
                    _yLength = value;

            }
        }

        public SharedDirection()
        {

        }

        public SharedDirection(float _divisor)
        : base(_divisor)
        {
             _xLength = (float)(12 / Math.Sqrt(2));
            _yLength = (float)(12 / Math.Sqrt(2));
        }

        public SharedDirection(float _xLength, float _yLength, float _divisor)
        : base(_xLength,_divisor)
        {
            if (!(_yLength % _divisor == 0 && !(_xLength == 0 && _yLength == 0)))
                throw new Exception("Make sure yLength is a non zero number divisible by the divisor.");
            this._yLength = _yLength;
        }


        public new float GetDirectionLength()
        {
            return (float)Math.Sqrt(_xLength * _xLength + _yLength * _yLength);
           
        }

        public override string ToString()
        {
            return "xLength : " + _xLength + "\tyLength : " + _yLength + "\tDirection Divisor : " + _divisor + "\n";
        }
    }
}
