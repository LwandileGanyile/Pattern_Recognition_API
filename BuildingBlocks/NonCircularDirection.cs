using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Defination;
using Pieces;
using SharedResources;
using NonCircularIteration;

namespace BuildingBlocks
{
    public class NonCircularDirection<T, U> : NonCircular<T, U>, IPointIterator<U>
    {

        public NonCircularDirection()
        :base()
        {
           
        }


        public NonCircularDirection(List<bool> pointsCanSwitchList, bool canSwitch,
        int numberOfRepeatations)
        : base(pointsCanSwitchList, canSwitch, numberOfRepeatations)
        {

        }

        // Return an itertator for points.
        // Used in case a player decided to keep track of points.
        public PointIterator<U> RetrievePointIterator()
        {
            return new PointIterator<U>(0, (DoubleLinkedList<U>)linkedList);
        }

        
    }
}
