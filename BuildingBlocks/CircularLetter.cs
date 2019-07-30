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
    public class CircularLetter<T, U> : Circular<T, U>, IPointIterator<U>, IDirectionIterator<U>
    {
        public CircularLetter()
        : base()
        {

        }

        public CircularLetter(List<bool> directionsCanSwitchList, 
        bool canSwitch, int numberOfRotations)
        : base(directionsCanSwitchList, canSwitch, numberOfRotations)
        {

        }

        // Return an itertator for points.
        // Used in case a player decided to keep track of points.
        public PointIterator<U> RetrievePointIterator()
        {
            return new PointIterator<U>(0, (CircularLinkedList<U>)linkedList);
        }

        // Return an itertator for directions.
        // Used in case a player decided to keep track of directions.
        public DirectionIterator<U> RetrieveDirectionIterator()
        {
            return new DirectionIterator<U>(0, (CircularLinkedList<U>)linkedList);
        }
    }
}
