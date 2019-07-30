using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources
{
    
    public class SharedDirection 
    {
        protected List<float> length;
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

        public List<float> Length
        {
            get
            {
                return length;
            }

            set
            {

                if (value !=  null && value.Count == length.Count)
                    length = value;

            }
        }

        

        public SharedDirection()
        {
            _divisor = 1;
            length = new List<float>();
            length.Add(2);
        }

        public SharedDirection(float _divisor)
        {
            if (_divisor < 1 || _divisor > 12)
                throw new Exception("Make sure the divisor is between 1 and 12.");

            if (12 % _divisor != 0)
                throw new Exception("Make sure the divisor is a divisor of 12.");

            this._divisor = _divisor;
            length = new List<float>();
            length.Add(12);

        }

        public SharedDirection(List<float> length, float _divisor)
        {
            if (_divisor < 1)
                throw new Exception("Make sure the divisor is at least 1.");
            this._divisor = _divisor;

            this.length = length;
        }


        public float GetDirectionLength()
        {
            float sumOfSquares = 0;

            foreach (float directionLength in length)
                sumOfSquares += (float)Math.Pow(directionLength,2);
                    
            return (float)Math.Sqrt(sumOfSquares);
        }

        public override string ToString()
        {
            string toReturn = "Length : ";

            foreach (float directionLength in length)
                toReturn += directionLength + " ";

            toReturn += "\tDirection Divisor : " + _divisor+"\n";

            return toReturn;
        }

        public float GetDirectionLengthComponent(int componentIndex)
        {
            float toReturn = float.MaxValue;

            if (componentIndex >= 0 && componentIndex < length.Count)
                toReturn = length[componentIndex];
            return toReturn;
        }

        public int GetNumberOfElements() { return (int)(GetDirectionLength()/Divisor); }

       
    }
}