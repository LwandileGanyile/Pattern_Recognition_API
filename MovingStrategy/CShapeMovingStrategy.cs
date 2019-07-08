using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using CircularIteration;

namespace MovingStrategy
{
    public abstract class CShapeMovingStrategy<T, U, V> : CMovingStrategy<T, U>, IPointIterator<Point>, IDirectionIterator<V>
    {
        //protected ShapeTraceType traceType;

        //public ShapeTraceType TraceType { get; set; }


        public CShapeMovingStrategy()
        : base()
        {
            //traceType = ShapeTraceType.Direction_Trace;
            Fill();
        }

        protected CShapeMovingStrategy(Point _startingPoint, int direction,
        Dictionary<int, int> duration, int numberOfRotations/*, ShapeTraceType traceType*/)
        : base(_startingPoint, direction, duration, numberOfRotations)
        {
            //this.traceType = traceType;
            Fill();
        }

        protected CShapeMovingStrategy(Point _startingPoint, int direction,
        List<bool> canShootList, Dictionary<int, int> duration,
        int numberOfRotations/*, ShapeTraceType traceType*/)
        : base(_startingPoint, direction,
        canShootList, duration, numberOfRotations)
        {
            //this.traceType = traceType;
            Fill();
        }

        protected CShapeMovingStrategy(List<U> movingStrategy/*, ShapeTraceType traceType*/)
        {
            //this.traceType = traceType;

            for (int i = 0; i < movingStrategy.Count; i++)
                linkedList.Add(movingStrategy[i]);

        }

        public abstract DirectionIterator<V> RetrieveDirectionIterator();

        // Used if a player decides to trace points instead of directions.
        // Delegate to the moving strategy helper class.
        public PointIterator<Point> RetrievePointIterator()
        {
            throw new NotImplementedException();
        }
    }
}
