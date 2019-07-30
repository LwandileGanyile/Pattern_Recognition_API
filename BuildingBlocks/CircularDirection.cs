using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using Pieces;
using SharedResources;
using CircularIteration;

namespace BuildingBlocks
{
    public class CircularDirection<T, U> : Circular<T, U>, IPointIterator<U>
    {

        public CircularDirection()
        : base()
        {
            
        }

        public CircularDirection(List<bool> canSwitchList, bool canSwitch,
        int numberOfTimes)
        : base(canSwitchList, canSwitch,numberOfTimes)
        {

        }

        // Return an itertator for points.
        // Used in case a player decided to keep track of points.
        public PointIterator<U> RetrievePointIterator()
        {
            return new PointIterator<U>(0, (CircularLinkedList<U>)linkedList);
        }

       
    }

}
