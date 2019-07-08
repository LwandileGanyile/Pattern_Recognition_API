using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircularIteration;
using Pieces;

namespace MovingStrategy
{
    public abstract class CLetterMovingStrategy<T, U, V, W> : CMovingStrategy<T, U>, IPointIterator<Point>, IDirectionIterator<V>, ILetterIterator<W>
    {

        //protected LetterTraceType traceType;

       // public LetterTraceType TraceType { get; set; }


        public CLetterMovingStrategy()
        : base()
        {
           // traceType = LetterTraceType.Direction_Trace;
            Fill();
        }

        protected CLetterMovingStrategy(Point _startingPoint, int direction,
        Dictionary<int, int> duration, int dimension, int numberOfRotations/*, LetterTraceType traceType*/)
        : base(_startingPoint, direction, duration, numberOfRotations)
        {
            //this.traceType = traceType;
            Fill();
        }

        protected CLetterMovingStrategy(Point _startingPoint, int direction,
        List<bool> canShootList, Dictionary<int, int> duration,
        int numberOfRotations/*, LetterTraceType traceType*/)
        : base(_startingPoint, direction,
        canShootList, duration, numberOfRotations)
        {
            //this.traceType = traceType;
            Fill();
        }

        protected CLetterMovingStrategy(List<U> movingStrategy/*, LetterTraceType traceType*/)
        {
            //this.traceType = traceType;

            for (int i = 0; i < movingStrategy.Count; i++)
                linkedList.Add(movingStrategy[i]);

        }


        public PointIterator<Point> RetrievePointIterator()
        {
            throw new NotImplementedException();
        }

        public abstract DirectionIterator<V> RetrieveDirectionIterator();
        public abstract LetterIterator<W> RetrieveLetterIterator();

    }
}
