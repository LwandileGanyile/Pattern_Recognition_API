using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovingStrategy;
using NonCircularIteration;
using BuildingBlocks;
using SharedResources;
using Pieces;

namespace Primary_Queen
{
    public class R1NCMovingStrategy : NCShapeMovingStrategy<R1NCMovingStrategy, R1NCDirection, Primary_Direction>,
    IPrimaryMovingStrategy, ICloneable
    {
        private Primary_Trace_Type traceType;

        private MovingStrategyHelper<R1NCDirection>
                helperMovingStrategy = new MovingStrategyHelper<R1NCDirection>();

        private Move<R1NCDirection> move;



        public Primary_Trace_Type TraceType { get; set; }
        public MovingStrategyHelper<R1NCDirection> MovingStrategyHelper { get; }
        public Move<R1NCDirection> Move { get { return move; } set { if (value != null) move = value; } }

        public R1NCMovingStrategy()
        {
            move = new RightOnly<R1NCDirection>();
            traceType = Primary_Trace_Type.POINT_TRACE;
            InitializeAttributes();
            Fill();
            FillCanSwitchList();
            FillDuration(1000);

        }

        public R1NCMovingStrategy(Move<R1NCDirection> move, List<bool> CanSwitchList,
        Dictionary<int, int> duration, Primary_Trace_Type traceType)
        {
            this.move = move;
            this.duration = duration;
            this.CanSwitchList = CanSwitchList;
            this.traceType = traceType;

            InitializeAttributes();
            Fill();
        }

        public R1NCMovingStrategy(Move<R1NCDirection> move, Primary_Trace_Type traceType)
        {
            this.move = move;
            this.traceType = traceType;
            CanSwitchList = new List<bool>();
            duration = new Dictionary<int, int>();

            InitializeAttributes();
            FillCanSwitchList();
            FillDuration(1000);
        }

        private void CreateLinkedList(MyLinkedList<R1NCDirection> movingStrategy)
        {


            if (movingStrategy.Size != 0) movingStrategy.Clear();

            R1NCDirection currentDirection = linkedList.GetFirst();
            R1NCDirection directionToAdd = currentDirection.GetOppositeDirection();
            movingStrategy.Add(directionToAdd);


            for (int i = 1; i < linkedList.Size; i++)
            {
                currentDirection = linkedList.GetAt(i);
                currentDirection.StartingPoint = directionToAdd.GetLast().Position;
                directionToAdd = currentDirection.GetOppositeDirection();
                movingStrategy.Add(directionToAdd);
            }

        }

        private void InitializeAttributes()
        {
            MovingStrategy movingStrategy = ((MovingStrategy)move.IMovingStrategy);

            _startingPoint = movingStrategy.StartingPoint.Position;
            direction = ((R1NCDirection)movingStrategy.LinkedList.GetLast()).Direction;

        }

        // Compare this moving strategy with the given one.
        // Work the same as the CompareTo method in the NCPrimaryMovingStrategy.
        // Delegate to the moving strategy helper class.
        public int CompareTo(R1NCMovingStrategy comparableInstance)
        {
            int returnValue = 0;

            if (linkedList.Size < comparableInstance.linkedList.Size)
                returnValue = -1;
            else if (linkedList.Size > comparableInstance.linkedList.Size)
                returnValue = 1;

            return returnValue;
        }

        // Work the same as the Display method in the NCPrimaryMovingStrategy.
        // Display string representation for this moving strategy.
        public void Display()
        {
            Console.WriteLine("\n" + ToString());
        }

        public override void Fill()
        {
            if (linkedList.Size > 0)
                linkedList.Clear();
            MovingStrategy movingStrategy = ((MovingStrategy)move.IMovingStrategy);

            for (int i = 0; i < movingStrategy.LinkedList.Size; i++)
                linkedList.Add((R1NCDirection)movingStrategy.LinkedList.GetAt(i));
        }


        // Reflect about any axis.
        // Work the same as the ReflectAboutAxis method in the NCPrimaryMovingStrategy.
        // Delegate to the moving strategy helper class.
        public R1NCMovingStrategy ReflectAboutAxis(int axisIndex)
        {
            if (axisIndex != 1)
                return this;

            R1NCMovingStrategy newMovingStrategy = (R1NCMovingStrategy)Clone();

            MyLinkedList<R1NCDirection> newLinkedList;
            if (linkedList is DoubleLinkedList<R1NCDirection>)
                newLinkedList = new DoubleLinkedList<R1NCDirection>();
            else
                newLinkedList = new CircularLinkedList<R1NCDirection>();

            CreateLinkedList(newLinkedList);

            newMovingStrategy.LinkedList = newLinkedList;
            newMovingStrategy.Direction = newLinkedList.GetLast().GetOppositeDirection().Direction;

            return newMovingStrategy;
        }


        // Reflect about any direction that is between two perpendicular axis.
        // Work the same as the ReflectAboutEqualAxis method in the NCPrimaryMovingStrategy.
        public R1NCMovingStrategy ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }


        // Reflect around any direction that is between two perpendicular axis.
        // Work the same as the ReflectAboutEqualAxis method in the CPrimaryMovingStrategy.
        public R1NCMovingStrategy ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }


        // Retrieve the direction iterator for this moving stategy.
        // Work the same as the RetrieveDirectionIterator method in the CPrimaryMovingStrategy.
        public override DirectionIterator<Primary_Direction> RetrieveDirectionIterator()
        {
            throw new NotImplementedException();
        }


        // Rotate around either x-axis, y-axis or z-axis.
        // Work the same as the RotateAroundAxis method in the CPrimaryMovingStrategy.
        public R1NCMovingStrategy RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }


        // Rotate the moving strategy. This i haven't yet thought about it.
        // Work the same as the RotateAroundEqualAxis method in the CPrimaryMovingStrategy.
        public R1NCMovingStrategy RotateAroundEqualAxis(List<int> indecesOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }


        // Move this moving strategy by a certain amount.
        // Work the same as the Translate method in the CPrimaryMovingStrategy.
        // Delegate to the moving strategy helper class.
        public R1NCMovingStrategy Translate(int coordinateSystemDirection, float amount)
        {
            if (coordinateSystemDirection != 1 && coordinateSystemDirection != 2)
                return this;

            R1NCMovingStrategy movingStrategy = (R1NCMovingStrategy)Clone();
            MyLinkedList<R1NCDirection> newMovingStrategy = movingStrategy.LinkedList;


            if (coordinateSystemDirection == 1)
                for (int i = 0; i < newMovingStrategy.Size; i++)
                    newMovingStrategy.GetAt(i).StartingPoint.IncreaseAxisAt(0, Math.Abs(amount));
            else
                for (int i = 0; i < newMovingStrategy.Size; i++)
                    newMovingStrategy.GetAt(i).StartingPoint.DecreaseAxisAt(0, Math.Abs(amount));

            return movingStrategy;
        }

        // Delegate to the moving strategy helper class.
        public override string ToString()
        {
            string presentation = "Moving Strategy Name : ";
            string leftRight = "\n\nMoving Strategy : ";

            string directionsLength = "\n\nEach Direction Length : " + linkedList.GetLast().DirectionHelper.SharedDirection.XLength;
            string directionsDivisor = "\t\tEach Direction Divisor : " + linkedList.GetLast().DirectionHelper.SharedDirection.Divisor;

            string endPoints = "\n\nStarting At " + linkedList.GetFirst().GetFirst() + "\t\tEnding At " + linkedList.GetLast().GetLast();

            for (int i = 0; i < linkedList.Size; i++)
                if (linkedList.GetAt(i).Direction == 1)
                    leftRight += "Right ";
                else
                    leftRight += "Left ";



            presentation += leftRight;
            presentation += directionsLength;
            presentation += directionsDivisor;
            presentation += endPoints;

            return presentation;
        }

        public object Clone()
        {
            return new R1NCMovingStrategy(move, CanSwitchList,
           duration, traceType);
        }
    }
}
