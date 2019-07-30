using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonCircularIteration;
using Pieces;

namespace MovingStrategy
{
    // T - A subclass of NCShapeMovingStrategy.
    // U - A class that represents 1D, 2D, or 3D directions.
    // V - An enum that represents 1D, 2D, or 3D directions. 
    public abstract class NCShapeMovingStrategy<T, U, V> : NCMovingStrategy<T, U>, IPointIterator<Point>, IDirectionIterator<V>
    {
        //protected ShapeTraceType traceType;

        public NCShapeMovingStrategy()
        : base()
        {
            //traceType = ShapeTraceType.Direction_Trace;
            Fill();
        }

        protected NCShapeMovingStrategy(Point _startingPoint, int direction,
        Dictionary<int, int> duration, int dimension, int numberOfRepeatation/*, ShapeTraceType traceType*/)
        : base(_startingPoint, direction, duration, numberOfRepeatation)
        {
            //this.traceType = traceType;
            Fill();
        }

        protected NCShapeMovingStrategy(Point _startingPoint, int direction,
        List<bool> CanSwitchList, Dictionary<int, int> duration,
        int numberOfRepeatation/*, ShapeTraceType traceType*/)
        : base(_startingPoint, direction,
        CanSwitchList, duration, numberOfRepeatation)
        {
            //this.traceType = traceType;
            Fill();
        }

        protected NCShapeMovingStrategy(List<U> movingStrategy/*, ShapeTraceType traceType*/)
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
