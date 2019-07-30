using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovingStrategy;
using CircularIteration;
using SharedResources;
using BuildingBlocks;

namespace Primary_Queen
{
    public class R1CMovingStrategy : CShapeMovingStrategy<R1CMovingStrategy,
    R1CDirection, Primary_Direction>, IPrimaryMovingStrategy, ICloneable
    {
        private Primary_Trace_Type traceType;

        private MovingStrategyHelper<R1CDirection>
        helperMovingStrategy = new MovingStrategyHelper<R1CDirection>();

        private Move<R1CDirection> move;

        public Primary_Trace_Type TraceType { get; set; }
        public Move<R1CDirection> Move { get { return move; } set { if (value != null) move = value; } }
        public MovingStrategyHelper<R1CDirection> MovingStrategyHelper { get; }

        public R1CMovingStrategy()
        {
            move = new RightOnly<R1CDirection>();
            traceType = Primary_Trace_Type.POINT_TRACE;
            InitializeAttributes();
            FillCanSwitchList();
            FillDuration(1000);

        }

        public R1CMovingStrategy(Move<R1CDirection> move, List<bool> CanSwitchList,
        Dictionary<int, int> duration, Primary_Trace_Type traceType)
        {
            this.move = move;
            this.duration = duration;
            this.CanSwitchList = CanSwitchList;
            this.traceType = traceType;

            InitializeAttributes();
        }

        public R1CMovingStrategy(Move<R1CDirection> move, Primary_Trace_Type traceType)
        {
            this.move = move;
            this.traceType = traceType;
            CanSwitchList = new List<bool>();
            duration = new Dictionary<int, int>();

            InitializeAttributes();
            FillCanSwitchList();
            FillDuration(1000);
        }

        private void InitializeAttributes()
        {
            MovingStrategy movingStrategy = ((MovingStrategy)move.IMovingStrategy);

            _startingPoint = movingStrategy.StartingPoint.Position;
            direction = ((R1CDirection)movingStrategy.LinkedList.GetLast()).Direction;


            Fill();

        }


        // Compare this moving strategy with the given one.
        // Work the same as the CompareTo method in the NCPrimaryMovingStrategy.
        // Delegate to the moving strategy helper class.
        public int CompareTo(R1CMovingStrategy comparableInstance)
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
                linkedList.Add((R1CDirection)movingStrategy.LinkedList.GetAt(i));
        }

        private void CreateLinkedList(MyLinkedList<R1CDirection> movingStrategy)
        {
            if (movingStrategy.Size != 0) movingStrategy.Clear();

            R1CDirection currentDirection = linkedList.GetFirst();
            R1CDirection directionToAdd = currentDirection.GetOppositeDirection();
            movingStrategy.Add(directionToAdd);


            for (int i = 1; i < linkedList.Size; i++)
            {
                currentDirection = linkedList.GetAt(i);
                currentDirection.StartingPoint = directionToAdd.GetLast().Position;
                directionToAdd = currentDirection.GetOppositeDirection();
                movingStrategy.Add(directionToAdd);
            }

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


        // Reflect about any axis.
        // Work the same as the ReflectAboutAxis method in the NCPrimaryMovingStrategy.
        // Delegate to the moving strategy helper class.
        public R1CMovingStrategy ReflectAboutAxis(int axisIndex)
        {
            if (axisIndex != 1)
                return this;

            R1CMovingStrategy newMovingStrategy = (R1CMovingStrategy)Clone();

            MyLinkedList<R1CDirection> newLinkedList;
            if (linkedList is DoubleLinkedList<R1CDirection>)
                newLinkedList = new DoubleLinkedList<R1CDirection>();
            else
                newLinkedList = new CircularLinkedList<R1CDirection>();

            CreateLinkedList(newLinkedList);

            newMovingStrategy.LinkedList = newLinkedList;
            newMovingStrategy.Direction = newLinkedList.GetLast().GetOppositeDirection().Direction;

            return newMovingStrategy;
        }


        // Reflect about any direction that is between two perpendicular axis.
        // Work the same as the ReflectAboutEqualAxis method in the NCPrimaryMovingStrategy.
        public R1CMovingStrategy ReflectAboutEqualAxis(int[] axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }

        // Reflect around any direction that is between two perpendicular axis.
        // Work the same as the ReflectAboutEqualAxis method in the NCPrimaryMovingStrategy.
        public R1CMovingStrategy ReflectAboutEqualAxis(List<int> axisIndeces, int numberOfTimes)
        {
            throw new NotImplementedException();
        }


        // Retrieve the direction iterator for this moving stategy.
        // Work the same as the RetrieveDirectionIterator method in the NCPrimaryMovingStrategy.
        public override DirectionIterator<Primary_Direction> RetrieveDirectionIterator()
        {
            throw new NotImplementedException();
        }


        // Rotate around either x-axis, y-axis or z-axis.
        // Work the same as the RotateAroundAxis method in the NCPrimaryMovingStrategy.
        public R1CMovingStrategy RotateAroundAxis(int indexOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }


        // Rotate the moving strategy. This i haven't yet thought about it.
        // Work the same as the RotateAroundEqualAxis method in the NCPrimaryMovingStrategy.
        public R1CMovingStrategy RotateAroundEqualAxis(List<int> indecesOfAxis, int numberOfTimes)
        {
            throw new NotImplementedException();
        }


        // Move this moving strategy by a certain amount.
        // Work the same as the Translate method in the NCPrimaryMovingStrategy.
        // Delegate to the moving strategy helper class.
        public R1CMovingStrategy Translate(int coordinateSystemDirection, float amount)
        {
            if (coordinateSystemDirection != 1 && coordinateSystemDirection != 2)
                return this;

            R1CMovingStrategy movingStrategy = (R1CMovingStrategy)Clone();
            MyLinkedList<R1CDirection> newMovingStrategy = movingStrategy.LinkedList;


            if (coordinateSystemDirection == 1)
                for (int i = 0; i < newMovingStrategy.Size; i++)
                    newMovingStrategy.GetAt(i).StartingPoint.IncreaseAxisAt(0, Math.Abs(amount));
            else
                for (int i = 0; i < newMovingStrategy.Size; i++)
                    newMovingStrategy.GetAt(i).StartingPoint.DecreaseAxisAt(0, Math.Abs(amount));

            return movingStrategy;
        }

        public object Clone()
        {
            return new R1CMovingStrategy(move, CanSwitchList,
            duration, traceType);
        }
    }
}
