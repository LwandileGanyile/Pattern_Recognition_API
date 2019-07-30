using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using SharedResources;
using NonCircularIteration;

namespace BuildingBlocks
{
    public abstract class NonCircularLetter<T, U> : NonCircular<T, U>, IPointIterator<U>, IDirectionIterator<U>
    {

        public NonCircularLetter()
        : base()
        {
            
        }

        public NonCircularLetter(List<bool> directionsCanSwitchList, 
        bool canSwitch, int numberOfRepeatations)
        : base(directionsCanSwitchList, canSwitch,numberOfRepeatations)
        {

        }

        
        // Return an itertator for points.
        // Used in case a player decided to keep track of points.
        public PointIterator<U> RetrievePointIterator()
        {
            return new PointIterator<U>(0, (DoubleLinkedList<U>)linkedList);
        }

        // Return an itertator for directions.
        // Used in case a player decided to keep track of directions.
        public DirectionIterator<U> RetrieveDirectionIterator()
        {
            return new DirectionIterator<U>(0, (DoubleLinkedList<U>)linkedList);
        }
    }
}
