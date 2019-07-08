using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources;

namespace Primary_Queen
{
    public abstract class MovingStrategy : IMove
    {
        protected R1Point startingPoint;
        protected float lengthOfDirections;
        protected float divisorOfDirections;
        protected int _numberOfTimes;
        protected MyLinkedList<IPrimaryDirection> linkedList;
        protected bool circular;

        public int NumberOfTimes
        {
            get { return _numberOfTimes; }
            set { if (_numberOfTimes > 0) { _numberOfTimes = value; FillMove(); } }
        }

        public float LengthOfDirections
        {
            get
            {
                return lengthOfDirections;
            }

            set
            {
                if (lengthOfDirections >= 1)
                    lengthOfDirections = value;
            }
        }

        public float DivisorOfDirections
        {
            get
            {
                return divisorOfDirections;
            }

            set
            {
                if (divisorOfDirections >= 1)
                    divisorOfDirections = value;
            }
        }

        public R1Point StartingPoint
        {
            get
            {
                return startingPoint;
            }

            set
            {
                if (value != null) startingPoint = value;
            }
        }

        public MyLinkedList<IPrimaryDirection> LinkedList
        {
            get;
        }

        protected MovingStrategy()
        {
            startingPoint = new R1Point();
            lengthOfDirections = 1;
            divisorOfDirections = 0.1f;
            _numberOfTimes = 1;
            circular = true;

        }

        protected MovingStrategy(R1Point startingPoint, bool circular, int _numberOfTimes)
        {
            this.startingPoint = startingPoint;
            lengthOfDirections = 1;
            divisorOfDirections = 0.1f;
            this._numberOfTimes = _numberOfTimes;
            this.circular = circular;

        }

        protected MovingStrategy(R1Point startingPoint,
        float lengthOfDirections, float divisorOfDirections,
        int _numberOfTimes, bool circular)
        {
            this.divisorOfDirections = divisorOfDirections;
            this.startingPoint = startingPoint;
            this.lengthOfDirections = lengthOfDirections;
            this._numberOfTimes = _numberOfTimes;
            this.circular = circular;
        }

        public abstract void FillMove();
    }
}
