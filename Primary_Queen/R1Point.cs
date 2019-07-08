using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks;
using Game_Defination;
using Pieces;

namespace Primary_Queen
{
    public class R1Point : ITranslate<R1Point>, IComparable<R1Point>, IDisplay, IReflect<R1Point>, IReflectable<R1Point>
    {
        /* Used to access methods and attributes by this class because any n 
        dimensional point isn't allowed to directly access the Point class.*/
        private Point _point;



        public R1Point()
        {
            _point = new Point();
        }

        public R1Point(float _xCoordinate)
        {
            _point = new Point(new List<float> { _xCoordinate }, false);
        }

        public R1Point(Point _point)
        {
            this._point = _point;
        }

        // Change x value.
        public void SetXCoordinate(float _xCoordinate)
        {
            _point.SetAxisAt(0, _xCoordinate);
        }

        // Retrieve x value.
        public Point Position
        {
            get { return _point; }
        }


        public float this[int index]
        {
            get { return _point.GetAxisAt(index); }

            set { _point.SetAxisAt(index, value); }
        }

        public float this[char axisValue]
        {
            get
            {
                float returnValue;
                if (axisValue == 'x' || axisValue == 'X')
                    returnValue = _point.GetAxisAt(0);
                else if (axisValue == 'y' || axisValue == 'Y')
                    returnValue = _point.GetAxisAt(1);
                else if (axisValue == 'z' || axisValue == 'Z')
                    returnValue = _point.GetAxisAt(2);
                else
                    returnValue = _point.GetAxisAt(3);
                return returnValue;
            }

            set
            {
                float returnValue;
                if (value == 'x' || value == 'X')
                    _point.SetAxisAt(0, value);
                else if (value == 'y' || value == 'Y')
                    _point.SetAxisAt(1, value);
                else if (value == 'z' || value == 'Z')
                    _point.SetAxisAt(2, value);
                else
                    returnValue = _point.GetAxisAt(3);
                _point.SetAxisAt(3, value);
            }
        }


        // Retrieve x- value.
        public float GetXCoordinate()
        {
            return _point.GetAxisAt(0);
        }

        // Increasing the current x value by amount.
        public void IncreaseXCoordinate(float amount)
        {
            _point.IncreaseAxisAt(0, amount);
        }

        // Decreasing the current x value by amount.
        public void DecreaseXCoordinate(float amount)
        {
            _point.DecreaseAxisAt(0, amount);
        }

        // The dimension will always be 1.
        public int GetDimension()
        {
            return _point.GetDimension();
        }

        // Move a point a long a number line.
        public R1Point Translate(int coordinateSystemDirection, float amount)
        {

            if (coordinateSystemDirection == 1)
                return new R1Point(_point.GetAxisAt(0) - amount);
            else if (coordinateSystemDirection >= 2)
                return new R1Point(_point.GetAxisAt(0) + amount);

            return new R1Point(_point.GetAxisAt(0));

        }

        // The method is unsupported to this class however it is implemented.
        // The method returns a copy of this instance.
        public R1Point ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {

            return new R1Point(_point.GetAxisAt(0));
        }

        // Negative x of this point.
        public void NegateAtCoornate(int axisAt)
        {
            if (axisAt == 1)
                _point.NegateAtCoornate(axisAt);

        }

        // Return a new R1Point as a result of reflecting this R1Point about the origin.
        // The axisIndex value equals to 0 means reflecting about the origin.
        public R1Point ReflectAboutAxis(int axisIndex)
        {
            if (axisIndex == 0)
                return new R1Point(-_point.GetAxisAt(0));
            return new R1Point(_point.GetAxisAt(0));
        }

        // Display a 1 dimensional point in the form (x).
        public void Display()
        {
            if (_point != null)
                _point.Display();
        }

        /* Compare any two R1Point objects, the returned values is -1, 0, 1, or -99
           if the returned value is -99 it means the two points are of different dimension.*/
        public int CompareTo(R1Point other)
        {

            return _point.CompareTo(other.Position);
        }

        // String representation of a one dimensional point.
        public override string ToString()
        {
            return _point.ToString();
        }

        // The method is undefined for this class.
        public R1Point ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }
    }
}
