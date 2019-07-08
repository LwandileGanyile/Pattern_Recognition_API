using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircularIteration;
using MovingStrategy;

namespace Secondary_Queen
{
    public class R2CSMovingStrategy : CShapeMovingStrategy<R2CDirection, R2CDirection, Secondary_Direction>
    {

        private Secondary_Trace_Type traceType;

        public Secondary_Trace_Type TraceType { get; set; }

        public R2CSMovingStrategy()
        {

        }

        public R2CSMovingStrategy(R2Point startingPoint, int movingStrategyNumber, Secondary_Trace_Type traceType)
        {

        }

        public R2CSMovingStrategy(List<R2CDirection> movingStrategy, Secondary_Trace_Type traceType)
        {

        }

        public R2CSMovingStrategy(List<int> movingStrategy, Secondary_Trace_Type traceType)
        {

        }

        public override DirectionIterator<Secondary_Direction> RetrieveDirectionIterator()
        {
            throw new NotImplementedException();
        }

        public override int CompareTo(R2CDirection comparableInstance)
        {
            throw new NotImplementedException();
        }

        public override R2CDirection ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override R2CDirection RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override R2CDirection ReflectAboutAxis(int axisIndex)
        {
            throw new NotImplementedException();
        }

        public override R2CDirection ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override R2CDirection RotateAroundEqualAxis(List<int> indecesOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        public override R2CDirection Translate(int coordinateSystemDirection, float amaunt)
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Fill()
        {
            throw new NotImplementedException();
        }
    }
}
