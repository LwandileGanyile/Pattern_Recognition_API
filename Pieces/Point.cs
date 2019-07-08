using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;

namespace Pieces
{
    public class Point :IDisplay
    {
        private List<float> _coordinate;
        private bool _canShoot;


        public Point()
        {
            _coordinate = new List<float> { 0 };

            _canShoot = false;
        }

        

        public Point(List<float> _coordinate, bool _canShoot)
        {
            if (_coordinate.Count > 0)
                this._coordinate = _coordinate;
            this._canShoot = _canShoot;

        }

        public override string ToString()
        {
            string output = "(";

            for (int i = 0; i < Coordinate.Count - 1; i++)
                output += (_coordinate[i] + ", ");
            output += (_coordinate[Coordinate.Count - 1] + ")");

            return output;
        }

        // Compare two points of the same dimension.
        public int CompareTo(Point point)
        {
            if (point._coordinate.Count == _coordinate.Count)
            {
                for (int j = 0; j < point._coordinate.Count; j++)
                    if (_coordinate[j] < point._coordinate[j])
                        return -1;
                    else if (_coordinate[j] > point._coordinate[j])
                        return 1;
                return 0;
            }

            return -99;
        }

        public bool CanShoot { get; set; }
        public List<float> Coordinate
        {
            get
            {
                return _coordinate;
            }

            set
            {
                _coordinate = value;
            }
        }

        // Set to a new value at coordinateAt.
        public void SetAxisAt(int coordinateAt, float value)
        {
            if (coordinateAt >= 0 && coordinateAt < _coordinate.Count)
                _coordinate[coordinateAt] = value;
            else if (coordinateAt >= _coordinate.Count)
                _coordinate[_coordinate.Count - 1] = value;
            else
                _coordinate[0] = value; ;

        }

        // Get the axis value.
        // Return the first element if the coordinateAt parameter is out of range.
        public float GetAxisAt(int coordinateAt)
        {

            if ((coordinateAt >= 0 && coordinateAt < _coordinate.Count))
                return _coordinate[coordinateAt];
            else if (coordinateAt >= _coordinate.Count)
                return _coordinate[_coordinate.Count - 1];
            else
                return _coordinate[0];
        }

        // The method only works for a valid coordinate index.
        public void DecreaseAxisAt(int coordinateAt, float amount)
        {
            if (coordinateAt >= 0 && coordinateAt < _coordinate.Count)
                _coordinate[coordinateAt] = _coordinate[coordinateAt] - amount;
        }

        // The method only works for a valid coordinate index.
        public void IncreaseAxisAt(int coordinateAt, float amount)
        {
            if (coordinateAt >= 0 && coordinateAt < _coordinate.Count)
                _coordinate[coordinateAt] = _coordinate[coordinateAt] + amount;
        }

        // Return the dimension of this point.
        public int GetDimension()
        {
            return _coordinate.Count;
        }

        // Print this point to a console.
        public void Display()
        {
            Console.Write("(");

            for (int i = 0; i < _coordinate.Count; i++)
                if (i < _coordinate.Count - 1)
                    Console.Write(_coordinate[i] + " , ");
                else
                    Console.Write(_coordinate[_coordinate.Count - 1] + ") ");
        }


        // Negate this point on the specific axis.
        public void NegateAtCoornate(int axisAt)
        {
            if (axisAt >= 0 && axisAt < GetDimension())
                _coordinate[axisAt] *= (-1);

        }
    }
}
