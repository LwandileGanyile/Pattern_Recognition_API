using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonCircularIteration;
using Pieces;

namespace MovingStrategy
{
    public abstract class NCLetterMovingStrategy<T, U, V, W> : NCMovingStrategy<T, U>, IPointIterator<Point>, IDirectionIterator<V>, ILetterIterator<W>
    {

        //private LetterTraceType traceType;

        public NCLetterMovingStrategy()
        : base()
        {
            //traceType = LetterTraceType.Direction_Trace;
            Fill();
        }

        protected NCLetterMovingStrategy(Point _startingPoint, int direction,
        Dictionary<int, int> duration, int dimension, int numberOfRepeatations/*, LetterTraceType traceType*/)
        : base(_startingPoint, direction, duration, numberOfRepeatations)
        {
            //this.traceType = traceType;
            Fill();
        }

        protected NCLetterMovingStrategy(Point _startingPoint, int direction,
        List<bool> canShootList, Dictionary<int, int> duration,
        int numberOfRepeatations/*, LetterTraceType traceType*/)
        : base(_startingPoint, direction,
        canShootList, duration, numberOfRepeatations)
        {
            //this.traceType = traceType;
            Fill();
        }

        protected NCLetterMovingStrategy(List<U> movingStrategy/*, LetterTraceType traceType*/)
        {
            //this.traceType = traceType;

            for (int i = 0; i < movingStrategy.Count; i++)
                linkedList.Add(movingStrategy[i]);
            //initializeAttributes();
        }



        public PointIterator<Point> RetrievePointIterator()
        {
            throw new NotImplementedException();
        }

        public abstract DirectionIterator<V> RetrieveDirectionIterator();
        public abstract LetterIterator<W> RetrieveLetterIterator();

    }


}
